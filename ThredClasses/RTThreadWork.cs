using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CheckRT.ThredClasses
{
    internal class RTThreadWork
    {
        public event EventHandler Changed;
        public event EventHandler BreakConnection;

        //поля класса
        /// <summary>
        /// Для отображения в списке 
        /// </summary>
        public string Status = "";

        /// <summary>
        /// команда, которую нужно отправить
        /// </summary>
        public string CommandText = "";
        /// <summary>
        /// Флаг чтения или останова
        /// </summary>
        public bool readText = true;

        private string _ip;
        private int _port;
        private bool _socket_Connected;
        private SqlConnection _sqlConnection;        
        private int _managedThreadId;

        /// <summary>
        /// IP-адрес подключения
        /// </summary>
        public string ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
        /// <summary>
        /// Порт подключения
        /// </summary>
        public int port
        {
            get { return _port; }
            set { _port = value; }
        }


        public bool Socket_Connected
        {
            get { return _socket_Connected; }
        }

        public int ManagedThreadId
        {
            set { _managedThreadId = value; }
            get { return _managedThreadId; }
        }

        public SqlConnection sqlConnection
        { 
            get { return _sqlConnection; } 
            set { _sqlConnection = value; }
        }  

        public RTThreadWork(string ip, int port)
        {
            _ip = ip;
            _port = port;
        }

        public async void ConnectRT()
        {
            Status = "вошли в ConnectRT";
            bool dbwrite = false;

            if (_sqlConnection == null || _sqlConnection.State != System.Data.ConnectionState.Open)
            {
                this.Status = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + ";Отсутствует подключение к БД регистрации Log" + Environment.NewLine;
                Changed(this, new EventArgs());
            }
            else
            {
                this.Status = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + ";Подключение к БД регистрации Log установлено" + Environment.NewLine;
                dbwrite = true;
                Changed(this, new EventArgs());
            }


            using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                await socket.ConnectAsync(_ip, _port);

                if (socket.Connected) _socket_Connected = true;

                Status = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + ";" + $"Подключение к {socket.RemoteEndPoint} установлено!!!" + Environment.NewLine;
                Changed(this, new EventArgs());

                // буфер для получения данных
                byte[] responseBytes = new byte[4096];
                // получаем данные

                ArraySegment<byte> buffer = new(responseBytes);

                StringBuilder stringBuilder = new();
                int bytesCount;

                string sLog = "";

                do
                {
                    bytesCount = await socket.ReceiveAsync(buffer, SocketFlags.None);

                    // преобразуем полученные данные в строку
                    string response = Encoding.UTF8.GetString(buffer.Array, 0, bytesCount);
                    DateTime RegDT = DateTime.Now;

                    if (bytesCount > 0)
                    {
                        if (response.IndexOf("\n") != -1)  //ответ содержит окончание строки
                        {
                            //ответ может содержать несколько переводов строки, нужно разделить ответ на строки
                            string[] rep = response.Split("\n");
                            for (int i = 0; i < rep.Length; i++)
                            {
                                if (rep[i].Length > 0)
                                {
                                    string LogString = sLog + rep[i];
                                    this.Status = RegDT.ToString("yyyy-MM-dd HH:mm:ss.fff"/*, CultureInfo.InvariantCulture*/) + ";" + LogString + Environment.NewLine;
                                    if (dbwrite)
                                    {
                                        WriteLogToDB(RegDT, LogString); //регистрация в БД
                                    }                                    
                                    Changed(this, new EventArgs()); //отправляем событие в интерфейс
                                    sLog = "";
                                }
                            }
                        }
                        else
                        {
                            if (response.Length > 0)
                            {
                                sLog = sLog + response;
                            }
                        }
                    }
                    if (CommandText.Length > 0)
                    {
                        // конвертируем данные в массив байтов
                        var msgBytes = Encoding.UTF8.GetBytes(CommandText);
                        int bytesSent = await socket.SendAsync(msgBytes, SocketFlags.None);
                        RegDT = DateTime.Now;
                        Status = RegDT.ToString("yyyy-MM-dd HH:mm:ss.fff"/*, CultureInfo.InvariantCulture*/) + ";" +
                                 $"на адрес {_ip} отправлено {bytesSent} байт(а)" + Environment.NewLine;
                        CommandText = "";
                    }
                }
                while (bytesCount > 0 && readText); // повторяем цикл, пока сервер отправляет более 0 байтов

                Status = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + ";" + "Остановка чтения пользователем" + Environment.NewLine;
                Changed(this, new EventArgs());
                socket.Close();      // закрываем подключение                
                Status = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + ";" + $"Закрыли подключение с {socket}" + Environment.NewLine;
                Changed(this, new EventArgs());
            }
            catch (SocketException sockex)
            {
                Status = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + ";" + $"Код ошибки сокета: {sockex.ErrorCode.ToString()}, сообщение: " + sockex.Message + Environment.NewLine;
                Changed(this, new EventArgs());
            }
            finally
            {
                _socket_Connected = socket.Connected;

                if (socket.Connected)
                {
                    socket.Close();
                }
                BreakConnection(this, new EventArgs());
            }
        }

        private void WriteLogToDB(DateTime RegDT, string LogString)
        {
            if (_sqlConnection == null || _sqlConnection.State != System.Data.ConnectionState.Open) return;

            using (SqlCommand cmm = new()
            {
                Connection = _sqlConnection,
                CommandType = CommandType.Text,
                CommandText = "insert into [dbo].[tbLogRecords] (id_rec, RegDT, LogString, port, ip_address) " +
                                "select (select isnull(max(id_rec), 0) + 1 from [dbo].[tbLogRecords]), @RegDT, @LogString, @port, @ip_address"
            })
            {
                cmm.Parameters.AddWithValue("@RegDT", RegDT);
                cmm.Parameters.AddWithValue("@LogString", LogString);
                cmm.Parameters.AddWithValue("@port", _port);
                cmm.Parameters.AddWithValue("@ip_address", _ip);
                try
                {
                    cmm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при записи в БД (WriteLogToDB): " + ex.Message, "Запись строки лога", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
           }

        }
    }
}

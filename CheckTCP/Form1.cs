using System.Net.Sockets;
using System.Text;
using System.Xml;

namespace CheckTCP
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            tbStatus.Clear(); 
            ConnectToSocket(this.tbIP.Text, Convert.ToInt32(this.tbPort.Text));
        }

        /// <summary>
        /// Подключение к mplc
        /// </summary>
        /// <param name="IPAddress">IP адрес RT</param>
        /// <param name="Port">Порт</param>
        /// <param name="Trace">Включить режим отладки</param>
        async void ConnectToSocket(string IPAddress, int Port)
        {
            using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                labelTitle.Text = socket.ProtocolType.ToString();

                await socket.ConnectAsync(IPAddress, Port);
                tbStatus.Text = $"Подключение к {socket.RemoteEndPoint} установлено" + Environment.NewLine;

                // буфер для получения данных
                byte[] responseBytes = new byte[512];
                // получаем данные

                ArraySegment<byte> buffer = new ArraySegment<byte>(responseBytes);

                StringBuilder stringBuilder = new StringBuilder();
                int bytesCount;

                do
                {
                    bytesCount = await socket.ReceiveAsync(buffer, SocketFlags.None);

                    // преобразуем полученные данные в строку
                    string response = Encoding.UTF8.GetString(buffer.Array, 0, bytesCount);
                    this.tbStatus.AppendText(response);
                }
                while (bytesCount > 0); // повторяем цикл, пока сервер отправляет более 0 байтов

                socket.Close(); 
                this.tbStatus.AppendText("Остановка чтения после завершения" + Environment.NewLine);
            }
            catch (SocketException sockex)
            {
                tbStatus.AppendText($"Не удалось установить подключение с {socket.RemoteEndPoint}" + Environment.NewLine);
                tbStatus.AppendText(sockex.Message);
            }
        }


    }
}
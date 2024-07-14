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
        /// ����������� � mplc
        /// </summary>
        /// <param name="IPAddress">IP ����� RT</param>
        /// <param name="Port">����</param>
        /// <param name="Trace">�������� ����� �������</param>
        async void ConnectToSocket(string IPAddress, int Port)
        {
            using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                labelTitle.Text = socket.ProtocolType.ToString();

                await socket.ConnectAsync(IPAddress, Port);
                tbStatus.Text = $"����������� � {socket.RemoteEndPoint} �����������" + Environment.NewLine;

                // ����� ��� ��������� ������
                byte[] responseBytes = new byte[512];
                // �������� ������

                ArraySegment<byte> buffer = new ArraySegment<byte>(responseBytes);

                StringBuilder stringBuilder = new StringBuilder();
                int bytesCount;

                do
                {
                    bytesCount = await socket.ReceiveAsync(buffer, SocketFlags.None);

                    // ����������� ���������� ������ � ������
                    string response = Encoding.UTF8.GetString(buffer.Array, 0, bytesCount);
                    this.tbStatus.AppendText(response);
                }
                while (bytesCount > 0); // ��������� ����, ���� ������ ���������� ����� 0 ������

                socket.Close(); 
                this.tbStatus.AppendText("��������� ������ ����� ����������" + Environment.NewLine);
            }
            catch (SocketException sockex)
            {
                tbStatus.AppendText($"�� ������� ���������� ����������� � {socket.RemoteEndPoint}" + Environment.NewLine);
                tbStatus.AppendText(sockex.Message);
            }
        }


    }
}
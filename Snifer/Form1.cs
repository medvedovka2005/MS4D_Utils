using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Globalization;


namespace Snifer
{
    using System.Diagnostics;
    using System.Globalization;
    using System.Net.Http.Headers;
    using System.Net.Sockets;
    using System.Reflection.Metadata;
    using System.Reflection.Metadata.Ecma335;
    using System.Security.Cryptography;
    using System.Security.Cryptography.Xml;
    using System.Security.Policy;
    using System.Text.Json;
    using System.Web;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;
    using static System.Net.Mime.MediaTypeNames;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            InitDataStructure();
        }

        HttpClient httpClient = new();
        LoginAnswer? loginAnswer = new();
        CreateDataSubscriptionAnswer? dataSubscriptionAnswer = new();
        MonitoredDataItems monitoredDataItems = new();
        PublishDataAnswer? publishDataAnswer = new();
        int ackSequenceNumber = 0;


        DataSet dsMonitoredParams = new("dsMonitoredParams");
        DataTable tbMonitoredParams = new("tbMonitoredParams");
        BindingSource bsMonitoredParams = new();

        private void InitDataStructure()
        {
            DataColumn cl1 = new DataColumn("itemId", typeof(int));
            DataColumn cl2 = new DataColumn("value", typeof(object));
            DataColumn cl3 = new DataColumn("valueType", typeof(object));
            DataColumn cl4 = new DataColumn("serverDateTime", typeof(object));
            DataColumn cl5 = new DataColumn("clientHandle", typeof(int));

            tbMonitoredParams.Columns.Add(cl1);
            tbMonitoredParams.Columns.Add(cl2);
            tbMonitoredParams.Columns.Add(cl3);
            tbMonitoredParams.Columns.Add(cl4);
            tbMonitoredParams.Columns.Add(cl5);

            dsMonitoredParams.Tables.Add(tbMonitoredParams);

            DataRow rw0 = tbMonitoredParams.NewRow();
            rw0["itemId"] = 127143;
            rw0["value"] = "0";
            rw0["valueType"] = "DINT";
            rw0["clientHandle"] = 1;
            tbMonitoredParams.Rows.Add(rw0);

            DataRow rw1 = tbMonitoredParams.NewRow();
            rw1["itemId"] = 127161;
            rw1["value"] = "0";
            rw1["valueType"] = "DINT";
            rw1["clientHandle"] = 2;
            tbMonitoredParams.Rows.Add(rw1);

            bsMonitoredParams = new BindingSource
            {
                DataSource = dsMonitoredParams,
                DataMember = "tbMonitoredParams" //���� ����� ������, ������������ [dbo].[get_task_recs]
            };

            //���������� � ������� ���� �������� ����������
            dataGridViewMonitoredParams.AutoGenerateColumns = false;
            dataGridViewMonitoredParams.DataSource = bsMonitoredParams;
            dataGridViewMonitoredParams.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMonitoredParams.Columns[3].DefaultCellStyle.Format = @"dd.MM.yy HH:mm:ss";

        }


        //void DataViewUpdt(object i)
        //{
        //    dataGridViewMonitoredParams.BeginInvoke(new Action(() => dataGridViewMonitoredParams.Refresh())); //��������� �������
        //}

        /// <summary>
        /// ������������ � RT
        /// </summary>
        private async void button1_Click(object sender, EventArgs e)
        {
            {

                var rand = new Random();


                LoginRequest loginRequest = new LoginRequest();
                loginRequest.login = "usr1";
                loginRequest.hostName = Environment.MachineName;
                loginRequest.password = "698d51a19d8a121ce581499d7b701668";

                string s = JsonSerializer.Serialize(loginRequest);

                //������ �� ����������� �������� ��������
                HttpRequestMessage httpRequestLogin = new HttpRequestMessage(HttpMethod.Post, "http://10.30.5.55:8043//Methods/Login");
                httpRequestLogin.Content = new StringContent(s);  //JsonContent.Create(s);

                //����� �� ������ �� �����������
                HttpResponseMessage httpResponseMessageLogin = await httpClient.SendAsync(httpRequestLogin);
                string resp = await httpResponseMessageLogin.Content.ReadAsStringAsync();

                ResultsTextBox.AppendText($"��������� /Methods/Login: {s}" + Environment.NewLine);
                ResultsTextBox.AppendText($"�����: {resp}" + Environment.NewLine);
                //Debug.WriteLine(s);
                //Debug.WriteLine(resp);

                loginAnswer = JsonSerializer.Deserialize<LoginAnswer>(resp);
                if (loginAnswer == null) return;


                CreateDataSubscriptionRequest dataSubscriptionRequest = new CreateDataSubscriptionRequest();
                dataSubscriptionRequest.sessionId = loginAnswer.sessionId;

                s = JsonSerializer.Serialize(dataSubscriptionRequest);
                
                //������ �� �������� ��������
                HttpRequestMessage httpDataSubscriptionRequest = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:8043//Methods/CreateDataSubscription");
                httpDataSubscriptionRequest.Content = new StringContent(s);

                //����� �� ������ �� �������� ��������
                HttpResponseMessage httpDataSubscriptionAnswer = await httpClient.SendAsync(httpDataSubscriptionRequest);
                resp = await httpDataSubscriptionAnswer.Content.ReadAsStringAsync();
                
                dataSubscriptionAnswer = JsonSerializer.Deserialize<CreateDataSubscriptionAnswer>(resp);

                ResultsTextBox.AppendText($"��������� Methods/CreateDataSubscription: {s}" + Environment.NewLine);
                ResultsTextBox.AppendText($"�����: {resp}" + Environment.NewLine);
                //Debug.WriteLine($"������� ����� �� ������ �������� �������� {resp}");
                //Debug.WriteLine(JsonSerializer.Serialize(dataSubscriptionAnswer));


                //WriteData (����� ���� ��� ������)
                WriteDataRequest writeDataRequest = new WriteDataRequest();
                writeDataRequest.sessionId = loginAnswer.sessionId;

                ModifiedRecord dataRecord = new ModifiedRecord();
                dataRecord.itemId = 127143;
                dataRecord.value = rand.NextInt64(10000);
                dataRecord.operation = "move";
                dataRecord.type = "DINT";
                writeDataRequest.recs.Add(dataRecord);

                s = JsonSerializer.Serialize(writeDataRequest);
                Debug.WriteLine($"����������� ��� ������ {s}");                                                               
                HttpRequestMessage httpWriteDataRequest = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:8043//Methods/WriteData");
                httpWriteDataRequest.Content = new StringContent(s);
                HttpResponseMessage httpWriteDataAnswer = await httpClient.SendAsync(httpWriteDataRequest);
                resp = await httpWriteDataAnswer.Content.ReadAsStringAsync();

                ResultsTextBox.AppendText($"��������� Methods/WriteData: {s}" + Environment.NewLine);
                ResultsTextBox.AppendText($"�����: {resp}" + Environment.NewLine);

                //���������� ����������
                monitoredDataItems.sessionId = dataSubscriptionRequest.sessionId;
                monitoredDataItems.subscriptionId = dataSubscriptionAnswer.subscriptionId;
                ackSequenceNumber = 0;
                

                //������ ������������������ ��������� ��� �����������
                foreach (DataRow rw in tbMonitoredParams.Rows)
                {
                    MonitoredItem itm = new MonitoredItem();
                    itm.clientHandle = (int) rw["clientHandle"];
                    itm.itemId = (int)rw["itemId"];
                    itm.type = (string)rw["valueType"]; 
                    monitoredDataItems.items.Add(itm);
                }

                s = JsonSerializer.Serialize(monitoredDataItems);
                HttpRequestMessage httpMonitoredDataItemsRequest = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:8043/Methods/CreateMonitoredDataItems");
                httpMonitoredDataItemsRequest.Content = new StringContent(s);
                HttpResponseMessage httpMonitoredDataItemsAnswer = await httpClient.SendAsync(httpMonitoredDataItemsRequest);
                resp = await httpMonitoredDataItemsAnswer.Content.ReadAsStringAsync();

                ResultsTextBox.AppendText($"��������� Methods/CreateMonitoredDataItems: {s}" + Environment.NewLine);
                ResultsTextBox.AppendText($"�����: {resp}" + Environment.NewLine);

                timer1.Start();
              
            }

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            WriteDataRequest writeDataRequest = new WriteDataRequest();
            writeDataRequest.sessionId = loginAnswer.sessionId;

            //������ ������������������ ��������� ��� �����������
            foreach (DataRow rw in tbMonitoredParams.Rows)
            {
                ModifiedRecord dataRecord = new ModifiedRecord();
                dataRecord.itemId = (int)rw["itemId"];
                dataRecord.value = rw["value"];
                dataRecord.operation = "move";
                dataRecord.type = (string) rw["valueType"];
                writeDataRequest.recs.Add(dataRecord);
            }

            string s = JsonSerializer.Serialize(writeDataRequest);            
            HttpRequestMessage httpWriteDataRequest = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:8043//Methods/WriteData");
            httpWriteDataRequest.Content = new StringContent(s);
            HttpResponseMessage httpWriteDataAnswer = await httpClient.SendAsync(httpWriteDataRequest);
            
            string resp = await httpWriteDataAnswer.Content.ReadAsStringAsync();

            ResultsTextBox.AppendText($"��������� Methods/WriteData: {s}" + Environment.NewLine);
            ResultsTextBox.AppendText($"�����: {resp}" + Environment.NewLine);
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    DateTime dt = DateTime.Now;
        //    Debug.WriteLine($"�������� ������: {dt}");
        //    RunMetod(dt);
        //}

        private async void button3_Click(object sender, EventArgs e)
        {

            ExampleMethodAsync();
        }

        public async void ExampleMethodAsync()
        {

            HttpClient httpClient = new HttpClient();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://httpbin.org/post");

            string s = "{\"name\":\"Roman Lysenko\",\"occupation\":\"support specialist\"}";
            httpRequestMessage.Content = JsonContent.Create(s);

            string key = "4444";
            var AppKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(key));
            var guidstring = Guid.NewGuid().ToString();
            var date = DateTimeOffset.UtcNow.ToString("r", CultureInfo.InvariantCulture);
            var host = httpRequestMessage.RequestUri.Authority;
            var contentHash = ComputeContentHash(s);
            var stringToSign = $"POST\n{httpRequestMessage.RequestUri.PathAndQuery}\n{date};{host};{contentHash}";
            var signature = ComputeSignature(stringToSign, AppKey);

            httpRequestMessage.Headers.Add("X_CA_KEY", AppKey);
            httpRequestMessage.Headers.Add("X_CA_NONCE", guidstring);
            httpRequestMessage.Headers.Add("X_CA_TIMESTAMP", date); //�� ������� � ����� ������� ����
            httpRequestMessage.Headers.Add("X_CA_SIGNATURE", signature); //���-�� ���� ����� ��� ����������� SignUtil.Sign


            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            string sIn = await httpResponseMessage.Content.ReadAsStringAsync();

            Debug.WriteLine("!!!" + sIn);

            ResultsTextBox.Text = sIn;
        }

        static string ComputeContentHash(string content)
        {
            using var sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(content));
            return Convert.ToBase64String(hashedBytes);
        }

        private static string generateHash(string str, string cypherkey)
        {
            var encoding = new System.Text.ASCIIEncoding();

            var messageBytes = encoding.GetBytes(str);
            var keyBytes = encoding.GetBytes(cypherkey);

            using var hmacsha256 = new HMACSHA256(keyBytes);
            var hashmessage = hmacsha256.ComputeHash(messageBytes);
            return Convert.ToBase64String(hashmessage);
        }

        private static string myHash(string text, string key)
        {
           
            byte[] bytes = Encoding.Default.GetBytes(text);
            byte[] keyBytes = Encoding.Default.GetBytes(key);


            HMACSHA256 hmac = new HMACSHA256(keyBytes);
            
                hmac.ComputeHash(bytes);
                return Convert.ToBase64String(hmac.Hash);
        }


       

        private void timer1_Tick(object sender, EventArgs e)
        {
            RunPublishData();
        }

        /// <summary>
        /// ������ �� ��������� ������ �� ��������. ���� ����� ����������� ���, �� ���� data �� ����������. 
        /// ����� �� ���������� ���� sequenceNumber (� ��������� ������� ����� ������� ���������� �������� ackSequenceNumber).
        /// </summary>
        public async void RunPublishData()
        {
            PublishDataRequest publishData = new PublishDataRequest();
            publishData.sessionId = this.loginAnswer.sessionId;
            publishData.subscriptionId = this.dataSubscriptionAnswer.subscriptionId;
            publishData.ackSequenceNumber = ackSequenceNumber;

            string s = JsonSerializer.Serialize(publishData);
            HttpRequestMessage httpPublishDataRequest = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:8043/Methods/PublishData");
            httpPublishDataRequest.Content = new StringContent(s);
            HttpResponseMessage httpPublishDataAnswer = await httpClient.SendAsync(httpPublishDataRequest);
            string resp = await httpPublishDataAnswer.Content.ReadAsStringAsync();

            publishDataAnswer = JsonSerializer.Deserialize<PublishDataAnswer>(resp);

            if (publishDataAnswer.sequenceNumber > ackSequenceNumber)
            {
                ackSequenceNumber = publishDataAnswer.sequenceNumber;
            }

            if (publishDataAnswer.recs.Count > 0) {
                ParcePublishData();
            }

            ResultsTextBox.AppendText($"��������� Methods/PublishData: {s}" + Environment.NewLine);
            ResultsTextBox.AppendText($"�����: {resp}" + Environment.NewLine);

        }
        public async void ParcePublishData()
        {
            foreach (MonitoredItem rec in publishDataAnswer.recs)
            { 
                foreach (DataRow row in tbMonitoredParams.Rows)
                { 
                    if ((int) row["clientHandle"] == rec.clientHandle) 
                    {
                        row.BeginEdit();
                        row["value"] = rec.value.ToString();
                        row["serverDateTime"] = publishDataAnswer.serverDateTime;
                        row.EndEdit();
                    }
                }
            }
        }
        private async void button4_Click(object sender, EventArgs e)
        {
            //�������� ��������
            DeleteDataSubscriptionRequest deleteDataSubscriptionRequest = new DeleteDataSubscriptionRequest(loginAnswer.sessionId, dataSubscriptionAnswer.subscriptionId);
            HttpRequestMessage httpDeleteDataSubscriptionRequest = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:8043//Methods/DeleteDataSubscription");
            string s = JsonSerializer.Serialize(deleteDataSubscriptionRequest);
            httpDeleteDataSubscriptionRequest.Content = new StringContent(s);

            HttpResponseMessage httpDeleteDataSubscriptionAnswer = await httpClient.SendAsync(httpDeleteDataSubscriptionRequest);
            string resp = await httpDeleteDataSubscriptionAnswer.Content.ReadAsStringAsync();
            DeleteDataSubscriptionAnswer? deleteDataSubscriptionAnswer = JsonSerializer.Deserialize<DeleteDataSubscriptionAnswer>(resp);
                        
            timer1.Stop();

            ResultsTextBox.AppendText($"��������� Methods/DeleteDataSubscription: {s}" + Environment.NewLine);
            ResultsTextBox.AppendText($"�����: {resp}" + Environment.NewLine);

        }


        static string ComputeSignature(string stringToSign, string secret)
        {
            
            using var hmacsha256 = new HMACSHA256(Convert.FromBase64String(secret));
            var bytes = Encoding.UTF8.GetBytes(stringToSign);
            var hashedBytes = hmacsha256.ComputeHash(bytes);
            return Convert.ToBase64String(hashedBytes);
        }


        private async void button5_Click(object sender, EventArgs e)
        {
            string appSecret = "teUkzUWNLlgu6ozXg9fq6mPy4lOjU5X4EiE4bVuDnF8=";
            string request_method = "POST";
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.AllowAutoRedirect = false;
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);            
            HttpRequestMessage httpReqMsg = new HttpRequestMessage(HttpMethod.Post, "https://10.16.45.251/artemis/api/common/v1/version");
            
            httpReqMsg.Headers.Add("Accept", "application/json");
            httpReqMsg.Headers.Add("X-Ca-Key", "26916037");
            
            httpReqMsg.Content = new StringContent(string.Empty);
            httpReqMsg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpReqMsg.Content.Headers.ContentType.CharSet = "UTF-8";
          
            //Debug.WriteLine(httpReqMsg.Headers.Accept.ToString());


            string textToSign = httpReqMsg.Method.ToString() + "\n";
            textToSign += httpReqMsg.Headers.Accept.ToString() + "\n";
            textToSign += httpReqMsg.Content.Headers.ContentType + "\n";
            
            var url_path = "/artemis" + httpReqMsg.RequestUri.ToString().Split("artemis")[1];
            url_path = url_path.Replace("{{API_VER}}", "v1");

            textToSign += url_path;

            string hash = myHash(textToSign, appSecret);
            httpReqMsg.Headers.Add("X-Ca-Signature", hash);


            //string signature = ComputeSignature(textToSign, appSecret);

            //var authorizationHeader = $"HMAC-SHA256 SignedHeaders=x-ms-date;host;x-ms-content-sha256&Signature={signature}";


            //httpReqMsg.Headers.Add("Authorization", authorizationHeader);



            //FDDkgJuvIBvlkOyTUHzaF6ATtlbhtaDtEJCWtiSYbgs=
            //FDDkgJuvIBvlkOyTUHzaF6ATtlbhtaDtEJCWtiSYbgs=
            //FpT/upYsqMATyuacfnOsRm3yVYfEIsMwe/c5URQ20ZI=





            Debug.WriteLine("textToSign: " + textToSign);
            //Debug.WriteLine("ContentType: "  + httpReqMsg.Content.Headers.ContentType.ToString());


            /*
                resp: {"code":"0x02401003","msg":"Invalid Signature! and StringToSign: POST\n
            application/json\n
            application/json; charset=UTF-8\n
            /artemis/api/common/v1/version"}
            
            POST\n
            application/json\n
            application/json; charset=UTF-8\n
            /artemis/api/common/v1/version

             */


            /*
             var appSecret = pm.variables.get("SK");
            var textToSign = "";
            textToSign += request.method + "\n";
            textToSign += request.headers.accept + "\n";
            textToSign += request.headers["content-type"] + "\n";
            var url_path = "/artemis" + request.url.split("artemis")[1];
            url_path = url_path.replace("{{API_VER}}",  pm.variables.get("API_VER"));
            textToSign += url_path;
            var hash = CryptoJS.HmacSHA256(textToSign, appSecret);
            var signature = hash.toString(CryptoJS.enc.Base64);
            pm.environment.set("SIGNATURE", signature);             
             */


            try
            {
                


                HttpResponseMessage httpResponseMessage = await client.SendAsync(httpReqMsg);
                //httpResponseMessage.EnsureSuccessStatusCode();

                string resp = await httpResponseMessage.Content.ReadAsStringAsync();

                Debug.WriteLine($"resp: {resp}"); 
            }
            catch (Exception ex)
            {
                Debug.WriteLine("�������� �����: " + ex.Message);
            }

        }

        private async void button6_Click(object sender, EventArgs e)
        {
            GetLoginDataRequest getLoginDataRequest = new GetLoginDataRequest();

            HttpRequestMessage httpGetLoginDataRequest = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:8043//Methods/GetLoginData");
            string s = JsonSerializer.Serialize(getLoginDataRequest);
            //httpGetLoginDataRequest.Content = new StringContent(s);
            httpGetLoginDataRequest.Content = JsonContent.Create(s);

            HttpResponseMessage httpGetLoginDataAnswer = await httpClient.SendAsync(httpGetLoginDataRequest);
            string resp = await httpGetLoginDataAnswer.Content.ReadAsStringAsync();
            GetLoginDataAnswer? getLoginDataAnswer = JsonSerializer.Deserialize<GetLoginDataAnswer>(resp);


            ResultsTextBox.AppendText($"��������� Methods/GetLoginData: {s}" + Environment.NewLine);
            ResultsTextBox.AppendText($"�����: {resp}" + Environment.NewLine);


        }
    }


    class LoginRequest {

        public LoginRequest()
        { 
            
        }

        public LoginRequest(string login, string password, string hostName)
        {
            this.login = login;
            this.password = password;   
            this.hostName = hostName;
        }

        public string login { get; set; }
        public string password { get; set; }
        public string hostName { get; set; }
    }

    class LoginAnswer
    {

        public LoginAnswer()        {}

        public int sessionId { get; set; }
        public string user { get; set; }
        public string fullName { get; set; }
        public string startMnemoscheme { get; set; }
        public string hostName { get; set; }        
        
        public string clientAddress { get; set; }
        public int sessionExpireTime { get; set; }
        public int sessionIdleTime { get; set; }
        public string projectId { get; set; }
        public string projectVersion { get; set; }        
        public int projectSessionId { get; set; }
        public bool isMaster { get; set; }
        public int status { get; set; }
        public int features { get; set; }
        public int code { get; set; }

        public List<object> groups { get; set; }

        //public List<object> rights { get; set; }

    }

    class WriteDataRequest
    {

        public WriteDataRequest()
        {
            recs = new List<ModifiedRecord>();
        }
        public int sessionId { get; set; }

        public List<ModifiedRecord> recs { get; set; }
    }

    /// <summary>
    /// ������������� ��������
    /// </summary>
    class MonitoredItem : DataRecord
    {      
        /// <summary>
        /// ��������� �� ��������, ������������� ������������� � ����� ������������� �������������� ���������
        /// </summary>
        public int clientHandle { get; set; }
    }
    
    /// <summary>
    /// ���������� ��������
    /// </summary>
    class ModifiedRecord : DataRecord
    {
        /// <summary>
        /// ��������� �������� operation:
        /// move - ���������(�� ���������); concat - ������������; add - ��������; mul - ���������; div -�������; sub - ���������; impulse - ������ �������(��������������� value, �� ���� ����� ��������������� !value).
        /// </summary>
        public string operation { get; set; }

    }
    /// <summary>
    /// ������� �����, ����������� ��������
    /// </summary>
    class DataRecord
    {
        int m_taskId = 0;
        string m_dataSourceId = "MPLCDataSource";
        string m_path = "";
        int m_usesCounts = 1;
        /// <summary>
        /// id ������ ����
        /// </summary>
        public int taskId
        {
            set { m_taskId = value; }
            get { return m_taskId; }
        }
        
        /// <summary>
        /// ???
        /// </summary>
        public string dataSourceId
        {
            set { m_dataSourceId = value; }
            get { return m_dataSourceId; }
        }
        /// <summary>
        /// ID ��������� (������������� ��������� � ������� MS4d)
        /// </summary>
        public int itemId {get; set;}
        /// <summary>
        /// ���� ������ ���������� ��������� ItemID (����� �� ��������). ���� ItemID=0, �� � path ���������� ������ ���� � ���������.
        /// </summary>
        public string path
        {
            set { m_path = value; }
            get { return m_path; }
        }
        /// <summary>
        /// "��� ���������" - (����� ���� ������ �������� ����).
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// �������� ���������
        /// </summary>
        public object value { get; set; }
        
        /// <summary>
        /// ???
        /// </summary>
        public int usesCounts
        {
            set { m_usesCounts = value; }
            get { return m_usesCounts; }
        }

    }

    /// <summary>
    /// ������������� ���������
    /// </summary>
    class MonitoredDataItems {

        int m_sessionId { get; set; }
        int m_subscriptionId { get; set; }

        /// <summary>
        /// ����������� 
        /// </summary>
        public MonitoredDataItems()
        {
            items = new List<MonitoredItem>();
        }
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="sessionId">Id ������</param>
        /// <param name="subscriptionId">Id ��������</param>
        public MonitoredDataItems(int sessionId, int subscriptionId)
        {
            m_sessionId = sessionId;
            m_subscriptionId = subscriptionId;
            items = new List<MonitoredItem>();
        }
        /// <summary>
        /// Id ������
        /// </summary>
        public int sessionId
        {
            set { m_sessionId = value; }
            get { return m_sessionId; }
        }
        /// <summary>
        /// Id ��������
        /// </summary>
        public int subscriptionId
        {
            set { m_subscriptionId = value; }
            get { return m_subscriptionId; }
        }
        /// <summary>
        /// ������ ������������� ����������
        /// </summary>
        public List<MonitoredItem> items { get; set; }
    }
    /// <summary>
    /// ����� ������� - ������� �����, ���������� ����, ������������ ��������� ������
    /// </summary>
    class ServerAnswer
    {
        /// <summary>
        /// ����� ������ � ��������� �� ����������� � TimeStamp
        /// </summary>
        public Int64 serverTime { get; set; }
        /// <summary>
        /// ��� ��������. ���� 0, �� ��� ������
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// ���� � ����� �������
        /// </summary>
        public DateTime serverDateTime
        {
            get
            {
                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(serverTime).ToLocalTime();
                return dt;
            }
        }
    }

    /// <summary>
    /// ������ �� �������� �������� (��� ���������� ������ /Methods/CreateDataSubscription)
    /// </summary>
    class CreateDataSubscriptionRequest
    {
        int m_sessionId;
        int m_requestedPublishingInterval;
        int m_requestedLifetimeInterval;
        int m_maxNotificationsPerPublish;
        int m_maxSize;

        /// <summary>
        /// ������ �� �������� ��������
        /// </summary>
        /// <param name="sessionId">ID ������
        /// <param name="requestedPublishingInterval">������ �������� - ������ (��), � ������� ������ ������� ��������� ������, ���� 0, ������ ������������ ��������.
        /// <param name="requestedLifetimeInterval">������ �������, - ������, ���� � ��� ������� �� ����� ������� ����� ������, �������� ���������, ���� 0, ������ ������������ ��������.
        /// <param name="maxNotificationsPerPublish">����� ��������, - ������������ ����� �������� � ����� ������. 0 - ��� �����������.
        /// <param name="maxSize">������ - ������������ ������ ������ �� ������ PublishData � ������. ���� 0 - ����������� ������������ ��������
        public CreateDataSubscriptionRequest(int sessionId, int requestedPublishingInterval = 0
            , int requestedLifetimeInterval = 0, int maxNotificationsPerPublish = 0, int maxSize = 0)
        {
            m_sessionId = sessionId;
            m_requestedPublishingInterval = requestedPublishingInterval;
            m_requestedLifetimeInterval = requestedLifetimeInterval;
            m_maxNotificationsPerPublish = maxNotificationsPerPublish;
            m_maxSize = maxSize;
        }
        /// <summary>
        /// ��������
        /// </summary>
        public CreateDataSubscriptionRequest() { 
        
        }

        /// <summary>
        /// ID ������ 
        /// </summary>
        public int sessionId
        {
            set { m_sessionId = value; }
            get { return m_sessionId; }
        }
        /// <summary>
        /// ������ �������� - ������ (��), � ������� ������ ������� ��������� ������, ���� 0, ������ ������������ ��������.
        /// </summary>
        public int requestedPublishingInterval
        {
            set { m_requestedPublishingInterval = value; }
            get { return m_requestedPublishingInterval; }
        }
        /// <summary>
        /// ������ �������, ���� � ��� ������� �� ����� ������� ����� ������, �������� ���������, ���� 0, ������ ������������ ��������.</param>
        /// </summary>
        public int requestedLifetimeInterval
        {
            set { m_requestedLifetimeInterval = value; }
            get { return m_requestedLifetimeInterval; }
        }
        /// <summary>
        /// ����� �������� - ������������ ����� �������� � ����� ������. 0 - ��� �����������.
        /// </summary>
        public int maxNotificationsPerPublish
        {
            set { m_maxNotificationsPerPublish = value; }
            get { return m_maxNotificationsPerPublish; }
        }
        /// <summary>
        /// ������ - ������������ ������ ������ �� ������ PublishData � ������. ���� 0 - ����������� ������������ ��������.
        /// </summary>
        public int maxSize
        {
            set { m_maxSize = value; }
            get { return m_maxSize; }
        }

    }
    
    /// ����� �� ������ �� �������� ��������
    class CreateDataSubscriptionAnswer : ServerAnswer
    {
        int m_subscriptionId;
        int m_revisedPublishingInterval;
        int m_revisedLifetimeInterval;
        public CreateDataSubscriptionAnswer()
        { 
        }

        /// <summary>
        /// Id >, - Id ��������� ��������.
        /// </summary>
        public int subscriptionId
        {
            set { m_subscriptionId = value; }
            get { return m_subscriptionId; }
        }
        /// <summary>
        /// ������ ����������>, - �������� ������ ����������, ����� ���� ������.
        /// </summary>
        public int revisedPublishingInterval
        {
            set { m_revisedPublishingInterval = value; }
            get { return m_revisedPublishingInterval; }
        }

        /// <summary>
        /// ������ ������������> - �������� ������ ������������ ����� ��������� ��������.
        /// </summary>
        public int revisedLifetimeInterval
        {
            set { m_revisedLifetimeInterval = value; }
            get { return m_revisedLifetimeInterval; }
        }
    }

    /// <summary>
    /// ����� �� �������� ��������
    /// </summary>
    class DeleteDataSubscriptionRequest
    {
        int m_sessionId;
        int m_subscriptionId;
        
        /// <summary>
        /// ����������� ������
        /// </summary>
        /// <param name="sessionId">ID ������</param>
        /// <param name="subscriptionId">Id ��������� ��������</param>
        public DeleteDataSubscriptionRequest(int sessionId, int subscriptionId)
        {
            m_sessionId = sessionId;
            m_subscriptionId = subscriptionId;
        }

        /// <summary>
        /// ����������� ������
        /// </summary>
        public DeleteDataSubscriptionRequest()
        {
        }

        /// <summary>
        ///ID ������
        /// </summary>
        public int sessionId
        {
            set { m_sessionId = value; }
            get { return m_sessionId; }
        }

        /// <summary>
        /// Id ��������� ��������.
        /// </summary>
        public int subscriptionId
        {
            set { m_subscriptionId = value; }
            get { return m_subscriptionId; }
        }

    }
    /// <summary>
    /// ����� �� ������ �������� ��������
    /// </summary>
    class DeleteDataSubscriptionAnswer : ServerAnswer
    {
        
    }

    /// <summary>
    /// ������ �� ��������� ������ �� ��������. ���� ����� ����������� ���, �� ���� data �� ����������. 
    /// ����� �� ���������� ���� sequenceNumber (� ��������� ������� ����� ������� ���������� �������� ackSequenceNumber).
    /// </summary>
    class PublishDataRequest
    {
        int m_sessionId;
        int m_subscriptionId;
        int m_ackSequenceNumber = 0;

        /// <summary>
        /// ID ������
        /// </summary>
        public int sessionId
        {
            set { m_sessionId = value; }
            get { return m_sessionId; }
        }

        /// <summary>
        /// ID ��������
        /// </summary>
        public int subscriptionId
        {
            set { m_subscriptionId = value; }
            get { return m_subscriptionId; }
        }
        /// <summary>
        /// "����� ������" - ��������� ���������� �������� ����� ������ �� ������ ��������. ��� ������� ������� �� �����������.
        /// </summary>
        public int ackSequenceNumber
        {
            set { m_ackSequenceNumber = value; }
            get { return m_ackSequenceNumber; }
        }
    }
    /// <summary>
    /// ����� �� ������ �� ��������� ������ �� ��������.
    /// </summary>
    class PublishDataAnswer : ServerAnswer
    {
        int m_subscriptionId;
        int m_sequenceNumber;
        public PublishDataAnswer()
        {
            recs = new List<MonitoredItem>();
        }
        /// <summary>
        /// "ID ��������"
        /// </summary>
        public int subscriptionId
        {
            set { m_subscriptionId = value; }
            get { return m_subscriptionId; }
        }
        /// <summary>
        /// <������� ����� ������> - ������ ���������� ����� � �������, ��������� ����� ackSequenceNumber (���� �� ��� ������ �� ������� ��������, �� ������������ ������ �� �������).
        /// </summary>
        public int sequenceNumber
        {
            set { m_sequenceNumber = value; }
            get { return m_sequenceNumber; }
        }

        /// <summary>
        /// true - �� ��� ����������� ��������, ����� ��������� ������
        /// </summary>
        public bool hasMore { get; set; }

        /// <summary>
        /// ������ ������������� ����������
        /// </summary>
        public List<MonitoredItem> recs { get; set; }

    }


    class GetLoginDataRequest
    {
        int m_sessionId;

        /// <summary>
        /// ID ������
        /// </summary>
        public int sessionId
        {
            set { m_sessionId = value; }
            get { return m_sessionId; }
        }
    }

    class GetLoginDataAnswer
    {
        int m_code;
        string m_projectId = "";
        string m_currentOperator = "";
        string m_startMnemoscheme = "";

        /// <summary>
        /// code
        /// </summary>
        public int code
        {
            set { m_code = value; }
            get { return m_code; }
        }

        /// <summary>
        /// ��������� ������, ���������������� ������� ������ �������. �������� ����� ������ �������� ������� �� ������.
        /// </summary>
        public string projectId
        {
            set { m_projectId = value; }
            get { return m_projectId; }
        }

        /// <summary>
        /// ���� � sessionId ���������� ID �������� ������, �� ������������ ��� �������� ��������� (� ���� ������ ���� ������ ����� �� ����������, � ����� ���������� � ���������� ���� ������� ���������).
        /// </summary>
        public string currentOperator
        {
            set { m_currentOperator = value; }
            get { return m_currentOperator; }
        }

        /// <summary>
        ///  ��������� ID ���������� ���� �� ��������� (������������, ���� ��� ���������� ��� � ��������� �� ��������������).
        /// </summary>
        public string startMnemoscheme
        {
            set { m_startMnemoscheme = value; }
            get { return m_startMnemoscheme; }
        }



    }

}
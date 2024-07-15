using System.Diagnostics;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using System.Configuration;
using System.ComponentModel;
using CheckRT.PropertyClasses;
using System.Text.Json;
using Microsoft.Identity.Client.NativeInterop;
using CheckRT;
using System.Diagnostics.Metrics;
using System.Windows.Forms;

namespace CheckRT
{

    public partial class MainForm : Form
    {

        int RetryCount = 0;
        private string TempBuffer = "";

        CheckRT.ThredClasses.RTThreadWork rt;

        //������ �����������
        [Description("��������� ����������� � ���� ������"), Category("SQL Server Connection String")]
        //SqlConnectionStringBuilder sqlConnectionStringBuilder = new();
        SqlServerConnectionProperty sqlServerConnectionProperty = new();


        [Description("�������� ����������� � ���� ������"), Category("SQL Server Connection")]
        private SqlConnection cnnPrimary;


        public event EventHandler ReadyThred_RefreshFiltredRecs;
        public event EventHandler ReadyThred_RefreshLogRecs;
        public event EventHandler ReadyThred_RefreshStatRecs;
        public event EventHandler ReadyThred_RefreshArchStatRecs;

        private bool RefreshLogRecsIsFree = true;
        private bool RefreshFiltredRecsIsFree = true;
        private bool RefreshStatRecsIsFree = true;
        private bool RefreshArchStatRecsIsFree = true;


        //������ ����������� � ���� ������
        List<SqlConnection> sqlConnections = new();

        //������ ��� ��������� ����������� � ������
        SocketConnectionProperty socketConnectionProperty = new();
        //SqlConnectionStringBuilder sqlConnectionStringBuilder;

        //������� ��������� �����
        TaskProperty taskProperty_LogRecords; //������ �����������
        TaskProperty taskProperty_FiltredRecs; //��������������� ������
        TaskProperty taskProperty_TaskRecords; //���������� �����
        TaskProperty taskProperty_ArchiveStat; //���������� �������������

        #region �������� ��� ������ � ���������
        private SqlDataAdapter adFilters;
        private SqlDataAdapter adFilterSettings;

        private DataSet dsFilters;      //�������
        private BindingSource masterBindingSource;  //�������
        private BindingSource detailsBindingSource; //��������� ��������
        private BindingNavigator masterNavigator;
        private BindingNavigator detailsNavigator;
        #endregion


        #region �������� ��� ��������� ���������� �����
        SqlConnection sqlConnectionTaskStat = new();
        SqlDataAdapter adTaskStatistic = new();

        //����� (DataSet) ��� ���������� ������
        DataSet dsTaskStatistic = new("dsTaskStatistic");
        //���������� ������ �������
        DataTable tbTaskPrimary = new("tbTaskPrimary");
        //���������� ����� �������� � ����������
        DataTable tbTaskStat = new("tbTaskStat");
        //���������� ����� ��������
        DataTable tbTaskStatDetailU = new("tbTaskStatDetailU");
        DataTable tbTaskMemory = new("tbTaskMemory");

        //���������� ������������� ������ �������� � �����������
        DataTable tbMemoryStat = new("tbMemoryStat");


        //�������� ������ ��� ��������� ���������� (DataGridView)
        BindingSource bsTaskStatistic;
        BindingSource bsTaskStatisticPrimary;
        BindingSource bsUTaskStatistic;

        #endregion

        #region �������� ��� ��������� ���������� ������������� 
        SqlConnection sqlConnectionArchiveStat = new();
        SqlDataAdapter adArchiveStatistic = new();

        //������� ���������� �������������
        DataTable tbArchiveStatistic = new("tbArchiveStatistic");
        //������� � ���������������� ������� ���������� �������������, �.�. ������ ���� ������� �� �������
        DataTable tbArchiveStatisticParce = new("tbArchiveStatisticParce");

        //����� (DataSet) ��� ���������� ������������� 
        DataSet dsArchiveStatistic = new("dsArchiveStatistic");

        //�������� ������ ��� ��������� ���������� (DataGridView)
        BindingSource bsArchiveStatistic;
        BindingSource bsArchiveStatisticParce;
        #endregion


        public MainForm()
        {
            InitializeComponent();

            masterNavigator = new BindingNavigator(masterBindingSource);
            tableLayoutPanel1.Controls.Add(masterNavigator);

            ToolStripItem SaveItem = new ToolStripButton();
            SaveItem.ToolTipText = "���������";
            SaveItem.Name = "bindingNavigatorSaveItem";
            SaveItem.Image = imageList1.Images[0];
            SaveItem.Click += Filters_SaveItem_Click;
            masterNavigator.Items.Add(SaveItem);


            ToolStripItem RefreshItem = new ToolStripButton();
            RefreshItem.ToolTipText = "��������";
            RefreshItem.Name = "bindingNavigatorRefreshItem";
            RefreshItem.Image = imageList1.Images[1];
            RefreshItem.Click += Filters_RefreshItem_Click;
            masterNavigator.Items.Add(RefreshItem);

            ToolStripItem EditItem = new ToolStripButton();
            EditItem.ToolTipText = "��������";
            EditItem.Name = "bindingNavigatorEditItem";
            EditItem.Image = imageList1.Images[2];
            EditItem.Click += Filters_EditItem_Click;
            masterNavigator.Items.Add(EditItem);

            masterNavigator.Items["bindingNavigatorAddNewItem"].Click += Filters_AddItem_Click;


            foreach (ToolStripItem b in masterNavigator.Items)
            {
                Debug.WriteLine($"������������ ������ {b.Name}");
            }

            RefreshConnectionDB();
            GetData();
            ReadNodeSettings(); // ������ �������� �� ������ �������� ��� ����������� � propertyGrid1

            //������ �����������
            this.textBoxSqlServerConnectionString.DataBindings.Add(new Binding("Text", sqlServerConnectionProperty, "ConnectionString", false, DataSourceUpdateMode.OnPropertyChanged));
            sqlServerConnectionProperty.PropertyChanged += SqlServerConnectionProperty_PropertyChanged;

            this.ReadyThred_RefreshFiltredRecs += RefreshFiltredRecs;
            this.ReadyThred_RefreshLogRecs += RefreshLogRecs;
            this.ReadyThred_RefreshStatRecs += RefreshStatRecs;
            this.ReadyThred_RefreshArchStatRecs += RefreshArchStatRecs;

            this.numericUpDown_LogRecInterval.DataBindings.Add(new Binding("Value", taskProperty_LogRecords, "Interval", false, DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_AutoRefreshLog.DataBindings.Add(new Binding("Checked", taskProperty_LogRecords, "AvtoUpdate", false, DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown_LogRecReturnRecCount.DataBindings.Add(new Binding("Value", taskProperty_LogRecords, "ReturnRecCount", false, DataSourceUpdateMode.OnPropertyChanged));
            taskProperty_LogRecords.PropertyChanged += TaskProperty_LogRecords_PropertyChange;


            this.numericUpDown_FiltredRecInterval.DataBindings.Add(new Binding("Value", taskProperty_FiltredRecs, "Interval", false, DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_AutoRefreshFilter.DataBindings.Add(new Binding("Checked", taskProperty_FiltredRecs, "AvtoUpdate", false, DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown_FiltredRecReturnRecCount.DataBindings.Add(new Binding("Value", taskProperty_FiltredRecs, "ReturnRecCount", false, DataSourceUpdateMode.OnPropertyChanged));
            taskProperty_FiltredRecs.PropertyChanged += TaskProperty_FiltredRecs_PropertyChange;


            this.numericUpDown_IntervalTaskStat.DataBindings.Add(new Binding("Value", taskProperty_TaskRecords, "Interval", false, DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_AutoRefreshTaskStat.DataBindings.Add(new Binding("Checked", taskProperty_TaskRecords, "AvtoUpdate", false, DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown_TaskStatReturnRecCount.DataBindings.Add(new Binding("Value", taskProperty_TaskRecords, "ReturnRecCount", false, DataSourceUpdateMode.OnPropertyChanged));
            taskProperty_TaskRecords.PropertyChanged += TaskProperty_TaskRecords_PropertyChange;

            this.numericUpDown_IntervalArchStat.DataBindings.Add(new Binding("Value", taskProperty_ArchiveStat, "Interval", false, DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_AutoRefreshArchStat.DataBindings.Add(new Binding("Checked", taskProperty_ArchiveStat, "AvtoUpdate", false, DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown_ArchStatReturnRecCount.DataBindings.Add(new Binding("Value", taskProperty_ArchiveStat, "ReturnRecCount", false, DataSourceUpdateMode.OnPropertyChanged));
            taskProperty_ArchiveStat.PropertyChanged += TaskProperty_ArchiveStat_PropertyChange;


            this.textBox_IPAdr.DataBindings.Add(new Binding("Text", socketConnectionProperty, "IPAddress", false, DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown_Port.DataBindings.Add(new Binding("Value", socketConnectionProperty, "Port", false, DataSourceUpdateMode.OnPropertyChanged));
            socketConnectionProperty.PropertyChanged += SocketConnectionProperty_PropertyChange;

            #region ��������� ����������
            this.timer2.Interval = taskProperty_LogRecords.Interval;
            if (!taskProperty_LogRecords.AvtoUpdate)
                this.timer2.Stop();
            else
                this.timer2.Start();

            this.timer1.Interval = taskProperty_FiltredRecs.Interval;
            if (!taskProperty_FiltredRecs.AvtoUpdate)
                this.timer1.Stop();
            else
                this.timer1.Start();

            this.timer3.Interval = taskProperty_TaskRecords.Interval;
            if (!taskProperty_TaskRecords.AvtoUpdate)
                this.timer3.Stop();
            else
                this.timer3.Start();

            this.timer4.Interval = taskProperty_ArchiveStat.Interval;
            if (!taskProperty_ArchiveStat.AvtoUpdate)
                this.timer4.Stop();
            else
                this.timer4.Start();

            this.timer5.Start();

            #endregion ��������� ����������

            //�������������� �������� ��� ���������� �����
            InitTaskStat();
            //�������������� �������� ��� ���������� �������������
            InitArchiveStat();
        }


        /// <summary>
        /// ������ ��������� �� ������ ��������
        /// </summary>
        private void Filters_SaveItem_Click(object? sender, EventArgs e)
        {
            try
            {
                masterBindingSource.EndEdit();
                detailsBindingSource.EndEdit();
                //


                adFilters.Update(dsFilters.Tables["tbFilters"]);
                adFilterSettings.Update(dsFilters.Tables["tbFilterSettings"]);
                dsFilters.AcceptChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show("������ ���������� �������: " + ex.Message, "���������� �������� �������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Filters_RefreshItem_Click(object? sender, EventArgs e)
        {
            GetData();
        }

        /// <summary>
        /// �������. �������� ������ 
        /// </summary>
        private void Filters_AddItem_Click(object? sender, EventArgs e)
        {
            FilterDetail form = new FilterDetail();
            //masterBindingSource.AddNew();
            form.EditDetail(masterBindingSource, detailsBindingSource);
            form.Icon = this.Icon;
            DialogResult res = form.ShowDialog();

            if (res == DialogResult.OK)
            {
                try
                {
                    masterBindingSource.EndEdit();
                    detailsBindingSource.EndEdit();
                    adFilters.Update(dsFilters.Tables["tbFilters"]);
                    adFilterSettings.Update(dsFilters.Tables["tbFilterSettings"]);
                    dsFilters.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("������ ���������� �������: " + ex.Message, "���������� �������� �������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                masterBindingSource.CancelEdit();
                masterBindingSource.CancelEdit();
            }
        }

        private void Filters_EditItem_Click(object? sender, EventArgs e)
        {
            FilterDetail form = new FilterDetail();
            form.EditDetail(masterBindingSource, detailsBindingSource);
            form.Icon = this.Icon;
            form.Text = "��������� �������";
            DialogResult res = form.ShowDialog();

            if (res == DialogResult.OK)
            {
                try
                {
                    masterBindingSource.EndEdit();
                    detailsBindingSource.EndEdit();
                    adFilters.Update(dsFilters.Tables["tbFilters"]);
                    adFilterSettings.Update(dsFilters.Tables["tbFilterSettings"]);
                    dsFilters.AcceptChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("������ ���������� �������: " + ex.Message, "���������� �������� �������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                masterBindingSource.CancelEdit();
                masterBindingSource.CancelEdit();
            }

        }


        private void btnStopThread_Click(object sender, EventArgs e)
        {
            if (rt == null) return;
            rt.readText = false;
            RetryCount = 0;
        }

        private void btnSendCoomandToThread_Click(object sender, EventArgs e)
        {
            if (rt == null) return;
            rt.CommandText = this.textBox_Command.Text;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (SqlConnection sqlConn in sqlConnections)
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                    sqlConn.Close();
            }
        }


        #region ������� �������� ��������
        private void TaskProperty_ArchiveStat_PropertyChange(object? sender, EventArgs e)
        {
            this.timer4.Interval = taskProperty_ArchiveStat.Interval;
            if (!taskProperty_ArchiveStat.AvtoUpdate)
                this.timer4.Stop();
            else
                this.timer4.Start();
            //��������� ������ json 
            string jsonString = JsonSerializer.Serialize(taskProperty_ArchiveStat);
            //��������� ���������
            AddOrUpdateAppSettings("ArchiveStat", jsonString);
        }

        private void TaskProperty_TaskRecords_PropertyChange(object? sender, EventArgs e)
        {
            this.timer3.Interval = taskProperty_TaskRecords.Interval;
            if (!taskProperty_TaskRecords.AvtoUpdate)
                this.timer3.Stop();
            else
                this.timer3.Start();

            //��������� ������ json 
            string jsonString = JsonSerializer.Serialize(taskProperty_TaskRecords);
            //��������� ���������
            AddOrUpdateAppSettings("TaskRecords", jsonString);
        }

        private void TaskProperty_FiltredRecs_PropertyChange(object? sender, EventArgs e)
        {
            this.timer1.Interval = taskProperty_FiltredRecs.Interval;
            if (!taskProperty_FiltredRecs.AvtoUpdate)
                this.timer1.Stop();
            else
                this.timer1.Start();

            //��������� ������ json 
            string jsonString = JsonSerializer.Serialize(taskProperty_FiltredRecs);
            //��������� ���������
            AddOrUpdateAppSettings("FiltredRecs", jsonString);
        }

        private void TaskProperty_LogRecords_PropertyChange(object? sender, EventArgs e)
        {
            this.timer2.Interval = taskProperty_LogRecords.Interval;
            if (!taskProperty_LogRecords.AvtoUpdate)
                this.timer2.Stop();
            else
                this.timer2.Start();

            //��������� ������ json 
            string jsonString = JsonSerializer.Serialize(taskProperty_LogRecords);
            //��������� ���������
            AddOrUpdateAppSettings("LogRecords", jsonString);
        }

        /// <summary>
        /// �������� �������� ����������� � RT
        /// </summary>
        private void SocketConnectionProperty_PropertyChange(object? sender, EventArgs e)
        {
            //��������� ������ json 
            string jsonString = JsonSerializer.Serialize(socketConnectionProperty);
            //��������� ���������
            AddOrUpdateAppSettings("SocketConnectionProperty", jsonString);
        }
        #endregion ������� �������� ��������

        /// <summary>
        /// ����������� � ��
        /// </summary>
        private void RefreshConnectionDB()
        {

            buttonRefreshConnection.Image = imageListSqlServerConnection.Images[2];
            toolTip1.SetToolTip(this.buttonRefreshConnection, "����������� � ���� ������ �� �����������");

            if (cnnPrimary != null)
            {
                if (cnnPrimary.State == System.Data.ConnectionState.Open)
                    cnnPrimary.Close();
            }


            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection csSection = config.ConnectionStrings;
            if (csSection.ConnectionStrings["cnnPrimary"] != null)
            {
                sqlServerConnectionProperty.ConnectionString = csSection.ConnectionStrings["cnnPrimary"].ConnectionString;

            }
            //���������� � ��
            try
            {
                cnnPrimary = new SqlConnection(sqlServerConnectionProperty.ConnectionString);
                cnnPrimary.Open();

                if (cnnPrimary.State == System.Data.ConnectionState.Open)
                {
                    sqlConnections.Add(cnnPrimary);
                    buttonRefreshConnection.Image = imageListSqlServerConnection.Images[1];
                    toolTip1.SetToolTip(this.buttonRefreshConnection, "����������� ����������� � ���� ������: " + cnnPrimary.Database);

                    CheckRT.db_object.db_object.MakeDataBaseObject(cnnPrimary);
                }
            }
            catch (Exception ex)
            {
                string sError = "������ ��������� ����������� � ��: " + ex.Message;
                textBoxSqlServerError.Text = sError;
                MessageBox.Show(sError, "��������� ����������� 'RefreshConnectionDB'", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonRefreshConnection.Image = imageListSqlServerConnection.Images[2];
                toolTip1.SetToolTip(this.buttonRefreshConnection, "������ ����������� � ���� ������: " + ex.Message);
                return;
            }
        }

        private void SqlServerConnectionProperty_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            AddOrUpdateConnectionString("cnnPrimary", sqlServerConnectionProperty.ConnectionString);
            buttonRefreshConnection.Image = imageListSqlServerConnection.Images[0];
            toolTip1.SetToolTip(this.buttonRefreshConnection, "���������� ��������� �������� �����������");
        }

        /// <summary>
        /// ��������� ������� ��������� ������ �� ������������� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void Rt_Changed(object? sender, EventArgs e)
        {
            var result = rt.Status;
            TempBuffer = TempBuffer + result;

            //if (!checkBox_Pause.Checked)
            //{
            //    //if (checkBox_AutoRefreshMonitor.Checked)
            //    this.tbStatus.BeginInvoke((MethodInvoker)(() => this.tbStatus.AppendText(result)));
            //}
            //else
            //{
            //    TempBuffer = TempBuffer + result;
            //}

        }

        private void RunQuerySocket()
        {
            if (cnnPrimary.State != ConnectionState.Open) return;

            if (rt == null)
            {
                rt = new CheckRT.ThredClasses.RTThreadWork(socketConnectionProperty.IPAddress, socketConnectionProperty.Port);
                rt.Changed += Rt_Changed;
                rt.BreakConnection += Rt_BreakConnection;

                SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
                sqlConnectionStringBuilder.ConnectionString = cnnPrimary.ConnectionString;
                sqlConnectionStringBuilder.ApplicationName = "CheckRT_QuerySocket";

                SqlConnection sqlConnection = new(sqlConnectionStringBuilder.ConnectionString);

                try
                {
                    sqlConnection.Open();
                    rt.sqlConnection = sqlConnection;
                    sqlConnections.Add(sqlConnection);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("������ ����������� � �� ����������� Log: " + ex.Message, "������ ����������� � RT RunQuerySocket", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            Debug.WriteLine("��������� �������...");

            rt.ip = socketConnectionProperty.IPAddress;
            rt.port = socketConnectionProperty.Port;

            rt.readText = true;
            Thread thread1 = new(rt.ConnectRT);
            thread1.Start();
            rt.ManagedThreadId = thread1.ManagedThreadId;
        }

        /// <summary>
        /// ������� ������� � �� � �������� �� ����������� ������ � ��������� �����
        /// </summary>
        private void btnConnectThread_Click(object sender, EventArgs e)
        {
            if (rt != null)
            {
                rt.readText = false;
            }
            //��������� ���������� ���������� ���� ��� ������ �����, ����������� �� ������
            timer5.Start();

            RefreshConnectionDB();
            RunQuerySocket();
            ClearDataLogRecords();
            GetDataLogRecords();

            InitTaskStat();
            InitArchiveStat();

        }

        /// <summary>
        /// ��������� ������� ������� ���������� � �������
        /// </summary>
        private void Rt_BreakConnection(object? sender, EventArgs e)
        {
            if (rt != null && RetryCount < 100 && rt.readText == true)
            {
                Thread.Sleep(10);
                RetryCount++;
                this.tbStatus.BeginInvoke((MethodInvoker)(() => this.tbStatus.AppendText($"������� ���������� ����������� � ������ RT: {RetryCount}" + Environment.NewLine)));
                RunQuerySocket();
            }
        }



        private void buttonRefreshConnection_Click(object sender, EventArgs e)
        {
            this.RefreshConnectionDB();
        }

        /// <summary>
        /// �������� ���� ������� �� �������, ��� �������������� ������, ���������� �� ������
        /// </summary>
        private void ClearDataLogRecords()
        {
            if (cnnPrimary.State != ConnectionState.Open) return;

            using (SqlCommand cmm = new()
            {
                Connection = cnnPrimary,
                CommandTimeout = 180,
                CommandType = CommandType.Text,
                CommandText = "delete from [dbo].[tbLogRecords] where (port = @port and ip_address = @ip_address) or (port = 0 and ip_address = '127.0.0.1')"
            }
            )
            {
                cmm.Parameters.AddWithValue("@port", rt.port);
                cmm.Parameters.AddWithValue("@ip_address", rt.ip);
                cmm.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// �������. ������������ ����������� ��� ������ � ���������
        /// </summary>
        private void GetData()
        {
            if (cnnPrimary.State != System.Data.ConnectionState.Open) return;

            //������� � ��
            SqlCommand selectCommand = new()
            {
                Connection = cnnPrimary,
                CommandType = System.Data.CommandType.Text,
                CommandText = "select * from [dbo].[tbFilters]"
            };

            SqlCommand updateCommand = new()
            {
                Connection = cnnPrimary,
                CommandType = System.Data.CommandType.Text,
                CommandText = "update [dbo].[tbFilters] set FilterName = @FilterName, Descr = @Descr, Active = @Active where id_filter = @id_filter"
            };
            updateCommand.Parameters.Add(new SqlParameter("@FilterName", SqlDbType.VarChar, 500, "FilterName"));
            updateCommand.Parameters.Add(new SqlParameter("@Descr", SqlDbType.NVarChar, 4000, "Descr"));
            updateCommand.Parameters.Add(new SqlParameter("@Active", SqlDbType.Bit, 1, "Active"));
            updateCommand.Parameters.Add(new SqlParameter("@id_filter", SqlDbType.Int, 4, "id_filter"));

            SqlCommand insertCommand = new()
            {
                Connection = cnnPrimary,
                CommandType = System.Data.CommandType.Text,
                CommandText = "insert into [dbo].[tbFilters] (FilterName, Descr) select @FilterName, @Descr; select @id_filter = SCOPE_IDENTITY()"
            };
            insertCommand.Parameters.Add(new SqlParameter("@FilterName", SqlDbType.VarChar, 500, "FilterName"));
            insertCommand.Parameters.Add(new SqlParameter("@Descr", SqlDbType.NVarChar, 4000, "Descr"));
            insertCommand.Parameters.Add(new SqlParameter("@Active", SqlDbType.Bit, 1, "Active"));

            SqlParameter id_filterParameter = new();
            id_filterParameter.Direction = ParameterDirection.Output;
            id_filterParameter.ParameterName = "@id_filter";
            id_filterParameter.DbType = DbType.Int32;
            id_filterParameter.SourceColumn = "id_filter";
            insertCommand.Parameters.Add((SqlParameter)id_filterParameter);

            SqlCommand deleteCommand = new()
            {
                Connection = cnnPrimary,
                CommandType = System.Data.CommandType.Text,
                CommandText = "delete from [dbo].[tbFilters] where id_filter = @id_filter"
            };
            deleteCommand.Parameters.Add(new SqlParameter("@id_filter", SqlDbType.Int, 4, "id_filter"));

            adFilters = new SqlDataAdapter
            {
                SelectCommand = selectCommand,
                UpdateCommand = updateCommand,
                InsertCommand = insertCommand,
                DeleteCommand = deleteCommand
            };

            dsFilters = new DataSet();
            adFilters.Fill(dsFilters, "tbFilters"); //��������� DataSet

            DataColumn idCln = dsFilters.Tables["tbFilters"].Columns["id_filter"];
            idCln.Unique = true;
            idCln.AutoIncrement = true;
            idCln.AutoIncrementSeed = -1;
            idCln.AutoIncrementStep = -1;
            idCln.ReadOnly = true;


            SqlCommand selectCommand1 = new()
            {
                Connection = cnnPrimary,
                CommandType = System.Data.CommandType.Text,
                CommandText = "select id_rec, id_filter, FilterString, Active, UsingFreeText from [dbo].[tbFilterSettings]"
            };
            SqlCommand insertCommand1 = new()
            {
                Connection = cnnPrimary,
                CommandType = System.Data.CommandType.Text,
                CommandText = "insert into [dbo].[tbFilterSettings] (id_filter, FilterString, Active, UsingFreeText) select @id_filter, @FilterString, @Active, isnull(@UsingFreeText,0); select @id_rec = SCOPE_IDENTITY()",
            };
            insertCommand1.Parameters.Add(new SqlParameter("@id_filter", SqlDbType.Int, 4, "id_filter"));
            insertCommand1.Parameters.Add(new SqlParameter("@FilterString", SqlDbType.VarChar, 2000, "FilterString"));
            insertCommand1.Parameters.Add(new SqlParameter("@Active", SqlDbType.Bit, 1, "Active"));
            insertCommand1.Parameters.Add(new SqlParameter("@UsingFreeText", SqlDbType.TinyInt, 1, "UsingFreeText"));

            SqlParameter id_recParameter = new();
            id_recParameter.Direction = ParameterDirection.Output;
            id_recParameter.ParameterName = "@id_rec";
            id_recParameter.DbType = DbType.Int32;
            id_recParameter.SourceColumn = "id_rec";
            insertCommand1.Parameters.Add((SqlParameter)id_recParameter);


            SqlCommand updateCommand1 = new()
            {
                Connection = cnnPrimary,
                CommandType = System.Data.CommandType.Text,
                CommandText = "update [dbo].[tbFilterSettings] set id_filter = @id_filter, FilterString = @FilterString, Active = @Active, UsingFreeText = @UsingFreeText where id_rec = @id_rec"
            };
            updateCommand1.Parameters.Add(new SqlParameter("@id_filter", SqlDbType.Int, 4, "id_filter"));
            updateCommand1.Parameters.Add(new SqlParameter("@FilterString", SqlDbType.VarChar, 2000, "FilterString"));
            updateCommand1.Parameters.Add(new SqlParameter("@Active", SqlDbType.Bit, 1, "Active"));
            updateCommand1.Parameters.Add(new SqlParameter("@UsingFreeText", SqlDbType.TinyInt, 1, "UsingFreeText"));
            updateCommand1.Parameters.Add(new SqlParameter("@id_rec", SqlDbType.Int, 4, "id_rec"));

            SqlCommand deleteCommand1 = new()
            {
                Connection = cnnPrimary,
                CommandType = System.Data.CommandType.Text,
                CommandText = "delete from [dbo].[tbFilterSettings] where id_rec = @id_rec"
            };
            deleteCommand1.Parameters.Add(new SqlParameter("@id_rec", SqlDbType.Int, 4, "id_rec"));

            adFilterSettings = new SqlDataAdapter()
            {
                SelectCommand = selectCommand1,
                InsertCommand = insertCommand1,
                UpdateCommand = updateCommand1,
                DeleteCommand = deleteCommand1
            };
            adFilterSettings.Fill(dsFilters, "tbFilterSettings");

            DataColumn idClnP = dsFilters.Tables["tbFilterSettings"].Columns["id_filter"];
            idClnP.ReadOnly = true;

            DataColumn idClnS = dsFilters.Tables["tbFilterSettings"].Columns["id_rec"];
            idClnS.Unique = true;
            idClnS.AutoIncrement = true;
            idClnS.AutoIncrementSeed = -1;
            idClnS.AutoIncrementStep = -1;
            idClnS.ReadOnly = true;


            //��������� ��������� ����� ���������
            dsFilters.Relations.Add("Relation_tbFilterSettings_tbFilters", dsFilters.Tables["tbFilters"].Columns["id_filter"], dsFilters.Tables["tbFilterSettings"].Columns["id_filter"], false);

            ForeignKeyConstraint foreignKey = new ForeignKeyConstraint(dsFilters.Tables["tbFilters"].Columns["id_filter"], dsFilters.Tables["tbFilterSettings"].Columns["id_filter"])
            {
                ConstraintName = "FilterSettingsForeignKey",
                DeleteRule = Rule.Cascade,
                UpdateRule = Rule.Cascade
            };
            foreignKey.AcceptRejectRule = AcceptRejectRule.Cascade;

            dsFilters.Tables["tbFilterSettings"].Constraints.Add(foreignKey);
            dsFilters.EnforceConstraints = true;

            masterBindingSource = new BindingSource
            {
                DataSource = dsFilters,
                DataMember = "tbFilters"
            };

            detailsBindingSource = new BindingSource
            {
                DataSource = masterBindingSource,
                DataMember = "Relation_tbFilterSettings_tbFilters"
            };

            //���������� � �������� ����
            dataGridViewFilters.DataSource = masterBindingSource;
            masterNavigator.BindingSource = masterBindingSource;

            #region ������������� ������ ������� � ���������
            dataGridViewFilters.Columns[0].Width = 50;
            dataGridViewFilters.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewFilters.Columns[2].Width = 200;
            dataGridViewFilters.Columns[3].Width = 75;
            //���������
            dataGridViewFilters.Columns[0].HeaderText = "Id";
            dataGridViewFilters.Columns[1].HeaderText = "������������ �������";
            dataGridViewFilters.Columns[2].HeaderText = "��������";
            dataGridViewFilters.Columns[3].HeaderText = "����������";
            #endregion



        }

        private void GetDataLogRecords()
        {

            if (cnnPrimary.State != ConnectionState.Open) return;

            this.button_RefreshLogRecords.BeginInvoke((MethodInvoker)(() => this.button_RefreshLogRecords.Enabled = false));

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.ConnectionString = cnnPrimary.ConnectionString;
            sqlConnectionStringBuilder.ApplicationName = "CheckRT_GetLogRecords";
            SqlConnection sqlConnection = new(sqlConnectionStringBuilder.ConnectionString);
            sqlConnections.Add(sqlConnection);

            try
            {

                SqlCommand selectCommand = new()
                {
                    Connection = sqlConnection,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "select top(@rec_count) * from (select top(@rec_count) * from [tbLogRecords] " +
                    "where (port = @port and ip_address = @ip_address) " +
                    "or (port = 0 and ip_address = '127.0.0.1') order by id_rec desc) as rep order by id_rec asc"
                };
                selectCommand.Parameters.AddWithValue("@rec_count", taskProperty_LogRecords.ReturnRecCount);
                selectCommand.Parameters.AddWithValue("@port", socketConnectionProperty.Port);
                selectCommand.Parameters.AddWithValue("@ip_address", socketConnectionProperty.IPAddress);

                SqlCommand insertCommand = new()
                {
                    Connection = sqlConnection,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "insert into [dbo].[tbLogRecords] (id_rec, RegDT, LogString) select @id_rec, @RegDT, @LogString"
                };
                insertCommand.Parameters.Add(new SqlParameter("@id_rec", SqlDbType.Int, 4, "id_rec"));
                insertCommand.Parameters.Add(new SqlParameter("@RegDT", SqlDbType.DateTime, 4, "RegDT"));
                insertCommand.Parameters.Add(new SqlParameter("@LogString", SqlDbType.NVarChar, 4000, "LogString"));

                SqlCommand updateCommand = new()
                {
                    Connection = sqlConnection,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "update [dbo].[tbLogRecords] set id_rec = @id_rec, RegDT = @RegDT, LogString = @LogString where id_rec = @id_rec"
                };
                updateCommand.Parameters.Add(new SqlParameter("@id_rec", SqlDbType.Int, 4, "id_rec"));
                updateCommand.Parameters.Add(new SqlParameter("@RegDT", SqlDbType.DateTime, 4, "RegDT"));
                updateCommand.Parameters.Add(new SqlParameter("@LogString", SqlDbType.NVarChar, 4000, "LogString"));

                SqlCommand deleteCommand = new()
                {
                    Connection = sqlConnection,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "delete from [dbo].[tbLogRecords] where id_rec = @id_rec"
                };
                deleteCommand.Parameters.Add(new SqlParameter("@id_rec", SqlDbType.Int, 4, "id_rec"));


                using (SqlDataAdapter adLogRecords = new()
                {
                    SelectCommand = selectCommand,
                    InsertCommand = insertCommand,
                    UpdateCommand = updateCommand,
                    DeleteCommand = deleteCommand
                })
                {
                    DataSet dsLogRecords = new();

                    if (dsLogRecords.Tables["tbLogRecords"] != null)
                        dsLogRecords.Tables.Remove("tbLogRecords");
                    adLogRecords.Fill(dsLogRecords, "tbLogRecords");

                    BindingSource logBindingSource = new()
                    {
                        DataSource = dsLogRecords,
                        DataMember = "tbLogRecords"
                    };
                    logBindingSource.MoveLast();

                    this.dataGridViewLogRecords.BeginInvoke((MethodInvoker)(() => this.dataGridViewLogRecords.DataSource = logBindingSource));
                    this.dataGridViewLogRecords.BeginInvoke((MethodInvoker)(() => this.dataGridViewLogRecords.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells));

                    ReadyThred_RefreshLogRecs(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("������ ��� ������ ������� �������: " + ex.Message, "��������� ������ GetDataLogRecords", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.button_RefreshLogRecords.BeginInvoke((MethodInvoker)(() => this.button_RefreshLogRecords.Enabled = true));
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
                GC.Collect();
            }
        }

        private void GetDataFiltredRecords()
        {
            if (cnnPrimary.State != ConnectionState.Open) return;

            //��������� ������ ���������� �� ����������
            this.btnRefreshFiltredRecords.BeginInvoke((MethodInvoker)(() => this.btnRefreshFiltredRecords.Enabled = false));

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.ConnectionString = cnnPrimary.ConnectionString;
            sqlConnectionStringBuilder.ApplicationName = "CheckRT_GetFiltredRecords";
            SqlConnection sqlConnection = new(sqlConnectionStringBuilder.ConnectionString);
            sqlConnections.Add(sqlConnection);

            SqlCommand selectCommand = new()
            {
                Connection = sqlConnection,
                CommandTimeout = 180,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "[dbo].[get_filtred_recs]"
            };
            selectCommand.Parameters.AddWithValue("@rec_count", taskProperty_FiltredRecs.ReturnRecCount);
            selectCommand.Parameters.AddWithValue("@port", socketConnectionProperty.Port);
            selectCommand.Parameters.AddWithValue("@ip_address", socketConnectionProperty.IPAddress);


            SqlDataAdapter adFiltredRecords = new()
            {
                SelectCommand = selectCommand
            };

            try
            {
                DataSet ds = new();

                if (ds.Tables["tbFiltredRecords"] != null)
                    ds.Tables.Remove("tbFiltredRecords");
                adFiltredRecords.Fill(ds, "tbFiltredRecords");

                BindingSource filtredBindingSource = new()
                {
                    DataSource = ds,
                    DataMember = "tbFiltredRecords"
                };
                filtredBindingSource.MoveLast();

                this.dataGridViewFiltredRecords.BeginInvoke((MethodInvoker)(() => this.dataGridViewFiltredRecords.DataSource = filtredBindingSource));
                this.dataGridViewFiltredRecords.BeginInvoke((MethodInvoker)(() => this.dataGridViewFiltredRecords.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells));

                ReadyThred_RefreshFiltredRecs(this, new EventArgs());

            }
            catch (Exception ex)
            {
                MessageBox.Show("������ ��� ������ ������� �� �������: " + ex.Message, "��������� �������������� ������ GetDataFiltredRecords", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.btnRefreshFiltredRecords.BeginInvoke((MethodInvoker)(() => this.btnRefreshFiltredRecords.Enabled = true));
                RefreshFiltredRecsIsFree = true; //���� ������, �� ��������� ����� ������, � �������, ��� ������� ����� �����������
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }
        }

        private void InitTaskStat()
        {
            if (cnnPrimary.State != ConnectionState.Open) return;

            dsTaskStatistic = new("dsTaskStatistic");
            //���������� ������ �������
            tbTaskPrimary = new("tbTaskPrimary");
            //���������� ����� �������� � ����������
            tbTaskStat = new("tbTaskStat");
            //���������� ����� ��������
            tbTaskStatDetailU = new("tbTaskStatDetailU");
            tbTaskMemory = new("tbTaskMemory");
            tbMemoryStat = new("tbMemoryStat");

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.ConnectionString = cnnPrimary.ConnectionString;
            sqlConnectionStringBuilder.ApplicationName = "CheckRT_GetTaskStat";
            SqlConnection sqlConnection = new(sqlConnectionStringBuilder.ConnectionString);
            sqlConnections.Add(sqlConnection);

            #region ������� � ��
            SqlCommand selectCommand = new()
            {
                Connection = sqlConnection,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "[dbo].[get_task_recs]"
            };
            selectCommand.Parameters.AddWithValue("@port", socketConnectionProperty.Port);
            selectCommand.Parameters.AddWithValue("@ip_address", socketConnectionProperty.IPAddress);
            #endregion ������� � ��

            adTaskStatistic.SelectCommand = selectCommand;

            #region ������ ��������� ������/ ������������ ��������� ��� ���������� � ���������� �����

            //���������� ������ ������� tbTaskPrimary
            DataColumn pcl0 = new("id_rec", typeof(Int32));
            tbTaskPrimary.Columns.Add(pcl0);

            DataColumn pcl1 = new("TaskCicle", typeof(string)); //M - ������, S - ����� 
            tbTaskPrimary.Columns.Add(pcl1);

            DataColumn pcl2 = new("Date", typeof(string));
            tbTaskPrimary.Columns.Add(pcl2);

            DataColumn pcl3 = new("Time", typeof(string));
            tbTaskPrimary.Columns.Add(pcl3);

            DataColumn pcl4 = new("N", typeof(string));//N - ���������� ������������ �������� UDP (�� ����������� ��������� �����, ������� ��������� � N2). � ������� ����������� - <������������ ����� ��������� �������, N ������� ��������� �� ������� ���� ����� ������ ���������>
            tbTaskPrimary.Columns.Add(pcl4);

            DataColumn pcl5 = new("N2", typeof(string)); //N2 - ���������� ������������ �������� UDP, ������� ������������ ��� �������������� �� ������ ���������� ��� ������� �������� ��� ��������� ����� /udp2, � ����� ��� ������������� ������� (������ ������� �������������� � ��������� ������)
            tbTaskPrimary.Columns.Add(pcl5);

            DataColumn pcl6 = new DataColumn("ModbusRTUSlave", typeof(string)); //M =< ��� - �� ������������ ��������> -� ������ Modbus RTU Slave ������
            tbTaskPrimary.Columns.Add(pcl6);

            DataColumn pcl7 = new("A", typeof(string)); //A =< ���������� ������������ �������� �� HMI �������� >
            tbTaskPrimary.Columns.Add(pcl7);

            DataColumn pcl8 = new("O", typeof(string)); //O<������ �����������>=<���-�� ������>(<����� ���������� ����� ������>,<����� ���-�� ������>) - ���������� ������ ���������� ����� (��� ����� � ������ ������������ ��������� ������).
            tbTaskPrimary.Columns.Add(pcl8);

            DataColumn pcl9 = new("HR", typeof(string)); //HR=<���-�� ���������� �������� ��������>(<�����, ����������� �� ��������� ����������>)
            tbTaskPrimary.Columns.Add(pcl9);

            DataColumn pcl10 = new("R", typeof(string)); //R =<���-�� ������ ������ ��������������>(<����� ���������� �����>,<����� ��������� ������������� ������>,<���� ����� ������ �� ������� �����������>,<���-�� ��������� �������>). � ������ SLAVE �� ������ ����� ����������� �������� ��������� ������� �����������, � ����� ��������� ������, ���� � �������� ��������� ������ �������� ������ ������. � ����� ������� ����� ������������� ����� 20��
            tbTaskPrimary.Columns.Add(pcl10);

            DataColumn pcl11 = new("MemoryUsing", typeof(string)); //M=<������������ ����� ������ ���������>Kb
            tbTaskPrimary.Columns.Add(pcl11);

            dsTaskStatistic.Tables.Add(tbTaskPrimary);

            //���������� ����� �������� � ���������� tbTaskStatDetailU
            DataColumn scl0 = new("id_rec", typeof(Int32));
            tbTaskStat.Columns.Add(scl0);

            DataColumn scl1 = new("RegDT", typeof(DateTime));
            tbTaskStat.Columns.Add(scl1);

            DataColumn scl2 = new("LogString", typeof(string));
            tbTaskStat.Columns.Add(scl2);

            dsTaskStatistic.Tables.Add(tbTaskStat);

            #region ���������� ����� �������� tbTaskStatDetailU
            DataColumn ucl0 = new("id_rec", typeof(Int32));
            tbTaskStatDetailU.Columns.Add(ucl0);

            DataColumn ucl1 = new("TaskIndex", typeof(string));
            tbTaskStatDetailU.Columns.Add(ucl1);

            DataColumn ucl2 = new("CicleCount", typeof(string));
            tbTaskStatDetailU.Columns.Add(ucl2);

            DataColumn ucl3 = new("ErrCount", typeof(string));
            tbTaskStatDetailU.Columns.Add(ucl3);

            DataColumn ucl4 = new("AvgCicle", typeof(string));
            tbTaskStatDetailU.Columns.Add(ucl4);

            DataColumn ucl5 = new("MinCicle", typeof(string));
            tbTaskStatDetailU.Columns.Add(ucl5);

            DataColumn ucl6 = new("MaxCicle", typeof(string));
            tbTaskStatDetailU.Columns.Add(ucl6);

            DataColumn ucl7 = new("AvgCicleReal", typeof(string));
            tbTaskStatDetailU.Columns.Add(ucl7);

            DataColumn ucl8 = new("MinCicleReal", typeof(string));
            tbTaskStatDetailU.Columns.Add(ucl8);

            DataColumn ucl9 = new("MaxCicleReal", typeof(string));
            tbTaskStatDetailU.Columns.Add(ucl9);

            DataColumn ucl10 = new("TimeRead", typeof(string));
            tbTaskStatDetailU.Columns.Add(ucl10);

            DataColumn ucl11 = new("TimeWork", typeof(string));
            tbTaskStatDetailU.Columns.Add(ucl11);

            DataColumn ucl12 = new("TimeWrite", typeof(string));
            tbTaskStatDetailU.Columns.Add(ucl12);

            DataColumn ucl13 = new("Mem", typeof(string));
            tbTaskStatDetailU.Columns.Add(ucl13);

            dsTaskStatistic.Tables.Add(tbTaskStatDetailU);
            #endregion


            DataColumn mcl0 = new("dateTime", typeof(DateTime));
            tbTaskMemory.Columns.Add(mcl0);

            DataColumn mcl1 = new("mem", typeof(double));
            tbTaskMemory.Columns.Add(mcl1);

            dsTaskStatistic.Tables.Add(tbTaskMemory);


            #region ������� ��� ���������� ������ ��� ����� ���������� � �������� tbMemoryStat
            DataColumn dateValue = new DataColumn("dateValue", typeof(DateTime));
            tbMemoryStat.Columns.Add(dateValue);

            //��������� ������� ���������� ��������� ��� ������� ������ ����������, �� ���� �������������
            //DataColumn U0 = new DataColumn("U0", typeof(double));
            //tbMemoryStat.Columns.Add(U0);

            //DataColumn U1 = new DataColumn("U1", typeof(double));
            //tbMemoryStat.Columns.Add(U1);

            //DataColumn U2 = new DataColumn("U2", typeof(double));
            //tbMemoryStat.Columns.Add(U2);

            //DataColumn S0 = new DataColumn("S0", typeof(double));
            //tbMemoryStat.Columns.Add(S0);

            //DataColumn S1 = new DataColumn("S1", typeof(double));
            //tbMemoryStat.Columns.Add(S1);

            //DataColumn S2 = new DataColumn("S2", typeof(double));
            //tbMemoryStat.Columns.Add(S2);

            dsTaskStatistic.Tables.Add(tbMemoryStat);
            #endregion


            #endregion ������ ��������� ������

            bsTaskStatistic = new BindingSource
            {
                DataSource = dsTaskStatistic,
                DataMember = "tbTaskStat" //���� ����� ������, ������������ [dbo].[get_task_recs]
            };

            //��������� ��������� ����� ���������
            dsTaskStatistic.Relations.Add("Relation_tbTaskStat_tbTaskPrimary", dsTaskStatistic.Tables["tbTaskStat"].Columns["id_rec"], dsTaskStatistic.Tables["tbTaskPrimary"].Columns["id_rec"]); //�������� ������
            dsTaskStatistic.Relations.Add("Relation_tbTaskStat_tbTaskStatDetailU", dsTaskStatistic.Tables["tbTaskStat"].Columns["id_rec"], dsTaskStatistic.Tables["tbTaskStatDetailU"].Columns["id_rec"]); //���� � ���������


            bsTaskStatisticPrimary = new BindingSource
            {
                DataSource = bsTaskStatistic,
                DataMember = "Relation_tbTaskStat_tbTaskPrimary"
            };

            bsUTaskStatistic = new BindingSource
            {
                DataSource = bsTaskStatistic,
                DataMember = "Relation_tbTaskStat_tbTaskStatDetailU"
            };


            //���������� � �������� ���� ������ ����������                                              
            dataGridViewTaskStat.AutoGenerateColumns = false;
            dataGridViewTaskStat.DataSource = bsTaskStatistic;
            dataGridViewTaskStat.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTaskStat.Columns[1].DefaultCellStyle.Format = @"dd.MM.yy HH:mm:ss";

            //� ����������� 
            dataGridViewTaskPrimary.DataSource = bsTaskStatisticPrimary;

            //� � ������ ���������
            dataGridViewTaskStatDetailU.DataSource = bsUTaskStatistic;
            dataGridViewTaskStatDetailU.Columns[13].DefaultCellStyle.Format = @"#,##0";

        }


        /// <summary>
        /// ������ ���������� �� ��
        /// </summary>
        private void GetTaskStatData()
        {
            if (cnnPrimary.State != ConnectionState.Open) return;

            //��������� ������ ���������� �� ����������
            this.btnRefreshTaskStat.BeginInvoke((MethodInvoker)(() => this.btnRefreshTaskStat.Enabled = false));


            tbMemoryStat.Clear();
            tbTaskStatDetailU.Clear();
            tbTaskPrimary.Clear();
            tbTaskStat.Clear();


            try
            {

                adTaskStatistic.Fill(dsTaskStatistic, "tbTaskStat"); //��������� DataSet � ������� ����������

                foreach (DataRow rw in dsTaskStatistic.Tables["tbTaskStat"].Rows)
                {
                    string? sInfo = "";
                    if (rw["LogString"] != DBNull.Value)
                    {
                        sInfo = rw["LogString"].ToString();
                        if (sInfo.Length > 0)
                        {
                            int id_rec = Convert.ToInt32(rw["id_rec"]);
                            parce_stat(id_rec, sInfo);
                        }
                    }
                }


                //���������
                if (tbTaskMemory.Rows.Count > 0)
                    this.BeginInvoke((MethodInvoker)(() => this.SetChar1tDataSource()));

                if (tbMemoryStat.Rows.Count > 0)
                    this.BeginInvoke((MethodInvoker)(() => this.SetChar2tDataSource()));

                #region �� ������ 03/07/2024
                //CurrencyManager cm = (CurrencyManager)this.dataGridViewTaskStat.BindingContext[bsTaskStatistic];
                //if (cm != null)
                //{
                //    this.BeginInvoke((MethodInvoker)(() => cm.Refresh()));
                //    this.BeginInvoke((MethodInvoker)(() => bsTaskStatistic.MoveLast()));
                //}

                //CurrencyManager cm1 = (CurrencyManager)this.dataGridViewTaskPrimary.BindingContext[bsTaskStatisticPrimary];
                //if (cm1 != null)
                //{
                //    this.BeginInvoke((MethodInvoker)(() => cm1.Refresh()));
                //}

                //CurrencyManager cm2 = (CurrencyManager)this.dataGridViewTaskStatDetailU.BindingContext[bsUTaskStatistic];
                //if (cm2 != null)
                //{
                //    this.BeginInvoke((MethodInvoker)(() => cm2.Refresh()));
                //}
                #endregion

                #region ������ 03/07/2024
                this.BeginInvoke((MethodInvoker)(() => bsTaskStatistic.ResetBindings(false)));
                this.BeginInvoke((MethodInvoker)(() => bsTaskStatistic.MoveLast()));
                this.BeginInvoke((MethodInvoker)(() => bsTaskStatisticPrimary.ResetBindings(false)));
                this.BeginInvoke((MethodInvoker)(() => bsUTaskStatistic.ResetBindings(false)));
                #endregion


                //�������� � ���, ��� ������ ���������
                this.ReadyThred_RefreshStatRecs(this, new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show("������ ��� ������ ������� �� �������: " + ex.Message, "��������� �������������� ������ GetTaskStatData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.btnRefreshTaskStat.BeginInvoke((MethodInvoker)(() => this.btnRefreshTaskStat.Enabled = true));
            }
        }
        /// <summary>
        /// ������ ���������� ������ 
        /// </summary>
        /// <param name="id_rec"></param>
        /// <param name="sInfo"></param>
        private void parce_stat(int id_rec, string sInfo)
        {
            string[] words = sInfo.Split(' ');
            int rec_num = 0;
            int year = DateTime.UtcNow.Year;
            int month = DateTime.UtcNow.Month;
            int day = DateTime.UtcNow.Day;
            DateTime dateTime = new DateTime();

            DataRow rwtp = tbTaskPrimary.NewRow();
            rwtp[0] = id_rec;

            DataRow rwmem = tbMemoryStat.NewRow();

            //M30/05 21:22:52.789 N=0(0,0) N2=0 A=0 U0=28924,e0(108,100,111)(0,0,2)(,0,0,0)665Kb HR=1(0) M=29600Kb 
            //M29998179: 13/05 16:12:17.507 N=0(0,0) N2=0 A=24539 U0=117307,e0(108,100,113)(0,0,1)(,0,0,0)461Kb HR=1(1) M=30448Kb 
            bool oldFormat = false;

            if (words.Length > 0) //��������� ������ �� ������� ����
            {
                if ((words[0].Substring(0, 1) == "M" || words[0].Substring(0, 1) == "S")
                    && words[0].Length == 6 && words[0].Substring(3, 1) == "/") //������ ��� �����, 4-�� ������ "/" 
                {
                    oldFormat = true;
                }
            }

            try
            {
                foreach (string sCurrent in words)
                {
                    if (oldFormat) //1.3.5 � ������
                    {
                        if (rec_num == 0) //���� ������
                        {
                            rwtp[1] = sCurrent.Substring(0, 1);

                            string s = sCurrent.Replace("M", "").Replace("S", "");
                            string[] sDT = s.Split("/");
                            month = Convert.ToInt32(sDT[1]);
                            day = Convert.ToInt32(sDT[0]);

                            rwtp[2] = s;
                        }
                        if (rec_num == 1) //����� ������
                        {
                            DateTime t = Convert.ToDateTime(sCurrent);
                            dateTime = new DateTime(year, month, day, t.Hour, t.Minute, t.Second, t.Millisecond);
                            rwtp[3] = sCurrent;
                            rwmem["dateValue"] = dateTime;
                        }

                        if (rec_num == 2) //N - ���������� ������������ �������� UDP (�� ����������� ��������� �����, ������� ��������� � N2).
                                          //� ������� ����������� - <������������ ����� ��������� �������, N ������� ��������� �� ������� ���� ����� ������ ���������>
                        {
                            rwtp[4] = sCurrent;
                        }

                        if (rec_num == 3) //N2 - ���������� ������������ �������� UDP, ������� ������������ ��� �������������� �� ������ ���������� ��� ������� �������� ��� ��������� ����� /udp2,
                                          //� ����� ��� ������������� ������� (������ ������� �������������� � ��������� ������)
                        {
                            rwtp[5] = sCurrent;
                        }
                    }
                    else //1.3.6 � ����
                    {
                        if (rec_num == 0) //����� ����� ������
                        {
                            rwtp[1] = sCurrent;
                        }

                        if (rec_num == 1) //���� ������
                        {
                            string[] sDT = sCurrent.Split("/");
                            month = Convert.ToInt32(sDT[1]);
                            day = Convert.ToInt32(sDT[0]);

                            rwtp[2] = sCurrent;
                        }

                        if (rec_num == 2) //����� ������
                        {
                            DateTime t = Convert.ToDateTime(sCurrent);
                            dateTime = new DateTime(year, month, day, t.Hour, t.Minute, t.Second, t.Millisecond);
                            rwtp[3] = sCurrent;
                            rwmem["dateValue"] = dateTime;
                        }

                        if (rec_num == 3) //N - ���������� ������������ �������� UDP (�� ����������� ��������� �����, ������� ��������� � N2).
                                          //� ������� ����������� - <������������ ����� ��������� �������, N ������� ��������� �� ������� ���� ����� ������ ���������>
                        {
                            rwtp[4] = sCurrent;
                        }

                        if (rec_num == 4) //N2 - ���������� ������������ �������� UDP, ������� ������������ ��� �������������� �� ������ ���������� ��� ������� �������� ��� ��������� ����� /udp2,
                                          //� ����� ��� ������������� ������� (������ ������� �������������� � ��������� ������)
                        {
                            rwtp[5] = sCurrent;
                        }
                    }

                    //M =< ��� - �� ������������ ��������> -� ������ Modbus RTU Slave ������
                    if (sCurrent.Length >= 2 && (sCurrent.Substring(0, 2) == "M=") && (rec_num == 5 || rec_num == 6))
                    {
                        rwtp[6] = sCurrent;
                    }

                    //A=<���������� ������������ �������� �� HMI ��������>
                    if (sCurrent.Length >= 2 && (sCurrent.Substring(0, 2) == "A="))
                    {
                        rwtp[7] = sCurrent;
                    }


                    //O<������ �����������>=<���-�� ������>(<����� ���������� ����� ������>,<����� ���-�� ������>) - ���������� ������ ���������� ����� (��� ����� � ������ ������������ ��������� ������).
                    if (sCurrent.Length >= 1 && (sCurrent.Substring(0, 1) == "O"))
                    {
                        rwtp[8] = sCurrent;
                    }

                    //C��������� ������ ��������
                    //U<������ ������>=<���-�� ������>(<������� �����>,<��� �����>,<���� �����>)
                    //(<������� ��������� ����������>,<���>,<����>)(,<����� ������ ������� ������ � ��������� �����>,<����� ���������� ������ � ��������� �����>,<����� ������ �������� ������ � ��������� �����>)
                    //<����� ������ ����������� ������>Kb - ���������� ������ ��������
                    if (sCurrent.Length >= 1 && (sCurrent.Substring(0, 1) == "U"))
                    {
                        DataRow rw = tbTaskStatDetailU.NewRow();
                        rw[0] = id_rec;

                        string[] delimiterWords = { "=", ",", "(", ")(", ")" };

                        string[] sarr = sCurrent.Split(delimiterWords, StringSplitOptions.RemoveEmptyEntries);

                        rw[1] = sarr[0];    //������ ������
                        rw[2] = sarr[1];    //���-�� ������
                        rw[3] = sarr[2];    //������
                        rw[4] = sarr[3];    //������� �����
                        rw[5] = sarr[4];    //����������� �����
                        rw[6] = sarr[5];    //������������ �����
                        rw[7] = sarr[6];    //������� ����� ����������
                        rw[8] = sarr[7];    //����������� ����� ����������
                        rw[9] = sarr[8];    //������������ ����� ����������
                        rw[10] = sarr[9];    //����� ������
                        rw[11] = sarr[10];    //����� ����������
                        rw[12] = sarr[11];    //����� ������
                        rw[13] = sarr[12].ToString().Replace("Kb", String.Empty);    //����� ������

                        tbTaskStatDetailU.Rows.Add(rw);

                        //�������� ������� �������
                        if (!tbMemoryStat.Columns.Contains(sarr[0]))
                        {
                            DataColumn clm = new DataColumn(sarr[0], typeof(double));
                            tbMemoryStat.Columns.Add(clm);
                        }
                        rwmem[sarr[0]] = Convert.ToDouble(rw[13]);
                    }

                    //���������� ������ ����������
                    //S < ������ ������ >=< ��� - �� ������ >,e < ����� ��� - �� ������ >/< ��� - �� ������ � ��������� �����> (< ������� ����� >,< ��� ����� >,< ���� ����� >)(< ������� ��������� ����������>,< ��� >,< ���� >)< ����� ������ ����������� ������ > Kb - � ���������� ������ ����������
                    if (sCurrent.Length >= 1 && (sCurrent.Substring(0, 1) == "S"))
                    {
                        DataRow rw = tbTaskStatDetailU.NewRow();
                        rw[0] = id_rec;

                        string[] delimiterWords = { "=", ",", "(", ")(", ")" };

                        string[] sarr = sCurrent.Split(delimiterWords, StringSplitOptions.RemoveEmptyEntries);

                        rw[1] = sarr[0];    //������ ������
                        rw[2] = sarr[1];    //���-�� ������
                        rw[3] = sarr[2];    //������
                        rw[4] = sarr[3];    //������� �����
                        rw[5] = sarr[4];    //����������� �����
                        rw[6] = sarr[5];    //������������ �����
                        rw[7] = sarr[6];    //������� ����� ����������
                        rw[8] = sarr[7];    //����������� ����� ����������
                        rw[9] = sarr[8];    //������������ ����� ����������
                        rw[13] = sarr[9].ToString().Replace("Kb", String.Empty);    //����� ������

                        tbTaskStatDetailU.Rows.Add(rw);

                        //�������� ������� �������
                        if (!tbMemoryStat.Columns.Contains(sarr[0]))
                        {
                            DataColumn clm = new DataColumn(sarr[0], typeof(double));
                            tbMemoryStat.Columns.Add(clm);
                        }
                        rwmem[sarr[0]] = Convert.ToDouble(rw[13]);
                    }

                    //HR=< ��� - �� ���������� �������� �������� > (< �����, ����������� �� ��������� ���������� >)
                    if (sCurrent.Length >= 3 && sCurrent.Substring(0, 2) == "HR=")
                    {
                        rwtp[9] = sCurrent;
                    }

                    //R=< ��� - �� ������ ������ �������������� > (< ����� ���������� �����>,< ����� ��������� ������������� ������ >,< ���� ����� ������ �� ������� ����������� >,< ��� - �� ��������� �������>). � ������ SLAVE �� ������ ����� ����������� �������� ��������� ������� �����������, � ����� ��������� ������, ���� � �������� ��������� ������ �������� ������ ������.� ����� ������� ����� ������������� ����� 20��
                    if (sCurrent.Length >= 2 && (sCurrent.Substring(0, 2) == "R="))
                    {
                        rwtp[10] = sCurrent;
                    }

                    //������������ ������ ��������
                    if ((sCurrent.Length >= 2) && (sCurrent.Substring(0, 2) == "M=" && sCurrent.Contains("Kb")))
                    {
                        //M=<������������ ����� ������ ���������>Kb
                        string s = sCurrent.Replace("M=", "");
                        s = s.Replace("Kb", "");

                        if (s.Length > 0)
                        {
                            DataRow rw = tbTaskMemory.NewRow();
                            rw[0] = dateTime;
                            rw[1] = Convert.ToDouble(s);
                            tbTaskMemory.Rows.Add(rw);
                        }
                        rwtp[11] = sCurrent;
                    }
                    rec_num++;
                }
                tbMemoryStat.Rows.Add(rwmem);
            }
            catch (Exception ex)
            {
                rwtp[1] = $"������ ������� ������: {sInfo}";
            }
            tbTaskPrimary.Rows.Add(rwtp);
        }



        /// <summary>
        /// ������������� ��������� ��� ���������� �������������
        /// </summary>
        private void InitArchiveStat()
        {
            if (cnnPrimary.State != ConnectionState.Open) return;

            dsArchiveStatistic = new DataSet("dsArchiveStatistic");
            tbArchiveStatistic = new DataTable("tbArchiveStatistic");
            tbArchiveStatisticParce = new DataTable("tbArchiveStatisticParce");

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.ConnectionString = cnnPrimary.ConnectionString;
            sqlConnectionStringBuilder.ApplicationName = "CheckRT_GetArchiveStat";
            SqlConnection sqlConnection = new(sqlConnectionStringBuilder.ConnectionString);
            sqlConnections.Add(sqlConnection);

            #region ������� � ��
            SqlCommand selectCommand = new()
            {
                Connection = sqlConnection,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "[dbo].[get_arch_recs]"
            };

            int RecsQuery = taskProperty_ArchiveStat.ReturnRecCount; //����� �� ��������
            selectCommand.Parameters.AddWithValue("@rec_count", RecsQuery);
            selectCommand.Parameters.AddWithValue("@port", socketConnectionProperty.Port);
            selectCommand.Parameters.AddWithValue("@ip_address", socketConnectionProperty.IPAddress);

            #endregion

            adArchiveStatistic.SelectCommand = selectCommand;


            #region ����������� ������� ���������� �������������
            DataColumn scl0 = new DataColumn("id_rec", typeof(Int32));
            tbArchiveStatistic.Columns.Add(scl0);

            DataColumn scl1 = new DataColumn("RegDT", typeof(DateTime));
            tbArchiveStatistic.Columns.Add(scl1);

            DataColumn scl2 = new DataColumn("LogString", typeof(string));
            tbArchiveStatistic.Columns.Add(scl2);

            tbArchiveStatistic.Constraints.Add("tbArchiveStatistic_pk", scl0, true);
            #endregion

            #region ����������� ������� ��� ����������� ������ ���������� �������������            
            /* R(Tm:0.0, Ct:0, Av:0, Rc:0, Rq:0) W(Tm:0.0, Ct:0, Av:0, Wt:0, Ps:0, Ls:0) D(Tm:0.0, Ct:0, Av:0) I(All:-1)
            R - ������
            W - ������
            D - ��������
            Tm - ����� ������, ����������� �� ��������� R/W/D
            �t - ���������� ������� ������������ �� ��������� ������ R/W/D
            Av - C������ �������� � ��� ������������� ������� R/W/D
            Wt - ���������� ������� � ������� �� ������ � ��
            Ps: - ���������� ������� � ��� ��������� �������
            Ls: - ���������� ��������� ������� � ���������� ������������ (�� ������������ ������� ������)
            Rc: - ���������� ����������� �������� ������
            Rq: - ���������� �������� ������ � �������            
            */
            DataColumn adcl0 = new("id_rec", typeof(Int32));
            tbArchiveStatisticParce.Columns.Add(adcl0);

            #region ������
            DataColumn adcl1 = new("RTm", typeof(string));
            tbArchiveStatisticParce.Columns.Add(adcl1);

            DataColumn adcl2 = new("R�t", typeof(string));
            tbArchiveStatisticParce.Columns.Add(adcl2);

            DataColumn adcl3 = new("RAv", typeof(string));
            tbArchiveStatisticParce.Columns.Add(adcl3);

            DataColumn adcl4 = new("RRc", typeof(string));
            tbArchiveStatisticParce.Columns.Add(adcl4);

            DataColumn adcl5 = new("RRq", typeof(string));
            tbArchiveStatisticParce.Columns.Add(adcl5);
            #endregion

            #region ������
            DataColumn adcl6 = new("WTm", typeof(string));
            tbArchiveStatisticParce.Columns.Add(adcl6);

            DataColumn adcl7 = new("W�t", typeof(string));
            tbArchiveStatisticParce.Columns.Add(adcl7);

            DataColumn adcl8 = new("WAv", typeof(string));
            tbArchiveStatisticParce.Columns.Add(adcl8);

            DataColumn adcl9 = new("WWt", typeof(string));
            tbArchiveStatisticParce.Columns.Add(adcl9);

            DataColumn adcl10 = new("WPs", typeof(string));
            tbArchiveStatisticParce.Columns.Add(adcl10);

            DataColumn adcl11 = new("WLs", typeof(string));
            tbArchiveStatisticParce.Columns.Add(adcl11);
            #endregion

            #region ��������
            DataColumn adcl12 = new("DTm", typeof(string));
            tbArchiveStatisticParce.Columns.Add(adcl12);

            DataColumn adcl13 = new("D�t", typeof(string));
            tbArchiveStatisticParce.Columns.Add(adcl13);

            DataColumn adcl14 = new("DAv", typeof(string));
            tbArchiveStatisticParce.Columns.Add(adcl14);
            #endregion

            #endregion

            //��������� ������� � �����
            dsArchiveStatistic.Tables.Add(tbArchiveStatistic);
            dsArchiveStatistic.Tables.Add(tbArchiveStatisticParce);

            //��������� ��������� ����� ���������
            DataColumn parentColumn = dsArchiveStatistic.Tables["tbArchiveStatistic"].Columns["id_rec"];
            DataColumn childColumn = dsArchiveStatistic.Tables["tbArchiveStatisticParce"].Columns["id_rec"];
            DataRelation relArchiveStatistic;
            relArchiveStatistic = new DataRelation("relArchiveStatistic",
                parentColumn, childColumn);

            // Add the relation to the DataSet.
            dsArchiveStatistic.Relations.Add(relArchiveStatistic);


            bsArchiveStatistic = new BindingSource
            {
                //���������� �������� ������ ��� ��������
                DataSource = dsArchiveStatistic,
                DataMember = "tbArchiveStatistic"
            };
            //bsArchiveStatistic.MoveLast();

            bsArchiveStatisticParce = new BindingSource
            {
                //���������� �������� ������ ��� ��������
                DataSource = bsArchiveStatistic,
                DataMember = relArchiveStatistic.RelationName
            };

            dataGridViewArchStat.DataSource = bsArchiveStatistic;
            dataGridViewArchStat.Columns[1].DefaultCellStyle.Format = @"dd.MM.yy HH:mm:ss";
            dataGridViewArchStat.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewArchStatDetail.DataSource = bsArchiveStatisticParce;

        }

        /// <summary>
        /// ������ ���������� �� �������������
        /// </summary>
        private void GetArchiveStatData()
        {

            if (cnnPrimary.State != ConnectionState.Open) return;

            //��������� ������ ���������� �� ����������
            this.btnRefreshArchStat.BeginInvoke((MethodInvoker)(() => this.btnRefreshArchStat.Enabled = false));
            dsArchiveStatistic.Tables[1].Clear();
            dsArchiveStatistic.Tables[0].Clear();

            try
            {

                adArchiveStatistic.Fill(dsArchiveStatistic, "tbArchiveStatistic"); //��������� ������ � �� � ��������� DataSet � ������� ����������

                foreach (DataRow rw in dsArchiveStatistic.Tables["tbArchiveStatistic"].Rows)
                {
                    string sInfo = "";
                    if (rw["LogString"] != DBNull.Value)
                    {
                        sInfo = rw["LogString"].ToString();
                        if (sInfo.Length > 0)
                        {
                            int id_rec = Convert.ToInt32(rw["id_rec"]);
                            parce_ArchStat(id_rec, sInfo);
                        }
                    }
                }

                CurrencyManager cm = (CurrencyManager)this.dataGridViewArchStat.BindingContext[bsArchiveStatistic];
                if (cm != null)
                {
                    this.BeginInvoke((MethodInvoker)(() => cm.Refresh()));
                    this.BeginInvoke((MethodInvoker)(() => bsArchiveStatistic.MoveLast()));
                }

                CurrencyManager cs = (CurrencyManager)this.dataGridViewArchStatDetail.BindingContext[bsArchiveStatisticParce];
                if (cs != null)
                {
                    this.BeginInvoke((MethodInvoker)(() => cs.Refresh()));
                }

                //�������� � ���, ��� ������ ���������                       
                this.ReadyThred_RefreshArchStatRecs(this, new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show("������ ��� ������ ������� �� �������: " + ex.Message, "��������� ���������� �� ������������� 'GetArchiveStatData'", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.btnRefreshArchStat.BeginInvoke((MethodInvoker)(() => this.btnRefreshArchStat.Enabled = true));
            }
        }


        /// <summary>
        /// ���������� �������
        /// </summary>
        /// <param name="dataTable"></param>
        private void SetChar1tDataSource()
        {
            chart1.Series.Clear();
            chart1.DataSource = tbTaskMemory;

            chart1.Series.Add("Series1");
            chart1.Series["Series1"].LegendText = "������ ��������";
            chart1.Series["Series1"].XValueMember = "dateTime";
            chart1.Series["Series1"].YValueMembers = "mem";
            chart1.Series["Series1"].ChartType = SeriesChartType.StackedArea;

            DateTime minDate = Convert.ToDateTime(tbTaskMemory.Rows[0][0]);
            DateTime maxDate = Convert.ToDateTime(tbTaskMemory.Rows[tbTaskMemory.Rows.Count - 1][0]);

            //chart1.ChartAreas[0].AxisX.Minimum = minDate.ToOADate();
            //chart1.ChartAreas[0].AxisX.Maximum = maxDate.ToOADate();
            chart1.ChartAreas[0].AxisY.Title = "Kb";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";

            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "dd.MM.yy HH:mm:ss";
            chart1.ChartAreas["ChartArea1"].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart1.DataBind();
        }

        private void SetChar2tDataSource()
        {
            chart2.Series.Clear();
            chart2.DataSource = tbMemoryStat;

            foreach (DataColumn column in tbMemoryStat.Columns)
            {
                if (column.ColumnName != "dateValue")
                {
                    string SeriesName = "Series_" + column.ColumnName;
                    chart2.Series.Add(SeriesName);
                    chart2.Series[SeriesName].ChartType = SeriesChartType.Spline;
                    chart2.Series[SeriesName].LegendText = column.ColumnName;
                    chart2.Series[SeriesName].XValueMember = "dateValue";
                    chart2.Series[SeriesName].YValueMembers = column.ColumnName;
                }
            }

            chart2.ChartAreas[0].AxisY.Title = "Kb";
            chart2.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
            chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "dd.MM.yy HH:mm:ss";
            chart2.ChartAreas["ChartArea1"].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart2.DataBind();
        }




        private void btnRefreshFiltredRecords_Click(object sender, EventArgs e)
        {
            RunRefreshFiltredRecs();
        }

        private void button_RefreshLogRecords_Click(object sender, EventArgs e)
        {
            RunRefreshLogRecs();
        }

        /// <summary>
        /// ��������� ������� ��������� ������
        /// </summary>
        private void RefreshFiltredRecs(object sender, EventArgs e)
        {
            RefreshFiltredRecsIsFree = true;
        }
        /// <summary>
        /// ������ ���������� ��������� �� �������� ��������
        /// </summary>
        private void RunRefreshFiltredRecs()
        {
            if (!RefreshFiltredRecsIsFree) return;
            RefreshFiltredRecsIsFree = false;
            Thread newThread = new(new ThreadStart(this.GetDataFiltredRecords));
            newThread.Start();
        }
        /// <summary>
        /// ��������� ������� ��������� ������
        /// </summary>
        private void RefreshLogRecs(object sender, EventArgs e)
        {
            RefreshLogRecsIsFree = true;
        }

        /// <summary>
        /// ������ ������ ������� ���������
        /// </summary>
        private void RunRefreshLogRecs()
        {
            if (!RefreshLogRecsIsFree) return;

            RefreshLogRecsIsFree = false;
            Thread newThread = new(new ThreadStart(this.GetDataLogRecords));
            newThread.Start();
        }

        private void RefreshStatRecs(object? sender, EventArgs e)
        {
            RefreshStatRecsIsFree = true;
        }

        /// <summary>
        /// ������ ��������� ���������� ��������� ���������
        /// </summary>        
        private void RefreshArchStatRecs(object? sender, EventArgs e)
        {
            RefreshArchStatRecsIsFree = true;
        }

        private void RunRefreshStatRecs()
        {
            if (!RefreshStatRecsIsFree) return;

            RefreshStatRecsIsFree = false;
            Thread newThread = new(new ThreadStart(this.GetTaskStatData));
            newThread.Start();
        }


        /// <summary>
        /// ������ ������ ���������� ���������� �������������
        /// </summary>
        private void RunRefreshArhStatRecs()
        {
            if (!RefreshArchStatRecsIsFree) return;
            RefreshArchStatRecsIsFree = false;
            Thread newThread = new(new ThreadStart(this.GetArchiveStatData));
            newThread.Start();
        }

        /// <summary>
        /// ���������������� �� ������ � ������� ����������� �� ��������� ��������������� ������.
        /// </summary>
        private void dataGridViewFiltredRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id_rec = 0;
            DataGridViewRow rw = dataGridViewFiltredRecords.CurrentRow;

            if (rw.Cells[0].Value != DBNull.Value)
                id_rec = Convert.ToInt32(rw.Cells[0].Value);

            if (id_rec > 0)
            {
                BindingSource bs = (BindingSource)dataGridViewLogRecords.DataSource;
                bs.Position = bs.Find("id_rec", id_rec);
            }
        }

        private void btnRefreshTaskStat_Click(object sender, EventArgs e)
        {
            RunRefreshStatRecs();
        }


        #region �������
        /// <summary>
        /// ������ ��������� ���������� ������� �����������
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            RunRefreshFiltredRecs();
        }
        /// <summary>
        /// ����� ����������� �� ������� � �������� �����������
        /// </summary>
        private void timer2_Tick(object sender, EventArgs e)
        {
            RunRefreshLogRecs();
        }
        /// <summary>
        /// ������ ��������� ������� � ������� �������������� ���������� �� ������� �������� � ���������
        /// </summary>
        private void timer3_Tick(object sender, EventArgs e)
        {
            RunRefreshStatRecs();
        }
        /// <summary>
        /// ������ ��������� ������� � ������� ���������� �������������
        /// </summary>
        private void timer4_Tick(object sender, EventArgs e)
        {
            RunRefreshArhStatRecs();
        }
        #endregion �������


        private void parce_ArchStat(int id_rec, string sInfo)
        {

            string[] delimiterWords = { ",", "(", ")(", ")" };
            string[] words = sInfo.Split(delimiterWords, StringSplitOptions.RemoveEmptyEntries);

            int rec_num = 0;

            DataRow rwtp = tbArchiveStatisticParce.NewRow();
            rwtp[0] = id_rec;

            foreach (string sCurrent in words)
            {
                if (rec_num == 1) //RTm
                {
                    rwtp[1] = sCurrent;
                }
                if (rec_num == 2) //R�t
                {
                    rwtp[2] = sCurrent;
                }
                if (rec_num == 3) //RAv
                {
                    rwtp[3] = sCurrent;
                }
                if (rec_num == 4) //RRc
                {
                    rwtp[4] = sCurrent;
                }
                if (rec_num == 5) //RRq
                {
                    rwtp[5] = sCurrent;
                }
                if (rec_num == 7) //WTm
                {
                    rwtp[6] = sCurrent;
                }
                if (rec_num == 8) //W�t
                {
                    rwtp[7] = sCurrent;
                }
                if (rec_num == 9) //WAv
                {
                    rwtp[8] = sCurrent;
                }
                if (rec_num == 10) //WRt
                {
                    rwtp[9] = sCurrent;
                }
                if (rec_num == 11) //WPs
                {
                    rwtp[10] = sCurrent;
                }
                if (rec_num == 12) //WLs
                {
                    rwtp[11] = sCurrent;
                }
                if (rec_num == 14) //DTm
                {
                    rwtp[12] = sCurrent;
                }
                if (rec_num == 15) //D�t
                {
                    rwtp[13] = sCurrent;
                }
                if (rec_num == 16) //DAv
                {
                    rwtp[14] = sCurrent;
                }
                rec_num++;
            }

            tbArchiveStatisticParce.Rows.Add(rwtp);

        }


        //������������� ���������� ���� ������
        private void checkBox_Pause_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Pause.Checked)
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                timer4.Stop();
                timer5.Stop();
                GC.Collect();

                checkBox_Pause.BackColor = Color.Yellow; //checkBox_Pause.ForeColor = Color.                
            }
            else
            {
                if (checkBox_AutoRefreshFilter.Checked)
                    timer1.Start();

                if (checkBox_AutoRefreshLog.Checked)
                    timer2.Start();

                if (checkBox_AutoRefreshTaskStat.Checked)
                    timer3.Start();

                if (checkBox_AutoRefreshArchStat.Checked)
                    timer4.Start();

                timer5.Start();

                checkBox_Pause.BackColor = SystemColors.Control;
            }
        }


        private void btnRefreshArchStat_Click(object sender, EventArgs e)
        {
            RunRefreshArhStatRecs();
        }


        #region ��������� (������/������)
        /// <summary>
        /// ���������� �������� � ���� ������������
        /// </summary>
        /// <param name="key">���������</param>
        /// <param name="value">��������</param>
        public static void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        /// <summary>
        /// ������ ��������� �� ����� ������������
        /// </summary>
        /// <param name="key">����</param>
        /// <returns>�������� ���������</returns>
        private static object ReadAppSetting(string key)
        {
            object ret = null;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection csSection = config.AppSettings;

            if (csSection.Settings[key] != null)
            {
                ret = csSection.Settings[key].Value;
            }
            return ret;
        }

        /// <summary>
        /// ���������� ��������� ����������� � ��. ����� ��������� ��������� ��������, �.�. ����� ������������� ����������� � ��������� �� �� �������� ����������
        /// </summary>
        /// <param name="key">������������ �����������</param>
        /// <param name="sqlConnectionString">������ �����������</param>
        public static void AddOrUpdateConnectionString(string key, string sqlConnectionString)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                // Get the connection strings section.

                ConnectionStringsSection csSection =
                    config.ConnectionStrings;

                if (ConfigurationManager.ConnectionStrings[key] == null)
                {
                    ConnectionStringSettings csSettings = new ConnectionStringSettings(key, sqlConnectionString);
                    csSection.ConnectionStrings.Add(csSettings);
                }
                else
                {
                    ConnectionStringSettings csSettings = new ConnectionStringSettings();
                    csSettings = csSection.ConnectionStrings[key];
                    csSettings.ConnectionString = sqlConnectionString;
                }

                // Save the configuration file.
                config.Save(ConfigurationSaveMode.Modified);

            }
            catch (ConfigurationErrorsException ex)
            {
                MessageBox.Show("������ ���������� ������������: " + ex.Message, "��������� ������������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Error writing app settings: " + ex.Message);
            }
        }
        #endregion ��������� (������/������)


        private void dataGridViewArchStat_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridViewArchStatDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>
        /// ���������. ���������
        /// </summary>
        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            PropertyGrid pg = (PropertyGrid)s;
            if (pg == null) { return; }

            if (propertyGrid1.SelectedObject.GetType() == typeof(SqlConnectionStringBuilder)) //�������� ��������� ����������� � ��
            {
                SqlConnectionStringBuilder sqlConnectionStringBuilder = (SqlConnectionStringBuilder)propertyGrid1.SelectedObject;
                sqlServerConnectionProperty.ConnectionString = sqlConnectionStringBuilder.ConnectionString;
            }
        }

        private void button_OpenConnectionProperty_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder =
                new SqlConnectionStringBuilder(sqlServerConnectionProperty.ConnectionString);

            propertyGrid1.SelectedObject = sqlConnectionStringBuilder;
            propertyGrid1.Tag = "cnnPrimary"; //��� �����������
        }


        private void textBoxSqlServerConnectionString_Enter(object sender, EventArgs e)
        {
            //SqlConnectionStringBuilder sqlConnectionStringBuilder =
            //    new SqlConnectionStringBuilder(sqlServerConnectionProperty.ConnectionString);

            //propertyGrid1.SelectedObject = sqlConnectionStringBuilder;
            //propertyGrid1.Tag = "cnnPrimary"; //��� �����������
        }


        /// <summary>
        /// ������ �������� �� ������ �������� ��� ����������� � propertyGrid1
        /// </summary>
        private void ReadNodeSettings()
        {
            foreach (TreeNode nd in this.treeViewSettings.Nodes)
            {
                RecurceNodeSettings(nd);
            }
        }
        private void RecurceNodeSettings(TreeNode currentTreeNode)
        {

            if (currentTreeNode.Tag != null && currentTreeNode.Tag.ToString() == "SocketConnectionProperty")
            {
                //��������� �����������
                string? jsonString = (string?)ReadAppSetting("SocketConnectionProperty");
                if (jsonString != null)
                {
                    socketConnectionProperty = JsonSerializer.Deserialize<SocketConnectionProperty>(jsonString);
                }
                else
                {
                    socketConnectionProperty.IPAddress = "127.0.0.1";
                    socketConnectionProperty.Port = 31550;
                }
                currentTreeNode.Tag = socketConnectionProperty;
            }
            if (currentTreeNode.Tag != null && currentTreeNode.Tag.ToString() == "TaskProperty")
            {
                TaskProperty taskProperty = new TaskProperty();

                string? jsonString = (string?)ReadAppSetting(currentTreeNode.Name);
                if (jsonString != null)
                {
                    taskProperty = JsonSerializer.Deserialize<TaskProperty>(jsonString);
                }
                else
                {
                    //�������� �� ��������� ��� ������ ���� ��������� �� ������� (���������� � ������). ����� ������ ������� ��� ����, ��� �������� �� ������� ������� � ����� ������������
                    taskProperty.Name = currentTreeNode.Name;
                }
                if (currentTreeNode.Name == "LogRecords")
                {
                    taskProperty_LogRecords = taskProperty;
                }
                if (currentTreeNode.Name == "FiltredRecs")
                {
                    taskProperty_FiltredRecs = taskProperty;
                }
                if (currentTreeNode.Name == "TaskRecords")
                {
                    taskProperty_TaskRecords = taskProperty;
                }
                if (currentTreeNode.Name == "ArchiveStat")
                {
                    taskProperty_ArchiveStat = taskProperty;
                }
                currentTreeNode.Tag = taskProperty;
            }

            foreach (TreeNode nd in currentTreeNode.Nodes)
            {
                RecurceNodeSettings(nd);
            }
        }

        private void treeViewSettings_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewSettings.SelectedNode.Tag != null)
            {
                propertyGrid1.SelectedObject = treeViewSettings.SelectedNode.Tag;
                propertyGrid1.Tag = treeViewSettings.SelectedNode.Tag;
            }
            else
            {
                propertyGrid1.SelectedObject = null;
                propertyGrid1.Tag = null;
            }
        }

        private void button_ImportLogFile_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            taskProperty_LogRecords.AvtoUpdate = false;
            taskProperty_FiltredRecs.AvtoUpdate = false;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string? initialDirectory = (string?)ReadAppSetting("LogDir");

                if (initialDirectory != null)
                    openFileDialog.InitialDirectory = initialDirectory;

                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    FileInfo fi1 = new FileInfo(filePath);
                    AddOrUpdateAppSettings("LogDir", fi1.DirectoryName);

                    SqlCommand selectCommand = new()
                    {
                        Connection = cnnPrimary,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "[dbo].[import_log]"
                    };
                    selectCommand.Parameters.AddWithValue("@filename", filePath);
                    try
                    {
                        selectCommand.ExecuteNonQuery();
                        MessageBox.Show("������ ������� �� ����� � �� ��������", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("������ ������ ������� �� ����� � ��: " + ex.Message, "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void dataGridViewTaskStat_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridViewTaskPrimary_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridViewTaskStatDetailU_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (!checkBox_Pause.Checked)
            {
                this.tbStatus.AppendText(TempBuffer);
                TempBuffer = "";
            }
        }

        private void button_FilterLogRecords_Click(object sender, EventArgs e)
        {
            checkBox_AutoRefreshLog.Checked = false;
            BindingSource bs = (BindingSource)this.dataGridViewLogRecords.DataSource;
            try
            {
                bs.Filter = $"LogString like '%{textBoxFilterForLogRecords.Text}%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show("������ �����", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_FilterFiltredRecs_Click(object sender, EventArgs e)
        {
            checkBox_AutoRefreshFilter.Checked = false;
            BindingSource bs = (BindingSource)this.dataGridViewFiltredRecords.DataSource;
            try
            {
                bs.Filter = $"LogString like '%{textBoxFilterForFiltredRecords.Text}%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show("������ �����", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddFilter_Click(object sender, EventArgs e)
        {
        }

        private void textBoxSqlServerConnectionString_TextChanged(object sender, EventArgs e)
        {

        }


    }


}


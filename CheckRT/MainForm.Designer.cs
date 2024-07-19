namespace CheckRT
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            TreeNode treeNode1 = new TreeNode("Подключение к RT");
            TreeNode treeNode2 = new TreeNode("Журнал логирования");
            TreeNode treeNode3 = new TreeNode("Результат применения фильтров");
            TreeNode treeNode4 = new TreeNode("Статистика задач");
            TreeNode treeNode5 = new TreeNode("Статистика архивирования");
            TreeNode treeNode6 = new TreeNode("Настройки задач", new TreeNode[] { treeNode2, treeNode3, treeNode4, treeNode5 });
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle25 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            DataGridViewCellStyle dataGridViewCellStyle26 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle27 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle28 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle29 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle30 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle31 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle32 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle33 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle34 = new DataGridViewCellStyle();
            textBox_IPAdr = new TextBox();
            tbStatus = new TextBox();
            label4 = new Label();
            textBox_Command = new TextBox();
            btnConnectThread = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            numericUpDown_Port = new NumericUpDown();
            label9 = new Label();
            label8 = new Label();
            btnSendCoomandToThread = new Button();
            btnStopThread = new Button();
            tabPage2 = new TabPage();
            splitContainer4 = new SplitContainer();
            splitContainerSettings = new SplitContainer();
            splitContainer5 = new SplitContainer();
            button_OpenConnectionProperty = new Button();
            imageList1 = new ImageList(components);
            label23 = new Label();
            textBoxSqlServerError = new TextBox();
            label1 = new Label();
            label20 = new Label();
            textBoxSqlServerConnectionString = new TextBox();
            label19 = new Label();
            buttonRefreshConnection = new Button();
            imageListSqlServerConnection = new ImageList(components);
            treeViewSettings = new TreeView();
            tableLayoutPanel1 = new TableLayoutPanel();
            dataGridViewFilters = new DataGridView();
            label3 = new Label();
            propertyGrid1 = new PropertyGrid();
            tabPage3 = new TabPage();
            splitContainer1 = new SplitContainer();
            button_FilterLogRecords = new Button();
            textBoxFilterForLogRecords = new TextBox();
            label25 = new Label();
            numericUpDown_LogRecReturnRecCount = new NumericUpDown();
            label2 = new Label();
            numericUpDown_LogRecInterval = new NumericUpDown();
            label18 = new Label();
            label6 = new Label();
            checkBox_AutoRefreshLog = new CheckBox();
            dataGridViewLogRecords = new DataGridView();
            button_RefreshLogRecords = new Button();
            button_FilterFiltredRecs = new Button();
            textBoxFilterForFiltredRecords = new TextBox();
            label24 = new Label();
            numericUpDown_FiltredRecReturnRecCount = new NumericUpDown();
            label5 = new Label();
            numericUpDown_FiltredRecInterval = new NumericUpDown();
            label17 = new Label();
            dataGridViewFiltredRecords = new DataGridView();
            label_FiltredRecInterval = new Label();
            btnRefreshFiltredRecords = new Button();
            checkBox_AutoRefreshFilter = new CheckBox();
            tabPage4 = new TabPage();
            numericUpDown_TaskStatReturnRecCount = new NumericUpDown();
            label21 = new Label();
            numericUpDown_IntervalTaskStat = new NumericUpDown();
            splitContainer3 = new SplitContainer();
            label11 = new Label();
            dataGridViewTaskStatDetailU = new DataGridView();
            id_rec = new DataGridViewTextBoxColumn();
            TaskIndex = new DataGridViewTextBoxColumn();
            CicleCount = new DataGridViewTextBoxColumn();
            ErrCount = new DataGridViewTextBoxColumn();
            AvgCicle = new DataGridViewTextBoxColumn();
            MinCicle = new DataGridViewTextBoxColumn();
            MaxCicle = new DataGridViewTextBoxColumn();
            AvgCicleReal = new DataGridViewTextBoxColumn();
            MinCicleReal = new DataGridViewTextBoxColumn();
            MaxCicleReal = new DataGridViewTextBoxColumn();
            TimeRead = new DataGridViewTextBoxColumn();
            TimeWork = new DataGridViewTextBoxColumn();
            TimeWrite = new DataGridViewTextBoxColumn();
            Mem = new DataGridViewTextBoxColumn();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            splitContainer2 = new SplitContainer();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dataGridViewTaskPrimary = new DataGridView();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            TaskCicle = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            Time = new DataGridViewTextBoxColumn();
            N = new DataGridViewTextBoxColumn();
            N2 = new DataGridViewTextBoxColumn();
            ModbusRTUSlave = new DataGridViewTextBoxColumn();
            A = new DataGridViewTextBoxColumn();
            O = new DataGridViewTextBoxColumn();
            HR = new DataGridViewTextBoxColumn();
            R = new DataGridViewTextBoxColumn();
            MemoryUsing = new DataGridViewTextBoxColumn();
            label13 = new Label();
            numericUpDown_ArchStatReturnRecCount = new NumericUpDown();
            label22 = new Label();
            numericUpDown_IntervalArchStat = new NumericUpDown();
            label16 = new Label();
            dataGridViewArchStatDetail = new DataGridView();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            label15 = new Label();
            checkBox_AutoRefreshArchStat = new CheckBox();
            btnRefreshArchStat = new Button();
            dataGridViewArchStat = new DataGridView();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            label14 = new Label();
            label7 = new Label();
            checkBox_AutoRefreshTaskStat = new CheckBox();
            btnRefreshTaskStat = new Button();
            dataGridViewTaskStat = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            RegDT = new DataGridViewTextBoxColumn();
            LogString = new DataGridViewTextBoxColumn();
            tabPage5 = new TabPage();
            button_Parce = new Button();
            textBox_ParceTRG = new TextBox();
            textBox_ParceSRC = new TextBox();
            button_ImportLogFile = new Button();
            checkBox_Pause = new CheckBox();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            toolTip1 = new ToolTip(components);
            timer3 = new System.Windows.Forms.Timer(components);
            label10 = new Label();
            timer4 = new System.Windows.Forms.Timer(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            timer5 = new System.Windows.Forms.Timer(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Port).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerSettings).BeginInit();
            splitContainerSettings.Panel1.SuspendLayout();
            splitContainerSettings.Panel2.SuspendLayout();
            splitContainerSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
            splitContainer5.Panel1.SuspendLayout();
            splitContainer5.Panel2.SuspendLayout();
            splitContainer5.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFilters).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_LogRecReturnRecCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_LogRecInterval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLogRecords).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_FiltredRecReturnRecCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_FiltredRecInterval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiltredRecords).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_TaskStatReturnRecCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_IntervalTaskStat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTaskStatDetailU).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTaskPrimary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_ArchStatReturnRecCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_IntervalArchStat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArchStatDetail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArchStat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTaskStat).BeginInit();
            tabPage5.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_IPAdr
            // 
            textBox_IPAdr.BackColor = Color.Black;
            textBox_IPAdr.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_IPAdr.ForeColor = Color.Chartreuse;
            textBox_IPAdr.Location = new Point(63, 34);
            textBox_IPAdr.Name = "textBox_IPAdr";
            textBox_IPAdr.Size = new Size(169, 32);
            textBox_IPAdr.TabIndex = 8;
            textBox_IPAdr.TextAlign = HorizontalAlignment.Center;
            // 
            // tbStatus
            // 
            tbStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbStatus.BackColor = SystemColors.WindowText;
            tbStatus.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tbStatus.ForeColor = Color.LimeGreen;
            tbStatus.Location = new Point(6, 74);
            tbStatus.Multiline = true;
            tbStatus.Name = "tbStatus";
            tbStatus.ScrollBars = ScrollBars.Vertical;
            tbStatus.Size = new Size(1407, 654);
            tbStatus.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.DarkGreen;
            label4.Location = new Point(904, 45);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 15;
            label4.Text = "Команда";
            // 
            // textBox_Command
            // 
            textBox_Command.BackColor = Color.Black;
            textBox_Command.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_Command.ForeColor = Color.Chartreuse;
            textBox_Command.Location = new Point(965, 34);
            textBox_Command.Name = "textBox_Command";
            textBox_Command.Size = new Size(79, 32);
            textBox_Command.TabIndex = 14;
            textBox_Command.TextAlign = HorizontalAlignment.Center;
            // 
            // btnConnectThread
            // 
            btnConnectThread.FlatAppearance.BorderSize = 0;
            btnConnectThread.FlatAppearance.MouseDownBackColor = Color.Yellow;
            btnConnectThread.FlatStyle = FlatStyle.Flat;
            btnConnectThread.Image = (Image)resources.GetObject("btnConnectThread.Image");
            btnConnectThread.Location = new Point(401, 32);
            btnConnectThread.Margin = new Padding(0);
            btnConnectThread.Name = "btnConnectThread";
            btnConnectThread.Size = new Size(146, 35);
            btnConnectThread.TabIndex = 34;
            btnConnectThread.UseVisualStyleBackColor = true;
            btnConnectThread.Click += btnConnectThread_Click;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Location = new Point(5, 57);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1429, 763);
            tabControl1.TabIndex = 35;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(numericUpDown_Port);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(btnSendCoomandToThread);
            tabPage1.Controls.Add(btnStopThread);
            tabPage1.Controls.Add(tbStatus);
            tabPage1.Controls.Add(textBox_IPAdr);
            tabPage1.Controls.Add(btnConnectThread);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(textBox_Command);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1421, 735);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Монитор";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_Port
            // 
            numericUpDown_Port.BackColor = Color.Black;
            numericUpDown_Port.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDown_Port.ForeColor = Color.Chartreuse;
            numericUpDown_Port.Location = new Point(269, 35);
            numericUpDown_Port.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numericUpDown_Port.Name = "numericUpDown_Port";
            numericUpDown_Port.Size = new Size(120, 32);
            numericUpDown_Port.TabIndex = 43;
            numericUpDown_Port.TextAlign = HorizontalAlignment.Center;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.DarkGreen;
            label9.Location = new Point(238, 45);
            label9.Name = "label9";
            label9.Size = new Size(33, 15);
            label9.TabIndex = 42;
            label9.Text = "порт";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.DarkGreen;
            label8.Location = new Point(6, 45);
            label8.Name = "label8";
            label8.Size = new Size(54, 15);
            label8.TabIndex = 41;
            label8.Text = "IP адрес";
            // 
            // btnSendCoomandToThread
            // 
            btnSendCoomandToThread.FlatAppearance.BorderSize = 0;
            btnSendCoomandToThread.FlatAppearance.MouseDownBackColor = Color.Yellow;
            btnSendCoomandToThread.FlatStyle = FlatStyle.Flat;
            btnSendCoomandToThread.Image = (Image)resources.GetObject("btnSendCoomandToThread.Image");
            btnSendCoomandToThread.Location = new Point(1047, 32);
            btnSendCoomandToThread.Margin = new Padding(0);
            btnSendCoomandToThread.Name = "btnSendCoomandToThread";
            btnSendCoomandToThread.Size = new Size(146, 35);
            btnSendCoomandToThread.TabIndex = 37;
            btnSendCoomandToThread.UseVisualStyleBackColor = true;
            btnSendCoomandToThread.Click += btnSendCoomandToThread_Click;
            // 
            // btnStopThread
            // 
            btnStopThread.FlatAppearance.BorderSize = 0;
            btnStopThread.FlatAppearance.MouseDownBackColor = Color.Yellow;
            btnStopThread.FlatStyle = FlatStyle.Flat;
            btnStopThread.Image = (Image)resources.GetObject("btnStopThread.Image");
            btnStopThread.Location = new Point(556, 32);
            btnStopThread.Margin = new Padding(0);
            btnStopThread.Name = "btnStopThread";
            btnStopThread.Size = new Size(146, 35);
            btnStopThread.TabIndex = 36;
            btnStopThread.UseVisualStyleBackColor = true;
            btnStopThread.Click += btnStopThread_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(splitContainer4);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1421, 735);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Настройки";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            splitContainer4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer4.BorderStyle = BorderStyle.Fixed3D;
            splitContainer4.Location = new Point(6, 3);
            splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(splitContainerSettings);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(propertyGrid1);
            splitContainer4.Size = new Size(1410, 727);
            splitContainer4.SplitterDistance = 1089;
            splitContainer4.TabIndex = 18;
            // 
            // splitContainerSettings
            // 
            splitContainerSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainerSettings.BorderStyle = BorderStyle.Fixed3D;
            splitContainerSettings.Location = new Point(3, 3);
            splitContainerSettings.Name = "splitContainerSettings";
            splitContainerSettings.Orientation = Orientation.Horizontal;
            // 
            // splitContainerSettings.Panel1
            // 
            splitContainerSettings.Panel1.Controls.Add(splitContainer5);
            // 
            // splitContainerSettings.Panel2
            // 
            splitContainerSettings.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainerSettings.Panel2.Controls.Add(label3);
            splitContainerSettings.Size = new Size(1079, 717);
            splitContainerSettings.SplitterDistance = 223;
            splitContainerSettings.TabIndex = 35;
            // 
            // splitContainer5
            // 
            splitContainer5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer5.BorderStyle = BorderStyle.Fixed3D;
            splitContainer5.Location = new Point(5, 3);
            splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            splitContainer5.Panel1.Controls.Add(button_OpenConnectionProperty);
            splitContainer5.Panel1.Controls.Add(label23);
            splitContainer5.Panel1.Controls.Add(textBoxSqlServerError);
            splitContainer5.Panel1.Controls.Add(label1);
            splitContainer5.Panel1.Controls.Add(label20);
            splitContainer5.Panel1.Controls.Add(textBoxSqlServerConnectionString);
            splitContainer5.Panel1.Controls.Add(label19);
            splitContainer5.Panel1.Controls.Add(buttonRefreshConnection);
            // 
            // splitContainer5.Panel2
            // 
            splitContainer5.Panel2.Controls.Add(treeViewSettings);
            splitContainer5.Size = new Size(1072, 213);
            splitContainer5.SplitterDistance = 652;
            splitContainer5.TabIndex = 41;
            // 
            // button_OpenConnectionProperty
            // 
            button_OpenConnectionProperty.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_OpenConnectionProperty.ImageIndex = 2;
            button_OpenConnectionProperty.ImageList = imageList1;
            button_OpenConnectionProperty.Location = new Point(614, 39);
            button_OpenConnectionProperty.Name = "button_OpenConnectionProperty";
            button_OpenConnectionProperty.Size = new Size(26, 26);
            button_OpenConnectionProperty.TabIndex = 44;
            toolTip1.SetToolTip(button_OpenConnectionProperty, "Настроить подключение");
            button_OpenConnectionProperty.UseVisualStyleBackColor = true;
            button_OpenConnectionProperty.Click += button_OpenConnectionProperty_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "ProgressSkip.ico");
            imageList1.Images.SetKeyName(1, "sync.ico");
            imageList1.Images.SetKeyName(2, "pencil_106685.png");
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label23.ForeColor = Color.DarkGreen;
            label23.Location = new Point(14, 141);
            label23.Name = "label23";
            label23.Size = new Size(98, 15);
            label23.TabIndex = 43;
            label23.Text = "Список ошибок";
            // 
            // textBoxSqlServerError
            // 
            textBoxSqlServerError.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSqlServerError.BackColor = SystemColors.Window;
            textBoxSqlServerError.ForeColor = Color.DarkGreen;
            textBoxSqlServerError.Location = new Point(14, 159);
            textBoxSqlServerError.Multiline = true;
            textBoxSqlServerError.Name = "textBoxSqlServerError";
            textBoxSqlServerError.Size = new Size(625, 47);
            textBoxSqlServerError.TabIndex = 42;
            textBoxSqlServerError.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkGreen;
            label1.Location = new Point(14, 14);
            label1.Name = "label1";
            label1.Size = new Size(390, 19);
            label1.TabIndex = 41;
            label1.Text = "Настройки подключения к БД на Microsoft SQL Server";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label20.ForeColor = Color.DarkGreen;
            label20.Location = new Point(14, 50);
            label20.Name = "label20";
            label20.Size = new Size(131, 15);
            label20.TabIndex = 40;
            label20.Text = "Строка подключения";
            // 
            // textBoxSqlServerConnectionString
            // 
            textBoxSqlServerConnectionString.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSqlServerConnectionString.BackColor = SystemColors.Window;
            textBoxSqlServerConnectionString.ForeColor = Color.DarkGreen;
            textBoxSqlServerConnectionString.Location = new Point(14, 68);
            textBoxSqlServerConnectionString.Multiline = true;
            textBoxSqlServerConnectionString.Name = "textBoxSqlServerConnectionString";
            textBoxSqlServerConnectionString.Size = new Size(625, 46);
            textBoxSqlServerConnectionString.TabIndex = 30;
            textBoxSqlServerConnectionString.TabStop = false;
            textBoxSqlServerConnectionString.Text = "Пример: Data Source=DT-MS-51321\\SQLEXPRESS;Initial Catalog=mps_p1;Integrated Security=True;Trust Server Certificate=True;Application Name=CheckRT";
            textBoxSqlServerConnectionString.TextChanged += textBoxSqlServerConnectionString_TextChanged;
            textBoxSqlServerConnectionString.Enter += textBoxSqlServerConnectionString_Enter;
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label19.ForeColor = Color.DarkGreen;
            label19.Location = new Point(463, 132);
            label19.Name = "label19";
            label19.Size = new Size(153, 15);
            label19.TabIndex = 29;
            label19.Text = "Состояние подключения";
            // 
            // buttonRefreshConnection
            // 
            buttonRefreshConnection.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRefreshConnection.ImageList = imageListSqlServerConnection;
            buttonRefreshConnection.Location = new Point(614, 126);
            buttonRefreshConnection.Name = "buttonRefreshConnection";
            buttonRefreshConnection.Size = new Size(26, 26);
            buttonRefreshConnection.TabIndex = 39;
            toolTip1.SetToolTip(buttonRefreshConnection, "Обновить подключение");
            buttonRefreshConnection.UseVisualStyleBackColor = true;
            buttonRefreshConnection.Click += buttonRefreshConnection_Click;
            // 
            // imageListSqlServerConnection
            // 
            imageListSqlServerConnection.ColorDepth = ColorDepth.Depth8Bit;
            imageListSqlServerConnection.ImageStream = (ImageListStreamer)resources.GetObject("imageListSqlServerConnection.ImageStream");
            imageListSqlServerConnection.TransparentColor = Color.Transparent;
            imageListSqlServerConnection.Images.SetKeyName(0, "ProgressWarn.ico");
            imageListSqlServerConnection.Images.SetKeyName(1, "ProgressSkip.ico");
            imageListSqlServerConnection.Images.SetKeyName(2, "ProgressError.ico");
            // 
            // treeViewSettings
            // 
            treeViewSettings.BackColor = SystemColors.Window;
            treeViewSettings.Dock = DockStyle.Fill;
            treeViewSettings.ForeColor = Color.DarkGreen;
            treeViewSettings.Location = new Point(0, 0);
            treeViewSettings.Name = "treeViewSettings";
            treeNode1.Name = "Socket0";
            treeNode1.Tag = "SocketConnectionProperty";
            treeNode1.Text = "Подключение к RT";
            treeNode1.ToolTipText = "Настройки подключения к RT ";
            treeNode2.Name = "LogRecords";
            treeNode2.Tag = "TaskProperty";
            treeNode2.Text = "Журнал логирования";
            treeNode2.ToolTipText = "Настройки журнала логирования";
            treeNode3.Name = "FiltredRecs";
            treeNode3.Tag = "TaskProperty";
            treeNode3.Text = "Результат применения фильтров";
            treeNode3.ToolTipText = "Настройки отображения отфильрованнных записей журнала логирования";
            treeNode4.Name = "TaskRecords";
            treeNode4.Tag = "TaskProperty";
            treeNode4.Text = "Статистика задач";
            treeNode4.ToolTipText = "Настройки отображения информации по статистике задач узлов и протоколов";
            treeNode5.Name = "ArchiveStat";
            treeNode5.Tag = "TaskProperty";
            treeNode5.Text = "Статистика архивирования";
            treeNode5.ToolTipText = "Настройки отображения информации по статистике архивирования";
            treeNode6.Name = "NodeTask";
            treeNode6.Text = "Настройки задач";
            treeViewSettings.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode6 });
            treeViewSettings.Size = new Size(412, 209);
            treeViewSettings.TabIndex = 41;
            treeViewSettings.TabStop = false;
            treeViewSettings.AfterSelect += treeViewSettings_AfterSelect;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(dataGridViewFilters, 0, 0);
            tableLayoutPanel1.Location = new Point(5, 34);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.Size = new Size(1067, 449);
            tableLayoutPanel1.TabIndex = 42;
            // 
            // dataGridViewFilters
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewFilters.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewFilters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewFilters.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewFilters.Dock = DockStyle.Fill;
            dataGridViewFilters.Location = new Point(3, 3);
            dataGridViewFilters.Name = "dataGridViewFilters";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridViewFilters.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewFilters.RowTemplate.Height = 25;
            dataGridViewFilters.Size = new Size(1061, 408);
            dataGridViewFilters.TabIndex = 35;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.DarkGreen;
            label3.Location = new Point(3, 9);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(72, 19);
            label3.TabIndex = 36;
            label3.Text = "Фильтры";
            // 
            // propertyGrid1
            // 
            propertyGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            propertyGrid1.Location = new Point(3, 44);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(311, 676);
            propertyGrid1.TabIndex = 14;
            propertyGrid1.PropertyValueChanged += propertyGrid1_PropertyValueChanged;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(splitContainer1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1421, 735);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Журнал";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(button_FilterLogRecords);
            splitContainer1.Panel1.Controls.Add(textBoxFilterForLogRecords);
            splitContainer1.Panel1.Controls.Add(label25);
            splitContainer1.Panel1.Controls.Add(numericUpDown_LogRecReturnRecCount);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(numericUpDown_LogRecInterval);
            splitContainer1.Panel1.Controls.Add(label18);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(checkBox_AutoRefreshLog);
            splitContainer1.Panel1.Controls.Add(dataGridViewLogRecords);
            splitContainer1.Panel1.Controls.Add(button_RefreshLogRecords);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(button_FilterFiltredRecs);
            splitContainer1.Panel2.Controls.Add(textBoxFilterForFiltredRecords);
            splitContainer1.Panel2.Controls.Add(label24);
            splitContainer1.Panel2.Controls.Add(numericUpDown_FiltredRecReturnRecCount);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(numericUpDown_FiltredRecInterval);
            splitContainer1.Panel2.Controls.Add(label17);
            splitContainer1.Panel2.Controls.Add(dataGridViewFiltredRecords);
            splitContainer1.Panel2.Controls.Add(label_FiltredRecInterval);
            splitContainer1.Panel2.Controls.Add(btnRefreshFiltredRecords);
            splitContainer1.Panel2.Controls.Add(checkBox_AutoRefreshFilter);
            splitContainer1.Size = new Size(1415, 729);
            splitContainer1.SplitterDistance = 357;
            splitContainer1.TabIndex = 4;
            // 
            // button_FilterLogRecords
            // 
            button_FilterLogRecords.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_FilterLogRecords.FlatAppearance.BorderSize = 0;
            button_FilterLogRecords.FlatAppearance.MouseDownBackColor = Color.Yellow;
            button_FilterLogRecords.FlatStyle = FlatStyle.Flat;
            button_FilterLogRecords.Image = (Image)resources.GetObject("button_FilterLogRecords.Image");
            button_FilterLogRecords.Location = new Point(1324, 18);
            button_FilterLogRecords.Margin = new Padding(0);
            button_FilterLogRecords.Name = "button_FilterLogRecords";
            button_FilterLogRecords.Size = new Size(80, 32);
            button_FilterLogRecords.TabIndex = 20;
            button_FilterLogRecords.TextAlign = ContentAlignment.TopLeft;
            button_FilterLogRecords.UseVisualStyleBackColor = true;
            button_FilterLogRecords.Click += button_FilterLogRecords_Click;
            // 
            // textBoxFilterForLogRecords
            // 
            textBoxFilterForLogRecords.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFilterForLogRecords.BackColor = Color.Black;
            textBoxFilterForLogRecords.ForeColor = Color.Chartreuse;
            textBoxFilterForLogRecords.Location = new Point(686, 23);
            textBoxFilterForLogRecords.Name = "textBoxFilterForLogRecords";
            textBoxFilterForLogRecords.Size = new Size(632, 23);
            textBoxFilterForLogRecords.TabIndex = 19;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label25.ForeColor = Color.DarkGreen;
            label25.Location = new Point(598, 25);
            label25.Name = "label25";
            label25.Size = new Size(86, 15);
            label25.TabIndex = 18;
            label25.Text = "Фильтр строк";
            // 
            // numericUpDown_LogRecReturnRecCount
            // 
            numericUpDown_LogRecReturnRecCount.BackColor = Color.Black;
            numericUpDown_LogRecReturnRecCount.ForeColor = Color.Chartreuse;
            numericUpDown_LogRecReturnRecCount.Location = new Point(499, 23);
            numericUpDown_LogRecReturnRecCount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDown_LogRecReturnRecCount.Name = "numericUpDown_LogRecReturnRecCount";
            numericUpDown_LogRecReturnRecCount.Size = new Size(82, 23);
            numericUpDown_LogRecReturnRecCount.TabIndex = 12;
            numericUpDown_LogRecReturnRecCount.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DarkGreen;
            label2.Location = new Point(453, 26);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 11;
            label2.Text = "Строк";
            // 
            // numericUpDown_LogRecInterval
            // 
            numericUpDown_LogRecInterval.BackColor = Color.Black;
            numericUpDown_LogRecInterval.ForeColor = Color.Chartreuse;
            numericUpDown_LogRecInterval.Location = new Point(354, 23);
            numericUpDown_LogRecInterval.Maximum = new decimal(new int[] { 600000, 0, 0, 0 });
            numericUpDown_LogRecInterval.Name = "numericUpDown_LogRecInterval";
            numericUpDown_LogRecInterval.Size = new Size(82, 23);
            numericUpDown_LogRecInterval.TabIndex = 10;
            numericUpDown_LogRecInterval.TextAlign = HorizontalAlignment.Center;
            numericUpDown_LogRecInterval.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label18.ForeColor = Color.DarkGreen;
            label18.Location = new Point(-2, 0);
            label18.Name = "label18";
            label18.Size = new Size(293, 15);
            label18.TabIndex = 9;
            label18.Text = "Записи логирования, зарегистрированные в БД  ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.DarkGreen;
            label6.Location = new Point(262, 27);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 8;
            label6.Text = "Интервал (мс)";
            // 
            // checkBox_AutoRefreshLog
            // 
            checkBox_AutoRefreshLog.AutoSize = true;
            checkBox_AutoRefreshLog.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox_AutoRefreshLog.ForeColor = Color.DarkGreen;
            checkBox_AutoRefreshLog.Location = new Point(122, 25);
            checkBox_AutoRefreshLog.Name = "checkBox_AutoRefreshLog";
            checkBox_AutoRefreshLog.Size = new Size(124, 19);
            checkBox_AutoRefreshLog.TabIndex = 5;
            checkBox_AutoRefreshLog.Text = "Автообновление";
            checkBox_AutoRefreshLog.UseVisualStyleBackColor = true;
            // 
            // dataGridViewLogRecords
            // 
            dataGridViewLogRecords.AllowUserToOrderColumns = true;
            dataGridViewLogRecords.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridViewLogRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewLogRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridViewLogRecords.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewLogRecords.Location = new Point(6, 50);
            dataGridViewLogRecords.Name = "dataGridViewLogRecords";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridViewLogRecords.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle7.BackColor = Color.Black;
            dataGridViewCellStyle7.ForeColor = Color.LimeGreen;
            dataGridViewLogRecords.RowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewLogRecords.RowTemplate.Height = 25;
            dataGridViewLogRecords.Size = new Size(1402, 300);
            dataGridViewLogRecords.TabIndex = 0;
            // 
            // button_RefreshLogRecords
            // 
            button_RefreshLogRecords.FlatAppearance.BorderSize = 0;
            button_RefreshLogRecords.FlatAppearance.MouseDownBackColor = Color.Yellow;
            button_RefreshLogRecords.FlatStyle = FlatStyle.Flat;
            button_RefreshLogRecords.Image = (Image)resources.GetObject("button_RefreshLogRecords.Image");
            button_RefreshLogRecords.Location = new Point(9, 15);
            button_RefreshLogRecords.Margin = new Padding(0);
            button_RefreshLogRecords.Name = "button_RefreshLogRecords";
            button_RefreshLogRecords.Size = new Size(80, 32);
            button_RefreshLogRecords.TabIndex = 1;
            button_RefreshLogRecords.UseVisualStyleBackColor = true;
            button_RefreshLogRecords.Click += button_RefreshLogRecords_Click;
            // 
            // button_FilterFiltredRecs
            // 
            button_FilterFiltredRecs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_FilterFiltredRecs.FlatAppearance.BorderSize = 0;
            button_FilterFiltredRecs.FlatAppearance.MouseDownBackColor = Color.Yellow;
            button_FilterFiltredRecs.FlatStyle = FlatStyle.Flat;
            button_FilterFiltredRecs.Image = (Image)resources.GetObject("button_FilterFiltredRecs.Image");
            button_FilterFiltredRecs.Location = new Point(1324, 28);
            button_FilterFiltredRecs.Margin = new Padding(0);
            button_FilterFiltredRecs.Name = "button_FilterFiltredRecs";
            button_FilterFiltredRecs.Size = new Size(80, 32);
            button_FilterFiltredRecs.TabIndex = 21;
            button_FilterFiltredRecs.TextAlign = ContentAlignment.TopLeft;
            button_FilterFiltredRecs.UseVisualStyleBackColor = true;
            button_FilterFiltredRecs.Click += button_FilterFiltredRecs_Click;
            // 
            // textBoxFilterForFiltredRecords
            // 
            textBoxFilterForFiltredRecords.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFilterForFiltredRecords.BackColor = Color.Black;
            textBoxFilterForFiltredRecords.ForeColor = Color.Chartreuse;
            textBoxFilterForFiltredRecords.Location = new Point(686, 34);
            textBoxFilterForFiltredRecords.Name = "textBoxFilterForFiltredRecords";
            textBoxFilterForFiltredRecords.Size = new Size(632, 23);
            textBoxFilterForFiltredRecords.TabIndex = 17;
            // 
            // label24
            // 
            label24.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label24.ForeColor = Color.DarkGreen;
            label24.Location = new Point(598, 36);
            label24.Name = "label24";
            label24.Size = new Size(86, 15);
            label24.TabIndex = 16;
            label24.Text = "Фильтр строк";
            // 
            // numericUpDown_FiltredRecReturnRecCount
            // 
            numericUpDown_FiltredRecReturnRecCount.BackColor = Color.Black;
            numericUpDown_FiltredRecReturnRecCount.ForeColor = Color.Chartreuse;
            numericUpDown_FiltredRecReturnRecCount.Location = new Point(499, 35);
            numericUpDown_FiltredRecReturnRecCount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDown_FiltredRecReturnRecCount.Name = "numericUpDown_FiltredRecReturnRecCount";
            numericUpDown_FiltredRecReturnRecCount.Size = new Size(82, 23);
            numericUpDown_FiltredRecReturnRecCount.TabIndex = 15;
            numericUpDown_FiltredRecReturnRecCount.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.DarkGreen;
            label5.Location = new Point(453, 37);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 14;
            label5.Text = "Строк";
            // 
            // numericUpDown_FiltredRecInterval
            // 
            numericUpDown_FiltredRecInterval.BackColor = Color.Black;
            numericUpDown_FiltredRecInterval.ForeColor = Color.Chartreuse;
            numericUpDown_FiltredRecInterval.Location = new Point(354, 35);
            numericUpDown_FiltredRecInterval.Maximum = new decimal(new int[] { 600000, 0, 0, 0 });
            numericUpDown_FiltredRecInterval.Name = "numericUpDown_FiltredRecInterval";
            numericUpDown_FiltredRecInterval.Size = new Size(82, 23);
            numericUpDown_FiltredRecInterval.TabIndex = 13;
            numericUpDown_FiltredRecInterval.TextAlign = HorizontalAlignment.Center;
            numericUpDown_FiltredRecInterval.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = Color.DarkGreen;
            label17.Location = new Point(6, 0);
            label17.Name = "label17";
            label17.Size = new Size(162, 15);
            label17.TabIndex = 7;
            label17.Text = "Отфильтрованные данные";
            // 
            // dataGridViewFiltredRecords
            // 
            dataGridViewFiltredRecords.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dataGridViewFiltredRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewFiltredRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Window;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dataGridViewFiltredRecords.DefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewFiltredRecords.Location = new Point(6, 63);
            dataGridViewFiltredRecords.Name = "dataGridViewFiltredRecords";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.Control;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dataGridViewFiltredRecords.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.BackColor = Color.Black;
            dataGridViewCellStyle11.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle11.ForeColor = Color.LimeGreen;
            dataGridViewFiltredRecords.RowsDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewFiltredRecords.RowTemplate.Height = 25;
            dataGridViewFiltredRecords.Size = new Size(1402, 298);
            dataGridViewFiltredRecords.TabIndex = 2;
            dataGridViewFiltredRecords.CellDoubleClick += dataGridViewFiltredRecords_CellDoubleClick;
            // 
            // label_FiltredRecInterval
            // 
            label_FiltredRecInterval.AutoSize = true;
            label_FiltredRecInterval.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label_FiltredRecInterval.ForeColor = Color.DarkGreen;
            label_FiltredRecInterval.Location = new Point(262, 36);
            label_FiltredRecInterval.Name = "label_FiltredRecInterval";
            label_FiltredRecInterval.Size = new Size(88, 15);
            label_FiltredRecInterval.TabIndex = 6;
            label_FiltredRecInterval.Text = "Интервал (мс)";
            // 
            // btnRefreshFiltredRecords
            // 
            btnRefreshFiltredRecords.FlatAppearance.BorderSize = 0;
            btnRefreshFiltredRecords.FlatAppearance.MouseDownBackColor = Color.Yellow;
            btnRefreshFiltredRecords.FlatStyle = FlatStyle.Flat;
            btnRefreshFiltredRecords.Image = (Image)resources.GetObject("btnRefreshFiltredRecords.Image");
            btnRefreshFiltredRecords.Location = new Point(6, 25);
            btnRefreshFiltredRecords.Name = "btnRefreshFiltredRecords";
            btnRefreshFiltredRecords.Size = new Size(80, 32);
            btnRefreshFiltredRecords.TabIndex = 3;
            btnRefreshFiltredRecords.UseVisualStyleBackColor = true;
            btnRefreshFiltredRecords.Click += btnRefreshFiltredRecords_Click;
            // 
            // checkBox_AutoRefreshFilter
            // 
            checkBox_AutoRefreshFilter.AutoSize = true;
            checkBox_AutoRefreshFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox_AutoRefreshFilter.ForeColor = Color.DarkGreen;
            checkBox_AutoRefreshFilter.Location = new Point(122, 35);
            checkBox_AutoRefreshFilter.Name = "checkBox_AutoRefreshFilter";
            checkBox_AutoRefreshFilter.Size = new Size(124, 19);
            checkBox_AutoRefreshFilter.TabIndex = 4;
            checkBox_AutoRefreshFilter.Text = "Автообновление";
            checkBox_AutoRefreshFilter.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(numericUpDown_TaskStatReturnRecCount);
            tabPage4.Controls.Add(label21);
            tabPage4.Controls.Add(numericUpDown_IntervalTaskStat);
            tabPage4.Controls.Add(splitContainer3);
            tabPage4.Controls.Add(splitContainer2);
            tabPage4.Controls.Add(label7);
            tabPage4.Controls.Add(checkBox_AutoRefreshTaskStat);
            tabPage4.Controls.Add(btnRefreshTaskStat);
            tabPage4.Controls.Add(dataGridViewTaskStat);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1421, 735);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Статистика";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_TaskStatReturnRecCount
            // 
            numericUpDown_TaskStatReturnRecCount.BackColor = Color.Black;
            numericUpDown_TaskStatReturnRecCount.ForeColor = Color.Chartreuse;
            numericUpDown_TaskStatReturnRecCount.Location = new Point(479, 7);
            numericUpDown_TaskStatReturnRecCount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown_TaskStatReturnRecCount.Name = "numericUpDown_TaskStatReturnRecCount";
            numericUpDown_TaskStatReturnRecCount.Size = new Size(82, 23);
            numericUpDown_TaskStatReturnRecCount.TabIndex = 22;
            numericUpDown_TaskStatReturnRecCount.TextAlign = HorizontalAlignment.Center;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            label21.ForeColor = Color.DarkGreen;
            label21.Location = new Point(433, 9);
            label21.Name = "label21";
            label21.Size = new Size(42, 13);
            label21.TabIndex = 21;
            label21.Text = "Строк";
            // 
            // numericUpDown_IntervalTaskStat
            // 
            numericUpDown_IntervalTaskStat.BackColor = Color.Black;
            numericUpDown_IntervalTaskStat.ForeColor = Color.Chartreuse;
            numericUpDown_IntervalTaskStat.Location = new Point(334, 7);
            numericUpDown_IntervalTaskStat.Maximum = new decimal(new int[] { 600000, 0, 0, 0 });
            numericUpDown_IntervalTaskStat.Minimum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown_IntervalTaskStat.Name = "numericUpDown_IntervalTaskStat";
            numericUpDown_IntervalTaskStat.Size = new Size(82, 23);
            numericUpDown_IntervalTaskStat.TabIndex = 20;
            numericUpDown_IntervalTaskStat.TextAlign = HorizontalAlignment.Center;
            numericUpDown_IntervalTaskStat.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            // 
            // splitContainer3
            // 
            splitContainer3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer3.BorderStyle = BorderStyle.Fixed3D;
            splitContainer3.Location = new Point(6, 533);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(label11);
            splitContainer3.Panel1.Controls.Add(dataGridViewTaskStatDetailU);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(chart2);
            splitContainer3.Size = new Size(1407, 196);
            splitContainer3.SplitterDistance = 630;
            splitContainer3.TabIndex = 19;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.DarkGreen;
            label11.Location = new Point(3, 0);
            label11.Name = "label11";
            label11.Size = new Size(336, 13);
            label11.TabIndex = 13;
            label11.Text = "Статистика задач объектов (U) и задач протоколов (S)";
            // 
            // dataGridViewTaskStatDetailU
            // 
            dataGridViewTaskStatDetailU.AllowUserToAddRows = false;
            dataGridViewTaskStatDetailU.AllowUserToDeleteRows = false;
            dataGridViewTaskStatDetailU.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = SystemColors.Control;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dataGridViewTaskStatDetailU.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            dataGridViewTaskStatDetailU.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTaskStatDetailU.Columns.AddRange(new DataGridViewColumn[] { id_rec, TaskIndex, CicleCount, ErrCount, AvgCicle, MinCicle, MaxCicle, AvgCicleReal, MinCicleReal, MaxCicleReal, TimeRead, TimeWork, TimeWrite, Mem });
            dataGridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = SystemColors.Window;
            dataGridViewCellStyle24.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle24.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle24.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = DataGridViewTriState.False;
            dataGridViewTaskStatDetailU.DefaultCellStyle = dataGridViewCellStyle24;
            dataGridViewTaskStatDetailU.Location = new Point(3, 18);
            dataGridViewTaskStatDetailU.Name = "dataGridViewTaskStatDetailU";
            dataGridViewTaskStatDetailU.ReadOnly = true;
            dataGridViewCellStyle25.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = SystemColors.Control;
            dataGridViewCellStyle25.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle25.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = DataGridViewTriState.True;
            dataGridViewTaskStatDetailU.RowHeadersDefaultCellStyle = dataGridViewCellStyle25;
            dataGridViewTaskStatDetailU.RowTemplate.Height = 25;
            dataGridViewTaskStatDetailU.Size = new Size(620, 171);
            dataGridViewTaskStatDetailU.TabIndex = 11;
            dataGridViewTaskStatDetailU.DataError += dataGridViewTaskStatDetailU_DataError;
            // 
            // id_rec
            // 
            id_rec.DataPropertyName = "id_rec";
            dataGridViewCellStyle13.BackColor = Color.FromArgb(224, 224, 224);
            id_rec.DefaultCellStyle = dataGridViewCellStyle13;
            id_rec.HeaderText = "Id записи";
            id_rec.Name = "id_rec";
            id_rec.ReadOnly = true;
            id_rec.Width = 75;
            // 
            // TaskIndex
            // 
            TaskIndex.DataPropertyName = "TaskIndex";
            TaskIndex.HeaderText = "Индекс задачи";
            TaskIndex.Name = "TaskIndex";
            TaskIndex.ReadOnly = true;
            TaskIndex.Width = 50;
            // 
            // CicleCount
            // 
            CicleCount.DataPropertyName = "CicleCount";
            CicleCount.HeaderText = "кол-во циклов";
            CicleCount.Name = "CicleCount";
            CicleCount.ReadOnly = true;
            CicleCount.Width = 70;
            // 
            // ErrCount
            // 
            ErrCount.DataPropertyName = "ErrCount";
            dataGridViewCellStyle14.BackColor = Color.FromArgb(255, 192, 192);
            ErrCount.DefaultCellStyle = dataGridViewCellStyle14;
            ErrCount.HeaderText = "Ошибки";
            ErrCount.Name = "ErrCount";
            ErrCount.ReadOnly = true;
            ErrCount.Width = 70;
            // 
            // AvgCicle
            // 
            AvgCicle.DataPropertyName = "AvgCicle";
            dataGridViewCellStyle15.BackColor = Color.FromArgb(192, 255, 192);
            AvgCicle.DefaultCellStyle = dataGridViewCellStyle15;
            AvgCicle.HeaderText = "среднее цикла";
            AvgCicle.Name = "AvgCicle";
            AvgCicle.ReadOnly = true;
            AvgCicle.Width = 70;
            // 
            // MinCicle
            // 
            MinCicle.DataPropertyName = "MinCicle";
            dataGridViewCellStyle16.BackColor = Color.FromArgb(192, 255, 192);
            MinCicle.DefaultCellStyle = dataGridViewCellStyle16;
            MinCicle.HeaderText = "мин.";
            MinCicle.Name = "MinCicle";
            MinCicle.ReadOnly = true;
            MinCicle.ToolTipText = "минимальное цикла";
            MinCicle.Width = 70;
            // 
            // MaxCicle
            // 
            MaxCicle.DataPropertyName = "MaxCicle";
            dataGridViewCellStyle17.BackColor = Color.FromArgb(192, 255, 192);
            MaxCicle.DefaultCellStyle = dataGridViewCellStyle17;
            MaxCicle.HeaderText = "макс.";
            MaxCicle.Name = "MaxCicle";
            MaxCicle.ReadOnly = true;
            MaxCicle.ToolTipText = "максимальное цикла";
            MaxCicle.Width = 70;
            // 
            // AvgCicleReal
            // 
            AvgCicleReal.DataPropertyName = "AvgCicleReal";
            dataGridViewCellStyle18.BackColor = Color.FromArgb(192, 255, 255);
            AvgCicleReal.DefaultCellStyle = dataGridViewCellStyle18;
            AvgCicleReal.HeaderText = "среднее цикла (факт.)";
            AvgCicleReal.Name = "AvgCicleReal";
            AvgCicleReal.ReadOnly = true;
            AvgCicleReal.ToolTipText = "среднее реального выполнения";
            AvgCicleReal.Width = 70;
            // 
            // MinCicleReal
            // 
            MinCicleReal.DataPropertyName = "MinCicleReal";
            dataGridViewCellStyle19.BackColor = Color.FromArgb(192, 255, 255);
            MinCicleReal.DefaultCellStyle = dataGridViewCellStyle19;
            MinCicleReal.HeaderText = "мин.";
            MinCicleReal.Name = "MinCicleReal";
            MinCicleReal.ReadOnly = true;
            MinCicleReal.ToolTipText = "минимальное фактическое";
            MinCicleReal.Width = 70;
            // 
            // MaxCicleReal
            // 
            MaxCicleReal.DataPropertyName = "MaxCicleReal";
            dataGridViewCellStyle20.BackColor = Color.FromArgb(192, 255, 255);
            MaxCicleReal.DefaultCellStyle = dataGridViewCellStyle20;
            MaxCicleReal.HeaderText = "макс.";
            MaxCicleReal.Name = "MaxCicleReal";
            MaxCicleReal.ReadOnly = true;
            MaxCicleReal.ToolTipText = "максимальное фактическое";
            MaxCicleReal.Width = 70;
            // 
            // TimeRead
            // 
            TimeRead.DataPropertyName = "TimeRead";
            dataGridViewCellStyle21.BackColor = Color.FromArgb(255, 255, 192);
            TimeRead.DefaultCellStyle = dataGridViewCellStyle21;
            TimeRead.HeaderText = "время чтения";
            TimeRead.Name = "TimeRead";
            TimeRead.ReadOnly = true;
            TimeRead.ToolTipText = "время чтения входных данных в последнем цикле";
            TimeRead.Width = 70;
            // 
            // TimeWork
            // 
            TimeWork.DataPropertyName = "TimeWork";
            dataGridViewCellStyle22.BackColor = Color.FromArgb(255, 255, 192);
            TimeWork.DefaultCellStyle = dataGridViewCellStyle22;
            TimeWork.HeaderText = "время вып.";
            TimeWork.Name = "TimeWork";
            TimeWork.ReadOnly = true;
            TimeWork.ToolTipText = "время выполнения задачи в последнем цикле";
            TimeWork.Width = 70;
            // 
            // TimeWrite
            // 
            TimeWrite.DataPropertyName = "TimeWrite";
            dataGridViewCellStyle23.BackColor = Color.FromArgb(255, 255, 192);
            TimeWrite.DefaultCellStyle = dataGridViewCellStyle23;
            TimeWrite.HeaderText = "время записи";
            TimeWrite.Name = "TimeWrite";
            TimeWrite.ReadOnly = true;
            TimeWrite.ToolTipText = "время записи выходных данных в последнем цикле";
            TimeWrite.Width = 70;
            // 
            // Mem
            // 
            Mem.DataPropertyName = "Mem";
            Mem.HeaderText = "объём памяти";
            Mem.Name = "Mem";
            Mem.ReadOnly = true;
            Mem.ToolTipText = "объем памяти виртуальной машины Kb - статистика задачи объектов";
            Mem.Width = 70;
            // 
            // chart2
            // 
            chart2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chart2.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart2.Legends.Add(legend1);
            chart2.Location = new Point(3, 3);
            chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Font = new Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point);
            series1.Legend = "Legend1";
            series1.LegendText = "U0";
            series1.Name = "Series1";
            series1.ToolTip = "#VAL{N0}";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chart2.Series.Add(series1);
            chart2.Size = new Size(763, 186);
            chart2.TabIndex = 6;
            chart2.Text = "chart2";
            chart2.Click += chart2_Click;
            // 
            // splitContainer2
            // 
            splitContainer2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer2.BorderStyle = BorderStyle.Fixed3D;
            splitContainer2.Location = new Point(6, 206);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(chart1);
            splitContainer2.Panel1.Controls.Add(dataGridViewTaskPrimary);
            splitContainer2.Panel1.Controls.Add(label13);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(numericUpDown_ArchStatReturnRecCount);
            splitContainer2.Panel2.Controls.Add(label22);
            splitContainer2.Panel2.Controls.Add(numericUpDown_IntervalArchStat);
            splitContainer2.Panel2.Controls.Add(label16);
            splitContainer2.Panel2.Controls.Add(dataGridViewArchStatDetail);
            splitContainer2.Panel2.Controls.Add(label15);
            splitContainer2.Panel2.Controls.Add(checkBox_AutoRefreshArchStat);
            splitContainer2.Panel2.Controls.Add(btnRefreshArchStat);
            splitContainer2.Panel2.Controls.Add(dataGridViewArchStat);
            splitContainer2.Panel2.Controls.Add(label14);
            splitContainer2.Size = new Size(1407, 321);
            splitContainer2.SplitterDistance = 704;
            splitContainer2.TabIndex = 16;
            // 
            // chart1
            // 
            chart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(3, 112);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series2.Legend = "Legend1";
            series2.LegendText = "Память процесса";
            series2.LegendToolTip = "M=<используемый объем памяти процессом>Kb";
            series2.Name = "Series1";
            series2.ToolTip = "#VAL{N0}";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chart1.Series.Add(series2);
            chart1.Size = new Size(694, 201);
            chart1.TabIndex = 5;
            chart1.Text = "chart1";
            // 
            // dataGridViewTaskPrimary
            // 
            dataGridViewTaskPrimary.AllowUserToAddRows = false;
            dataGridViewTaskPrimary.AllowUserToDeleteRows = false;
            dataGridViewTaskPrimary.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewTaskPrimary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTaskPrimary.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn2, TaskCicle, Date, Time, N, N2, ModbusRTUSlave, A, O, HR, R, MemoryUsing });
            dataGridViewTaskPrimary.Location = new Point(3, 21);
            dataGridViewTaskPrimary.Name = "dataGridViewTaskPrimary";
            dataGridViewTaskPrimary.ReadOnly = true;
            dataGridViewTaskPrimary.RowTemplate.Height = 25;
            dataGridViewTaskPrimary.Size = new Size(694, 86);
            dataGridViewTaskPrimary.TabIndex = 15;
            toolTip1.SetToolTip(dataGridViewTaskPrimary, "Каждые 10 сек отображается диагностическое сообщение со статистикой по всем задачам\r\n");
            dataGridViewTaskPrimary.DataError += dataGridViewTaskPrimary_DataError;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "id_rec";
            dataGridViewTextBoxColumn2.HeaderText = "Id записи";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 75;
            // 
            // TaskCicle
            // 
            TaskCicle.DataPropertyName = "TaskCicle";
            TaskCicle.HeaderText = "Цикл задачи";
            TaskCicle.Name = "TaskCicle";
            TaskCicle.ReadOnly = true;
            TaskCicle.ToolTipText = "Начинается с M если Master и S если Slave ";
            TaskCicle.Width = 75;
            // 
            // Date
            // 
            Date.DataPropertyName = "Date";
            Date.HeaderText = "Дата";
            Date.Name = "Date";
            Date.ReadOnly = true;
            Date.Width = 50;
            // 
            // Time
            // 
            Time.DataPropertyName = "Time";
            Time.HeaderText = "Время";
            Time.Name = "Time";
            Time.ReadOnly = true;
            Time.Width = 90;
            // 
            // N
            // 
            N.DataPropertyName = "N";
            N.HeaderText = "запр. UDP";
            N.Name = "N";
            N.ReadOnly = true;
            N.ToolTipText = resources.GetString("N.ToolTipText");
            N.Width = 90;
            // 
            // N2
            // 
            N2.DataPropertyName = "N2";
            N2.HeaderText = "запр. UDP2";
            N2.Name = "N2";
            N2.ReadOnly = true;
            N2.ToolTipText = resources.GetString("N2.ToolTipText");
            N2.Width = 50;
            // 
            // ModbusRTUSlave
            // 
            ModbusRTUSlave.DataPropertyName = "ModbusRTUSlave";
            ModbusRTUSlave.HeaderText = "Modbus RTU";
            ModbusRTUSlave.Name = "ModbusRTUSlave";
            ModbusRTUSlave.ReadOnly = true;
            ModbusRTUSlave.ToolTipText = "M =<кол-во обработанных запросов> - в случае Modbus RTU Slave задачи";
            ModbusRTUSlave.Width = 75;
            // 
            // A
            // 
            A.DataPropertyName = "A";
            A.HeaderText = "запр. HMI";
            A.Name = "A";
            A.ReadOnly = true;
            A.ToolTipText = "A =<количество обработанных запросов от HMI клиентов>";
            A.Width = 50;
            // 
            // O
            // 
            O.DataPropertyName = "O";
            O.HeaderText = "контроллер";
            O.Name = "O";
            O.ReadOnly = true;
            O.ToolTipText = "O<индекс контроллера>=<кол-во циклов>(<время последнего цикла опроса>,<общее кол-во ошибок>) - статистика задачи межузловой связи (для связи с каждым контроллером отдельная задача).";
            O.Width = 50;
            // 
            // HR
            // 
            HR.DataPropertyName = "HR";
            HR.HeaderText = "гор. рестарт";
            HR.Name = "HR";
            HR.ReadOnly = true;
            HR.ToolTipText = "HR=<кол-во сохранений горячего рестарта>(<время, затраченное на последнее сохранение>)";
            HR.Width = 70;
            // 
            // R
            // 
            R.DataPropertyName = "R";
            R.HeaderText = "резервирование";
            R.Name = "R";
            R.ReadOnly = true;
            R.ToolTipText = resources.GetString("R.ToolTipText");
            // 
            // MemoryUsing
            // 
            MemoryUsing.DataPropertyName = "MemoryUsing";
            MemoryUsing.HeaderText = "Память";
            MemoryUsing.Name = "MemoryUsing";
            MemoryUsing.ReadOnly = true;
            MemoryUsing.ToolTipText = "M=<используемый объем памяти процессом>Kb";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.DarkGreen;
            label13.Location = new Point(1, 3);
            label13.Name = "label13";
            label13.Size = new Size(113, 15);
            label13.TabIndex = 14;
            label13.Text = "Статистика задачи";
            // 
            // numericUpDown_ArchStatReturnRecCount
            // 
            numericUpDown_ArchStatReturnRecCount.BackColor = Color.Black;
            numericUpDown_ArchStatReturnRecCount.ForeColor = Color.Chartreuse;
            numericUpDown_ArchStatReturnRecCount.Location = new Point(477, 28);
            numericUpDown_ArchStatReturnRecCount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown_ArchStatReturnRecCount.Name = "numericUpDown_ArchStatReturnRecCount";
            numericUpDown_ArchStatReturnRecCount.Size = new Size(82, 23);
            numericUpDown_ArchStatReturnRecCount.TabIndex = 25;
            numericUpDown_ArchStatReturnRecCount.TextAlign = HorizontalAlignment.Center;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(431, 31);
            label22.Name = "label22";
            label22.Size = new Size(40, 15);
            label22.TabIndex = 24;
            label22.Text = "Строк";
            // 
            // numericUpDown_IntervalArchStat
            // 
            numericUpDown_IntervalArchStat.BackColor = Color.Black;
            numericUpDown_IntervalArchStat.ForeColor = Color.Chartreuse;
            numericUpDown_IntervalArchStat.Location = new Point(332, 28);
            numericUpDown_IntervalArchStat.Maximum = new decimal(new int[] { 600000, 0, 0, 0 });
            numericUpDown_IntervalArchStat.Minimum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown_IntervalArchStat.Name = "numericUpDown_IntervalArchStat";
            numericUpDown_IntervalArchStat.Size = new Size(82, 23);
            numericUpDown_IntervalArchStat.TabIndex = 23;
            numericUpDown_IntervalArchStat.TextAlign = HorizontalAlignment.Center;
            numericUpDown_IntervalArchStat.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            label16.ForeColor = Color.DarkGreen;
            label16.Location = new Point(4, 224);
            label16.Name = "label16";
            label16.Size = new Size(169, 13);
            label16.TabIndex = 22;
            label16.Text = "Статистика архивирования";
            // 
            // dataGridViewArchStatDetail
            // 
            dataGridViewArchStatDetail.AllowUserToAddRows = false;
            dataGridViewArchStatDetail.AllowUserToDeleteRows = false;
            dataGridViewArchStatDetail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle26.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = SystemColors.Control;
            dataGridViewCellStyle26.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle26.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = DataGridViewTriState.True;
            dataGridViewArchStatDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            dataGridViewArchStatDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewArchStatDetail.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn6 });
            dataGridViewCellStyle27.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = SystemColors.Window;
            dataGridViewCellStyle27.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle27.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle27.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = DataGridViewTriState.False;
            dataGridViewArchStatDetail.DefaultCellStyle = dataGridViewCellStyle27;
            dataGridViewArchStatDetail.Location = new Point(4, 242);
            dataGridViewArchStatDetail.Name = "dataGridViewArchStatDetail";
            dataGridViewArchStatDetail.ReadOnly = true;
            dataGridViewCellStyle28.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = SystemColors.Control;
            dataGridViewCellStyle28.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle28.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle28.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = DataGridViewTriState.True;
            dataGridViewArchStatDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle28;
            dataGridViewArchStatDetail.RowTemplate.Height = 25;
            dataGridViewArchStatDetail.Size = new Size(688, 71);
            dataGridViewArchStatDetail.TabIndex = 21;
            dataGridViewArchStatDetail.DataError += dataGridViewArchStatDetail_DataError;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "id_rec";
            dataGridViewTextBoxColumn6.HeaderText = "Id записи";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = Color.DarkGreen;
            label15.Location = new Point(240, 30);
            label15.Name = "label15";
            label15.Size = new Size(92, 13);
            label15.TabIndex = 20;
            label15.Text = "Интервал (мс)";
            // 
            // checkBox_AutoRefreshArchStat
            // 
            checkBox_AutoRefreshArchStat.AutoSize = true;
            checkBox_AutoRefreshArchStat.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox_AutoRefreshArchStat.ForeColor = Color.DarkGreen;
            checkBox_AutoRefreshArchStat.Location = new Point(100, 29);
            checkBox_AutoRefreshArchStat.Name = "checkBox_AutoRefreshArchStat";
            checkBox_AutoRefreshArchStat.Size = new Size(124, 17);
            checkBox_AutoRefreshArchStat.TabIndex = 18;
            checkBox_AutoRefreshArchStat.Text = "Автообновление";
            checkBox_AutoRefreshArchStat.UseVisualStyleBackColor = true;
            // 
            // btnRefreshArchStat
            // 
            btnRefreshArchStat.FlatAppearance.BorderSize = 0;
            btnRefreshArchStat.FlatAppearance.MouseDownBackColor = Color.Yellow;
            btnRefreshArchStat.FlatStyle = FlatStyle.Flat;
            btnRefreshArchStat.Image = (Image)resources.GetObject("btnRefreshArchStat.Image");
            btnRefreshArchStat.Location = new Point(3, 22);
            btnRefreshArchStat.Name = "btnRefreshArchStat";
            btnRefreshArchStat.Size = new Size(80, 32);
            btnRefreshArchStat.TabIndex = 17;
            btnRefreshArchStat.UseVisualStyleBackColor = true;
            btnRefreshArchStat.Click += btnRefreshArchStat_Click;
            // 
            // dataGridViewArchStat
            // 
            dataGridViewArchStat.AllowUserToAddRows = false;
            dataGridViewArchStat.AllowUserToDeleteRows = false;
            dataGridViewArchStat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle29.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = SystemColors.Control;
            dataGridViewCellStyle29.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle29.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle29.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = DataGridViewTriState.True;
            dataGridViewArchStat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            dataGridViewArchStat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewArchStat.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dataGridViewCellStyle30.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = SystemColors.Window;
            dataGridViewCellStyle30.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle30.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle30.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle30.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = DataGridViewTriState.False;
            dataGridViewArchStat.DefaultCellStyle = dataGridViewCellStyle30;
            dataGridViewArchStat.Location = new Point(4, 57);
            dataGridViewArchStat.Name = "dataGridViewArchStat";
            dataGridViewArchStat.ReadOnly = true;
            dataGridViewCellStyle31.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = SystemColors.Control;
            dataGridViewCellStyle31.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle31.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle31.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle31.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = DataGridViewTriState.True;
            dataGridViewArchStat.RowHeadersDefaultCellStyle = dataGridViewCellStyle31;
            dataGridViewArchStat.RowTemplate.Height = 25;
            dataGridViewArchStat.Size = new Size(688, 164);
            dataGridViewArchStat.TabIndex = 16;
            dataGridViewArchStat.DataError += dataGridViewArchStat_DataError;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "id_rec";
            dataGridViewTextBoxColumn3.HeaderText = "Id записи";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "RegDT";
            dataGridViewTextBoxColumn4.HeaderText = "время регистрации";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "LogString";
            dataGridViewTextBoxColumn5.HeaderText = "Строка информации";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.DarkGreen;
            label14.Location = new Point(4, 3);
            label14.Name = "label14";
            label14.Size = new Size(101, 15);
            label14.TabIndex = 15;
            label14.Text = "Архивирование";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.DarkGreen;
            label7.Location = new Point(242, 11);
            label7.Name = "label7";
            label7.Size = new Size(92, 13);
            label7.TabIndex = 10;
            label7.Text = "Интервал (мс)";
            // 
            // checkBox_AutoRefreshTaskStat
            // 
            checkBox_AutoRefreshTaskStat.AutoSize = true;
            checkBox_AutoRefreshTaskStat.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox_AutoRefreshTaskStat.ForeColor = Color.DarkGreen;
            checkBox_AutoRefreshTaskStat.Location = new Point(102, 11);
            checkBox_AutoRefreshTaskStat.Name = "checkBox_AutoRefreshTaskStat";
            checkBox_AutoRefreshTaskStat.Size = new Size(124, 17);
            checkBox_AutoRefreshTaskStat.TabIndex = 8;
            checkBox_AutoRefreshTaskStat.Text = "Автообновление";
            checkBox_AutoRefreshTaskStat.UseVisualStyleBackColor = true;
            // 
            // btnRefreshTaskStat
            // 
            btnRefreshTaskStat.FlatAppearance.BorderSize = 0;
            btnRefreshTaskStat.FlatAppearance.MouseDownBackColor = Color.Yellow;
            btnRefreshTaskStat.FlatStyle = FlatStyle.Flat;
            btnRefreshTaskStat.Image = (Image)resources.GetObject("btnRefreshTaskStat.Image");
            btnRefreshTaskStat.Location = new Point(3, 3);
            btnRefreshTaskStat.Name = "btnRefreshTaskStat";
            btnRefreshTaskStat.Size = new Size(80, 32);
            btnRefreshTaskStat.TabIndex = 4;
            btnRefreshTaskStat.UseVisualStyleBackColor = true;
            btnRefreshTaskStat.Click += btnRefreshTaskStat_Click;
            // 
            // dataGridViewTaskStat
            // 
            dataGridViewTaskStat.AllowUserToAddRows = false;
            dataGridViewTaskStat.AllowUserToDeleteRows = false;
            dataGridViewTaskStat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle32.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = SystemColors.Control;
            dataGridViewCellStyle32.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle32.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle32.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle32.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = DataGridViewTriState.True;
            dataGridViewTaskStat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle32;
            dataGridViewTaskStat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTaskStat.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, RegDT, LogString });
            dataGridViewCellStyle33.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = SystemColors.Window;
            dataGridViewCellStyle33.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle33.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle33.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle33.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle33.WrapMode = DataGridViewTriState.False;
            dataGridViewTaskStat.DefaultCellStyle = dataGridViewCellStyle33;
            dataGridViewTaskStat.Location = new Point(6, 36);
            dataGridViewTaskStat.Name = "dataGridViewTaskStat";
            dataGridViewTaskStat.ReadOnly = true;
            dataGridViewCellStyle34.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = SystemColors.Control;
            dataGridViewCellStyle34.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle34.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle34.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = DataGridViewTriState.True;
            dataGridViewTaskStat.RowHeadersDefaultCellStyle = dataGridViewCellStyle34;
            dataGridViewTaskStat.RowTemplate.Height = 25;
            dataGridViewTaskStat.Size = new Size(1407, 164);
            dataGridViewTaskStat.TabIndex = 0;
            dataGridViewTaskStat.DataError += dataGridViewTaskStat_DataError;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "id_rec";
            dataGridViewTextBoxColumn1.HeaderText = "Id записи";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // RegDT
            // 
            RegDT.DataPropertyName = "RegDT";
            RegDT.HeaderText = "время регистрации";
            RegDT.Name = "RegDT";
            RegDT.ReadOnly = true;
            // 
            // LogString
            // 
            LogString.DataPropertyName = "LogString";
            LogString.HeaderText = "Строка информации";
            LogString.Name = "LogString";
            LogString.ReadOnly = true;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(button_Parce);
            tabPage5.Controls.Add(textBox_ParceTRG);
            tabPage5.Controls.Add(textBox_ParceSRC);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1421, 735);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "tabPage5";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // button_Parce
            // 
            button_Parce.Location = new Point(1289, 205);
            button_Parce.Name = "button_Parce";
            button_Parce.Size = new Size(111, 23);
            button_Parce.TabIndex = 2;
            button_Parce.Text = "Разобрать";
            button_Parce.UseVisualStyleBackColor = true;
            button_Parce.Click += button_Parce_Click;
            // 
            // textBox_ParceTRG
            // 
            textBox_ParceTRG.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox_ParceTRG.Location = new Point(22, 234);
            textBox_ParceTRG.Multiline = true;
            textBox_ParceTRG.Name = "textBox_ParceTRG";
            textBox_ParceTRG.Size = new Size(1378, 484);
            textBox_ParceTRG.TabIndex = 1;
            // 
            // textBox_ParceSRC
            // 
            textBox_ParceSRC.Location = new Point(22, 30);
            textBox_ParceSRC.Multiline = true;
            textBox_ParceSRC.Name = "textBox_ParceSRC";
            textBox_ParceSRC.Size = new Size(1378, 139);
            textBox_ParceSRC.TabIndex = 0;
            // 
            // button_ImportLogFile
            // 
            button_ImportLogFile.FlatAppearance.BorderSize = 0;
            button_ImportLogFile.FlatAppearance.MouseDownBackColor = Color.Yellow;
            button_ImportLogFile.FlatStyle = FlatStyle.Flat;
            button_ImportLogFile.Image = (Image)resources.GetObject("button_ImportLogFile.Image");
            button_ImportLogFile.Location = new Point(336, 15);
            button_ImportLogFile.Margin = new Padding(0);
            button_ImportLogFile.Name = "button_ImportLogFile";
            button_ImportLogFile.Size = new Size(146, 35);
            button_ImportLogFile.TabIndex = 13;
            button_ImportLogFile.UseVisualStyleBackColor = true;
            button_ImportLogFile.Click += button_ImportLogFile_Click;
            // 
            // checkBox_Pause
            // 
            checkBox_Pause.Appearance = Appearance.Button;
            checkBox_Pause.FlatAppearance.BorderSize = 0;
            checkBox_Pause.FlatAppearance.MouseDownBackColor = Color.Yellow;
            checkBox_Pause.FlatStyle = FlatStyle.Flat;
            checkBox_Pause.Image = (Image)resources.GetObject("checkBox_Pause.Image");
            checkBox_Pause.Location = new Point(492, 15);
            checkBox_Pause.Margin = new Padding(0);
            checkBox_Pause.Name = "checkBox_Pause";
            checkBox_Pause.Size = new Size(146, 35);
            checkBox_Pause.TabIndex = 40;
            checkBox_Pause.UseVisualStyleBackColor = true;
            checkBox_Pause.CheckedChanged += checkBox_Pause_CheckedChanged;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // timer2
            // 
            timer2.Tick += timer2_Tick;
            // 
            // toolTip1
            // 
            toolTip1.AutoPopDelay = 15000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 100;
            // 
            // timer3
            // 
            timer3.Tick += timer3_Tick;
            // 
            // label10
            // 
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.ControlDark;
            label10.Image = (Image)resources.GetObject("label10.Image");
            label10.ImageAlign = ContentAlignment.TopLeft;
            label10.Location = new Point(5, 9);
            label10.Name = "label10";
            label10.Size = new Size(385, 41);
            label10.TabIndex = 36;
            label10.Text = " ";
            // 
            // timer4
            // 
            timer4.Tick += timer4_Tick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // timer5
            // 
            timer5.Interval = 1000;
            timer5.Tick += timer5_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1437, 823);
            Controls.Add(button_ImportLogFile);
            Controls.Add(label10);
            Controls.Add(tabControl1);
            Controls.Add(checkBox_Pause);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Разбор лога";
            FormClosing += MainForm_FormClosing;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Port).EndInit();
            tabPage2.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            splitContainerSettings.Panel1.ResumeLayout(false);
            splitContainerSettings.Panel2.ResumeLayout(false);
            splitContainerSettings.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerSettings).EndInit();
            splitContainerSettings.ResumeLayout(false);
            splitContainer5.Panel1.ResumeLayout(false);
            splitContainer5.Panel1.PerformLayout();
            splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
            splitContainer5.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewFilters).EndInit();
            tabPage3.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown_LogRecReturnRecCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_LogRecInterval).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLogRecords).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_FiltredRecReturnRecCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_FiltredRecInterval).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiltredRecords).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_TaskStatReturnRecCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_IntervalTaskStat).EndInit();
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewTaskStatDetailU).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTaskPrimary).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_ArchStatReturnRecCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_IntervalArchStat).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArchStatDetail).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArchStat).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTaskStat).EndInit();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox textBox_IPAdr;
        private TextBox tbStatus;
        private Label label4;
        private TextBox textBox_Command;
        private Button btnConnectThread;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnStopThread;
        private Button btnSendCoomandToThread;
        private TabPage tabPage3;
        private DataGridView dataGridViewLogRecords;
        private Button button_RefreshLogRecords;
        private Button btnRefreshFiltredRecords;
        private DataGridView dataGridViewFiltredRecords;
        private SplitContainer splitContainer1;
        private CheckBox checkBox_AutoRefreshFilter;
        private CheckBox checkBox_AutoRefreshLog;
        private TabPage tabPage4;
        private DataGridView dataGridViewTaskStat;
        private Button btnRefreshTaskStat;
        private CheckBox checkBox_AutoRefreshMonitor;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Label label_FiltredRecInterval;
        private Label label6;
        private ToolTip toolTip1;
        private Label label7;
        private CheckBox checkBox_AutoRefreshTaskStat;
        private System.Windows.Forms.Timer timer3;
        private CheckBox checkBox_Pause;
        private Label label8;
        private Label label9;
        private Label label10;
        private DataGridView dataGridViewTaskStatDetailS;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn RegDT;
        private DataGridViewTextBoxColumn LogString;
        private System.Windows.Forms.Timer timer4;
        private SplitContainer splitContainer2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private DataGridView dataGridViewTaskPrimary;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn TaskCicle;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn N;
        private DataGridViewTextBoxColumn N2;
        private DataGridViewTextBoxColumn ModbusRTUSlave;
        private DataGridViewTextBoxColumn A;
        private DataGridViewTextBoxColumn O;
        private DataGridViewTextBoxColumn HR;
        private DataGridViewTextBoxColumn R;
        private DataGridViewTextBoxColumn MemoryUsing;
        private Label label13;
        private Label label15;
        private CheckBox checkBox_AutoRefreshArchStat;
        private Button btnRefreshArchStat;
        private DataGridView dataGridViewArchStat;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Label label14;
        private Label label16;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridView dataGridViewArchStatDetail;
        private PropertyGrid propertyGrid1;
        private SplitContainer splitContainer3;
        private Label label11;
        private DataGridView dataGridViewTaskStatDetailU;
        private DataGridViewTextBoxColumn id_rec;
        private DataGridViewTextBoxColumn TaskIndex;
        private DataGridViewTextBoxColumn CicleCount;
        private DataGridViewTextBoxColumn ErrCount;
        private DataGridViewTextBoxColumn AvgCicle;
        private DataGridViewTextBoxColumn MinCicle;
        private DataGridViewTextBoxColumn MaxCicle;
        private DataGridViewTextBoxColumn AvgCicleReal;
        private DataGridViewTextBoxColumn MinCicleReal;
        private DataGridViewTextBoxColumn MaxCicleReal;
        private DataGridViewTextBoxColumn TimeRead;
        private DataGridViewTextBoxColumn TimeWork;
        private DataGridViewTextBoxColumn TimeWrite;
        private DataGridViewTextBoxColumn Mem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private Label label18;
        private Label label17;
        private SplitContainer splitContainer4;
        private SplitContainer splitContainerSettings;
        private Button buttonRefreshConnection;
        private TextBox textBoxApplicationName;
        private Label label5;
        private TextBox textBoxDataSource;
        private Label label2;
        private TextBox textBoxInitialCatalog;
        private Label label1;
        private CheckBox checkBoxConnectionDB;
        private CheckBox checkBox_SqlServerConnectionString;
        private TextBox textBoxSqlServerConnectionString;
        private Label label19;
        private Label label3;
        private DataGridView dataGridViewFilters;
        private ImageList imageListSqlServerConnection;
        private SplitContainer splitContainer5;
        private TreeView treeView1;
        private TreeView treeViewSettings;
        private Label label20;
        private NumericUpDown numericUpDown_Port;
        private ContextMenuStrip contextMenuStrip1;
        private NumericUpDown numericUpDown_LogRecInterval;
        private NumericUpDown numericUpDown_LogRecReturnRecCount;
        private NumericUpDown numericUpDown_FiltredRecReturnRecCount;
        private NumericUpDown numericUpDown_FiltredRecInterval;
        private NumericUpDown numericUpDown_TaskStatReturnRecCount;
        private Label label21;
        private NumericUpDown numericUpDown_IntervalTaskStat;
        private NumericUpDown numericUpDown_ArchStatReturnRecCount;
        private Label label22;
        private NumericUpDown numericUpDown_IntervalArchStat;
        private Label label23;
        private TextBox textBoxSqlServerError;
        private Button button_ImportLogFile;
        private System.Windows.Forms.Timer timer5;
        private Label label24;
        private TextBox textBoxFilterForFiltredRecords;
        private TextBox textBoxFilterForLogRecords;
        private Label label25;
        private Button button_FilterLogRecords;
        private Button button_FilterFiltredRecs;
        private TableLayoutPanel tableLayoutPanel1;
        private ImageList imageList1;
        private Button button_OpenConnectionProperty;
        private TabPage tabPage5;
        private Button button_Parce;
        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox textBox_ParceTRG;
        private TextBox textBox_ParceSRC;
    }
}
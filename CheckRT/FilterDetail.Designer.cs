namespace CheckRT
{
    partial class FilterDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterDetail));
            Label_id_filter = new Label();
            textBox_id_filter = new TextBox();
            label1 = new Label();
            textBox_FilterName = new TextBox();
            textBox_Descr = new TextBox();
            label2 = new Label();
            checkBox_Active = new CheckBox();
            textBox_FilterAssembly = new TextBox();
            label3 = new Label();
            button_FileDialogOpen = new Button();
            openFileDialog1 = new OpenFileDialog();
            tableLayoutPanel1 = new TableLayoutPanel();
            dataGridViewFilterSettings = new DataGridView();
            id_rec = new DataGridViewTextBoxColumn();
            id_filter = new DataGridViewTextBoxColumn();
            FilterString = new DataGridViewTextBoxColumn();
            Active = new DataGridViewCheckBoxColumn();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel1 = new Panel();
            button_Ok = new Button();
            button_Cancel = new Button();
            imageList1 = new ImageList(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFilterSettings).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Label_id_filter
            // 
            Label_id_filter.AutoSize = true;
            Label_id_filter.Location = new Point(98, 15);
            Label_id_filter.Name = "Label_id_filter";
            Label_id_filter.Size = new Size(46, 15);
            Label_id_filter.TabIndex = 0;
            Label_id_filter.Text = "id_filter";
            // 
            // textBox_id_filter
            // 
            textBox_id_filter.Enabled = false;
            textBox_id_filter.Location = new Point(158, 12);
            textBox_id_filter.Name = "textBox_id_filter";
            textBox_id_filter.Size = new Size(79, 23);
            textBox_id_filter.TabIndex = 0;
            textBox_id_filter.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 44);
            label1.Name = "label1";
            label1.Size = new Size(140, 15);
            label1.TabIndex = 2;
            label1.Text = "Наименование фильтра";
            // 
            // textBox_FilterName
            // 
            textBox_FilterName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_FilterName.Location = new Point(158, 41);
            textBox_FilterName.Name = "textBox_FilterName";
            textBox_FilterName.Size = new Size(777, 23);
            textBox_FilterName.TabIndex = 1;
            // 
            // textBox_Descr
            // 
            textBox_Descr.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Descr.Location = new Point(158, 70);
            textBox_Descr.Multiline = true;
            textBox_Descr.Name = "textBox_Descr";
            textBox_Descr.Size = new Size(777, 53);
            textBox_Descr.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(82, 73);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 4;
            label2.Text = "Описание";
            // 
            // checkBox_Active
            // 
            checkBox_Active.AutoSize = true;
            checkBox_Active.Location = new Point(158, 129);
            checkBox_Active.Name = "checkBox_Active";
            checkBox_Active.Size = new Size(89, 19);
            checkBox_Active.TabIndex = 3;
            checkBox_Active.Text = "Активность";
            checkBox_Active.UseVisualStyleBackColor = true;
            // 
            // textBox_FilterAssembly
            // 
            textBox_FilterAssembly.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_FilterAssembly.Location = new Point(158, 154);
            textBox_FilterAssembly.Name = "textBox_FilterAssembly";
            textBox_FilterAssembly.Size = new Size(740, 23);
            textBox_FilterAssembly.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 157);
            label3.Name = "label3";
            label3.Size = new Size(134, 15);
            label3.TabIndex = 7;
            label3.Text = "Подключаемая сборка";
            // 
            // button_FileDialogOpen
            // 
            button_FileDialogOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_FileDialogOpen.Location = new Point(904, 153);
            button_FileDialogOpen.Name = "button_FileDialogOpen";
            button_FileDialogOpen.Size = new Size(31, 24);
            button_FileDialogOpen.TabIndex = 9;
            button_FileDialogOpen.Text = "***";
            button_FileDialogOpen.TextAlign = ContentAlignment.BottomCenter;
            button_FileDialogOpen.UseVisualStyleBackColor = true;
            button_FileDialogOpen.Click += button_FileDialogOpen_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "dll";
            openFileDialog1.FileName = "МояСборкаДляРазбора";
            openFileDialog1.Filter = "C# dll files|*.dll|Все файлы|*.*";
            openFileDialog1.Title = "Выбор файла сборки для разбора строки лога";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(dataGridViewFilterSettings, 0, 0);
            tableLayoutPanel1.Location = new Point(2, 239);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(951, 269);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // dataGridViewFilterSettings
            // 
            dataGridViewFilterSettings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFilterSettings.Columns.AddRange(new DataGridViewColumn[] { id_rec, id_filter, FilterString, Active });
            dataGridViewFilterSettings.Dock = DockStyle.Fill;
            dataGridViewFilterSettings.Location = new Point(3, 3);
            dataGridViewFilterSettings.Name = "dataGridViewFilterSettings";
            dataGridViewFilterSettings.RowTemplate.Height = 25;
            dataGridViewFilterSettings.Size = new Size(945, 233);
            dataGridViewFilterSettings.TabIndex = 1000;
            dataGridViewFilterSettings.TabStop = false;
            dataGridViewFilterSettings.DataError += dataGridViewFilterSettings_DataError;
            dataGridViewFilterSettings.Enter += dataGridViewFilterSettings_Enter;
            // 
            // id_rec
            // 
            id_rec.DataPropertyName = "id_rec";
            id_rec.HeaderText = "Id записи";
            id_rec.Name = "id_rec";
            // 
            // id_filter
            // 
            id_filter.DataPropertyName = "id_filter";
            id_filter.HeaderText = "Id фильтра";
            id_filter.Name = "id_filter";
            // 
            // FilterString
            // 
            FilterString.DataPropertyName = "FilterString";
            FilterString.HeaderText = "Настройка фильтра";
            FilterString.Name = "FilterString";
            // 
            // Active
            // 
            Active.DataPropertyName = "Active";
            Active.HeaderText = "Активность";
            Active.Name = "Active";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Location = new Point(5, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel2.Size = new Size(946, 230);
            tableLayoutPanel2.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox_id_filter);
            panel1.Controls.Add(Label_id_filter);
            panel1.Controls.Add(button_FileDialogOpen);
            panel1.Controls.Add(textBox_FilterName);
            panel1.Controls.Add(textBox_FilterAssembly);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox_Descr);
            panel1.Controls.Add(checkBox_Active);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(940, 189);
            panel1.TabIndex = 0;
            // 
            // button_Ok
            // 
            button_Ok.DialogResult = DialogResult.OK;
            button_Ok.Location = new Point(2, 514);
            button_Ok.Name = "button_Ok";
            button_Ok.Size = new Size(102, 23);
            button_Ok.TabIndex = 12;
            button_Ok.Text = "Ок";
            button_Ok.UseVisualStyleBackColor = true;
            button_Ok.Click += button_Ok_Click;
            // 
            // button_Cancel
            // 
            button_Cancel.DialogResult = DialogResult.Cancel;
            button_Cancel.Location = new Point(110, 514);
            button_Cancel.Name = "button_Cancel";
            button_Cancel.Size = new Size(102, 23);
            button_Cancel.TabIndex = 13;
            button_Cancel.Text = "Отмена";
            button_Cancel.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "ProgressSkip.ico");
            imageList1.Images.SetKeyName(1, "pencil_106685.png");
            imageList1.Images.SetKeyName(2, "sync.ico");
            // 
            // FilterDetail
            // 
            AcceptButton = button_Ok;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button_Cancel;
            ClientSize = new Size(954, 539);
            Controls.Add(button_Cancel);
            Controls.Add(button_Ok);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Name = "FilterDetail";
            Text = "FilterDetail";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewFilterSettings).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label Label_id_filter;
        private TextBox textBox_id_filter;
        private Label label1;
        private TextBox textBox_FilterName;
        private TextBox textBox_Descr;
        private Label label2;
        private CheckBox checkBox_Active;
        private TextBox textBox_FilterAssembly;
        private Label label3;
        private Button button_FileDialogOpen;
        private OpenFileDialog openFileDialog1;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGridViewFilterSettings;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private Button button_Ok;
        private Button button_Cancel;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ImageList imageList1;
        private DataGridViewTextBoxColumn id_rec;
        private DataGridViewTextBoxColumn id_filter;
        private DataGridViewTextBoxColumn FilterString;
        private DataGridViewCheckBoxColumn Active;
    }
}
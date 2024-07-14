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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterDetail));
            this.Label_id_filter = new System.Windows.Forms.Label();
            this.textBox_id_filter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_FilterName = new System.Windows.Forms.TextBox();
            this.textBox_Descr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_Active = new System.Windows.Forms.CheckBox();
            this.textBox_FilterAssembly = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_FileDialogOpen = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewFilterSettings = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Ok = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.id_rec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_filter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilterString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilterSettings)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label_id_filter
            // 
            this.Label_id_filter.AutoSize = true;
            this.Label_id_filter.Location = new System.Drawing.Point(98, 15);
            this.Label_id_filter.Name = "Label_id_filter";
            this.Label_id_filter.Size = new System.Drawing.Size(46, 15);
            this.Label_id_filter.TabIndex = 0;
            this.Label_id_filter.Text = "id_filter";
            // 
            // textBox_id_filter
            // 
            this.textBox_id_filter.Enabled = false;
            this.textBox_id_filter.Location = new System.Drawing.Point(158, 12);
            this.textBox_id_filter.Name = "textBox_id_filter";
            this.textBox_id_filter.Size = new System.Drawing.Size(79, 23);
            this.textBox_id_filter.TabIndex = 0;
            this.textBox_id_filter.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Наименование фильтра";
            // 
            // textBox_FilterName
            // 
            this.textBox_FilterName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_FilterName.Location = new System.Drawing.Point(158, 41);
            this.textBox_FilterName.Name = "textBox_FilterName";
            this.textBox_FilterName.Size = new System.Drawing.Size(777, 23);
            this.textBox_FilterName.TabIndex = 1;
            // 
            // textBox_Descr
            // 
            this.textBox_Descr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Descr.Location = new System.Drawing.Point(158, 70);
            this.textBox_Descr.Multiline = true;
            this.textBox_Descr.Name = "textBox_Descr";
            this.textBox_Descr.Size = new System.Drawing.Size(777, 53);
            this.textBox_Descr.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Описание";
            // 
            // checkBox_Active
            // 
            this.checkBox_Active.AutoSize = true;
            this.checkBox_Active.Location = new System.Drawing.Point(158, 129);
            this.checkBox_Active.Name = "checkBox_Active";
            this.checkBox_Active.Size = new System.Drawing.Size(89, 19);
            this.checkBox_Active.TabIndex = 3;
            this.checkBox_Active.Text = "Активность";
            this.checkBox_Active.UseVisualStyleBackColor = true;
            // 
            // textBox_FilterAssembly
            // 
            this.textBox_FilterAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_FilterAssembly.Location = new System.Drawing.Point(158, 154);
            this.textBox_FilterAssembly.Name = "textBox_FilterAssembly";
            this.textBox_FilterAssembly.Size = new System.Drawing.Size(740, 23);
            this.textBox_FilterAssembly.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Подключаемая сборка";
            // 
            // button_FileDialogOpen
            // 
            this.button_FileDialogOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_FileDialogOpen.Location = new System.Drawing.Point(904, 153);
            this.button_FileDialogOpen.Name = "button_FileDialogOpen";
            this.button_FileDialogOpen.Size = new System.Drawing.Size(31, 24);
            this.button_FileDialogOpen.TabIndex = 9;
            this.button_FileDialogOpen.Text = "***";
            this.button_FileDialogOpen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_FileDialogOpen.UseVisualStyleBackColor = true;
            this.button_FileDialogOpen.Click += new System.EventHandler(this.button_FileDialogOpen_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "dll";
            this.openFileDialog1.FileName = "МояСборкаДляРазбора";
            this.openFileDialog1.Filter = "C# dll files|*.dll|Все файлы|*.*";
            this.openFileDialog1.Title = "Выбор файла сборки для разбора строки лога";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewFilterSettings, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 239);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(951, 269);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // dataGridViewFilterSettings
            // 
            this.dataGridViewFilterSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFilterSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_rec,
            this.id_filter,
            this.FilterString,
            this.Active});
            this.dataGridViewFilterSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFilterSettings.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewFilterSettings.Name = "dataGridViewFilterSettings";
            this.dataGridViewFilterSettings.RowTemplate.Height = 25;
            this.dataGridViewFilterSettings.Size = new System.Drawing.Size(945, 233);
            this.dataGridViewFilterSettings.TabIndex = 1000;
            this.dataGridViewFilterSettings.TabStop = false;
            this.dataGridViewFilterSettings.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewFilterSettings_DataError);
            this.dataGridViewFilterSettings.Enter += new System.EventHandler(this.dataGridViewFilterSettings_Enter);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(946, 230);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_id_filter);
            this.panel1.Controls.Add(this.Label_id_filter);
            this.panel1.Controls.Add(this.button_FileDialogOpen);
            this.panel1.Controls.Add(this.textBox_FilterName);
            this.panel1.Controls.Add(this.textBox_FilterAssembly);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_Descr);
            this.panel1.Controls.Add(this.checkBox_Active);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 189);
            this.panel1.TabIndex = 0;
            // 
            // button_Ok
            // 
            this.button_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Ok.Location = new System.Drawing.Point(2, 514);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(102, 23);
            this.button_Ok.TabIndex = 12;
            this.button_Ok.Text = "Ок";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(110, 514);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(102, 23);
            this.button_Cancel.TabIndex = 13;
            this.button_Cancel.Text = "Отмена";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ProgressSkip.ico");
            this.imageList1.Images.SetKeyName(1, "pencil_106685.png");
            this.imageList1.Images.SetKeyName(2, "sync.ico");
            // 
            // id_rec
            // 
            this.id_rec.DataPropertyName = "id_rec";
            this.id_rec.HeaderText = "id_rec";
            this.id_rec.Name = "id_rec";
            // 
            // id_filter
            // 
            this.id_filter.DataPropertyName = "id_filter";
            this.id_filter.HeaderText = "id_filter";
            this.id_filter.Name = "id_filter";
            // 
            // FilterString
            // 
            this.FilterString.DataPropertyName = "FilterString";
            this.FilterString.HeaderText = "FilterString";
            this.FilterString.Name = "FilterString";
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            // 
            // FilterDetail
            // 
            this.AcceptButton = this.button_Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(954, 539);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FilterDetail";
            this.Text = "FilterDetail";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilterSettings)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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
namespace CheckRT
{
    partial class FilterSettingDetail
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
            textBox_id_rec = new TextBox();
            Label_id_rec = new Label();
            textBox_id_filter = new TextBox();
            label1 = new Label();
            textBox_FilterString = new TextBox();
            label_FilterString = new Label();
            checkBox_Active = new CheckBox();
            button_Cancel = new Button();
            button_Ok = new Button();
            textBox_CheckResult = new TextBox();
            label2 = new Label();
            button_Check = new Button();
            label3 = new Label();
            comboBox_UsingFreeText = new ComboBox();
            SuspendLayout();
            // 
            // textBox_id_rec
            // 
            textBox_id_rec.Enabled = false;
            textBox_id_rec.Location = new Point(132, 12);
            textBox_id_rec.Name = "textBox_id_rec";
            textBox_id_rec.Size = new Size(77, 23);
            textBox_id_rec.TabIndex = 1;
            textBox_id_rec.TabStop = false;
            // 
            // Label_id_rec
            // 
            Label_id_rec.AutoSize = true;
            Label_id_rec.Location = new Point(88, 15);
            Label_id_rec.Name = "Label_id_rec";
            Label_id_rec.Size = new Size(38, 15);
            Label_id_rec.TabIndex = 2;
            Label_id_rec.Text = "id_rec";
            // 
            // textBox_id_filter
            // 
            textBox_id_filter.Enabled = false;
            textBox_id_filter.Location = new Point(132, 41);
            textBox_id_filter.Name = "textBox_id_filter";
            textBox_id_filter.Size = new Size(77, 23);
            textBox_id_filter.TabIndex = 3;
            textBox_id_filter.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(80, 44);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 4;
            label1.Text = "id_filter";
            // 
            // textBox_FilterString
            // 
            textBox_FilterString.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_FilterString.Location = new Point(132, 70);
            textBox_FilterString.Multiline = true;
            textBox_FilterString.Name = "textBox_FilterString";
            textBox_FilterString.Size = new Size(724, 94);
            textBox_FilterString.TabIndex = 5;
            textBox_FilterString.TabStop = false;
            // 
            // label_FilterString
            // 
            label_FilterString.AutoSize = true;
            label_FilterString.Location = new Point(10, 73);
            label_FilterString.Name = "label_FilterString";
            label_FilterString.Size = new Size(116, 15);
            label_FilterString.TabIndex = 6;
            label_FilterString.Text = "Настройка фильтра";
            // 
            // checkBox_Active
            // 
            checkBox_Active.AutoSize = true;
            checkBox_Active.Location = new Point(699, 11);
            checkBox_Active.Name = "checkBox_Active";
            checkBox_Active.Size = new Size(89, 19);
            checkBox_Active.TabIndex = 9;
            checkBox_Active.Text = "Активность";
            checkBox_Active.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            button_Cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Cancel.DialogResult = DialogResult.Cancel;
            button_Cancel.Location = new Point(118, 522);
            button_Cancel.Name = "button_Cancel";
            button_Cancel.Size = new Size(102, 23);
            button_Cancel.TabIndex = 15;
            button_Cancel.Text = "Отмена";
            button_Cancel.UseVisualStyleBackColor = true;
            // 
            // button_Ok
            // 
            button_Ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Ok.DialogResult = DialogResult.OK;
            button_Ok.Location = new Point(10, 522);
            button_Ok.Name = "button_Ok";
            button_Ok.Size = new Size(102, 23);
            button_Ok.TabIndex = 14;
            button_Ok.Text = "Ок";
            button_Ok.UseVisualStyleBackColor = true;
            // 
            // textBox_CheckResult
            // 
            textBox_CheckResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox_CheckResult.Location = new Point(132, 268);
            textBox_CheckResult.Multiline = true;
            textBox_CheckResult.Name = "textBox_CheckResult";
            textBox_CheckResult.ScrollBars = ScrollBars.Both;
            textBox_CheckResult.Size = new Size(724, 231);
            textBox_CheckResult.TabIndex = 16;
            textBox_CheckResult.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 268);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 17;
            label2.Text = "Результат";
            // 
            // button_Check
            // 
            button_Check.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Check.Location = new Point(767, 239);
            button_Check.Name = "button_Check";
            button_Check.Size = new Size(89, 23);
            button_Check.TabIndex = 18;
            button_Check.Text = "Проверить";
            button_Check.UseVisualStyleBackColor = true;
            button_Check.Click += button_Check_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 173);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 20;
            label3.Text = "Тип фильтра";
            // 
            // comboBox_UsingFreeText
            // 
            comboBox_UsingFreeText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox_UsingFreeText.FormattingEnabled = true;
            comboBox_UsingFreeText.Location = new Point(132, 170);
            comboBox_UsingFreeText.Name = "comboBox_UsingFreeText";
            comboBox_UsingFreeText.Size = new Size(724, 23);
            comboBox_UsingFreeText.TabIndex = 21;
            // 
            // FilterSettingDetail
            // 
            AcceptButton = button_Ok;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button_Cancel;
            ClientSize = new Size(868, 557);
            Controls.Add(comboBox_UsingFreeText);
            Controls.Add(label3);
            Controls.Add(button_Check);
            Controls.Add(label2);
            Controls.Add(textBox_CheckResult);
            Controls.Add(button_Cancel);
            Controls.Add(button_Ok);
            Controls.Add(checkBox_Active);
            Controls.Add(textBox_FilterString);
            Controls.Add(label_FilterString);
            Controls.Add(textBox_id_filter);
            Controls.Add(label1);
            Controls.Add(textBox_id_rec);
            Controls.Add(Label_id_rec);
            Name = "FilterSettingDetail";
            Text = "FilterSettingDetail";
            Load += FilterSettingDetail_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_id_rec;
        private Label Label_id_rec;
        private TextBox textBox_id_filter;
        private Label label1;
        private TextBox textBox_FilterString;
        private Label label_FilterString;
        private CheckBox checkBox_Active;
        private Button button_Cancel;
        private Button button_Ok;
        private TextBox textBox2;
        private Label label2;
        private Button button_Check;
        private Label label3;
        private ComboBox comboBox1;
        private ComboBox comboBox_UsingFreeText;
        private TextBox textBox_CheckResult;
    }
}
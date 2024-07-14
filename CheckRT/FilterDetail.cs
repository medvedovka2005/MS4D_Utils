using CheckRT.PropertyClasses;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckRT
{
    public partial class FilterDetail : Form
    {

        BindingSource m_masterBindingSource;
        BindingSource m_detailsBindingSource;
        BindingNavigator detailsNavigator = new();
        

        DataTable tbFilterTypes = new DataTable("FilterTypes");

        public FilterDetail()
        {
            InitializeComponent();
            SetFilterTypesSource();
        }

        private void SetFilterTypesSource()
        {

            DataColumn clm1 = new("UsingType", typeof(byte));
            tbFilterTypes.Columns.Add(clm1);
            DataColumn clm2 = new("TypeName", typeof(string));
            tbFilterTypes.Columns.Add(clm2);

            DataRow rw1 = tbFilterTypes.NewRow();
            rw1[0] = 0;
            rw1[1] = "CONTAIN - Поиск точных или нечетких (менее точных) совпадений с отдельными словами и фразами";
            tbFilterTypes.Rows.Add(rw1);

            DataRow rw2 = tbFilterTypes.NewRow();
            rw2[0] = 1;
            rw2[1] = "FREETEXT - Поиск значений, которые соответствуют значению, а не просто точной формулировке слов в условии поиска";
            tbFilterTypes.Rows.Add(rw2);

            DataRow rw3 = tbFilterTypes.NewRow();
            rw3[0] = 2;
            rw3[1] = "LIKE - Поиск по соответствию символьной строки указанному шаблону";
            tbFilterTypes.Rows.Add(rw3);
        }


        public void EditDetail(BindingSource masterBindingSource, BindingSource detailsBindingSource)
        {
            m_masterBindingSource = masterBindingSource;
            m_detailsBindingSource = detailsBindingSource;

            detailsNavigator = new BindingNavigator(detailsBindingSource);


            textBox_id_filter.DataBindings.Add(new Binding("Text", this.m_masterBindingSource, "id_filter", true));
            textBox_FilterName.DataBindings.Add(new Binding("Text", this.m_masterBindingSource, "FilterName", true));
            textBox_Descr.DataBindings.Add(new Binding("Text", this.m_masterBindingSource, "Descr", true));
            checkBox_Active.DataBindings.Add(new Binding("Checked", this.m_masterBindingSource, "Active", true));
            textBox_FilterAssembly.DataBindings.Add(new Binding("Text", this.m_masterBindingSource, "FilterAssembly", true));


            DataGridViewComboBoxColumn comboBox_UsingFreeText = new();
            comboBox_UsingFreeText.DataSource = tbFilterTypes;
            comboBox_UsingFreeText.ValueMember = "UsingType";
            comboBox_UsingFreeText.DisplayMember = "TypeName";
            comboBox_UsingFreeText.DataPropertyName = "UsingFreeText";
            dataGridViewFilterSettings.Columns.Add(comboBox_UsingFreeText);


            dataGridViewFilterSettings.Columns[0].Width = 50;
            dataGridViewFilterSettings.Columns[1].Width = 75;
            dataGridViewFilterSettings.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewFilterSettings.Columns[3].Width = 75;
            dataGridViewFilterSettings.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //Заголовки
            //dataGridViewFilterSettings.Columns[0].HeaderText = "Id записи";
            //dataGridViewFilterSettings.Columns[1].HeaderText = "Id фильтра";
            //dataGridViewFilterSettings.Columns[2].HeaderText = "Настройка фильтра";
            //dataGridViewFilterSettings.Columns[3].HeaderText = "Активность";
            dataGridViewFilterSettings.Columns[4].HeaderText = "Тип фильтра";

            dataGridViewFilterSettings.AutoGenerateColumns = false;
            dataGridViewFilterSettings.DataSource = m_detailsBindingSource;

            tableLayoutPanel1.Controls.Add(detailsNavigator);


            ToolStripItem SaveItem = new ToolStripButton();
            SaveItem.ToolTipText = "Сохранить";
            SaveItem.Name = "bindingNavigatorSaveItem";
            SaveItem.Image = imageList1.Images[0];
            detailsNavigator.Items.Add(SaveItem);

            ToolStripItem RefreshItem = new ToolStripButton();
            RefreshItem.ToolTipText = "Обновить";
            RefreshItem.Name = "bindingNavigatorRefreshItem";
            RefreshItem.Image = imageList1.Images[2];
            RefreshItem.Click += bindingNavigatorRefreshItem_Click;
            detailsNavigator.Items.Add(RefreshItem);

            ToolStripItem EditItem = new ToolStripButton();
            EditItem.ToolTipText = "Изменить";
            EditItem.Name = "bindingNavigatorEditItem";
            EditItem.Image = imageList1.Images[1];
            EditItem.Click += bindingNavigatorEditItem_Click;
            detailsNavigator.Items.Add(EditItem);


            detailsNavigator.Items["bindingNavigatorAddNewItem"].Click += bindingNavigatorAddNewItem_Click;
            detailsNavigator.Items["bindingNavigatorSaveItem"].Click += bindingNavigatorSaveItem_Click;
        }

        /// <summary>
        /// кнопка добавить
        /// </summary>
        private void bindingNavigatorAddNewItem_Click(object? sender, EventArgs e)
        {

            FilterSettingDetail form = new FilterSettingDetail();
            form.EditDetail(m_detailsBindingSource, tbFilterTypes);
            form.Icon = this.Icon;
            form.Text = "Добавление фильтра";
            DialogResult res = form.ShowDialog();

            if (res == DialogResult.OK)
            {

                m_detailsBindingSource.EndEdit();
            }
            else
            {
                m_detailsBindingSource.CancelEdit();
            }

        }

        /// <summary>
        /// кнопка сохранить
        /// </summary>
        private void bindingNavigatorSaveItem_Click(object? sender, EventArgs e)
        {
            m_detailsBindingSource.EndEdit();
        }

        /// <summary>
        /// кнопка обновить
        /// </summary>
        private void bindingNavigatorRefreshItem_Click(object? sender, EventArgs e)
        {
            m_detailsBindingSource.ResetBindings(true);
        }
        /// <summary>
        /// кнопка редактировать
        /// </summary>
        private void bindingNavigatorEditItem_Click(object? sender, EventArgs e)
        {
            FilterSettingDetail form = new FilterSettingDetail();
            form.EditDetail(m_detailsBindingSource, tbFilterTypes);
            form.Icon = this.Icon;
            form.Text = "Редактирование фильтра";
            DialogResult res = form.ShowDialog();

            if (res == DialogResult.OK)
            {

                m_detailsBindingSource.EndEdit();
            }
            else
            {
                m_detailsBindingSource.CancelEdit();
            }
        }


        private void button_FileDialogOpen_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();

            if (res == DialogResult.Cancel || openFileDialog1.FileNames.Length == 0) return;

            textBox_FilterAssembly.Text = openFileDialog1.FileNames[0];

        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
        }

        private void dataGridViewFilterSettings_Enter(object sender, EventArgs e)
        {
            //ApplayChenges();
        }

        private void dataGridViewFilterSettings_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}

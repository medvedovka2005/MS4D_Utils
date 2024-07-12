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

        public FilterDetail()
        {
            InitializeComponent();
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

            dataGridViewFilterSettings.DataSource = m_detailsBindingSource;
            
            dataGridViewFilterSettings.Columns[0].Width = 50;
            dataGridViewFilterSettings.Columns[1].Width = 75;
            dataGridViewFilterSettings.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewFilterSettings.Columns[3].Width = 75;
            dataGridViewFilterSettings.Columns[4].Width = 75;

            //Заголовки
            dataGridViewFilterSettings.Columns[0].HeaderText = "Id записи";
            dataGridViewFilterSettings.Columns[1].HeaderText = "Id фильтра";
            dataGridViewFilterSettings.Columns[2].HeaderText = "Настройка фильтра";
            dataGridViewFilterSettings.Columns[3].HeaderText = "Активность";
            dataGridViewFilterSettings.Columns[4].HeaderText = "FREETEXT";


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
            form.EditDetail(m_detailsBindingSource);
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
            form.EditDetail(m_detailsBindingSource);
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

    }
}

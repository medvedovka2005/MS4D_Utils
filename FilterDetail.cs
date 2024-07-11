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
        public FilterDetail()
        {
            InitializeComponent();

        }

        BindingSource m_masterBindingSource;
        BindingSource m_detailsBindingSource;
        SqlDataAdapter m_masterDataAdapter;
        SqlDataAdapter m_detailsDataAdapter;

        BindingNavigator masterNavigator;
        BindingNavigator detailsNavigator;

        public void EditDetail(BindingSource masterBindingSource, BindingSource detailsBindingSource, SqlDataAdapter masterDataAdapter, SqlDataAdapter detailsDataAdapter)
        {
            m_masterBindingSource = masterBindingSource;
            m_detailsBindingSource = detailsBindingSource;
            m_masterDataAdapter = masterDataAdapter;
            m_detailsDataAdapter = detailsDataAdapter;

            //masterNavigator = new BindingNavigator(masterBindingSource);
            detailsNavigator = new BindingNavigator(detailsBindingSource);
            
            //masterNavigator.Dock = DockStyle.Bottom;
            //tableLayoutPanel2.Controls.Add(masterNavigator);
            
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
            SaveItem.Image = imageList1.Images[0];
            detailsNavigator.Items.Add(SaveItem);



            foreach (ToolStripItem b in detailsNavigator.Items)
            {
                Debug.WriteLine($"Наименование кнопки {b.Name}");
            }
            detailsNavigator.Items["bindingNavigatorAddNewItem"].Click += bindingNavigatorAddNewItem_Click;
        }

        private void bindingNavigatorAddNewItem_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Нажали добавить");
        }

        private void button_FileDialogOpen_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();

            if (res == DialogResult.Cancel || openFileDialog1.FileNames.Length == 0) return;

            textBox_FilterAssembly.Text = openFileDialog1.FileNames[0];

        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            var obj = m_detailsBindingSource.Current;
        }

        private void dataGridViewFilterSettings_Enter(object sender, EventArgs e)
        {
            /*
            masterBindingSource = new BindingSource
            {
                DataSource = dsFilters,
                DataMember = "tbFilters"
            };
             */

            m_masterBindingSource.EndEdit();

            DataRowView rw = (DataRowView) m_masterBindingSource.Current;

            if (rw.Row.RowState  != DataRowState.Unchanged)
            {                

                DataSet ds = (DataSet)m_masterBindingSource.DataSource;
                ds.AcceptChanges();

                m_masterDataAdapter.Update(ds.Tables["tbFilters"]);

                MessageBox.Show("Сохранение изменений");
            }

            //adFilters.Update(dsFilters.Tables["tbFilters"]);

        }
    }
}

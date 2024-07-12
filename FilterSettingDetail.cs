using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckRT
{
    public partial class FilterSettingDetail : Form
    {

        BindingSource m_detailsBindingSource;
        List<FilterType> filterType = new List<FilterType>
            {
                new FilterType { UsingType= 0, TypeName = "CONTAINS" }, // - Поиск точных или нечетких (менее точных) совпадений с отдельными словами и фразами"},
                new FilterType { UsingType = 1, TypeName = "FREETEXT" }, // - Поиск значений, которые соответствуют значению, а не просто точной формулировке слов в условии поиска"},
                new FilterType { UsingType = 2, TypeName = "LIKE" } //  - Поиск по соответствию символьной строки указанному шаблону"}
            };

        public FilterSettingDetail()
        {
            InitializeComponent();
        }

        public void EditDetail(BindingSource detailsBindingSource)
        {
            m_detailsBindingSource = detailsBindingSource;
            SetElementsSource();

            textBox_id_rec.DataBindings.Add(new Binding("Text", this.m_detailsBindingSource, "id_rec", true));
            textBox_id_filter.DataBindings.Add(new Binding("Text", this.m_detailsBindingSource, "id_filter", true));
            textBox_FilterString.DataBindings.Add(new Binding("Text", this.m_detailsBindingSource, "FilterString", true));
            checkBox_Active.DataBindings.Add(new Binding("Checked", this.m_detailsBindingSource, "Active", true));
            comboBox_UsingFreeText.DataBindings.Add(new Binding("SelectedValue", this.m_detailsBindingSource, "UsingFreeText", true));
        }

        private void SetElementsSource()
        {

            DataTable tb = new DataTable("FilterTypes");
            DataColumn clm1 = new("UsingType", typeof(int));
            tb.Columns.Add(clm1);
            DataColumn clm2 = new("TypeName", typeof(string));
            tb.Columns.Add(clm2);

            DataRow rw1 = tb.NewRow();
            rw1[0] = 0;
            rw1[1] = "CONTAIN";
            tb.Rows.Add(rw1);

            DataRow rw2 = tb.NewRow();
            rw2[0] = 1;
            rw2[1] = "FREETEXT";
            tb.Rows.Add(rw2);

            DataRow rw3 = tb.NewRow();
            rw3[0] = 2;
            rw3[1] = "LIKE";
            tb.Rows.Add(rw3);

            comboBox_UsingFreeText.DataSource = tb;
            comboBox_UsingFreeText.ValueMember = "UsingType";
            comboBox_UsingFreeText.DisplayMember = "TypeName";

        }


        private void FilterSettingDetail_Load(object sender, EventArgs e)
        {


        }

        private void button_Check_Click(object sender, EventArgs e)
        {

            DataRowView rw = (DataRowView)this.m_detailsBindingSource.Current;
            comboBox_UsingFreeText.SelectedValue = (byte)rw.Row["UsingFreeText"];

        }
    }


    partial class FilterType
    {
        public int UsingType { get; set; }
        public string TypeName { get; set; }
    }
}

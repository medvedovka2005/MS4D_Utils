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

        public FilterSettingDetail()
        {
            InitializeComponent();
        }

        public void EditDetail(BindingSource detailsBindingSource)
        {
            m_detailsBindingSource = detailsBindingSource;

            textBox_id_rec.DataBindings.Add(new Binding("Text", this.m_detailsBindingSource, "id_rec", true));
            textBox_id_filter.DataBindings.Add(new Binding("Text", this.m_detailsBindingSource, "id_filter", true));
            textBox_FilterString.DataBindings.Add(new Binding("Text", this.m_detailsBindingSource, "FilterString", true));
            checkBox_Active.DataBindings.Add(new Binding("Checked", this.m_detailsBindingSource, "Active", true));
        }


    }
}

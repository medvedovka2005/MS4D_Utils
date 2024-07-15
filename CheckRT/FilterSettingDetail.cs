using CheckRT.PropertyClasses;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        public void EditDetail(BindingSource detailsBindingSource, DataTable FilterTypesSource)
        {
            m_detailsBindingSource = detailsBindingSource;

            comboBox_UsingFreeText.DataSource = FilterTypesSource;
            comboBox_UsingFreeText.ValueMember = "UsingType";
            comboBox_UsingFreeText.DisplayMember = "TypeName";

            textBox_id_rec.DataBindings.Add(new Binding("Text", this.m_detailsBindingSource, "id_rec", true));
            textBox_id_filter.DataBindings.Add(new Binding("Text", this.m_detailsBindingSource, "id_filter", true));
            textBox_FilterString.DataBindings.Add(new Binding("Text", this.m_detailsBindingSource, "FilterString", true));
            checkBox_Active.DataBindings.Add(new Binding("Checked", this.m_detailsBindingSource, "Active", true));
            comboBox_UsingFreeText.DataBindings.Add(new Binding("SelectedValue", this.m_detailsBindingSource, "UsingFreeText", true));
        }


        private void FilterSettingDetail_Load(object sender, EventArgs e)
        {
        }

        private void button_Check_Click(object sender, EventArgs e)
        {
            textBox_CheckResult.Text = "";

            //Настройки подключения к БД
            SqlServerConnectionProperty sqlServerConnectionProperty = new();

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection csSection = config.ConnectionStrings;
            if (csSection.ConnectionStrings["cnnPrimary"] != null)
            {
                sqlServerConnectionProperty.ConnectionString = csSection.ConnectionStrings["cnnPrimary"].ConnectionString;
            }

            //Настройки подключения к сокету
            SocketConnectionProperty socketConnectionProperty = new();
            AppSettingsSection csSectionApp = config.AppSettings;

            if (csSectionApp.Settings["SocketConnectionProperty"] != null)             
            {
                string? jsonString = csSectionApp.Settings["SocketConnectionProperty"].Value;
                socketConnectionProperty = JsonSerializer.Deserialize<SocketConnectionProperty>(jsonString);
            }

            textBox_CheckResult.AppendText($"Запрос данных по сокету IP: {socketConnectionProperty.IPAddress}, Port: {socketConnectionProperty.Port}" + Environment.NewLine);

            using (SqlConnection sqlConnection = new())
            {                
                sqlConnection.ConnectionString = sqlServerConnectionProperty.ConnectionString;

                try
                {
                    sqlConnection.Open();
                    textBox_CheckResult.AppendText($"Установлено подключение к БД: {sqlConnection.ConnectionString}" + Environment.NewLine);

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = sqlConnection;
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.CommandText = "[dbo].[get_filtred_CheckResult]";

                    selectCommand.Parameters.AddWithValue("@rec_count", 1000);
                    selectCommand.Parameters.AddWithValue("@port", socketConnectionProperty.Port);
                    selectCommand.Parameters.AddWithValue("@ip_address", socketConnectionProperty.IPAddress);
                    selectCommand.Parameters.AddWithValue("@FilterString", textBox_FilterString.Text);
                    selectCommand.Parameters.AddWithValue("@UsingFreeText", comboBox_UsingFreeText.SelectedValue);

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    textBox_CheckResult.AppendText("Отфильтрованы строки:" + Environment.NewLine);
                    int i = 0;
                    while (reader.Read())
                    {
                        textBox_CheckResult.AppendText(reader[2].ToString() + Environment.NewLine);
                        i++;
                    }
                    textBox_CheckResult.AppendText($"Итого строк: {i}. Ошибок нет." + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    textBox_CheckResult.Text = ex.Message;
                }
                finally { sqlConnection.Close(); }                
            }

        }
    }


    partial class FilterType
    {
        public int UsingType { get; set; }
        public string TypeName { get; set; }
    }
}

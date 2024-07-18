using CheckRT.PropertyClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckRT
{
    public static class AppSettingsOper
    {
        /// <summary>
        /// Чтение настройки из файла конфигурации
        /// </summary>
        /// <param name="key">ключ</param>
        /// <returns>значение настройки</returns>
        public static object ReadAppSetting(string key)
        {
            object ret = null;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection csSection = config.AppSettings;

            if (csSection.Settings[key] != null)
            {
                ret = csSection.Settings[key].Value;
            }
            return ret;
        }

        /// <summary>
        /// Сохранение настроек в файл конфигурации
        /// </summary>
        /// <param name="key">настройка</param>
        /// <param name="value">значение</param>
        public static void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }



        public static object ReadConnectionString()
        {
            object ret = null;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection csSection = config.ConnectionStrings;
            if (csSection.ConnectionStrings["cnnPrimary"] != null)
            {
                ret = csSection.ConnectionStrings["cnnPrimary"].ConnectionString;
            }

            return ret;
        }



        /// <summary>
        /// Сохранении настройки подключения к БД. Может храниться несколько настроек, т.к. может потребоваться подключение к различным БД из объектов приложения
        /// </summary>
        /// <param name="key">Наименование подключения</param>
        /// <param name="sqlConnectionString">строка подключения</param>
        public static void AddOrUpdateConnectionString(string key, string sqlConnectionString)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                // Get the connection strings section.

                ConnectionStringsSection csSection =
                    config.ConnectionStrings;

                if (ConfigurationManager.ConnectionStrings[key] == null)
                {
                    ConnectionStringSettings csSettings = new ConnectionStringSettings(key, sqlConnectionString);
                    csSection.ConnectionStrings.Add(csSettings);
                }
                else
                {
                    ConnectionStringSettings csSettings = new ConnectionStringSettings();
                    csSettings = csSection.ConnectionStrings[key];
                    csSettings.ConnectionString = sqlConnectionString;
                }

                // Save the configuration file.
                config.Save(ConfigurationSaveMode.Modified);

            }
            catch (ConfigurationErrorsException ex)
            {
                MessageBox.Show("Ошибка сохранения конфигурации: " + ex.Message, "Настройка конфигурации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Error writing app settings: " + ex.Message);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CheckRT.PropertyClasses
{
    internal class TaskProperty : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        String m_name;
        int m_reccount = 100;
        bool m_autoupdate = false;
        int m_interval = 30000;

        [Browsable(true)]
        [Description("Наименование задачи")]
        [DisplayName("Задача")]
        [Category("Задача")]
        [ReadOnly(true)]
        public String Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        [Browsable(true)]
        [Description("Количество записей, возвращаемых из БД")]
        [DisplayName("Кол-во записей")]
        [Category("Задача")]
        public int ReturnRecCount
        {
            get { return m_reccount; }
            set { 
                if (m_reccount != value)
                {
                    m_reccount = value;
                    OnPropertyChange();
                }
            }
        }

        [Browsable(true)]
        [Description("Интервал выполнения запроса к БД, в миллисекундах")]
        [DisplayName("Интервал обновления (мс)")]
        [Category("Задача")]
        public int Interval
        {
            get { return m_interval; }
            set {
                if (m_interval != value)
                {
                    m_interval = value;
                    OnPropertyChange();
                }
            }
        }

        [Browsable(true)]
        [Description("Автоматически выполненять запрос к БД")]
        [DisplayName("Автообновление")]
        [Category("Задача")]
        public bool AvtoUpdate
        {
            get { return m_autoupdate; }
            set { 
                if (m_autoupdate != value)
                {
                    m_autoupdate = value;
                    OnPropertyChange();
                }
            }
        }
        protected virtual void OnPropertyChange([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

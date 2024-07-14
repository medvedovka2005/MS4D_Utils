using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CheckRT.PropertyClasses
{

    /*
    https://metanit.com/sharp/windowsforms/6.2.php
    Класс, который реализует интерфейс INotifyPropertyChanged, должен определить событие PropertyChanged. Вызыв этого события будет извещать систему об изменениях.
    Для каждого свойства создается поле, которое собственно хранит значение. Если требуется установить новое значение для свойства, то при его установке вызываем метод OnPropertyChanged, 
    в который передается название свойства. Но благодаря применению к параметру атрибута [CallerMemberName], мы можем не передавать в вызов метода название свойства - оно определяется автоматически исходя из того, 
    в каком именно свойстве вызывается этот метод. В этом методе собственно и вызывается событие PropertyChanged, в которое передается информация об измененном свойстве.
     */
    internal class SocketConnectionProperty : INotifyPropertyChanged //чтобы уведомить цель привязки об изменении значений источник привязки должен реализовать интерфейс INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        String m_ip = "127.0.0.1";        
        int m_port = 31550;

        [Browsable(true)]
        [Description("IP адрес узла, где развёрнута среда исполнения")]
        [DisplayName("IP адрес")]
        [Category("Подключение")]
        [ReadOnly(false)]
        public String IPAddress
        {
            get { return m_ip;}
            set {
                if (m_ip != value)
                {
                    m_ip = value;
                    OnPropertyChange();
                }
            }
        }

        [Browsable(true)]
        [Description("Порт для подключения к экземпляру RT")]
        [DisplayName("Порт")]
        [Category("Подключение")]
        [ReadOnly(false)]
        public int Port
        {
            get { return m_port;}
            set { 
                if (value != m_port)
                {
                    m_port = value;
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

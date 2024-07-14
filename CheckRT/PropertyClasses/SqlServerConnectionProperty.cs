using Microsoft.Data.SqlClient;
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

    //чтобы уведомить цель привязки об изменении значений источник привязки должен реализовать интерфейс INotifyPropertyChanged
     */
    internal class SqlServerConnectionProperty : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private String m_connectionString = @"Data Source=127.0.0.1\SQLEXPRESS;Initial Catalog=mps_p1;Integrated Security=True;Trust Server Certificate=True;Application Name=CheckRT;Command Timeout=60";
                    
        public String ConnectionString
        {
            get { return m_connectionString; }
            set {
                    m_connectionString = value;
                    OnPropertyChange();
            }
        }

        protected virtual void OnPropertyChange([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

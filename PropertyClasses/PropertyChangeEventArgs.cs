using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckRT.PropertyClasses
{
    public class PropertyChangeEventArgs : EventArgs
    {
        public int? Port { get; set; }
        public string? IPAddress { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosci
{
    public class Dice : INotifyPropertyChanged
    {
        private int _value;
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                }
            }
        }
        public bool IsSelected { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

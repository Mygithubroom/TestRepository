using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.Common.DAO
{
    public class LayoutInfo : INotifyPropertyChanged
    {
        private int id;
        private string type;

        public int Id { get => id; set { id = value;} }

        public string Type { get => type; set { type = value; OnPropertyChange(); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChange([CallerMemberName] string propertyName ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

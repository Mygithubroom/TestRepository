using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WanCeDesktopApp.Common
{
    public class SampleDateInfo: BaseInfo
    {
       
        private string format = "";
        //格式化类型
        public string Format { get => format; set { format = value; RaisePropertyChanged(); } }
    }
}

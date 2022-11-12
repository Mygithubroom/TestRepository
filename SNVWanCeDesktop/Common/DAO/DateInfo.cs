using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WanCeDesktopApp.Common.DAO;

namespace WanCeDesktopApp.Common
{
    public class DateInfo: InputInfo
    {
       
        private string format = "";
        //格式化类型
        public string DateFormatType { get => format; set { format = value; RaisePropertyChanged(); } }
    }
}

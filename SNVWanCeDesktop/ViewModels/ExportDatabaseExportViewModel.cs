
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.ViewModels
{
    public class ExportDatabaseExportViewModel : BindableBase
    {
        private string isExportDB;//是否导出数据库
        public string IsExportDB { get => isExportDB; set { isExportDB = value; RaisePropertyChanged(); } }



    }
}

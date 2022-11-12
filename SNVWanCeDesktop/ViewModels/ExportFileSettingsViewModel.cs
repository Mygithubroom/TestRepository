using Prism.Commands;
using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.ViewModels
{
    public class ExportFileSettingsViewModel:BindableBase
    {

        
        private string defaultFolder = ""; //默认文件夹
        private string addDateToSpecment = "";// 是否将日期添加到到名称
        private string isDiscard = ""; //完成后， 是否丢弃
        public ExportFileSettingsViewModel()
        {
           
        }

        public string DefaultFolder { get => defaultFolder; set { defaultFolder = value; RaisePropertyChanged(); } }
        public string AddDateToSpecment { get => addDateToSpecment; set { addDateToSpecment = value; RaisePropertyChanged(); } }
        public string IsDiscard { get => isDiscard; set { isDiscard = value; RaisePropertyChanged(); } }

    }
}


using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.ViewModels
{
    public class ExportsExport1ViewModel : BindableBase
    {
        private string exportFrequency=""; //导出频率
        private string resultTable1 = ""; //结果 表1
        private string fileSuffix = ""; //文件后缀
        private string excodeingType = ""; //编码编辑
        private string isOverride = ""; //是否覆盖
        private string exportSetting = "";//导出设置
        private string defaultFileName = "";//默认文件名。
        private string createFileSpecimen = ""; //为每个试样创建一个文件
        public string ExportFrequency { get => exportFrequency; set { exportFrequency = value; RaisePropertyChanged(); } }
        public string ResultTable1 { get => resultTable1; set { resultTable1 = value; RaisePropertyChanged(); } }
        public string FileSuffix { get => fileSuffix; set { fileSuffix = value; RaisePropertyChanged(); } }
        public string ExcodeingType { get => excodeingType; set { excodeingType = value; RaisePropertyChanged(); } }
        public string IsOverride { get => isOverride; set { isOverride = value; RaisePropertyChanged(); } }
        public string ExportSetting { get => exportSetting; set { exportSetting = value; RaisePropertyChanged(); } }
        public string DefaultFileName { get => defaultFileName; set { defaultFileName = value; RaisePropertyChanged(); } }
        public string CreateFileSpecimen { get => createFileSpecimen; set { createFileSpecimen = value; RaisePropertyChanged(); } }

        private string methodParam = "";
        private string resultTable2 = "";
        private string resultTable3 = "";
        private string resultTable4 = "";
        private string resultTable5 = "";
        private string rawData = "";
        private string isOverride2 = "";
        private string isOverride3 = "";
        public string MethodParam { get => methodParam; set { methodParam = value; RaisePropertyChanged(); } }
        public string ResultTable2 { get => resultTable2; set { resultTable2 = value; RaisePropertyChanged(); } }
        public string ResultTable3 { get => resultTable3; set { resultTable3 = value; RaisePropertyChanged(); } }
        public string RawData { get => rawData; set { rawData = value; RaisePropertyChanged(); } }
        public string IsOverride2 { get => isOverride2; set { isOverride2 = value; RaisePropertyChanged(); } }
        public string IsOverride3 { get => isOverride3; set { isOverride3 = value; RaisePropertyChanged(); } }
        public string ResultTable4 { get => resultTable4; set { resultTable4 = value; RaisePropertyChanged(); } }
        public string ResultTable5 { get => resultTable5; set { resultTable5 = value; RaisePropertyChanged(); } }
    }
}

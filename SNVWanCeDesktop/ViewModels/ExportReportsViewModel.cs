
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.ViewModels
{
    public class ExportReportsViewModel : BindableBase
    {
        private string reportSet = "";
        private string reportTemplate = "";
        private string saveReport = "";
        private string printReport = "";
        private string printGraphice1 = "";
        private string printGraphice2 = ""; 

        public string ReportSet { get => reportSet; set { reportSet = value; RaisePropertyChanged(); } }
        public string ReportTemplate { get => reportTemplate; set { reportTemplate = value; RaisePropertyChanged(); } }
        public string SaveReport { get => saveReport; set { saveReport = value; RaisePropertyChanged(); } }
        public string PrintReport { get => printReport; set { printReport = value; RaisePropertyChanged(); } }
        public string PrintGraphice1 { get => printGraphice1; set { printGraphice1 = value; RaisePropertyChanged(); } }
        public string PrintGraphice2 { get => printGraphice2; set { printGraphice2 = value; RaisePropertyChanged(); } }
        public ExportReportsViewModel()
        {
            OKInsertDB();
        }
        public void OKInsertDB()
        {
            SQLiteHelper dbTable = new SQLiteHelper("UserInfoInfoDataBase ");
            StringBuilder strCmd = new StringBuilder();
            {
                //添加变量的有效判断，然后再执行写入数据库操作
                strCmd.Append("INSERT INTO ExportTable(" +
                    "ExportID, " +
                    "MethodID," +
                    "TestType, " +
                    "ExportTemplate, " +
                    "FileName, " +
                    "IsRawData " +
                    ") VALUES ");
                strCmd.Append("(");
                strCmd.Append("1123");//ExportID
                strCmd.Append(", ");
                strCmd.Append("456");//MethodID
                strCmd.Append(", ");
                strCmd.Append("123");//TestType
                strCmd.Append(", ");
                strCmd.Append("\"");
                strCmd.Append("123");//ExportTemplate
                strCmd.Append("\"");
                strCmd.Append(", ");
                strCmd.Append("\"");
                strCmd.Append("54");//FileName
                strCmd.Append("\"");
                strCmd.Append(", ");
                strCmd.Append("1");//IsRawData
                strCmd.Append(");");
                string sqlStrCommande = strCmd.ToString();
                DataTable dt = dbTable.ExecuteDataTable(sqlStrCommande);
            }
        }
    }
}

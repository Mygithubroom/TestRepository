
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.ViewModels
{
    public class TestControlDataViewModel : BindableBase
    {
        public TestControlDataViewModel()
        {
            OKInsertDB();
        }
        public void OKInsertDB()//数据页数据
        {
            SQLiteHelper dbTable = new SQLiteHelper("TestControlDataBase ");
            StringBuilder strCmd = new StringBuilder();
            strCmd.Clear();
            strCmd.Append("INSERT INTO DataCaptureSchemeTable (" +
                       "TestID, " +
                       "MethodID," +
                       "TestCriteria," +
                       "Measurement, " +
                       "Interval" +
                       ") VALUES ");

            strCmd.Append("(");
            strCmd.Append("1123");//试验ID
            strCmd.Append(", ");
            strCmd.Append("456");//方法ID
            strCmd.Append(", ");
            strCmd.Append("1");//试验 标准 TestCriteria                                   
            strCmd.Append(", ");
            strCmd.Append("12564");//Measurement
            strCmd.Append(", ");
            strCmd.Append("321");//Interval 间隔
            strCmd.Append(");");
            string sqlStrCommande = strCmd.ToString();
            DataTable dt = dbTable.ExecuteDataTable(sqlStrCommande);
        }
    }
}

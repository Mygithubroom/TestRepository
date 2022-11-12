
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.ViewModels
{
    public class TestControlTestViewModel :BindableBase
    {
        //试验->
        //斜率控制1
        public string ramp1Control;//斜率控制
        public string ramp1Controlmode;//斜率控制模式
        public string ramp1Rate;//速率
        public string ramp1Unit;//单位
        //斜率控制2
        public string ramp2Control;//斜率控制
        public string ramp2Controlmode;//斜率控制模式
        public string ramp2Rate;//速率
        public string ramp2Unit;//单位
        //斜率控制1
        public string Ramp1Control { get => ramp1Control; set { ramp1Control = value; RaisePropertyChanged(); } }
        public string Ramp1Controlmode { get => ramp1Controlmode; set { ramp1Controlmode = value; RaisePropertyChanged(); } }
        public string Ramp1Rate { get => ramp1Rate; set { ramp1Rate = value; RaisePropertyChanged(); } }
        public string Ramp1Unit { get => ramp1Unit; set { ramp1Unit = value; RaisePropertyChanged(); } }

        //斜率控制2
        public string Ramp2Control { get => ramp2Control; set { ramp2Control = value; RaisePropertyChanged(); } }
        public string Ramp2Controlmode { get => ramp2Controlmode; set { ramp2Controlmode = value; RaisePropertyChanged(); } }
        public string Ramp2Rate { get => ramp1Rate; set { ramp1Rate = value; RaisePropertyChanged(); } }
        public string Ramp2Unit { get => ramp1Unit; set { ramp1Unit = value; RaisePropertyChanged(); } }
        public TestControlTestViewModel()
        {
            OKInsertDB();
        }  
        public void OKInsertDB() //试验页数据
        {
            SQLiteHelper dbTable = new SQLiteHelper("TestControlDataBase ");
            StringBuilder strCmd = new StringBuilder();
            strCmd.Clear();
            strCmd.Append("INSERT INTO TestTable (" +
                       "TestID, " +
                       "MethodID," +
                       "ControlMode," +
                       "RateValue, " +
                       "Unit " +
                       ") VALUES ");

            strCmd.Append("(");
            strCmd.Append("1123");//试验ID
            strCmd.Append(", ");
            strCmd.Append("456");//方法ID
            strCmd.Append(", ");
            strCmd.Append("\"");
            strCmd.Append("力控");//控制模式                                    
            strCmd.Append("\"");
            strCmd.Append(", ");
            strCmd.Append("1000");//速率值
            strCmd.Append(", ");
            strCmd.Append("\"");
            strCmd.Append("564");//单位
            strCmd.Append("\"");
            strCmd.Append(");");
            string sqlStrCommande = strCmd.ToString();
            DataTable dt = dbTable.ExecuteDataTable(sqlStrCommande);
        }
    }

  
}

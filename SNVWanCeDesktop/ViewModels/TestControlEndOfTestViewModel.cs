
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.ViewModels
{
    public class TestControlEndOfTestViewModel : BindableBase
    {        //<-
        //试验结束->
        public string testEnd1;//点选标记1
        public string testEndCriteria1; //试验结束标准
        public string testEndMeasurement1; //试验结束测量
        public string testEndSensitivity1; //灵敏度
        public string testEndCriteria2; //试验结束标准2
        public string testEndMeasurement2; //试验结束测量2
        public string testEndSensitivity2; //灵敏度2
        public string testEndAction; //结束后动作
        public string testEndFlage;//结束后动作标记

        public string TestEnd1 { get => testEnd1; set { testEnd1 = value; RaisePropertyChanged(); } }       
        public string TestEndCriteria1 { get => testEndCriteria1; set { testEndCriteria1 = value; RaisePropertyChanged(); } }
        public string TestEndMeasurement1 { get => testEndMeasurement1; set { testEndMeasurement1 = value; RaisePropertyChanged(); } }
        public string TestEndSensitivity1 { get => testEndSensitivity1; set { testEndSensitivity1 = value; RaisePropertyChanged(); } }
        public string testEnd2;//点先标记2
        public string TestEnd2 { get => testEnd2; set { testEnd2 = value; RaisePropertyChanged(); } }
        public string TestEndCriteria2 { get => testEndCriteria2; set { testEndCriteria2 = value; RaisePropertyChanged(); } }   
        public string TestEndMeasurement2 { get => testEndMeasurement2; set { testEndMeasurement2 = value; RaisePropertyChanged(); } }        
        public string TestEndSensitivity2 { get => testEndSensitivity2; set { testEndSensitivity2 = value; RaisePropertyChanged(); } }
        public string TestEndAction { get => testEndAction; set { testEndAction = value; RaisePropertyChanged(); } }
        public string TestEndFlage { get => testEndFlage; set { testEndFlage = value; RaisePropertyChanged(); } }

        public TestControlEndOfTestViewModel()
        {
            OKInsertDB();
        }
        public void OKInsertDB()//试验结束页数据
        {

            SQLiteHelper dbTable = new SQLiteHelper("TestControlDataBase ");
            StringBuilder strCmd = new StringBuilder();
            strCmd.Clear();
            strCmd.Append("INSERT INTO TestEndTable (" +
                       "TestID, " +
                       "MethodID," +
                       "TestEnd," +
                       "TestEndCriterion, " +
                       "MeasurementValue, " +
                       "Sensitivity, " +
                       "TestEndAction, " +
                       "TestEndFlage " +
                       ") VALUES ");

            strCmd.Append("(");
            strCmd.Append("1123");//试验ID
            strCmd.Append(", ");
            strCmd.Append("456");//方法ID
            strCmd.Append(", ");
            //strCmd.Append("\"");
            strCmd.Append("1");//试验结束标记 TestEnd                              
            //strCmd.Append("\"");
            strCmd.Append(", ");
            strCmd.Append("12564");//试验结束标准TestEndCriterion
            strCmd.Append(", ");
            strCmd.Append("\"");
            strCmd.Append("321");//测量值MeasurementValue 
            strCmd.Append("\"");
            strCmd.Append(", ");
            strCmd.Append("321");//Sensitivit灵敏度
            strCmd.Append(", ");
            strCmd.Append("321");//TestEndAction 结束动作
            strCmd.Append(", ");
            strCmd.Append("412");//TestEndFlage 
            strCmd.Append(");");
            string sqlStrCommande = strCmd.ToString();
            DataTable dt = dbTable.ExecuteDataTable(sqlStrCommande);
        }
    }
}

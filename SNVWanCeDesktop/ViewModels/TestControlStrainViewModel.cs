
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.ViewModels
{
    public class TestControlStrainViewModel : BindableBase
    {
        public bool baseSourceComboBox;
        public bool removeCheckBox;
        public string removCriteriaComboBox;
        public string measuremetnComboBox;
        public string valueTextBox;
        public string uintComBox;
        public string actionDuringComboBox;
        public bool lockTensileComboBox;
        public bool removeTransverseComboBox;
        public bool BaseSourceComboBox { get => baseSourceComboBox; set { baseSourceComboBox = value;RaisePropertyChanged(); } }
        public bool RemoveCheckBox { get => removeCheckBox; set { removeCheckBox = value;RaisePropertyChanged(); } }
        public string MeasuremetnComboBox { get => measuremetnComboBox; set { measuremetnComboBox = value; RaisePropertyChanged(); } }
        public string RemovCriteriaComboBox { get => removCriteriaComboBox; set { removCriteriaComboBox = value; RaisePropertyChanged(); } }
        public string ValueTextBox { get => valueTextBox; set { valueTextBox = value; RaisePropertyChanged(); } }
        public string UintComBox { get => uintComBox; set { uintComBox = value; RaisePropertyChanged(); } }        
        public string ActionDuringComboBox { get => actionDuringComboBox; set { actionDuringComboBox = value; RaisePropertyChanged(); } }
        public bool LockTensileComboBox { get => lockTensileComboBox; set { lockTensileComboBox = value; RaisePropertyChanged(); } }
        public bool RemoveTransverseComboBox { get => removeTransverseComboBox; set { removeTransverseComboBox = value; RaisePropertyChanged(); } }

        public TestControlStrainViewModel()
        {
            OKInsertDB();
        }
        public void OKInsertDB()
        {
            try
            {
                SQLiteHelper dbTable = new SQLiteHelper("TestControlDataBase ");
                StringBuilder strCmd = new StringBuilder();
                //添加变量的有效判断，然后再执行写入数据库操作
                strCmd.Clear();
                strCmd.Append("INSERT INTO StrainTable (" +
                    "MethodID, " +
                    "StrainID," +
                    "DataSource," +
                    "MeasurementEvent, " +
                    "RemoveISO, " +
                    "Value," +
                    "RemoveAction," +
                    "RemoveLockFlage" +
                    ") VALUES ");

                strCmd.Append("(");
                strCmd.Append("1123");//methodID
                strCmd.Append(", ");
                strCmd.Append("456");//StrainID
                strCmd.Append(", ");
                strCmd.Append("4652");//数据源// BaseSourceComboBox
                strCmd.Append(", ");
                strCmd.Append("\"");
                strCmd.Append("力");//MeasurementEvent MeasuremetnComboBox
                strCmd.Append("\"");
                strCmd.Append(", ");
                strCmd.Append("564");//RemoveISO RemovCriteriaComboBox
                strCmd.Append(", ");
                strCmd.Append("156412");//Value ValueTextBox
                strCmd.Append(", ");
                strCmd.Append("56812");//RemoveAction ActionDuringComboBox
                strCmd.Append(", ");
                strCmd.Append("12");//RemoveLockFlage LockTensileComboBox
                strCmd.Append(");");
                string sqlStrCommande = strCmd.ToString();
                DataTable dt = dbTable.ExecuteDataTable(sqlStrCommande);
            }catch (Exception ex)
            { 
                throw ex;
            }
        }

    }
}

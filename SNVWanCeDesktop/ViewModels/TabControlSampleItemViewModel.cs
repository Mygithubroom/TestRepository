using Prism.Mvvm;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common;
using System.Collections.ObjectModel;
using Prism.Services.Dialogs;
using Prism.Regions;

using WanCeDesktopApp.Extensions;
using WanCeDesktopApp.Common.DAO;
using WanCeDesktopApp.Views;

namespace WanCeDesktopApp.ViewModels
{
    public class TabControlSampleItemViewModel : BindableBase
    {
        
        private readonly IRegionManager regionManager;
        bool IsFirstLoad = true;
        #region
        //public DelegateCommand<NegativeBarInfos> OpenViewCommand { get; private set; }
        public DelegateCommand LoadedCommand { get; private set; }
        public DelegateCommand<NegativeBarInfos> SelectionChangedCommand { get; private set; }
        #endregion
        private ObservableCollection<NegativeBarInfos> negativeBarInfos;

        public ObservableCollection<NegativeBarInfos> NegativeBarInfos
        {
            get { return negativeBarInfos; }
            set { negativeBarInfos = value; RaisePropertyChanged(); }
        }

        public TabControlSampleItemViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            //OpenViewCommand = new DelegateCommand<NegativeBarInfos>(OpenView);
            LoadedCommand = new DelegateCommand(Loaded);
            NegativeBarInfos = new ObservableCollection<NegativeBarInfos>();
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 0, NameSpace = "SampleNotesView", Title = "Notes" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 1, NameSpace = "SampleNumberInputsView", Title = "TabSectionTitleNumberInputs" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 2, NameSpace = "SampleTextInputsView", Title = "TabSectionTitleTextInputs" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 3, NameSpace = "SampleChoiceInputsView", Title = "TabSectionTitleChoiceInputs" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 4, NameSpace = "SampleDateInputsView", Title = "DateInputs" });
            SelectionChangedCommand = new DelegateCommand<NegativeBarInfos>(SelectionChanged);
            //创建数据库与样品表
        }
        private void SelectionChanged(NegativeBarInfos obj)
        {
            try
            {
                if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
                {
                    return;
                }
                else
                {
                    this.regionManager.Regions[PrismManage.SampleItemViewRegionName].RequestNavigate(obj.NameSpace);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void Loaded()
        {
            if (IsFirstLoad)
            {
                regionManager.Regions[PrismManage.SampleItemViewRegionName].RequestNavigate(nameof(SampleNotesView));
                IsFirstLoad = false;
            }
        }
        //public void CreateTestMethod(string str)
        //{
        //    //建试验方法参数库
        //    SQLiteHelper TestMethod = new SQLiteHelper("TestMethodParamDataBase");
        //    SQLiteHelper.DataBaceList.Add("TESTMETHOD", TestMethod);
        //    TestMethod.CreateDataBase();

          
        //    //试样参数表         
        //    {
        //        StringBuilder sbr2 = new StringBuilder();
        //        sbr2.AppendLine("CREATE TABLE IF NOT EXISTS `SpecmentParamTable`(");
        //        sbr2.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,");//自增id主键
        //        sbr2.AppendLine("`MethodID` CHAR(8) NOT NULL,");//方法ID
        //        sbr2.AppendLine("`SpecmentParamID` CHAR(20) NOT NULL,"); //试样参数ID
        //        sbr2.AppendLine("`Geometry` CHAR(8) NOT NULL,");//试样型态
        //        sbr2.AppendLine("`width` CHAR(4) NOT NULL,");//宽
        //        sbr2.AppendLine("`Thickness` CHAR(4) NOT NULL,");//厚
        //        sbr2.AppendLine("`Length` CHAR(20) NOT NULL,"); //长
        //        sbr2.AppendLine("`FixtureSeparation` CHAR(8) NOT NULL,");//平行距离
        //        sbr2.AppendLine("`FinalWidth` CHAR(8) NOT NULL,");//最终宽
        //        sbr2.AppendLine("`FinalThickness` CHAR(8) NOT NULL,");//最终厚度
        //        sbr2.AppendLine("`FinalLength` CHAR(8) NOT NULL,");//最终长度
        //        sbr2.AppendLine("`Pitch` CHAR(8) NOT NULL,");//齿距
        //        sbr2.AppendLine("`LinearDensity` CHAR(8) NOT NULL,");//线密度
        //        sbr2.AppendLine("`ExternalDiameter` CHAR(8) NOT NULL,");//外径
        //        sbr2.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
        //        sbr2.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
        //        sbr2.AppendLine();
        //        string cmdText2 = sbr2.ToString();
        //        int val2;
        //        if (string.IsNullOrEmpty(cmdText2))
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            val2 = TestMethod.ExecuteNonQuery(cmdText2);
        //        }
        //    }

        //    //测量参数表         
        //    {
        //        StringBuilder sbr3 = new StringBuilder();
        //        sbr3.AppendLine("CREATE TABLE IF NOT EXISTS `MeasurementParamTable`(");
        //        sbr3.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,");//自增id主键
        //        sbr3.AppendLine("`MethodID` CHAR(8) NOT NULL,");//方法ID
        //        sbr3.AppendLine("`MeasurementParamID` CHAR(20) NOT NULL,"); //测量ID
        //        sbr3.AppendLine("`MeasurementName` TINYTEXT NOT NULL,");//测量名称
        //        sbr3.AppendLine("`MeasurementDescription` CHAR(4) NOT NULL,");//测量描述
        //        sbr3.AppendLine("`SensorConfig` CHAR(4) NOT NULL,");//传感器配置
        //        sbr3.AppendLine("`TransmissionInterface` CHAR(20) NOT NULL,");//接头
        //        sbr3.AppendLine("`PreTestLimitedtMax` CHAR(8) NOT NULL,");//最高限位
        //        sbr3.AppendLine("`PreTestLimitedtMin` CHAR(8) NOT NULL,");//最低限位
        //        sbr3.AppendLine("`Rate` CHAR(8) NOT NULL,");//速率
        //        sbr3.AppendLine("`RateDescript` CHAR(8) NOT NULL,");//速率描述
        //        sbr3.AppendLine("`DataPoint` CHAR(8) NOT NULL,");//数据点
        //        sbr3.AppendLine("`TrueStrainControl` CHAR(8) NOT NULL,");//真应变控制
        //        sbr3.AppendLine("`LinearRegression` CHAR(8) NOT NULL,");//线性回归
        //        sbr3.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
        //        sbr3.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
        //        sbr3.AppendLine();
        //        string cmdText3 = sbr3.ToString();
        //        int val3;
        //        if (string.IsNullOrEmpty(cmdText3))
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            val3 = TestMethod.ExecuteNonQuery(cmdText3);
        //        }
        //    }

        //    //计算参数表         
        //    {
        //        StringBuilder sbr4 = new StringBuilder();
        //        sbr4.AppendLine("CREATE TABLE IF NOT EXISTS `CalculationParamTable`(");
        //        sbr4.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,");//自增id主键
        //        sbr4.AppendLine("`MethodID` CHAR(8) NOT NULL,");//方法ID
        //        sbr4.AppendLine("`CalculationID` CHAR(20) NOT NULL,"); //计算ID
        //        sbr4.AppendLine("`CalculationName` TINYTEXT NOT NULL,");//计算名称
        //        sbr4.AppendLine("`CalculationDescript` TINYTEXT NOT NULL,");//计算描述
        //        sbr4.AppendLine("`Domain` CHAR(4) NOT NULL,");//计算范围
        //        sbr4.AppendLine("`CalculationType` CHAR(20) NOT NULL,"); //计算类型
        //        sbr4.AppendLine("`CalculationDuring` CHAR(8) NOT NULL,");//计算触发时间
        //        sbr4.AppendLine("`IndicateOnGraph` CHAR(8) NOT NULL,");//显示到曲线上
        //        sbr4.AppendLine("`SourceExpress` CHAR(8) NOT NULL,");//原表达式
        //        sbr4.AppendLine("`ModiExpress` CHAR(8) NOT NULL,");//修改后的表达式
        //        sbr4.AppendLine("`Create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
        //        sbr4.AppendLine("`Update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
        //        sbr4.AppendLine();
        //        string cmdText4 = sbr4.ToString();
        //        int val4;
        //        if (string.IsNullOrEmpty(cmdText4))
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            val4 = TestMethod.ExecuteNonQuery(cmdText4);
        //        }
        //    }

        //    ///控制台功能键(热键)
        //    {
        //        StringBuilder sbr5 = new StringBuilder();
        //        sbr5.AppendLine("CREATE TABLE IF NOT EXISTS `HoldKeyTable`(");
        //        sbr5.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,");//自增id主键
        //        sbr5.AppendLine("`HotKeyID` CHAR(8) NOT NULL,");//方法ID
        //        sbr5.AppendLine("`HotKeyName` CHAR(4) NOT NULL,");//名称
        //        sbr5.AppendLine("`DiaplayDescript` CHAR(20) NOT NULL,"); //显示描述
        //        sbr5.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
        //        sbr5.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
        //        sbr5.AppendLine();
        //        string cmdText5 = sbr5.ToString();
        //        int val5;
        //        if (string.IsNullOrEmpty(cmdText5))
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            val5 = TestMethod.ExecuteNonQuery(cmdText5);
        //        }
        //    }
        //    ///控制台参数表
        //    {
        //        StringBuilder sbr5 = new StringBuilder();
        //        sbr5.AppendLine("CREATE TABLE IF NOT EXISTS `ConsoleParamTable`(");
        //        sbr5.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,");//自增id主键
        //        sbr5.AppendLine("`MethodID` CHAR(8) NOT NULL,");//方法ID
        //        sbr5.AppendLine("`ConsoleID` CHAR(20) NOT NULL,"); //控制台ID
        //        sbr5.AppendLine("`OnTimeDisplayID` CHAR(8) NOT NULL,");//实时显示ID
        //        sbr5.AppendLine("`SensorID` CHAR(4) NOT NULL,");//传感器ID
        //        sbr5.AppendLine("`DisplayName` TINYTEXT NOT NULL,");//显示名称
        //        sbr5.AppendLine("`DiaplayDescript` TINYTEXT NOT NULL,"); //显示描述
        //        sbr5.AppendLine("`DiaplayUnit` CHAR(8) NOT NULL,");//显示单位
        //        sbr5.AppendLine("`DecimalPlace` CHAR(8) NOT NULL,");//小数位
        //        sbr5.AppendLine("`HotKeyName` CHAR(8) NOT NULL,");//功能键名称
        //        sbr5.AppendLine("`HotKeyDescript` CHAR(8) NOT NULL,");//功能键描述
        //        sbr5.AppendLine("`FrameSpace` CHAR(8) NOT NULL,");//作业空间
        //        sbr5.AppendLine("`FixturesType` CHAR(8) NOT NULL,");//夹具类型
        //        sbr5.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
        //        sbr5.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
        //        sbr5.AppendLine();
        //        string cmdText5 = sbr5.ToString();
        //        int val5;
        //        if (string.IsNullOrEmpty(cmdText5))
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            val5 = TestMethod.ExecuteNonQuery(cmdText5);
        //        }
        //    }

        //    ///结果表
        //    {
        //        StringBuilder sbr6 = new StringBuilder();
        //        sbr6.AppendLine("CREATE TABLE IF NOT EXISTS `ResultParamTable`(");
        //        sbr6.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,");//自增id主键
        //        sbr6.AppendLine("`MethodID` CHAR(8) NOT NULL,");//方法ID
        //        sbr6.AppendLine("`ResultID` CHAR(20) NOT NULL,"); //结果ID
        //        sbr6.AppendLine("`ResultName` TINYTEXT NOT NULL,");//结果名称
        //        sbr6.AppendLine("`ResultParamName` TINYTEXT NOT NULL,");//结果参数名称
        //        sbr6.AppendLine("`TestNumber` CHAR(4) NOT NULL,");//试验编号
        //        sbr6.AppendLine("`UserID` CHAR(4) NOT NULL,");//操作员ID
        //        sbr6.AppendLine("`RawDataPath` CHAR(20) NOT NULL,"); //元数据路径
        //        sbr6.AppendLine("`TestDate` DATE NOT NULL,");//试验日期
        //        sbr6.AppendLine("`RawbakPath` CHAR(20) NOT NULL,");//元数据备份路径
        //        sbr6.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
        //        sbr6.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
        //        sbr6.AppendLine();
        //        string cmdText6 = sbr6.ToString();
        //        int val6;
        //        if (string.IsNullOrEmpty(cmdText6))
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            val6 = TestMethod.ExecuteNonQuery(cmdText6);
        //        }
        //    }
        //}
    }
}

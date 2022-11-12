using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common.DAO;
using WanCeDesktopApp.Extensions;
using WanCeDesktopApp.Views;

namespace WanCeDesktopApp.ViewModels
{
    public class TabControlConsoleViewModel : BindableBase, INavigationAware
    {

        private readonly IRegionManager regionManager;
        bool IsFirstLoad = true;//是否是第一次加载
        public int MenuIndex { get; set; } = 0;
        private NavigationParameters parameter;
        #region
        public DelegateCommand<string> OpenViewCommand { get; private set; }
        public DelegateCommand LoadedCommand { get; private set; }
        public DelegateCommand<NegativeBarInfos> SelectionChangedCommand { get; private set; }
        #endregion
        private ObservableCollection<NegativeBarInfos> negativeBarInfos;

        public ObservableCollection<NegativeBarInfos> NegativeBarInfos
        {
            get { return negativeBarInfos; }
            set { negativeBarInfos = value; RaisePropertyChanged(); }
        }

        public TabControlConsoleViewModel(IRegionManager regionManager)
        {

            this.regionManager = regionManager;
            OpenViewCommand = new DelegateCommand<string>(OpenView);
            LoadedCommand = new DelegateCommand(Loaded);
            NegativeBarInfos = new ObservableCollection<NegativeBarInfos>();
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 0, NameSpace = "ConsoleLiveDisplaysView", Title = "TabSectionTitleLiveDisplays" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 1, NameSpace = "ConsoleSoftKeysView", Title = "TabSectionTitleSoftKeys" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 2, NameSpace = "ConsoleFrameView", Title = "TabSectionTitleFrame" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 3, NameSpace = "ConsoleGripsView", Title = "TabSectionTitleGrips" });
            SelectionChangedCommand = new DelegateCommand<NegativeBarInfos>(SelectionChanged);
            
        }

        private void SelectionChanged(NegativeBarInfos obj)
        {
            try
            {
                //OKInsertDB();
                if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
                {
                    return;
                }
                else
                {
                    this.regionManager.Regions[PrismManage.ConsoleViewRegionName].RequestNavigate(obj.NameSpace);
                }
            }
            catch (Exception ex)
            {


            }
        }
        private void Loaded()
        {


        }
        public void OpenView(string strItem)//注册导航
        {
            try
            {
                if (strItem == null || string.IsNullOrWhiteSpace(strItem))
                {
                    return;
                }
                else
                {
                    this.regionManager.Regions[PrismManage.ConsoleViewRegionName].RequestNavigate(strItem);
                }
            }
            catch (System.NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            parameter = navigationContext.Parameters;
            //先保留
            switch (parameter.GetValue<string>("Tag"))
            {
                case "LiveDisplay":
                    MenuIndex = 0;
                    regionManager.Regions[PrismManage.ConsoleViewRegionName].RequestNavigate(nameof(ConsoleLiveDisplaysView));
                    break;
                case "SoftKeys":
                    MenuIndex = 1;
                    regionManager.Regions[PrismManage.ConsoleViewRegionName].RequestNavigate(nameof(ConsoleSoftKeysView));
                    break;
                case "Frame":
                    MenuIndex = 2;
                    regionManager.Regions[PrismManage.ConsoleViewRegionName].RequestNavigate(nameof(ConsoleFrameView));
                    break;
                case "Grips":
                    MenuIndex = 3;
                    regionManager.Regions[PrismManage.ConsoleViewRegionName].RequestNavigate(nameof(ConsoleGripsView));
                    break;
                default:
                    MenuIndex = 0;
                    regionManager.Regions[PrismManage.ConsoleViewRegionName].RequestNavigate(nameof(ConsoleLiveDisplaysView));
                    break;
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
        public void OKInsertDB()//数据页数据
        {
            SQLiteHelper dbTable = new SQLiteHelper("TestControlDataBase ");
            StringBuilder strCmd = new StringBuilder();
            strCmd.Clear();
            strCmd.Append("INSERT INTO ConsoleParamTable (" +
                       "MethodID, " + //方法ID
                       "ConsoleID," + //控制台ID
                       "OnTimeDisplayID," + //实时显示ID
                       "DisplayName," +     //显示名称
                       "DisplayUnit," +     //显示单位
                       "DecimalPlaces," +   //显示小数位
                       "DisplayMax," +      //显示最大值
                       "DisplayRate," +     //显示速率
                       "MaxColumns," +      //显示最大列
                       "HotKeyName," +      //功能键名称
                       "FrameSpace," +      //作业空间
                       "FixturesType," +    //夹具类型
                       "EnableFlage," +     //预拉伸
                       "ValueType," +       //值
                       "ValueUnit" +        //unit
                       ") VALUES ");
            strCmd.Append("(");
            strCmd.Append("567890");//方法ID
            strCmd.Append(",");
            strCmd.Append("78");//控制台ID
            strCmd.Append(",");
            strCmd.Append("78");//实时显示ID
            strCmd.Append(",");
            strCmd.Append("\"");
            strCmd.Append("78");//显示名称t
            strCmd.Append("\"");
            strCmd.Append(",");
            strCmd.Append("78");//显示单位
            strCmd.Append(",");
            strCmd.Append("78");//小数位
            strCmd.Append(",");
            strCmd.Append("3");//显示最大值
            strCmd.Append(",");
            strCmd.Append("1000");//速率
            strCmd.Append(",");
            strCmd.Append("3");//显示最大列
            strCmd.Append(",");
            strCmd.Append("\"");
            strCmd.Append("78");//功能键名称
            strCmd.Append("\"");
            strCmd.Append(",");
            strCmd.Append("78");//作业空间
            strCmd.Append(",");
            strCmd.Append("\"");
            strCmd.Append("jhk");//夹具类型
            strCmd.Append("\"");
            strCmd.Append(",");
            strCmd.Append("1");  //预拉伸
            strCmd.Append(",");
            strCmd.Append("563");  //值
            strCmd.Append(",");
            strCmd.Append("\"");
            strCmd.Append("mm");  //unit
            strCmd.Append("\"");
            strCmd.Append(");");
            string sqlStrCommande = strCmd.ToString();
            DataTable dt = dbTable.ExecuteDataTable(sqlStrCommande);
        }
    }
    
}

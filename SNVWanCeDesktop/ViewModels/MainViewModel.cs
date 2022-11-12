using Prism.Mvvm;
using System.Collections.ObjectModel;
using WanCeDesktopApp.Common;
using Prism.Commands;
using Prism.Regions;
using WanCeDesktopApp.Extensions;
using Serilog;
using System;
using System.Windows.Input;
using System.Globalization;
using WPFLocalizeExtension.Engine;
using Prism.Events;
using System.Collections.Generic;
using WanCeDesktopApp.Common.DAO;
using System.Windows;
using WanCeDesktopApp.Views;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using MachineControlModule;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Linq;
using System.Text;

namespace WanCeDesktopApp.ViewModels
{
    public class MainViewModel : BindableBase, IConfigursIndexService
    {
        private static ILogger log = Log.ForContext<App>();
        private IDialogHostService dialogService; //自定义对话框
        private List<GaugeItemInfo> defaultDisplayInfos;
        public ShowInfo Menu1 { get; set; }
        public ShowInfo Menu2 { get; set; }
        public ShowInfo Menu3 { get; set; }
        public string HomeIcon { get; set; }
        public string HomeToolTip { get; set; }
        public Visibility IsVisibility { get; set; }

        /// <summary>
        /// 多语言切换命令
        /// </summary>
        public ICommand SwitchToLangCommand { get; private set; }
        public DelegateCommand HomeButtonClickCommand { get; private set; }
        public DelegateCommand<GaugeItemInfo> ClearThoroughfareCommand { get; private set; }
        public DelegateCommand<string> CommonKeyClickCommand { get; private set; }
        public int LiveDisplayColumnCount { get; private set; }
        public int LiveDisplayRowCount { get; private set; }
        public UniversalController UniController { get; set; }
        SampleData sampleData = null;
        public string IPAddress { get; set; }
        public string Port { get; set; }

        /// <summary>
        /// 创建菜单集合，动态添加资源
        /// </summary>
        public MainViewModel(
            IRegionManager regionManager,
            IDialogHostService dialog,
            IEventAggregator eventAggregator
        )
        {
            try
            { // UNDONE: 多语言功能的初始化需要与配置文件结合（目前配置文件尚未完成）
                // 配置多语言字典的 Culture，默认跟随当前系统语言
                CultureInfo ci = CultureInfo.CurrentCulture;
                LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo(
                    ci.TwoLetterISOLanguageName
                );
                //eventAggregator.GetEvent<MessageEvent>().Subscribe(ResponseUpdating, ThreadOption.PublisherThread, false, filter => filter.Filter == "MainView");
                eventAggregator.GetEvent<GaugeItemInfosEvent>().Subscribe(ResponseUpdatingPlus);
                eventAggregator
                    .GetEvent<MessageEvent>()
                    .Subscribe(
                        ShowMainMenuBar,
                        ThreadOption.PublisherThread,
                        false,
                        filter => filter.Filter == "MainView"
                    );
                Init();
                this.regionManager = regionManager; //导航日志
                this.dialogService = dialog;
                ExecuteAddDataShowCommand = new DelegateCommand<string>(Excute);

                GoBackCommand = new DelegateCommand(() =>
                {
                    if (journal != null && journal.CanGoBack)
                    {
                        journal.GoBack();
                        var name = regionManager.Regions[PrismManage.MainViewRegionName].Name;
                        //if (regionManager.Regions[PrismManage.MainViewRegionName])
                    }
                    else
                    {
                        log.Error("empty value !");
                    }
                });
                GoForwardCommand = new DelegateCommand(() =>
                {
                    if (journal != null && journal.CanGoForward)
                    {
                        journal.GoForward();
                    }
                    else
                    {
                        log.Error("empty value !");
                    }
                });
                SwitchToLangCommand = new DelegateCommand<string>(
                    (langName) =>
                    {
                        // UNDONE: 多语言切换需要写入配置文件（目前配置文件尚未完成）
                        CultureInfo newCulture = CultureInfo.GetCultureInfo(langName);
                        LocalizeDictionary.Instance.Culture = newCulture;
                    }
                );
                CreateDataBase(); //创建数据库
            }
            catch (System.NullReferenceException ex)
            {
                log.Error(ex, AppConstants.EXCEPTION_RAISED);
            }
            catch (Exception ex)
            {
                log.Error(ex, AppConstants.EXCEPTION_RAISED);
            }
        }

        private void Init()
        {
            MenuBars = new ObservableCollection<ShowInfo>();
            DataBars = new ObservableCollection<GaugeItemInfo>();
            ToolBars = new ObservableCollection<ShowInfo>();
            SoftKeyBars = new ObservableCollection<SoftKeyInfo>();
            NavigateCommand = new DelegateCommand<ShowInfo>(Navigate); //注册导航
            Menu1 = new ShowInfo()
            {
                Icon = "NetworkPos",
                Title = "Test",
                IsChecked = false,
                IsVisibility = Visibility.Collapsed
            };
            Menu2 = new ShowInfo()
            {
                Icon = "AccountEditOutline",
                Title = "Method",
                IsChecked = false,
                IsVisibility = Visibility.Collapsed
            };
            Menu3 = new ShowInfo()
            {
                Icon = "FileExportOutline",
                Title = "Report",
                IsChecked = false,
                IsVisibility = Visibility.Collapsed
            };
            ToolBars.Add(
                new ShowInfo()
                {
                    Icon = "AccountLock",
                    Description = "AccountLock",
                    IsVisibility = Visibility.Visible
                }
            );
            ToolBars.Add(
                new ShowInfo()
                {
                    Icon = "WeatherCloudyAlert",
                    Description = "NetworkPos",
                    IsVisibility = Visibility.Visible
                }
            );
            ToolBars.Add(
                new ShowInfo()
                {
                    Icon = "ContentSaveCheckOutline",
                    Description = "NetworkPos",
                    IsVisibility = Visibility.Visible
                }
            );
            ToolBars.Add(
                new ShowInfo()
                {
                    Icon = "NetworkPos",
                    Description = "NetworkPos",
                    IsVisibility = Visibility.Collapsed
                }
            );
            ToolBars.Add(
                new ShowInfo()
                {
                    Icon = "HelpCircleOutline",
                    Description = "NetworkPos",
                    IsVisibility = Visibility.Visible
                }
            );
            SoftKeyBars = Collections.SoftKeyItems;
            IsVisibility = Visibility.Collapsed;
            HomeIcon = "Close";
            HomeToolTip = "CloseTheWindow";
            HomeButtonClickCommand = new DelegateCommand(HomeButtonClick);
            ClearThoroughfareCommand = new DelegateCommand<GaugeItemInfo>(ClearThoroughfare);
            CommonKeyClickCommand = new DelegateCommand<string>(CommonKeyClick);
            IPAddress = "192.168.1.150";
            Port = "5000";
            UniController = UniversalController.Instance;
        }

        private void CommonKeyClick(string obj)
        {
            //通过icon区分不同的按钮
            if (obj == "ContentSaveCheckOutline")
            {
                CollectionsData collectionsData = new CollectionsData();
                collectionsData.Sample = Collections.Sample;
                collectionsData.SoftKeyItems = Collections.SoftKeyItems;
                collectionsData.Specimen = Collections.Specimen;
                collectionsData.GaugeItems = Collections.GaugeItems;
                collectionsData.SelectedCalculationItems = Collections.SelectedCalculationItems;
                //文件保存方法， 还需要一个总的文件来保存所有方法信息，根据这个信息去获取对应的方法文件
                //保存路径计划为： //方法文件//用户//保存的方法
                XmlProvider.Save("D:\\WANCE\\testFile.xml", collectionsData);
            }
        }

        private void ClearThoroughfare(GaugeItemInfo obj)
        {
            if (obj == null)
            {
                return;
            }
            UniChannel? channel = (UniChannel?)Enum.Parse(typeof(UniChannel), obj.Joint);
            UniController.Tare(channel.Value);
        }

        private void HomeButtonClick()
        {
            short port = short.Parse(Port);
            if (UniController.ConnectLAN(IPAddress, port))
            {
                UniController.GotSampleData += UniController_GotSampleData;
            }
            else
            {
                if (UniController.ActiveControllerType == ControllerType.Unknown)
                {
                    if (
                        MessageBox.Show(
                            "未检测到机架， 是否启用模拟数据？",
                            "提示",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question
                        ) == MessageBoxResult.Yes
                    )
                    {
                        DisplayUpdating(true);
                    }
                }
            }

            if (HomeIcon == "Home")
            {
                HomeIcon = "Close";
                HomeToolTip = "CloseTheWindow";
                IsVisibility = Visibility.Collapsed;
                ToolBars[2].IsVisibility = Visibility.Collapsed;
                CreateDataBar();
                regionManager.Regions[PrismManage.MainViewRegionName].RequestNavigate(
                    nameof(IndexView),
                    back =>
                    {
                        journal = back.Context.NavigationService.Journal;
                    }
                );

                SetCollapsed();
            }
        }

        private void UniController_GotSampleData(object? sender, GotSampleDataEventArgs e)
        {
            sampleData = e.Data;
            SampleData_DataChanged();
        }

        private void SetCollapsed()
        {
            Menu1.IsVisibility = Visibility.Collapsed;
            Menu2.IsVisibility = Visibility.Collapsed;
            Menu3.IsVisibility = Visibility.Collapsed;
        }

        private void ShowMainMenuBar(Message obj)
        {
            if (obj == null)
            {
                return;
            }
            try
            {
                HomeIcon = "Home";
                HomeToolTip = "GoBackToHome";
                IsVisibility = Visibility.Visible;
                ToolBars[2].IsVisibility = Visibility.Visible;
                switch (obj.Content)
                {
                    case "TestView":
                        Menu2.IsChecked = false;
                        Menu3.IsChecked = false;
                        Menu1.IsChecked = true;
                        Menu1.IsVisibility = Visibility.Visible;
                        Menu2.IsVisibility = Visibility.Collapsed;
                        Menu3.IsVisibility = Visibility.Collapsed;
                        break;
                    case "MethodView":
                        Menu1.IsChecked = false;
                        Menu3.IsChecked = false;
                        Menu2.IsChecked = true;
                        Menu1.IsVisibility = Visibility.Collapsed;
                        Menu2.IsVisibility = Visibility.Visible;
                        Menu3.IsVisibility = Visibility.Collapsed;
                        break;
                    case "3":
                        Menu1.IsChecked = false;
                        Menu2.IsChecked = false;
                        Menu3.IsChecked = true;
                        Menu1.IsVisibility = Visibility.Collapsed;
                        Menu2.IsVisibility = Visibility.Collapsed;
                        Menu3.IsVisibility = Visibility.Visible;
                        break;
                    case "EditMethod":
                        Menu1.IsChecked = false;
                        Menu3.IsChecked = false;
                        Menu2.IsChecked = true;
                        Menu1.IsVisibility = Visibility.Visible;
                        Menu2.IsVisibility = Visibility.Visible;
                        Menu3.IsVisibility = Visibility.Visible;
                        break;
                    //case "SoftKey":
                    //    if (SoftKeyBars.Count > 0)
                    //    {
                    //        SoftKeyPanelVisibility = Visibility.Visible;
                    //    }
                    //    else
                    //    {
                    //        SoftKeyPanelVisibility = Visibility.Collapsed;
                    //    }
                    //    break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        //显示更新
        private void DisplayUpdating(bool isSimulate)
        {
            cancellationTokenSource.Cancel();
            if (!isSimulate)
            {
                //通道数据
            }
            else
            {
                cancellationTokenSource = new CancellationTokenSource();
                CancellationToken token = cancellationTokenSource.Token;
                int frequency = 50; //刷新间隔 毫秒
                Tools.SimulateLiveDisplayData(token, frequency);
            }
            //DataBars
            //SampleData? LatestSampleData;
            //UniversalController UniController = UniversalController.Instance;
            //string IPAddress = "192.168.1.150";
            //string Port = "5000";
            //short port = short.Parse(Port);
            //LatestSampleData = UniController.ConnectLAN(IPAddress, port);
        }

        object o = new object();

        private void SampleData_DataChanged()
        {
            lock (o)
            {
                //通道赋值，模拟计算赋值 判断实验是否结束，结束给计算结果赋值
                foreach (var item in Collections.LiveDisplayGaugeItemInfos)
                {
                    //   接头
                    switch (item.GaugeType)
                    {
                        case "Time":
                            if (sampleData.Time.IsOnline)
                            {
                                item.ChannelValue = sampleData.Time.SampleValue;
                                item.ChannelUnit = "s";
                            }
                            break;
                        case "Force":
                            if (sampleData.Load.IsOnline)
                            {
                                item.ChannelValue = sampleData.Load.SampleValue;
                                item.ChannelUnit = "N";

                            }
                            break;
                        case "Position":
                            if (sampleData.Position.IsOnline)
                            {
                                item.ChannelValue = sampleData.Position.SampleValue;
                                item.ChannelUnit = "mm";
                            }
                            break;
                        case "Load":
                            if (sampleData.Load.IsOnline)
                            {
                                item.ChannelValue = sampleData.Load.SampleValue;
                                item.ChannelUnit = "N";
                            }
                            break;
                        case "PosSpeed":
                            if (sampleData.PosSpeed.IsOnline)
                            {
                                item.ChannelValue = sampleData.PosSpeed.SampleValue;
                                item.ChannelUnit = "mm/min";
                            }
                            break;
                        //变形
                        case "Deformation":
                            if (sampleData.Deformation.IsOnline)
                            {
                                item.ChannelValue = sampleData.Deformation.SampleValue;
                                item.ChannelUnit = "mm";

                            }
                            break;
                        case "LoadSpeed":
                            if (sampleData.LoadSpeed.IsOnline)
                            {
                                item.ChannelValue = sampleData.LoadSpeed.SampleValue;
                                item.ChannelUnit = "N/s";
                            }
                            break;
                        //阀开度
                        case "ValveOpen":
                            if (sampleData.ValveOpen.IsOnline)
                            {
                                item.ChannelValue = sampleData.ValveOpen.SampleValue;
                            }
                            break;
                        default:
                            break;
                    }

                    //sampleData.Time ;
                    //sampleData.Position ;
                    //sampleData.Load ;
                    //sampleData.Deformation ;
                    //sampleData.BigDeformUpper;
                    //sampleData.BigDeformLower;
                    //sampleData.ExtSensor1;
                    //sampleData.ExtSensor2;
                    //sampleData.ExtSensor3;
                    //sampleData.ExtSensor4;
                    //sampleData.PosSpeed ;
                    //sampleData.LoadSpeed ;
                    //sampleData.DeformSpeed ;
                    //sampleData.ValveOpen;
                    //sampleData.AbsPosition;
                }
            }
        }

        //针对增删改变
        private void ResponseUpdatingPlus(List<GaugeItemInfo> objs)
        {
            if (Collections.LiveDisplayGaugeItemInfos.Count == 0)
            {
                LiveDisplayColumnCount = 1;
                LiveDisplayRowCount = 1;
                DataBars = new ObservableCollection<GaugeItemInfo>();
                DataBars.Add(
                    new GaugeItemInfo()
                    {
                        UserDefinedTitle = null,
                        DefaultTitleKey = "NoLiveDisplays",
                        DisplayValue = "- - - -"
                    }
                );
                return;
            }
            DataBars = Collections.LiveDisplayGaugeItemInfos;
            if (Collections.LiveDisplayGaugeItemInfos.Count > 6)
            {
                LiveDisplayColumnCount = (int)
                    Math.Ceiling(Collections.LiveDisplayGaugeItemInfos.Count / 2.0);
                LiveDisplayRowCount = (int)
                    Math.Ceiling(Collections.LiveDisplayGaugeItemInfos.Count / 6.1);
            }
            else
            {
                LiveDisplayColumnCount = Collections.LiveDisplayGaugeItemInfos.Count;
                LiveDisplayRowCount = 1;
            }
            //DataBars = new ObservableCollection<GaugeItemInfo>();
            //LiveDisplayCount = objs.Count;
            //DataBars.AddRange(objs);
        }

        private void Excute(string str)
        {
            //if (str == "AddShowData")
            //{
            //    dialogService.ShowDialog("AddDataShowView", null);//自定义对话框
            //}
        }

        public void Navigate(ShowInfo obj) //注册导航
        {
            try
            {
                if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
                {
                    return;
                }
                else
                {
                    regionManager.Regions[PrismManage.MainViewRegionName].RequestNavigate(
                        obj.NameSpace,
                        back =>
                        {
                            journal = back.Context.NavigationService.Journal;
                        }
                    );
                }
            }
            catch (System.NullReferenceException ex)
            {
                log.Error(ex, AppConstants.EXCEPTION_RAISED);
            }
            catch (Exception ex)
            {
                log.Error(ex, AppConstants.EXCEPTION_RAISED);
            }
        }

        #region
        /// <summary>
        /// 注册导航
        /// </summary>
        public DelegateCommand<ShowInfo> NavigateCommand { get; private set; }
        public DelegateCommand<String> ExecuteAddDataShowCommand { get; private set; }
        public DelegateCommand GoBackCommand { get; private set; }
        public DelegateCommand GoForwardCommand { get; private set; }

        private IRegionNavigationJournal journal; //导航日志
        private readonly IRegionManager regionManager;

        private ObservableCollection<ShowInfo> menuBars; //注册菜单
        public ObservableCollection<ShowInfo> MenuBars
        {
            get { return menuBars; }
            set
            {
                menuBars = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<GaugeItemInfo> dataBars; //注册菜单
        public ObservableCollection<GaugeItemInfo> DataBars
        {
            get { return dataBars; }
            set
            {
                dataBars = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<ShowInfo> ToolBars { get; set; }
        public ObservableCollection<SoftKeyInfo> SoftKeyBars { get; set; }
        #endregion
        /// <summary>
        /// 创建动态绑定的listBox菜单,属性在MenuBar类中//注册菜单
        /// </summary>
        void CreateMenuBar()
        {
            try
            {
                menuBars.Add(
                    new ShowInfo()
                    {
                        Icon = "Home",
                        Title = "首页",
                        NameSpace = "IndexView"
                    }
                );
                menuBars.Add(
                    new ShowInfo()
                    {
                        Icon = "NotebookOutline",
                        Title = "试验",
                        NameSpace = "TestView"
                    }
                );
                menuBars.Add(
                    new ShowInfo()
                    {
                        Icon = "NotebookPlus",
                        Title = "方法",
                        NameSpace = "MethodView"
                    }
                );
                menuBars.Add(
                    new ShowInfo()
                    {
                        Icon = "Cog",
                        Title = "系统管理",
                        NameSpace = "SystemManageView"
                    }
                );
            }
            catch (System.NullReferenceException ex)
            {
                log.Error(ex, AppConstants.EXCEPTION_RAISED);
            }
            catch (Exception ex)
            {
                log.Error(ex, AppConstants.EXCEPTION_RAISED);
            }
        }

        void CreateDataBar()
        {
            try
            {
                Collections.LiveDisplayGaugeItemInfos = new ObservableCollection<GaugeItemInfo>();
                LiveDisplayColumnCount = 4;
                LiveDisplayRowCount = 1;
                if (defaultDisplayInfos == null)
                {
                    defaultDisplayInfos = new List<GaugeItemInfo>();
                    defaultDisplayInfos.Add(
                        new GaugeItemInfo()
                        {
                            DefaultTitleKey = "Displacement",
                            DisplayValue = "0.00000",
                            Unit = "mm",
                            Id = 0,
                            Index = 0,
                            UnitSetName = "Length",
                            Joint = "Position"
                        }
                    );
                    defaultDisplayInfos.Add(
                        new GaugeItemInfo()
                        {
                            DefaultTitleKey = "Load",
                            DisplayValue = "0.00000",
                            Unit = "N",
                            Id = 0,
                            Index = 0,
                            UnitSetName = "Force",
                            Joint = "Load"
                        }
                    );
                    defaultDisplayInfos.Add(
                        new GaugeItemInfo()
                        {
                            DefaultTitleKey = "Strain2",
                            DisplayValue = "0.00000",
                            Unit = "mm/mm",
                            Id = 0,
                            Index = 0,
                            Joint = "Strain"
                        }
                    );
                    defaultDisplayInfos.Add(
                        new GaugeItemInfo()
                        {
                            DefaultTitleKey = "Time",
                            DisplayValue = "- - - -",
                            Unit = "s",
                            Id = 0,
                            Index = 0,
                            UnitSetName = "Time",
                            Joint = "Time"
                        }
                    );
                }
                Collections.LiveDisplayGaugeItemInfos.AddRange(defaultDisplayInfos);
                DataBars = Collections.LiveDisplayGaugeItemInfos;
            }
            catch (System.NullReferenceException ex)
            {
                log.Error(ex, AppConstants.EXCEPTION_RAISED);
            }
            catch (Exception ex)
            {
                log.Error(ex, AppConstants.EXCEPTION_RAISED);
            }
        }

        /// <summary>
        /// 配置首页初始化参数
        /// </summary>
        public void Configure()
        {
            try
            {
                CreateMenuBar();
                CreateDataBar();
                regionManager.Regions[PrismManage.MainViewRegionName].RequestNavigate(
                    nameof(IndexView),
                    back =>
                    {
                        journal = back.Context.NavigationService.Journal;
                    }
                );
            }
            catch (System.NullReferenceException ex)
            {
                log.Error(ex, AppConstants.EXCEPTION_RAISED);
            }
            catch (Exception ex)
            {
                log.Error(ex, AppConstants.EXCEPTION_RAISED);
            }
        }

        public void CreateDataBase() //建库
        {
            string[] str_DB =
            {
                "ISODataBase",
                "SystemInfoDataBase",
                "TestControlDataBase",
                "TestMethodParamDataBase",
                "UserInfoInfoDataBase"
            };
            string[] str_KEY =
            {
                "ISO",
                "SystemInfo",
                "TestControl",
                "TestMethodParam",
                "UserInfoInfo"
            };

            for (int i = 0; i < str_DB.Length; i++)
            {
                SQLiteHelper UserInfo = new SQLiteHelper(str_DB[i]);
                SQLiteHelper.DataBaceList.Add(str_KEY[i], UserInfo);
                UserInfo.CreateDataBase();
            }
            CreateSystemInfoTable();
            CreateUserInfoTable();
            CreateISO9000Table();
        }

        public void CreateSystemInfoTable() //完成
        {
            //信息库
            SQLiteHelper SystemInfo = new SQLiteHelper("SystemInfoDataBase");
            //建系统信息表
            {
                StringBuilder sbr = new StringBuilder();
                sbr.AppendLine("CREATE TABLE IF NOT EXISTS `SystemInfoTable`(");
                sbr.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,"); //自增id主键
                sbr.AppendLine("`MachineID` CHAR(9) NOT NULL,"); //设备ID
                sbr.AppendLine("`MachineType` CHAR(4) NOT NULL,"); //设备类型
                sbr.AppendLine("`InstallDate` DATE NOT NULL,"); //安装日期
                sbr.AppendLine("`FrameNumber` CHAR(20) NOT NULL,"); //机架编号
                sbr.AppendLine("`ControlProtocolNumber` CHAR(20) NOT NULL,"); //控制器协议号
                sbr.AppendLine("`AttachmentID` CHAR(9) NOT NULL,"); //附件ID
                sbr.AppendLine("`SensorID` CHAR(9) NOT NULL,"); //传感器ID
                sbr.AppendLine("`CopyrightInformation` TINYTEXT NOT NULL,"); //版权信息
                sbr.AppendLine("`SoftwareVersion` CHAR(10) NOT NULL,"); //软件版本
                sbr.AppendLine("`KeyCode` CHAR(20) NOT NULL,"); //密钥
                sbr.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,"); //创建时间
                sbr.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );"); //更新时间
                sbr.AppendLine();
                string cmdText = sbr.ToString();
                int val;
                if (string.IsNullOrEmpty(cmdText))
                {
                    return;
                }
                else
                {
                    val = SystemInfo.ExecuteNonQuery(cmdText);
                }
            }

            //异常信息表
            {
                StringBuilder sbr = new StringBuilder();
                sbr.AppendLine("CREATE TABLE IF NOT EXISTS `ExceptionInfoTable`(");
                sbr.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,"); //自增id主键
                sbr.AppendLine("`ExceptionID` CHAR(9) NOT NULL,"); //异常ID
                sbr.AppendLine("`ExceptionNumber` CHAR(4) NOT NULL,"); //异常编号
                sbr.AppendLine("`ExceptionType` CHAR(4) NOT NULL,"); //异常类型
                sbr.AppendLine("`ExceptionLevel` TINYTEXT NOT NULL,"); //异常级别
                sbr.AppendLine("`ExceptionDescription` TINYTEXT NOT NULL,"); //异常描述
                sbr.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
                sbr.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
                sbr.AppendLine();
                string cmdText = sbr.ToString();
                int val;
                if (string.IsNullOrEmpty(cmdText))
                {
                    return;
                }
                else
                {
                    val = SystemInfo.ExecuteNonQuery(cmdText);
                }
            }

            //维保信息表
            {
                StringBuilder sbr = new StringBuilder();
                sbr.AppendLine("CREATE TABLE IF NOT EXISTS `OperationAndMaintenanceTable`(");
                sbr.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,"); //自增id主键
                sbr.AppendLine("`OperationAndMaintenanceID` CHAR(9) NOT NULL,"); //维保ID
                sbr.AppendLine("`OAMContent` TINYTEXT NOT NULL,"); //维保内容
                sbr.AppendLine("`LastOAMDate` DATE NOT NULL,"); //维保日期
                sbr.AppendLine("`OAMCycle` CHAR(4) NOT NULL,"); //维保周期
                sbr.AppendLine("`NextOAMDate` DATE NOT NULL,"); //下次维保时间
                sbr.AppendLine("`CompletCount` CHAR(8) NOT NULL,"); //维保计数
                sbr.AppendLine("`OAMRemindContent` TINYTEXT NOT NULL,"); //维保提醒内容
                sbr.AppendLine("`OAMFlage` CHAR(1) NOT NULL,"); //维保是否完成标记
                sbr.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
                sbr.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
                sbr.AppendLine();
                string cmdText = sbr.ToString();
                int val;
                if (string.IsNullOrEmpty(cmdText))
                {
                    return;
                }
                else
                {
                    val = SystemInfo.ExecuteNonQuery(cmdText);
                }
            }

            //附件表
            {
                StringBuilder sbr = new StringBuilder();
                sbr.AppendLine("CREATE TABLE IF NOT EXISTS `OperationAndMaintenanceTable`(");
                sbr.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,"); //自增id主键
                sbr.AppendLine("`AttachementID` CHAR(9) NOT NULL,"); //附件ID
                sbr.AppendLine("`AttachementName` TINYTEXT NOT NULL,"); //附件名称
                sbr.AppendLine("`SensorID` CHAR(9) NOT NULL,"); //传感器ID
                sbr.AppendLine("`AttachementType` CHAR(4) NOT NULL,"); //附件类型
                sbr.AppendLine("`Protocol` CHAR(4) NOT NULL,"); //通讯协议
                sbr.AppendLine("`ChannelNomber` CHAR(4) NOT NULL,"); //通道编号
                sbr.AppendLine("`MaxLoad` CHAR(4) NOT NULL,"); //最大载荷
                sbr.AppendLine("`StandLoad` CHAR(4) NOT NULL,"); //标准载荷
                sbr.AppendLine("`CollectionRate` CHAR(4) NOT NULL,"); //采集速率
                sbr.AppendLine("`Sensitivity` CHAR(4) NOT NULL,"); //灵敏度
                sbr.AppendLine("`AttachementParam` CHAR(8) NOT NULL,"); //附件参数
                sbr.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
                sbr.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
                sbr.AppendLine();
                string cmdText = sbr.ToString();
                int val;
                if (string.IsNullOrEmpty(cmdText))
                {
                    return;
                }
                else
                {
                    val = SystemInfo.ExecuteNonQuery(cmdText);
                }
            }
        }

        public void CreateUserInfoTable() //完成
        {
            //用户信息库
            SQLiteHelper UserInfo = new SQLiteHelper("UserInfoInfoDataBase");
            //用户表
            {
                StringBuilder sbr = new StringBuilder();
                sbr.AppendLine("CREATE TABLE IF NOT EXISTS `UserInfoTable`(");
                sbr.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,"); //自增id主键
                sbr.AppendLine("`UserID` CHAR(100), "); //用户ID
                sbr.AppendLine("`Password` CHAR(8),"); //用户密码
                sbr.AppendLine("`MethodID` CHAR(9), "); //方法ID
                sbr.AppendLine("`UserName` TINYTEXT,"); //姓名
                sbr.AppendLine("`RegDate` DATE ,"); //注册日期
                sbr.AppendLine("`Level` VARCHAR(40),"); //级别
                sbr.AppendLine("`Phone` CHAR(11),"); //电话
                sbr.AppendLine("`PermissionID` CHAR(9) ,"); //权限
                sbr.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
                sbr.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
                sbr.AppendLine();
                string cmdText = sbr.ToString();
                int val;
                if (string.IsNullOrEmpty(cmdText))
                {
                    return;
                }
                else
                {
                    val = UserInfo.ExecuteNonQuery(cmdText);
                }
            }
            ///权限表
            {
                StringBuilder sbr = new StringBuilder();
                sbr.AppendLine("CREATE TABLE IF NOT EXISTS `PermissionInfoTable`(");
                sbr.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,"); //自增id主键
                sbr.AppendLine("`Unit` VARCHAR(40) ,"); //单位权限
                sbr.AppendLine("`Calibration` VARCHAR(40) ,"); //校准
                sbr.AppendLine("`Verification` VARCHAR(40)  ,"); //检定
                sbr.AppendLine("`LinearCorrection` VARCHAR(40)  ,"); //线性修正
                sbr.AppendLine("`KeyboardSpeed` VARCHAR(40)  ,"); //键盘速度
                sbr.AppendLine("`GBiso` VARCHAR(40)  ,"); //标准
                sbr.AppendLine("`Rounding` VARCHAR(40)  ,"); //修约
                sbr.AppendLine("`AccountManage` VARCHAR(40)  ,"); //帐户管理
                sbr.AppendLine("`ReadReport` VARCHAR(40)  ,"); //预览报告
                sbr.AppendLine("`TestMethod` VARCHAR(40)  ,"); //试验方法
                sbr.AppendLine("`EditReportTmp` VARCHAR(40)  ,"); //编辑报告模版
                sbr.AppendLine("`DataManage` VARCHAR(40)  ,"); //数据管理
                sbr.AppendLine("`CurvilinearAnalysis` VARCHAR(40)  ,"); //曲线分析
                sbr.AppendLine("`PrintReport` VARCHAR(40)  ,"); //打印报告
                sbr.AppendLine("`LanguageManage` VARCHAR(40)  ,"); //语言管理
                sbr.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
                sbr.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
                sbr.AppendLine();
                string cmdText = sbr.ToString();
                int val;
                if (string.IsNullOrEmpty(cmdText))
                {
                    return;
                }
                else
                {
                    val = UserInfo.ExecuteNonQuery(cmdText);
                }
            }
            ///操作记录表
            {
                StringBuilder sbr = new StringBuilder();
                sbr.AppendLine("CREATE TABLE IF NOT EXISTS `OperationTable`(");
                sbr.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,"); //自增id主键
                sbr.AppendLine("`UserID` VARCHAR(40) NOT NULL,"); //用户ID
                sbr.AppendLine("`TestType` CHAR(2) NOT NULL,"); //试验类型
                sbr.AppendLine("`LoginDate` DATE NOT NULL,"); //登陆时间
                sbr.AppendLine("`LogoutDate` DATE NOT NULL,"); //登出时间
                sbr.AppendLine("`OperationType` CHAR(40) NOT NULL,"); //操作类型
                sbr.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
                sbr.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
                sbr.AppendLine();
                string cmdText = sbr.ToString();
                int val;
                if (string.IsNullOrEmpty(cmdText))
                {
                    return;
                }
                else
                {
                    val = UserInfo.ExecuteNonQuery(cmdText);
                }
            }
        }

        public void CreateISO9000Table() //完成
        {
            //用户信息库
            SQLiteHelper UserInfo = new SQLiteHelper("ISODataBase");
            //标准表
            {
                StringBuilder sbr = new StringBuilder();
                sbr.AppendLine("CREATE TABLE IF NOT EXISTS `ISOTable`(");
                sbr.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,"); //自增id主键
                sbr.AppendLine("`ISOID` CHAR(9) NOT NULL,"); //标准ID
                sbr.AppendLine("`ISOName` CHAR(8) NOT NULL,"); //标准名称
                sbr.AppendLine("`MethodID` CHAR(9) NOT NULL,"); //方法ID
                sbr.AppendLine("`AttachmentID` CHAR(9) NOT NULL,"); //附件ID
                sbr.AppendLine("`UserID` CHAR(9) NOT NULL,"); //用户ID
                sbr.AppendLine("`ISOApplicationType` VARCHAR(40) NOT NULL,"); //标准应用类型
                sbr.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
                sbr.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
                sbr.AppendLine();
                string cmdText = sbr.ToString();
                int val;
                if (string.IsNullOrEmpty(cmdText))
                {
                    return;
                }
                else
                {
                    val = UserInfo.ExecuteNonQuery(cmdText);
                }
            }
            ///标准参数表
            {
                StringBuilder sbr = new StringBuilder();
                sbr.AppendLine("CREATE TABLE IF NOT EXISTS `ISOParamTable`(");
                sbr.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,"); //自增id主键
                sbr.AppendLine("`ISOID` CHAR(9) NOT NULL,"); //标准ID
                sbr.AppendLine("`ISOParamName` TINYTEXT NOT NULL,"); //标准参数名
                sbr.AppendLine("`ISOParamType` CHAR(4) NOT NULL,"); //标准参数类型
                sbr.AppendLine("`ISOParamDescript` TINYTEXT NOT NULL,"); //标准参数描述
                sbr.AppendLine("`Express` CHAR(40) NOT NULL,"); //计算表达式
                sbr.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
                sbr.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
                sbr.AppendLine();
                string cmdText = sbr.ToString();
                int val;
                if (string.IsNullOrEmpty(cmdText))
                {
                    return;
                }
                else
                {
                    val = UserInfo.ExecuteNonQuery(cmdText);
                }
            }
        }

        public void CreateTestControlTable()
        {
            //建用户信息库
            SQLiteHelper UserInfo = new SQLiteHelper("TestControlDataBase");
            //应变表
            {
                StringBuilder sbr = new StringBuilder();
                sbr.AppendLine("CREATE TABLE IF NOT EXISTS `StrainTable`(");
                sbr.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,"); //自增id主键
                sbr.AppendLine("`StrainID` CHAR(9) NOT NULL,"); //应变ID
                sbr.AppendLine("`MethodID` CHAR(9) NOT NULL,"); //方法ID
                sbr.AppendLine("`MeasurementEvent` VARCHAR(40) NOT NULL,"); //测量事件
                sbr.AppendLine("`RemoveISO` VARCHAR(40) NOT NULL,"); //移除标准
                sbr.AppendLine("`Value` CHAR(20) NOT NULL,"); //值
                sbr.AppendLine("`RemoveAction` CHAR(20) NOT NULL,"); //移除后动作
                sbr.AppendLine("`RemoveLockFlage` CHAR(20) NOT NULL,"); //移除后锁定标记
                sbr.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
                sbr.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
                sbr.AppendLine();
                string cmdText = sbr.ToString();
                int val;
                if (string.IsNullOrEmpty(cmdText))
                {
                    return;
                }
                else
                {
                    val = UserInfo.ExecuteNonQuery(cmdText);
                }
            }
            //试验表
            {
                StringBuilder sbr = new StringBuilder();
                sbr.AppendLine("CREATE TABLE IF NOT EXISTS `TestTable`(");
                sbr.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,"); //自增id主键
                sbr.AppendLine("`TestID` CHAR(9) NOT NULL,"); //试验ID
                sbr.AppendLine("`MethodID` CHAR(9) NOT NULL,"); //方法ID
                sbr.AppendLine("`ControlMode` CHAR(4) NOT NULL,"); //控制模式
                sbr.AppendLine("`RateValue` CHAR(20) NOT NULL,"); //速率值
                sbr.AppendLine("`Unit` CHAR(10) NOT NULL,"); //单位
                sbr.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
                sbr.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
                sbr.AppendLine();
                string cmdText = sbr.ToString();
                int val;
                if (string.IsNullOrEmpty(cmdText))
                {
                    return;
                }
                else
                {
                    val = UserInfo.ExecuteNonQuery(cmdText);
                }
            }
            //预循环表
            {
                StringBuilder sbr = new StringBuilder();
                sbr.AppendLine("CREATE TABLE IF NOT EXISTS `PreCyclingTable`(");
                sbr.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,"); //自增id主键
                sbr.AppendLine("`PreCyclingID` CHAR(9) NOT NULL,"); //试验ID
                sbr.AppendLine("`MethodID` CHAR(9) NOT NULL,"); //方法ID
                sbr.AppendLine("`CircleControlCollection` CHAR(20) NOT NULL,"); //循环控制采集
                sbr.AppendLine("`ControlMode` CHAR(20) NOT NULL,"); //控制模式
                sbr.AppendLine("`Rate` CHAR(20) NOT NULL,"); //速率
                sbr.AppendLine("`MaxMeasurement` CHAR(20) NOT NULL,"); //测量最大值
                sbr.AppendLine("`Max` CHAR(10) NOT NULL,"); //最大值
                sbr.AppendLine("`MinMeasurement` CHAR(10) NOT NULL,"); //测量最小值
                sbr.AppendLine("`Min` CHAR(10) NOT NULL,"); //最小值
                sbr.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
                sbr.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
                sbr.AppendLine();
                string cmdText = sbr.ToString();
                int val;
                if (string.IsNullOrEmpty(cmdText))
                {
                    return;
                }
                else
                {
                    val = UserInfo.ExecuteNonQuery(cmdText);
                }
            }
            //数据采集表
            {
                StringBuilder sbr = new StringBuilder();
                sbr.AppendLine("CREATE TABLE IF NOT EXISTS `DataCollectionTable`(");
                sbr.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,"); //自增id主键
                sbr.AppendLine("`DataCollectionID` CHAR(9) NOT NULL,"); //试验ID
                sbr.AppendLine("`MethodID` CHAR(9) NOT NULL,"); //方法ID
                sbr.AppendLine("`Measurement` CHAR(10) NOT NULL,"); //测量
                sbr.AppendLine("`Interval` CHAR(20) NOT NULL,"); //间隔
                sbr.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
                sbr.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
                sbr.AppendLine();
                string cmdText = sbr.ToString();
                int val;
                if (string.IsNullOrEmpty(cmdText))
                {
                    return;
                }
                else
                {
                    val = UserInfo.ExecuteNonQuery(cmdText);
                }
            }
            //预加载控制表
            {
                StringBuilder sbr = new StringBuilder();
                sbr.AppendLine("CREATE TABLE IF NOT EXISTS `PreLoadTable`(");
                sbr.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,"); //自增id主键
                sbr.AppendLine("`PreLoadID` CHAR(9) NOT NULL,"); //试验ID
                sbr.AppendLine("`MethodID` CHAR(9) NOT NULL,"); //方法ID
                sbr.AppendLine("`ControlMode` CHAR(20) NOT NULL,"); //控制模式
                sbr.AppendLine("`ControlRate` CHAR(10) NOT NULL,"); //速率
                sbr.AppendLine("`Criteria` CHAR(20) NOT NULL,"); //标准
                sbr.AppendLine("`Rate` CHAR(10) NOT NULL,"); //速率
                sbr.AppendLine("`Overtravel` CHAR(20) NOT NULL,"); //过载保护
                sbr.AppendLine("`TemperatureSoak` VARCHAR(40) NOT NULL,"); //热浸驻留
                sbr.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
                sbr.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
                sbr.AppendLine();
                string cmdText = sbr.ToString();
                int val;
                if (string.IsNullOrEmpty(cmdText))
                {
                    return;
                }
                else
                {
                    val = UserInfo.ExecuteNonQuery(cmdText);
                }
            }
            //自动平衡表
            {
                StringBuilder sbr = new StringBuilder();
                sbr.AppendLine("CREATE TABLE IF NOT EXISTS `AutoBlanceTable`(");
                sbr.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,"); //自增id主键
                sbr.AppendLine("`AutoBlanceID` CHAR(9) NOT NULL,"); //试验ID
                sbr.AppendLine("`MethodID` CHAR(9) NOT NULL,"); //方法ID
                sbr.AppendLine("`MeasurementType` VARCHAR(40) NOT NULL,"); //测量类型
                sbr.AppendLine("`Descript` CHAR(40) NOT NULL,"); //描述
                sbr.AppendLine("`Unit` CHAR(10) NOT NULL,"); //单位
                sbr.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
                sbr.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
                sbr.AppendLine();
                string cmdText = sbr.ToString();
                int val;
                if (string.IsNullOrEmpty(cmdText))
                {
                    return;
                }
                else
                {
                    val = UserInfo.ExecuteNonQuery(cmdText);
                }
            }
            //试验结束表
            {
                StringBuilder sbr = new StringBuilder();
                sbr.AppendLine("CREATE TABLE IF NOT EXISTS `TestEndTable`(");
                sbr.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,"); //自增id主键
                sbr.AppendLine("`TestEndID` CHAR(9) NOT NULL,"); //试验ID
                sbr.AppendLine("`MethodID` CHAR(9) NOT NULL,"); //方法ID
                sbr.AppendLine("`TestEndType` CHAR(4) NOT NULL,"); //试验结束类型
                sbr.AppendLine("`Value` CHAR(10) NOT NULL,"); //值
                sbr.AppendLine("`Sensitivity` CHAR(20) NOT NULL,"); //灵敏度
                sbr.AppendLine("`SpecmentProtect` CHAR(10) NOT NULL,"); //试样保护
                sbr.AppendLine("`EndState` CHAR(4) NOT NULL,"); //结束后状态
                sbr.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
                sbr.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
                sbr.AppendLine();
                string cmdText = sbr.ToString();
                int val;
                if (string.IsNullOrEmpty(cmdText))
                {
                    return;
                }
                else
                {
                    val = UserInfo.ExecuteNonQuery(cmdText);
                }
            }
        }
    }
}

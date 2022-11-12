using OxyPlot;
using PlotControlLibrary.Common;
using PlotControlLibrary.Events.Payloads;
using PlotControlLibrary.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Extensions;
using OxyPlot.Axes;
using System.Diagnostics;

namespace WanCeDesktopApp.ViewModels
{
    public class IndexViewModel : BindableBase
    {
        IEventAggregator aggregator;
        public int NegativeIndex { get; set; }

        public IndexViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            try
            {
                aggregator = eventAggregator;
                IndexMenus = new ObservableCollection<ShowInfo>();
                CreateIndeMenu();
                NavigateCommandIndexView = new DelegateCommand<ShowInfo>(NavigateIndex);
                this.regionManager = regionManager;
                NegativeIndex = -1;
                //InitPlot();
            }
            catch (System.NullReferenceException ex) { }
            catch (Exception ex) { }
        }

        private readonly IRegionManager regionManager;

        private void InitPlot()
        {
            var channelDataBundle = new List<TestChannelData>()
            {
                new TestChannelData(
                    "Time",
                    "时间",
                    "s",
                    OxyColors.Black,
                    AxisPosition.Bottom,
                    ChannelInitMode.DisplayOnStart
                ),
                new TestChannelData(
                    "Force",
                    "力",
                    "N",
                    OxyColors.Black,
                    AxisPosition.Left,
                    ChannelInitMode.DisplayOnStart | ChannelInitMode.NeedLogarithmicAxis
                ),
                new TestChannelData("Displacement", "位移", "mm", OxyColors.Black, AxisPosition.Left),
                new TestChannelData("Deformation", "变形", "mm", OxyColors.Black, AxisPosition.Left),
                new TestChannelData(
                    "AbsDisplacement",
                    "绝对位移",
                    "mm",
                    OxyColors.Black,
                    AxisPosition.Left
                ),
                new TestChannelData("PosSpeed", "位移速率", "mm/s", OxyColors.Black, AxisPosition.Left),
            };
            var componentsArr = new BuiltinComponents[]
            {
                new BuiltinComponents(channelDataBundle)
            };
            aggregator
                .GetEvent<InitEvent>()
                .Publish(
                    new InitEventPayload(
                        new string[] { "MainTestPlot" },
                        OxyInitMode.SingleYAxis,
                        componentsArr
                    )
                );

            if (componentsArr[0].OxyPlotModel is not null)
            {
                Trace.WriteLine("hello");
            }
        }

        /// <summary>
        /// 注册菜单
        /// </summary>
        private ObservableCollection<ShowInfo> indexMenu; //注册菜单
        public ObservableCollection<ShowInfo> IndexMenus
        {
            get { return indexMenu; }
            set
            {
                indexMenu = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 注册导航
        /// </summary>
        public DelegateCommand<ShowInfo> NavigateCommandIndexView { get; private set; }

        public void NavigateIndex(ShowInfo obj)
        {
            try
            {
                if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
                {
                    return;
                }
                else
                {
                    NegativeIndex = -1;
                    regionManager.Regions[PrismManage.MainViewRegionName].RequestNavigate(
                        obj.NameSpace
                    );
                    aggregator
                        .GetEvent<MessageEvent>()
                        .Publish(new Message() { Content = obj.NameSpace, Filter = "MainView" });
                }
            }
            catch (System.NullReferenceException ex) { }
            catch (Exception ex) { }
        }

        void CreateIndeMenu()
        {
            try
            {
                IndexMenus.Add(
                    new ShowInfo()
                    {
                        Icon = "TestSample",
                        Color = "#D01A33",
                        Title = "Test",
                        NameSpace = "TestGraphyView", //TestView",
                        Content = "IndexMenuContentTest"
                    }
                );
                IndexMenus.Add(
                    new ShowInfo()
                    {
                        Icon = "TestMethod",
                        Color = "#136E9A",
                        Title = "Method",
                        NameSpace = "MethodView",
                        Content = "IndexMenuContentMethod"
                    }
                );
                IndexMenus.Add(
                    new ShowInfo()
                    {
                        Icon = "AdminManagement",
                        Color = "#FE8D00",
                        Title = "SystemManagement",
                        NameSpace = "SystemManageView",
                        Content = "IndexMenuContentManagement"
                    }
                );
                //IndexMenus.Add(new ShowInfo() { Icon = "Home", Color = "#FE8D00", Title = "系统管理", NameSpace = "NewMethodView", Content = "进入系统管理" });
            }
            catch (System.NullReferenceException ex) { }
            catch (Exception ex) { }
        }
    }
}

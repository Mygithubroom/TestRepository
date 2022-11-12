using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WanCeDesktopApp.Extensions;
using WanCeDesktopApp.Common;
using System.Windows;
using System.Collections.ObjectModel;
using WanCeDesktopApp.Common.DAO;
using WPFLocalizeExtension.Extensions;
using Prism.Events;
using WanCeDesktopApp.Views;
using System.Windows.Controls;

namespace WanCeDesktopApp.ViewModels
{
    public class TabControlViewModel : BindableBase, IConfigursIndexService
    {
        bool IsFirstLoad = true; //是否是第一次加载
        private IEventAggregator eventAggregator;
        #region 属性
        private readonly IRegionManager regionManager;
        public DelegateCommand<string> OpenViewCommand { get; private set; }
        public DelegateCommand LoadedCommand { get; private set; }
        private ObservableCollection<ShowInfo> headMenus; //headMenu
        public ObservableCollection<ShowInfo> HeadMenus
        {
            get { return headMenus; }
            set
            {
                headMenus = value;
                RaisePropertyChanged();
            }
        }
        public DelegateCommand<NegativeBarInfos> SelectionChangedCommand
        {
            get;
            private set;
        }
        #endregion
        private ObservableCollection<NegativeBarInfos> negativeBarInfos;

        public ObservableCollection<NegativeBarInfos> NegativeBarInfos
        {
            get { return negativeBarInfos; }
            set
            {
                negativeBarInfos = value;
                RaisePropertyChanged();
            }
        }

        public ScrollBarVisibility TabContentScrollBarVisbility { get; set; }

        public TabControlViewModel(
            IRegionManager regionManager,
            IEventAggregator aggregator
        )
        {
            this.regionManager = regionManager;
            this.eventAggregator = aggregator;
            TabContentScrollBarVisbility = ScrollBarVisibility.Disabled;
            HeadMenus = new ObservableCollection<ShowInfo>();
            OpenViewCommand = new DelegateCommand<string>(OpenView);
            LoadedCommand = new DelegateCommand(Loaded);
            NegativeBarInfos = new ObservableCollection<NegativeBarInfos>();
            NegativeBarInfos.Add(
                new NegativeBarInfos()
                {
                    Id = 0,
                    NameSpace = "TabControlGeneralView",
                    Title = "General",
                    Icon = "General"
                }
            );
            NegativeBarInfos.Add(
                new NegativeBarInfos()
                {
                    Id = 1,
                    NameSpace = "TabControlSampleItemView",
                    Title = "Sample",
                    Icon = "Sample"
                }
            );
            NegativeBarInfos.Add(
                new NegativeBarInfos()
                {
                    Id = 1,
                    NameSpace = "TabControlSpecimenItemView",
                    Title = "Specimen",
                    Icon = "Specimen"
                }
            );
            NegativeBarInfos.Add(
                new NegativeBarInfos()
                {
                    Id = 1,
                    NameSpace = "TabControlMeasurementsView",
                    Title = "Measurements",
                    Icon = "Measurements"
                }
            );
            NegativeBarInfos.Add(
                new NegativeBarInfos()
                {
                    Id = 1,
                    NameSpace = "TabControlCalculationsView",
                    Title = "Calculations",
                    Icon = "Calculations"
                }
            );
            NegativeBarInfos.Add(
                new NegativeBarInfos()
                {
                    Id = 1,
                    NameSpace = "TabControlTestControlView",
                    Title = "TestControl",
                    Icon = "MachineFrame"
                }
            );
            NegativeBarInfos.Add(
                new NegativeBarInfos()
                {
                    Id = 1,
                    NameSpace = "TabControlConsoleView",
                    Title = "Console",
                    Icon = "Console"
                }
            );
            NegativeBarInfos.Add(
                new NegativeBarInfos()
                {
                    Id = 1,
                    NameSpace = "TabControlWorkspaceView",
                    Title = "Workspace",
                    Icon = "Workspace"
                }
            );
            NegativeBarInfos.Add(
                new NegativeBarInfos()
                {
                    Id = 1,
                    NameSpace = "TabControlExportsView",
                    Title = "Exports",
                    Icon = "Exports"
                }
            );
            NegativeBarInfos.Add(
                new NegativeBarInfos()
                {
                    Id = 1,
                    NameSpace = "TabControlWorkflowView",
                    Title = "Workflow",
                    Icon = "Workflow"
                }
            );
            SelectionChangedCommand = new DelegateCommand<NegativeBarInfos>(
                SelectionChanged
            );
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
                    // 某些分页中不需要滚动条
                    switch (obj.NameSpace)
                    {
                        case nameof(SpecimenPropertiesView):
                            TabContentScrollBarVisbility =
                                ScrollBarVisibility.Disabled;
                            break;
                        default:
                            TabContentScrollBarVisbility =
                                ScrollBarVisibility.Auto;
                            break;
                    }
                    this.regionManager.Regions[
                        PrismManage.IndexViewRegionName
                    ].RequestNavigate(obj.NameSpace);
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
                TabContentScrollBarVisbility = ScrollBarVisibility.Auto;
                regionManager.Regions[
                    PrismManage.IndexViewRegionName
                ].RequestNavigate("TabControlGeneralView");
                this.eventAggregator
                    .GetEvent<GaugeItemInfosEvent>()
                    .Publish(new List<GaugeItemInfo>());
                IsFirstLoad = false;
            }
            //加载方法 应该在点击方法的时候就加载，再到这来赋值
            //CollectionsData data = new CollectionsData();
            //data = XmlProvider.Load<CollectionsData>("");
            //给Collections的静态字段赋值
            //为空就设置默认值
            Collections.LiveDisplayGaugeItemInfos =
                new ObservableCollection<GaugeItemInfo>();
            Collections.LiveDisplayGaugeItemInfos.Add(
                new GaugeItemInfo()
                {
                    Id = 0,
                    Index = 0,
                    InputTypeName = "Displacement",
                    Description = "Displacement",
                    DefaultTitleKey = "Displacement",
                    DisplayValue = "0.00000",
                    UnitSetName = "Length",
                    Unit = "mm"
                }
            ); //位移
            Collections.LiveDisplayGaugeItemInfos.Add(
                new GaugeItemInfo()
                {
                    Id = 0,
                    Index = 1,
                    InputTypeName = "Load",
                    Description = "Load",
                    DefaultTitleKey = "Load",
                    DisplayValue = "0.00000",
                    UnitSetName = "Force",
                    Unit = "N"
                }
            ); //载荷
            //处理
            Collections.GaugeItems = new ObservableCollection<GaugeItemInfo>();
            //用于可选区域        用于选定区域            用于显示控件      用于单位群
            Collections.GaugeItems.Add(
                new GaugeItemInfo()
                {
                    Id = 0,
                    InputTypeName = "Displacement",
                    DefaultTitleKey = "Displacement",
                    GaugeType = "Displacement",
                    UnitSetName = "Length",
                    DisplayValue = "0.00000",
                    DecimalPlaces = 5,
                    Unit="mm"
                    
                }
            );
            Collections.GaugeItems.Add(
                new GaugeItemInfo()
                {
                    Id = 0,
                    InputTypeName = "Load",
                    DefaultTitleKey = "Load",
                    GaugeType = "Load",
                    UnitSetName = "Force",
                    DisplayValue = "0.00000",
                    DecimalPlaces = 5,
                    Unit = "N"
                }
            );
            Collections.GaugeItems.Add(
                new GaugeItemInfo()
                {
                    Id = 0,
                    InputTypeName = "Time",
                    DefaultTitleKey = "Time",
                    GaugeType = "Time",
                    UnitSetName = "Time",
                    DisplayValue = "- - - -",
                    DecimalPlaces = 4,
                    Unit = "s"
                }
            );
            Collections.GaugeItems.Add(
                new GaugeItemInfo()
                {
                    Id = 0,
                    InputTypeName = "Tensile strain (displacement)",
                    DefaultTitleKey = "Tensile strain (displacement)",
                    GaugeType = "Strain(Displacement)",
                    UnitSetName = "Length",
                    DisplayValue = "0.00000",
                    DecimalPlaces = 5,
                    Unit = "mm"
                }
            );
            Collections.GaugeItems.Add(
                new GaugeItemInfo()
                {
                    Id = 0,
                    InputTypeName = "TensileDisplacement",
                    DefaultTitleKey = "TensileDisplacement",
                    GaugeType = "Displacement",
                    UnitSetName = "Length",
                    DisplayValue = "0.00000",
                    DecimalPlaces = 5,
                    Unit = "mm"
                }
            );
            Collections.GaugeItems.Add(
                new GaugeItemInfo()
                {
                    Id = 0,
                    InputTypeName = "TensileStress",
                    DefaultTitleKey = "TensileStress",
                    GaugeType = "Stress",
                    UnitSetName = "Force",
                    DisplayValue = "0.00000",
                    DecimalPlaces = 5,
                    Unit = "N"
                }
            );
            Collections.GaugeItems.Add(
                new GaugeItemInfo()
                {
                    Id = 0,
                    InputTypeName = "BruteForce",
                    DefaultTitleKey = "BruteForce",
                    GaugeType = "BruteForce",
                    UnitSetName = "Force",
                    DisplayValue = "0.00000",
                    DecimalPlaces = 5,
                    Unit = "N/tex"
                }
            );

            this.eventAggregator
                .GetEvent<GaugeItemInfosEvent>()
                .Publish(new List<GaugeItemInfo>());
        }

        public void OpenView(string strItem) //注册导航
        {
            try
            {
                if (strItem == null || string.IsNullOrWhiteSpace(strItem))
                {
                    return;
                }
                else
                {
                    // 某些分页中不需要滚动条
                    switch (strItem)
                    {
                        case nameof(SpecimenPropertiesView):
                            TabContentScrollBarVisbility =
                                ScrollBarVisibility.Disabled;
                            break;
                        default:
                            TabContentScrollBarVisbility =
                                ScrollBarVisibility.Auto;
                            break;
                    }
                    this.regionManager.Regions[
                        PrismManage.IndexViewRegionName
                    ].RequestNavigate(strItem);
                }
            }
            catch (System.NullReferenceException ex) { }
            catch (Exception ex) { }
        }
    }
}

using Prism.Commands;
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

namespace WanCeDesktopApp.ViewModels
{
    public class WorkspaceViewModel : BindableBase, IConfigursIndexService
    {
        private readonly IRegionManager _regionManager;
        private RegionNavigationJournal journal = new RegionNavigationJournal();
        private ObservableCollection<ShowInfo> subNavigation;
        public WorkspaceViewModel(IRegionManager regionManager)
        {
            RegisterRegion();
            _regionManager = regionManager/*.CreateRegionManager()*/;
            ItemSelectChangeCommand = new DelegateCommand<ShowInfo>(SampleItem_SelectChange);
            LoadedCommand = new DelegateCommand(Loaded);
        }

        private void Loaded()
        {
            _regionManager.Regions[PrismManage.WorkspaceViewRegionName].RequestNavigate("WorkspaceOperatorInputsView");
        }

        public DelegateCommand<ShowInfo> ItemSelectChangeCommand { get; private set; }
        public DelegateCommand LoadedCommand { get; private set; }
        public ObservableCollection<ShowInfo> SubNavigation { get => subNavigation; private set => subNavigation = value; }

        public void SampleItem_SelectChange(ShowInfo obj)
        {
            _regionManager.Regions[PrismManage.WorkspaceViewRegionName].RequestNavigate(obj.NameSpace);
        }
        private void RegisterRegion()
        {
            try
            {
                SubNavigation = new ObservableCollection<ShowInfo>();
                SubNavigation.Add(new ShowInfo() { Content = "Operator Inputs", NameSpace = "WorkspaceOperatorInputsView" });
                SubNavigation.Add(new ShowInfo() { Content = "Results 1", NameSpace = "WorkspaceResults_1View" });
                SubNavigation.Add(new ShowInfo() { Content = "Results 2", NameSpace = "WorkspaceResults_2View" });
                SubNavigation.Add(new ShowInfo() { Content = "Gragh 1", NameSpace = "WorkspaceGraph_1View" });
                SubNavigation.Add(new ShowInfo() { Content = "Gragh 2", NameSpace = "WorkspaceGraph_2View" });
                SubNavigation.Add(new ShowInfo() { Content = "Row Data", NameSpace = "WorkspaceRowDataView" });
                SubNavigation.Add(new ShowInfo() { Content = "Pass/Fail", NameSpace = "WorkspacePassorFailView" });
                SubNavigation.Add(new ShowInfo() { Content = "Layout", NameSpace = "WorkspaceLayoutView" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 配置首页初始化参数
        /// </summary>
        public void Configure()
        {
            
            
            
            try
            {
                _regionManager.Regions[PrismManage.WorkspaceViewRegionName].RequestNavigate("WorkspaceOperatorInputsView");
            }
            catch (System.NullReferenceException ex)
            {
                
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}

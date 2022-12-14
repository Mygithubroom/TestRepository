using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common.DAO;
using WanCeDesktopApp.Extensions;

namespace WanCeDesktopApp.ViewModels
{
    public class TabControlWorkspaceViewModel : BindableBase
    {
        
        private readonly IRegionManager regionManager;
        bool IsFirstLoad = true;//是否是第一次加载
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

        public TabControlWorkspaceViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            OpenViewCommand = new DelegateCommand<string>(OpenView);
            LoadedCommand = new DelegateCommand(Loaded);
            NegativeBarInfos = new ObservableCollection<NegativeBarInfos>();
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 0, NameSpace = "WorkspaceOperatorInputsView", Title = "TabSectionTitleOperatorInputs" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 1, NameSpace = "WorkspaceResults1View", Title = "TabSectionTitleResults1" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 1, NameSpace = "WorkspaceResults2View", Title = "TabSectionTitleResults2" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 2, NameSpace = "WorkspaceGraph1View", Title = "TabSectionTitleGraph1" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 2, NameSpace = "WorkspaceGraph2View", Title = "TabSectionTitleGraph2" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 3, NameSpace = "WorkspaceRawDataView", Title = "TabSectionTitleRawData" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 3, NameSpace = "WorkspacePassFailView", Title = "TabSectionTitlePassFail" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 3, NameSpace = "WorkspaceLayoutView", Title = "TabSectionTitleLayout" });
            SelectionChangedCommand = new DelegateCommand<NegativeBarInfos>(SelectionChanged);
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
                    this.regionManager.Regions[PrismManage.WorkspaceViewRegionName].RequestNavigate(obj.NameSpace);
                }
            }
            catch (Exception ex)
            {

                
            }
        }
        private void Loaded()
        {
            if (IsFirstLoad)
            {
                regionManager.Regions[PrismManage.WorkspaceViewRegionName].RequestNavigate("WorkspaceOperatorInputsView");
                IsFirstLoad = false;
            }
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
                    this.regionManager.Regions[PrismManage.WorkspaceViewRegionName].RequestNavigate(strItem);
                }
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

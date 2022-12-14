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
    public class TabControlTestControlViewModel : BindableBase
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

        public TabControlTestControlViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            OpenViewCommand = new DelegateCommand<string>(OpenView);
            LoadedCommand = new DelegateCommand(Loaded);
            NegativeBarInfos = new ObservableCollection<NegativeBarInfos>();
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 0, NameSpace = "TestControlStartTestView", Title = "TabSectionTitleStartTest" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 1, NameSpace = "TestControlStrainView", Title = "Strain" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 2, NameSpace = "TestControlPreTestView", Title = "TabSectionTitlePreTest" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 3, NameSpace = "TestControlTestView", Title = "Test" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 4, NameSpace = "TestControlEndOfTestView", Title = "TabSectionTitleEndofTest" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 5, NameSpace = "TestControlDataView", Title = "Data" });
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
                    this.regionManager.Regions[PrismManage.TestControlViewRegionName].RequestNavigate(obj.NameSpace);
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
                regionManager.Regions[PrismManage.TestControlViewRegionName].RequestNavigate("TestControlStartTestView");
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
                    this.regionManager.Regions[PrismManage.TestControlViewRegionName].RequestNavigate(strItem);
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

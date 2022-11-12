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

namespace WanCeDesktopApp
{
    public class SoftwareManageViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        bool IsFirstLoad = true;//是否是第一次加载

        public DelegateCommand LoadedCommand { get; private set; }
        public DelegateCommand<NegativeBarInfos> SelectionChangedCommand { get; private set; }

        private ObservableCollection<NegativeBarInfos> negativeBarInfos;

        public ObservableCollection<NegativeBarInfos> NegativeBarInfos
        {
            get { return negativeBarInfos; }
            set { negativeBarInfos = value; RaisePropertyChanged(); }
        }
        public SoftwareManageViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            LoadedCommand = new DelegateCommand(Loaded);
            NegativeBarInfos = new ObservableCollection<NegativeBarInfos>();
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 0, NameSpace = "SystemInfoView", Title = "SystemInformation" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 1, NameSpace = "MaintainingView", Title = "Maintaining" });
            //NegativeBarInfos.Add(new NegativeBarInfos() { Id = 2, NameSpace = "ShutdownRemindView", Title = "ShutdownRemind" });
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
                    this.regionManager.Regions[PrismManage.SoftwareManageViewRegionName].RequestNavigate(obj.NameSpace);
                }
            }
            catch (Exception)
            {

            }
        }

        private void Loaded()
        {
            if (IsFirstLoad)
            {
                regionManager.Regions[PrismManage.SoftwareManageViewRegionName].RequestNavigate("SystemInfoView");
                IsFirstLoad = false;
            }
        }
    }
}

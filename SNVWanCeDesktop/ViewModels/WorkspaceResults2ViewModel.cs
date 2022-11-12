using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Extensions;

namespace WanCeDesktopApp.ViewModels
{
    public class WorkspaceResults2ViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private bool IsFirstLoad = true;

        public WorkspaceResults2ViewModel(IRegionManager regionManager)
        {
            Init();
            BindingCommand();
            this.regionManager = regionManager;
        }

        private void Init()
        {
        }
        private void Loaded()
        {
            if (IsFirstLoad)
            {
                regionManager.Regions[PrismManage.ResultWorkRegionName2].RequestNavigate("WorkspaceResult_ColumnsView");
                IsFirstLoad = false;
            }
        }
        private void BindingCommand()
        {
            WorkRegionNavigateCommand = new DelegateCommand<string>(WorkRegionNavigate);
            LoadedCommand = new DelegateCommand(Loaded);
        }

        private void WorkRegionNavigate(string obj)
        {

            regionManager.Regions[PrismManage.ResultWorkRegionName2].RequestNavigate(obj);
        }

        public DelegateCommand<string> WorkRegionNavigateCommand { get; private set; }
        public DelegateCommand LoadedCommand { get; private set; }
    }
}

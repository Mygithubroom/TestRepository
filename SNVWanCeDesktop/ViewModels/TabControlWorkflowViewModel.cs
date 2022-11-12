using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Extensions;
using WanCeDesktopApp.Views;

namespace WanCeDesktopApp.ViewModels
{
    public class TabControlWorkflowViewModel
    {
        
        private IRegionManager regionManager;

        #region Command
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand LoadedCommand { get; private set; }
        #endregion

        public TabControlWorkflowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            Init();
            RegisterCommand();
        }

        private void RegisterCommand()
        {
            NavigateCommand = new DelegateCommand<string>(Navigate);
            LoadedCommand = new DelegateCommand(Loaded);
        }

        private void Loaded()
        {
            regionManager.Regions[PrismManage.WorkflowViewRegionName].RequestNavigate(nameof(WorkflowEditWorkflowView));
        }

        private void Navigate(string obj)
        {
            try
            {
                if (!string.IsNullOrEmpty(obj))
                {
                    regionManager.Regions[PrismManage.WorkflowViewRegionName].RequestNavigate(obj);
                }
            }
            catch (Exception ex)
            { 

                throw;
            }
        }

        private void Init()
        {
        }
    }
}

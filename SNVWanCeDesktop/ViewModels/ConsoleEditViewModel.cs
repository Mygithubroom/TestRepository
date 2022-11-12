using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Extensions;
using WanCeDesktopApp.Views;

namespace WanCeDesktopApp.ViewModels
{
    public class ConsoleEditViewModel : BindableBase,IDialogAware
    {
        public DelegateCommand LoadedCommand { get;private set; }
        private IRegionManager regionManager;

        public event Action<IDialogResult> RequestClose;

        public string ViewTag { get; set; }
        public string DialogHostName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DelegateCommand SaveCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DelegateCommand CancelCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Title => throw new NotImplementedException();

        public ConsoleEditViewModel(IRegionManager manager)
        {
            regionManager = manager;
            Init();
            RegisterCommand();
        }

        private void RegisterCommand()
        {
            LoadedCommand = new DelegateCommand(Loaded);
        }

        private void Loaded()
        {
            try { 
            NavigationParameters pairs = new NavigationParameters();
            pairs.Add("Tag", ViewTag);
            regionManager.Regions[PrismManage.ConsoleEditRegionName].RequestNavigate(nameof(TabControlConsoleView),pairs);
            }catch(Exception ex)
            {
                return;
            }
        }

        private void Init()
        {
            
        }

        public bool CanCloseDialog()
        {
           return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
           
        }
    }
}

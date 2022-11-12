using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common;

namespace WanCeDesktopApp.ViewModels
{
    public class DevGenerateToolViewModel : BindableBase
    {
        public DelegateCommand LoadCommand { get; set; }
        private IRegionManager manager;
        public DevGenerateToolViewModel(IEventAggregator aggregator, IRegionManager regionManager)
        {
            LoadCommand = new DelegateCommand(Load);
            manager = regionManager;
        }

        private void Load()
        {
            manager.Regions["ConsoleRegion"].RequestNavigate("TabControlConsoleView");
        }
    }
}

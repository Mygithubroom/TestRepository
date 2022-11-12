using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WanCeDesktopApp.ViewModels;

namespace WanCeDesktopApp.Views
{
    /// <summary>
    /// TabControlConsoleView.xaml 的交互逻辑
    /// </summary>
    public partial class TabControlConsoleView : UserControl
    {
        TabControlConsoleViewModel _viewModel;
        public TabControlConsoleView()
        {
            InitializeComponent();
            //每次加载都是新的ViewModel
            //Loaded += (s, e) =>
            //{
            //    if (DataContext == null)
            //    {
            //        DataContext = _viewModel;
            //    }
            //};
            //Unloaded += (s, e) =>
            //{
            //    this.DataContext = null;
            //};
            //var regionManager = ContainerLocator.Container.Resolve<IRegionManager>();
            //_viewModel = new TabControlConsoleViewModel(regionManager);
        }
    }
}

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
using System.Windows.Shapes;
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Common.Enum;

namespace WanCeDesktopApp.Views
{
    /// <summary>
    /// DevGenerateTool.xaml 的交互逻辑
    /// </summary>
    public partial class DevGenerateTool : Window
    {
        public IRegionManager regionManager;
        public DevGenerateTool()
        {
            InitializeComponent();
            //regionManager = manager;
            //RegionManager.SetRegionName(consoleRegion, "ConsoleRegion");
            //regionManager.RegisterViewWithRegion("ConsoleRegion", typeof(TabControlConsoleView));
            //regionManager.Regions["ConsoleRegion"].RequestNavigate("TabControlConsoleView");
            
            this.Loaded += DevGenerateTool_Loaded;  
        }

        private void DevGenerateTool_Loaded(object sender, RoutedEventArgs e)
        {
            //consoleRegion.Content = new TabControlConsoleView();
            //var provider = ContainerLocator.Container.Resolve<IContainerProvider>();
            //var regionManager = ContainerLocator.Container.Resolve<IRegionManager>();
            //var win = provider.Resolve<object>("ShowWindow");
            //if (win is Window view)
            //{
            //    RegionManager.SetRegionManager(view, regionManager);
            //    RegionManager.UpdateRegions();

            //    view.ShowDialog();
            //}
            //RegionManager.SetRegionName(consoleRegion, "ConsoleRegion");
            //RegionManager.SetRegionManager(consoleRegion, theRegionManagerInstanceFromUnity);
        }

        public static void AddUnitInfo(string unitsetName, string unitkey,string unitvalue)
        {
            //if (UnitSystems == null)
            //{
            //    Init();
            //}
            if (UnitSystemProvider.UnitSystems == null || string.IsNullOrEmpty(unitsetName) || string.IsNullOrEmpty(unitkey) || string.IsNullOrEmpty(unitvalue))
            {
                return;
            }
            UnitInfo result = null;
            switch (UnitSystemProvider.SelectUnitSystem)
            {
                case UnitSystemEnum.ALL:
                    result = UnitSystemProvider.UnitSystems.ALL.FindUnitSet(unitsetName);
                    if (result.DefaultValue==null)
                    {

                    }
                        result.Units.Add(new DictionaryExt() { Key = unitkey, Value = unitvalue });
                    break;
                case UnitSystemEnum.AmericanStandard:
                    result = UnitSystemProvider.UnitSystems.AmericanStandard.FindUnitSet(unitsetName);
                    result.Units.Add(new DictionaryExt() { Key = unitkey, Value = unitvalue });
                    break;
                case UnitSystemEnum.Metric:
                    result = UnitSystemProvider.UnitSystems.Metric.FindUnitSet(unitsetName);
                    result.Units.Add(new DictionaryExt() { Key = unitkey, Value = unitvalue });
                    break;
                case UnitSystemEnum.SI:
                    result = UnitSystemProvider.UnitSystems.SI.FindUnitSet(unitsetName);
                    result.Units.Add(new DictionaryExt() { Key = unitkey, Value = unitvalue });
                    break;
                default:
                    break;
            }
            //return result;
        }
    }
}

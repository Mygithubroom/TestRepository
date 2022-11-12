using Prism.Events;
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
using UnitsProvider;
using UnitsProvider.Extend;
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Common.DAO;
using WPFLocalizeExtension.Providers;

namespace WanCeDesktopApp.Views
{
    /// <summary>
    /// SampleNumberInputsView.xaml 的交互逻辑
    /// </summary>
    public partial class SampleNumberInputsView : UserControl
    {
        private IEventAggregator eventAggregator;
        ComboBox comboBox;
        public SampleNumberInputsView(IEventAggregator aggregator)
        {
            InitializeComponent();
            this.eventAggregator = aggregator;
            eventAggregator.GetEvent<MessageEvent>().Subscribe(SetUnit, ThreadOption.PublisherThread, false, filter => filter.Filter == "SampleNumberInputsView");
        }

        private void SetUnit(Message obj)
        {
            if (comboBox == null||string.IsNullOrEmpty(obj.Content) || string.IsNullOrEmpty(obj.Title))
            {
                return;
            }
            UnitSet unitSet = UnitTools.GetUnitSet(obj.Title);
            comboBox.ItemsSource=unitSet.Units;
            comboBox.SelectedIndex= unitSet.Units.FindIndex(match=>match.Symbol== obj.Content);
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ContentControl contentControl = this.Parent as ContentControl;
            FrameworkElement parentControl = Tools.FindVisualParent<FrameworkElement>(contentControl, "IndexViewRegion");
            if (parentControl == null)
            {
                return;
            }
            NumberInputsArea.Height = parentControl.RenderSize.Height - 20;
            NumberInputsArea.Width = parentControl.RenderSize.Width - 200;
            e.Handled = true;
        }

        private void ComboBox_DropDownOpened(object sender, EventArgs e)
        {
            //ComboBox comboBox = sender as ComboBox;

            //if (comboBox!=null)
            //{
            //    GaugeItemInfo itemInfo = comboBox.DataContext as GaugeItemInfo;
            //    if (itemInfo != null)
            //    {
            //        //可以做一次标记，单位源名一样就不用重新赋值
            //        var unitset = UnitTools.GetUnitSet(itemInfo.UnitSetName);
            //        if (unitset!=null)
            //        {
            //            comboBox.ItemsSource = unitset.Units; 
            //        }
            //    } 
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            DockPanel control = Tools.FindVisualParent<DockPanel>(button,filter=> filter.GetType()== typeof(DockPanel)) ;
            //comboBox = new ComboBox();
            comboBox = Tools.FindVisualChild<ComboBox>(control,filter=>filter.GetType()== typeof(ComboBox));
        }
    }
}

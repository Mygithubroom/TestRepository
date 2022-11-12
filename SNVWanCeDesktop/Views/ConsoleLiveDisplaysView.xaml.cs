using Prism.Events;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Common.DAO;
using WPFLocalizeExtension.Engine;

namespace WanCeDesktopApp.Views
{
    /// <summary>
    /// ConsoleLiveDisplaysView.xaml 的交互逻辑
    /// </summary>
    public partial class ConsoleLiveDisplaysView : UserControl
    {
        private IEventAggregator aggregator;

        public ConsoleLiveDisplaysView(IEventAggregator messageEvent)
        {
            InitializeComponent();
            this.aggregator = messageEvent;
            AllLoaded();
            //this.aggregator.GetEvent<MessageEvent>().Subscribe(AllLoaded,ThreadOption.PublisherThread,false,filter=> filter.Filter== "ConsoleLiveDisplaysView");
        }

        private void AllLoaded()
        {
            try
            {
                if (DeterMiniedParametersList.Items.Count > 0)
                {
                    //if (DeterMiniedParametersList.SelectedIndex == -1)
                    //{
                    //    DeterMiniedParametersList.SelectedItem = DeterMiniedParametersList.Items[0];
                    //}
                    detailedArea.Visibility = Visibility.Visible;
                    DeterMiniedParametersList.SelectedItem = DeterMiniedParametersList.Items[0];
                }
                else
                {
                    detailedArea.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void MoveUp_Click(object sender, RoutedEventArgs e)
        {
            if (DeterMiniedParametersList.Items.Count > 1)
            {
                if (DeterMiniedParametersList.SelectedIndex == 0)
                {
                    return;
                }
                int index = DeterMiniedParametersList.SelectedIndex;
                ObservableCollection<GaugeItemInfo> infos = (ObservableCollection<GaugeItemInfo>)DeterMiniedParametersList.ItemsSource;
                GaugeItemInfo info1 = infos[index];
                infos[index] = infos[index - 1];
                infos[index - 1] = info1;
                Collections.GaugeItems = infos;
                DeterMiniedParametersList.SelectedIndex = index - 1;
                //PlushToLiveDisplay(infos);
            }
        }

        private void MoveDown_Click(object sender, RoutedEventArgs e)
        {
            if (DeterMiniedParametersList.Items.Count > 1)
            {
                if (DeterMiniedParametersList.SelectedIndex == DeterMiniedParametersList.Items.Count - 1)
                {
                    return;
                }
                int index = DeterMiniedParametersList.SelectedIndex;
                ObservableCollection<GaugeItemInfo> infos = (ObservableCollection<GaugeItemInfo>)DeterMiniedParametersList.ItemsSource;
                GaugeItemInfo info1 = infos[index];
                infos[index] = infos[index + 1];
                infos[index + 1] = info1;
                Collections.GaugeItems = infos;
                DeterMiniedParametersList.SelectedIndex = index + 1;
                //PlushToLiveDisplay(infos);
            }
        }
        private void PlushToLiveDisplay(ObservableCollection<GaugeItemInfo> infos)
        {
            List<GaugeItemInfo> list = new List<GaugeItemInfo>();
            foreach (GaugeItemInfo item in infos)
            {
                list.Add(item);
            }
            aggregator.GetEvent<GaugeItemInfosEvent>().Publish(list);
        }
        private void DeterMiniedParametersList_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //DeterMiniedParametersList.SelectedIndex = DeterMiniedParametersList.Items.Count - 1;
        }

        private void DeterMiniedParametersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (detailedArea == null)
            {
                return;
            }
            GaugeItemInfo itemInfo = DeterMiniedParametersList.SelectedItem as GaugeItemInfo;
            if ((DeterMiniedParametersList.Items.Count == 0 || itemInfo == null))
            {
                detailedArea.Visibility = Visibility.Collapsed;
                return;
            }
            else
            {
                detailedArea.Visibility = Visibility.Visible;
            }
            ParameterLable.Text = LocalizationProviderWrapper.GetLocalizedStr(itemInfo.Description);
            txtPrompt.Text = itemInfo.Title;
            UnitInfo unitInfo = UnitSystemProvider.GetUnitInfo(itemInfo.UnitSetName);
            if (unitInfo == null)
            {
                Unit.ItemsSource = null;
                return;
            }
            Unit.ItemsSource = unitInfo.Units;
            //Unit.SelectedIndex = Unit.Items.IndexOf(unitInfo.DefaultValue);
            Unit.Text = unitInfo.DefaultValue.Value;
            maxCheck.IsChecked = itemInfo.IsShowMax;
            rateCheck.IsChecked = itemInfo.IsShowRate;
            //单位集合 单位类型对应集合
        }

        private void txtPrompt_TextChanged(object sender, TextChangedEventArgs e)
        {
            GaugeItemInfo itemInfo = DeterMiniedParametersList.SelectedItem as GaugeItemInfo;
            if (itemInfo == null)
            {
                return;
            }
            itemInfo.UserDefinedTitle = txtPrompt.Text;//文本，小数位数，单位
            //itemInfo.Unit = Unit.Text;
            //itemInfo.DecimalPlaces =Convert.ToInt16(DecimalNumber.SelectedValue);
            //aggregator.GetEvent<GaugeItemInfoEvent>().Publish(itemInfo);
        }

        private void Unit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GaugeItemInfo itemInfo = DeterMiniedParametersList.SelectedItem as GaugeItemInfo;
            if (itemInfo == null || Unit == null || Unit.SelectedValue == null)
            {
                return;
            }
            itemInfo.Unit = Unit.SelectedValue.ToString();
            //aggregator.GetEvent<GaugeItemInfoEvent>().Publish(itemInfo);
        }

        private void DecimalNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem comboBoxItem = DecimalNumber.SelectedItem as ComboBoxItem;
            if (comboBoxItem == null)
            {
                return;
            }
            GaugeItemInfo itemInfo = DeterMiniedParametersList.SelectedItem as GaugeItemInfo;
            if (itemInfo == null)
            {
                return;
            }
            itemInfo.DecimalPlaces = Convert.ToInt16(comboBoxItem.Content);
            itemInfo.DisplayValue = string.Format("{0:f" + itemInfo.DecimalPlaces + "}", Convert.ToDouble(itemInfo.DisplayValue));
            //itemInfo.UnitSetName = 
            //aggregator.GetEvent<GaugeItemInfoEvent>().Publish(itemInfo);
        }
        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var parent = this.Parent;
            if (parent is DialogWindow window)
            {
                if (window.RenderSize.Height > 240)
                {
                    DeterMiniedParametersList.Height = window.RenderSize.Height - 240;
                    treeView.Height = window.RenderSize.Height - 240;
                }
                return;
            }
            ContentControl contentControl = this.Parent as ContentControl;
            FrameworkElement parentControl = Tools.FindVisualParent<FrameworkElement>(contentControl, "IndexViewRegion");
            if (parentControl != null)
            {
                DeterMiniedParametersList.Height = parentControl.RenderSize.Height - 200;
                treeView.Height = parentControl.RenderSize.Height - 200;
                //e.Handled = true;
            }
        }
    }
}

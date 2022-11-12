using DocumentFormat.OpenXml.Office.CustomUI;
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
using WanCeDesktopApp.Common.DAO;
using WanCeDesktopApp.ViewModels;

namespace WanCeDesktopApp.Views
{
    /// <summary>
    /// CalculationsSetupView.xaml 的交互逻辑
    /// </summary>
    public partial class CalculationsSetupView : UserControl
    {
        CalculationsSetupViewModel viewModel = null;
        public CalculationsSetupView()
        {
            InitializeComponent();
            this.Loaded += CalculationsSetupView_Loaded;
        }

        private void CalculationsSetupView_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = this.DataContext as CalculationsSetupViewModel;
            GaugeItemInfo gaugeItemInfo = listBoxRight.SelectedItem as GaugeItemInfo;
            if (gaugeItemInfo == null)
            {
                EditArea.Visibility = Visibility.Collapsed;
            }
            else
            {
                EditArea.Visibility = Visibility.Visible;
            }
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ContentControl contentControl = this.Parent as ContentControl;
            FrameworkElement parentControl = Tools.FindVisualParent<FrameworkElement>(contentControl, "IndexViewRegion");
            if (parentControl == null)
            {
                return;
            }
            SetupViewScroll.Height = parentControl.RenderSize.Height - 20;
            SetupViewScroll.Width = parentControl.RenderSize.Width - 200;
            listBoxLeft.Height = SetupViewScroll.Height - 100;
            e.Handled = true;
        }

        private void listBoxRight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GaugeItemInfo gaugeItemInfo = listBoxRight.SelectedItem as GaugeItemInfo;
            if (gaugeItemInfo == null)
            {
                EditArea.Visibility = Visibility.Collapsed;
            }
            else
            {
                EditArea.Visibility = Visibility.Visible;
                double number = 0;
                if (Tools.TryCalculate(gaugeItemInfo.Expression, out number))
                {
                    MessageBox.Show(number + "");
                }
                //else
                //{
                //    MessageBox.Show("解析错误！");

                //}
                if (gaugeItemInfo.Expression != null)
                {
                    viewModel.TestValue = number + "";
                }
                else
                {
                    viewModel.TestValue = gaugeItemInfo.DisplayValue;
                }
            }
        }
    }
}

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

namespace WanCeDesktopApp.Views
{
    /// <summary>
    /// TestControlStartTestView.xaml 的交互逻辑
    /// </summary>
    public partial class TestControlStartTestView : UserControl
    {
        public TestControlStartTestView()
        {
            InitializeComponent();
        }
        private void chkBox_Checked(object sender, RoutedEventArgs e)
        {

            CheckBox box = sender as CheckBox;
            string temp = box.Tag?.ToString();
            if (!string.IsNullOrEmpty(temp))
            {
                var panel = this.FindName(temp) as Panel;
                panel.Visibility = Visibility.Visible;
            }
        }

        private void chkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox box = sender as CheckBox;
            string temp = box.Tag.ToString();
            if (!string.IsNullOrEmpty(temp))
            {
                var panel = this.FindName(temp) as Panel;
                panel.Visibility = Visibility.Collapsed;
            }
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ContentControl contentControl = this.Parent as ContentControl;
            FrameworkElement parentControl = Tools.FindVisualParent<FrameworkElement>(contentControl, "IndexViewRegion");
            StartTestViewScroll.Height = parentControl.RenderSize.Height - 20;
            StartTestViewScroll.Width = parentControl.RenderSize.Width - 200;
            e.Handled = true;
        }
    }
}

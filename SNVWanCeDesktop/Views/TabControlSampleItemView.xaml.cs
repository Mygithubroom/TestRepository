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
    /// TabControl1View.xaml 的交互逻辑
    /// </summary>
    public partial class TabControlSampleItemView : UserControl
    {
        public TabControlSampleItemView()
        {
            InitializeComponent();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            ContentPresenter cto = (ContentPresenter)checkBox.TemplatedParent;
            //this.ItemsSample.DataContext = cto.Content;
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ContentPresenter cto = (ContentPresenter)btn.TemplatedParent;
            //this.ItemsSample.DataContext = cto.Content;
        }

        private void TextInputList_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        //private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    ContentControl contentControl = this.Parent as ContentControl;
        //    FrameworkElement parentControl = Tools.FindVisualParent<FrameworkElement>(contentControl, "IndexViewRegion");
        //    SampleItemViewRegion.Height = parentControl.RenderSize.Height-20;
        //    SampleItemViewRegion.Width = parentControl.RenderSize.Width-190;
        //    e.Handled = true;
        //}
    }
}

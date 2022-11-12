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
    /// WorkspaceResults_1View.xaml 的交互逻辑
    /// </summary>
    public partial class WorkspaceResults1View : UserControl
    {
        public WorkspaceResults1View()
        {
            InitializeComponent();
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ContentControl contentControl = this.Parent as ContentControl;
            FrameworkElement parentControl = Tools.FindVisualParent<FrameworkElement>(contentControl, "IndexViewRegion");
            //Results1ViewScroll.Height = parentControl.RenderSize.Height;
            //Results1ViewScroll.Width = parentControl.RenderSize.Width - 200;
            //OperatorInputsViewDescribetion.MaxWidth = parentControl.RenderSize.Width - 230;
            //treeView.MinHeight = 8 * 80 - 200;
            //treeView.Height = parentControl.RenderSize.Height - 160;
            e.Handled = true;
        }
    }
}

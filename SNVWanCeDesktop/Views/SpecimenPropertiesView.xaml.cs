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
    /// SpecimenPropertiesView.xaml 的交互逻辑
    /// </summary>
    public partial class SpecimenPropertiesView : UserControl
    {
        public SpecimenPropertiesView()
        {
            InitializeComponent();
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //ContentControl contentControl = this.Parent as ContentControl;
            //FrameworkElement parentControl = Tools.FindVisualParent<FrameworkElement>(contentControl, "IndexViewRegion");
            //PropertiesViewScroll.Height = parentControl.RenderSize.Height - 20;
            //PropertiesViewScroll.Width = parentControl.RenderSize.Width - 200;
            //e.Handled = true;
        }
    }
}

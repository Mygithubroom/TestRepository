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
    /// SampleNotes.xaml 的交互逻辑
    /// </summary>
    public partial class SampleNotesView : UserControl
    {
        public SampleNotesView()
        {
            InitializeComponent();
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ContentControl contentControl = this.Parent as ContentControl;
            FrameworkElement parentControl = Tools.FindVisualParent<FrameworkElement>(contentControl, "IndexViewRegion");
            if (parentControl == null)
            {
                return;
            }
            NotesViewScroll.Height = parentControl.RenderSize.Height-20;
            NotesViewScroll.Width = parentControl.RenderSize.Width-200;
            e.Handled = true;
        }
    }
}

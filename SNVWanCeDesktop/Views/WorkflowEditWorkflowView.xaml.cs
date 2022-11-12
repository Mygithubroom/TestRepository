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
    /// WorkflowEditView.xaml 的交互逻辑
    /// </summary>
    public partial class WorkflowEditWorkflowView : UserControl
    {
        public WorkflowEditWorkflowView()
        {
            InitializeComponent();
        }

        private void ckbRunPrompted_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox box = sender as CheckBox;
            string temp = box.Tag?.ToString();
            if (!string.IsNullOrEmpty(temp))
            {
                var panel = this.FindName(temp) as Panel;
                panel.Visibility = Visibility.Collapsed;
            }
        }

        private void ckbRunPrompted_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox box = sender as CheckBox;
            string temp = box.Tag?.ToString();
            if (!string.IsNullOrEmpty(temp))
            {
                var panel = this.FindName(temp) as Panel;
                panel.Visibility = Visibility.Visible;
            }
        }
    }
}

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
using WanCeDesktopApp.Common;

namespace WanCeDesktopApp.Views
{
    /// <summary>
    /// TestView.xaml 的交互逻辑
    /// </summary>
    public partial class TestGraphyView : UserControl
    {

        public TestGraphyView()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            SoftKeyInfo info = button.DataContext as SoftKeyInfo;
            SoftKeyFactory factory = new SoftKeyFactory();
            ISoftKey softKey = factory.GetSoftKey(info.SoftKeyType);
            softKey?.ToDo();
        }
    }
}

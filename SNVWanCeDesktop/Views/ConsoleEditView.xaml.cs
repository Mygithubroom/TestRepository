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
using System.Windows.Shapes;

namespace WanCeDesktopApp.Views
{
    /// <summary>
    /// ConsoleEditView.xaml 的交互逻辑
    /// </summary>
    public partial class ConsoleEditView : Window
    {
        private string target;
        public ConsoleEditView()
        {
            InitializeComponent();
            this.Loaded += ConsoleEditView_Loaded;
            this.Closing += ConsoleEditView_Closing;
        }

        private void ConsoleEditView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void ConsoleEditView_Loaded(object sender, RoutedEventArgs e)
        {
            //target = this.Tag?.ToString();
        }
        //public ConsoleEditView(string obj)
        //{
        //    InitializeComponent();

        //}
    }
}

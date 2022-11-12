using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// SettingsDatabaseView.xaml 的交互逻辑
    /// </summary>
    public partial class SettingsDatabaseView : UserControl
    {
        public SettingsDatabaseView()
        {
            InitializeComponent();
        }

        ///// <summary>
        ///// 限制只能输入数字
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    Regex re = new Regex("[^0-9]+");
        //    e.Handled = re.IsMatch(e.Text);
        //}

        ///// <summary>
        ///// 数据改变切换焦点
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    TextBox textBox = (TextBox)sender;
        //    if (textBox.Text.Trim().Length >= 3)
        //    {
        //        switch (textBox.Name)
        //        {
        //            case "IP1":
        //                IP1.Text = IP1.Text[..3];
        //                IP2.Focus();
        //                break;
        //            case "IP2":
        //                IP2.Text = IP2.Text[..3];
        //                IP3.Focus();
        //                break;
        //            case "IP3":
        //                IP3.Text = IP3.Text[..3];
        //                IP4.Focus();
        //                break;
        //            default:
        //                break;
        //        }
        //    }else if (textBox.Text.Trim().Length == 0)
        //    {
        //        switch (textBox.Name)
        //        {
        //            case "IP4":
        //                IP3.Focus();
        //                IP3.SelectionStart = 3;
        //                break;
        //            case "IP3":
        //                IP2.Focus();
        //                IP2.SelectionStart = 3;
        //                break;
        //            case "IP2":
        //                IP1.Focus();
        //                IP1.SelectionStart = 3;
        //                break;
        //            default:
        //                break;
        //        }
        //    }

        //}
    }
}

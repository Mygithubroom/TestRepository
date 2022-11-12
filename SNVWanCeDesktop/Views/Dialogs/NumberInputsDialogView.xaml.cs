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

namespace WanCeDesktopApp.Views.Dialogs
{
    /// <summary>
    /// SampleNumberInputsDialogView.xaml 的交互逻辑
    /// </summary>
    public partial class NumberInputsDialogView : UserControl
    {
        public NumberInputsDialogView()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try
            //{
            //    if (e.AddedItems.Count > 0)
            //    {
            //        int num = Convert.ToInt32(e.AddedItems[0]);
            //        EditValue.Text = String.Format("{0:f"+num+"}",String.IsNullOrEmpty(EditValue.Text)?0:Convert.ToDouble(EditValue.Text));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(EditTitle.Text))
            {
                string str = LocalizationProviderWrapper.GetLocalizedStr("Prompt") + LocalizationProviderWrapper.GetLocalizedStr("EmptyWarning");//多语言Key转换
                MessageBox.Show(str);
                return;
            }
        }
    }
}

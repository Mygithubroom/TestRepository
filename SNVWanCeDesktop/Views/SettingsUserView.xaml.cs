using System;
using System.Collections.Generic;
using System.Data;
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
using WanCeDesktopApp.Models;

namespace WanCeDesktopApp.Views
{
    /// <summary>
    /// SettingsUserView.xaml 的交互逻辑
    /// </summary>
    public partial class SettingsUserView : UserControl
    {
        public SettingsUserView()
        {
            InitializeComponent();
        }

        //private void UserDataGrid_CurrentCellChanged(object sender, EventArgs e)
        //{
        //    UserInfo pModel = UserDataGrid.CurrentCell.Item as UserInfo;
        //    if (pModel == null)
        //    {
        //        return;
        //    }
            //ID.Text = Tools.ToString(pModel.UserID);
            //Account.Text = Tools.ToString(pModel.Account);
            ////Password.DataContext= Tools.ToString(pModel.Password);
            //Grade.SelectedIndex = Tools.ToString(pModel.Level) == "0" ? 0 : 1;
            //UserName.Text = Tools.ToString(pModel.UserName);
            //Phone.Text = Tools.ToString(pModel.Phone);
        //}
    }
}

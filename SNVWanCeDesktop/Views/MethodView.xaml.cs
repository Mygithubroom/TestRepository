using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WanCeDesktopApp.Common.Enum;

namespace WanCeDesktopApp.Views
{
    /// <summary>
    /// MethodView.xaml 的交互逻辑
    /// </summary>
    public partial class MethodView : UserControl
    {
        public MethodView()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBox comboBox = sender as ComboBox;
                ObservableCollection<ShowInfo> showInfos = RecentSpecimenItems.ItemsSource as ObservableCollection<ShowInfo>;
                if (showInfos.Count > 1)
                {
                    DictionaryExt obj =comboBox.SelectedItem as DictionaryExt;
                    SortTypeEnum item ;
                    if(!Enum.TryParse<SortTypeEnum>(obj.Key.ToString(), out item))
                    {
                        return;
                    }
                    switch (item)
                    {
                        case SortTypeEnum.AscendingName:
                            showInfos = new ObservableCollection<ShowInfo>(showInfos.OrderBy(info => info.Title));//根据名字升序
                            break;
                        case SortTypeEnum.DescendingName:
                            showInfos = new ObservableCollection<ShowInfo>(showInfos.OrderByDescending(info => info.Title));//根据名字降序
                            break;
                        case SortTypeEnum.AscendingType:
                            showInfos = new ObservableCollection<ShowInfo>(showInfos.OrderBy(info => info.Content));//根据类型升序
                            break;
                        case SortTypeEnum.DescendingType:
                            showInfos = new ObservableCollection<ShowInfo>(showInfos.OrderByDescending(info => info.Content));//根据类型降序
                            break;
                        case SortTypeEnum.AscendingTime:
                            showInfos = new ObservableCollection<ShowInfo>(showInfos.OrderBy(info => info.UpDateDate));//根据类型升序
                            break;
                        case SortTypeEnum.DescendingTime:
                            showInfos = new ObservableCollection<ShowInfo>(showInfos.OrderByDescending(info => info.UpDateDate));//根据类型降序
                            break;
                        default:
                            showInfos = new ObservableCollection<ShowInfo>(showInfos.OrderBy(info => info.Title));//默认按时间升序排序
                            break;
                    }
                    RecentSpecimenItems.ItemsSource = showInfos;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

using Prism.Services.Dialogs;
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
using WanCeDesktopApp.Common.DAO;

namespace WanCeDesktopApp.Views
{
    /// <summary>
    /// ConsoleSoftKeysView.xaml 的交互逻辑
    /// </summary>
    public partial class ConsoleSoftKeysView : UserControl
    {
        public ConsoleSoftKeysView()
        {
            InitializeComponent();
            this.Loaded += ConsoleSoftKeysView_Loaded;
            DeterMiniedParametersList.SelectionChanged += DeterMiniedParametersList_SelectionChanged;
        }

        private void DeterMiniedParametersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (detailedArea == null)
            {
                return;
            }
            GaugeItemInfo itemInfo = DeterMiniedParametersList.SelectedItem as GaugeItemInfo;
            if (DeterMiniedParametersList.Items.Count == 0 )
            {
                detailedArea.Visibility = Visibility.Collapsed;
                return;
            }
            else
            {
                detailedArea.Visibility = Visibility.Visible;
            }
        }

        private void ConsoleSoftKeysView_Loaded(object sender, RoutedEventArgs e)
        {
            if (detailedArea == null)
            {
                return;
            }
            if (DeterMiniedParametersList.Items.Count == 0)
            {
                detailedArea.Visibility = Visibility.Collapsed;
                return;
            }
            else
            {
                detailedArea.Visibility = Visibility.Visible;
            }
        }

        private void MoveUp_Click(object sender, RoutedEventArgs e)
        {
            if (DeterMiniedParametersList.Items.Count > 1)
            {
                if (DeterMiniedParametersList.SelectedIndex == 0)
                {
                    return;
                }
                int index = DeterMiniedParametersList.SelectedIndex;
                ObservableCollection<WorkspaceInputTypeInfo> infos = (ObservableCollection<WorkspaceInputTypeInfo>)DeterMiniedParametersList.ItemsSource;
                WorkspaceInputTypeInfo info1 = infos[index];
                infos[index] = infos[index - 1];
                infos[index - 1] = info1;
                DeterMiniedParametersList.ItemsSource = infos;
                DeterMiniedParametersList.SelectedIndex = index - 1;
            }
        }

        private void MoveDown_Click(object sender, RoutedEventArgs e)
        {
            if (DeterMiniedParametersList.Items.Count > 1)
            {
                if (DeterMiniedParametersList.SelectedIndex == DeterMiniedParametersList.Items.Count - 1)
                {
                    return;
                }
                int index = DeterMiniedParametersList.SelectedIndex;
                ObservableCollection<WorkspaceInputTypeInfo> infos = (ObservableCollection<WorkspaceInputTypeInfo>)DeterMiniedParametersList.ItemsSource;
                WorkspaceInputTypeInfo info1 = infos[index];
                infos[index] = infos[index + 1];
                infos[index + 1] = info1;
                DeterMiniedParametersList.ItemsSource = infos;
                DeterMiniedParametersList.SelectedIndex = index + 1;
            }
        }

        private void treeView_Expanded(object sender, RoutedEventArgs e)
        {
            //ObservableCollection<WorkspaceInputTypeInfo> items = treeView.ItemsSource as ObservableCollection<WorkspaceInputTypeInfo>;
            //WorkspaceInputTypeInfo item = AvailableParametersArrList.SelectedItem as WorkspaceInputTypeInfo;
            //item.AvailableParametersItemsArr = new ObservableCollection<TreeviewItemInfo>() { new WorkspaceInputTypeInfo() { Id = 0, Index = 0, InputTypeName = "TestInputParameter1" }, new WorkspaceInputTypeInfo() { Id = 0, Index = 1, InputTypeName = "TestInputParameter2" } };

        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var parent = this.Parent;
            if (parent is DialogWindow window)
            {
                if (window.RenderSize.Height > 240)
                {
                    //window.Height = e.NewSize.Height;
                    DeterMiniedParametersList.Height =e.NewSize.Height - 180;
                    AvailableParametersArrList.Height = e.NewSize.Height - 180;
                    e.Handled = true;
                }
                return;
            }
            ContentControl contentControl = this.Parent as ContentControl;
            FrameworkElement parentControl = Tools.FindVisualParent<FrameworkElement>(contentControl, "IndexViewRegion");
            if (parentControl == null)
            {
                return;
            }
            DeterMiniedParametersList.Height = parentControl.RenderSize.Height - 180;
            AvailableParametersArrList.Height = parentControl.RenderSize.Height- 180;
            e.Handled = true;
        }
     
    }
}

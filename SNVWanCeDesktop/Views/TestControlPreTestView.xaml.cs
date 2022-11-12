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
    /// TestControlPreTestView.xaml 的交互逻辑
    /// </summary>
    public partial class TestControlPreTestView : UserControl
    {
        public TestControlPreTestView()
        {
            InitializeComponent();
        }

        private void Preload_Checked(object sender, RoutedEventArgs e)
        {
            PreloadSettingLable.Visibility = Visibility.Visible;
        }

        private void Preload_Unchecked(object sender, RoutedEventArgs e)
        {
            PreloadSettingLable.Visibility = Visibility.Collapsed;
            //PreloadSettingLable.BeginAnimation(PreloadSettingLable.Height, Visibility.Collapsed);
        }
        private void chkBox_Checked(object sender, RoutedEventArgs e)
        {

            CheckBox box = sender as CheckBox;
            string temp = box.Tag?.ToString();
            if (!string.IsNullOrEmpty(temp))
            {
                var panel = WorkArea.FindName(temp) as Panel;
                panel.Visibility = Visibility.Visible;
            }
        }

        private void chkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox box = sender as CheckBox;
            string temp = box.Tag.ToString();
            if (!string.IsNullOrEmpty(temp))
            {
                var panel = WorkArea.FindName(temp) as Panel;
                panel.Visibility = Visibility.Collapsed;
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

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ContentControl contentControl = this.Parent as ContentControl;
            FrameworkElement parentControl = Tools.FindVisualParent<FrameworkElement>(contentControl, "IndexViewRegion");
            PreTestViewScroll.Height = parentControl.RenderSize.Height - 20;
            PreTestViewScroll.Width = parentControl.RenderSize.Width - 200;
            e.Handled = true;
        }
    }
}

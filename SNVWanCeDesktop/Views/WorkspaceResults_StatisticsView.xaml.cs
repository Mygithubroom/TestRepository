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
using WanCeDesktopApp.Common.DAO;

namespace WanCeDesktopApp.Views
{
    /// <summary>
    /// WorkspaceResults_StatisticsView.xaml 的交互逻辑
    /// </summary>
    public partial class WorkspaceResults_StatisticsView : UserControl
    {
        public WorkspaceResults_StatisticsView()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            
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
    }
}

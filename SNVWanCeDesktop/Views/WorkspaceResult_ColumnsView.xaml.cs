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
    /// WorkspaceResult_ColumnsView.xaml 的交互逻辑
    /// </summary>
    public partial class WorkspaceResult_ColumnsView : UserControl
    {
        public WorkspaceResult_ColumnsView()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.RoundFormatType.Items.Clear();
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("0", "1");
            map.Add("1", "2");
            map.Add("2", "3");
            map.Add("3", "4");
            //List<Dictionary<string, string>> keyValues = new List<Dictionary<string, string>>();
            //keyValues.Add(new Dictionary<string, string>("0", "1"));
            //keyValues.Add("1", "2");
            //keyValues.Add("2", "3");
            //keyValues.Add("3", "4");
            this.RoundFormatType.ItemsSource = map;
            //this.RoundFormatType.Items.Add(new BaseInfo() { Id=0,Content="1"});
            //this.RoundFormatType.Items.Add(new BaseInfo() { Id=1,Content="2"});
            //this.RoundFormatType.Items.Add(new BaseInfo() { Id=2,Content="3"});
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void DecimalNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ComboBox comboBox = sender as ComboBox;
            //int number = comboBox.SelectedIndex;

            //switch (number)
            //{
            //    default:
            //        break;
            //}
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ContentControl contentControl = this.Parent as ContentControl;
            FrameworkElement parentControl = Tools.FindVisualParent<FrameworkElement>(contentControl, "IndexViewRegion");
            WorkspaceResultColumnsDescribeOne.MaxWidth = parentControl.RenderSize.Width - 210;
            WorkspaceResultColumnsDescribeTwo.MaxWidth = parentControl.RenderSize.Width - 210;
            treeView.MinHeight = 8 * 80 - 200;
            if(parentControl.RenderSize.Height - 130< treeView.MinHeight)
            {
                treeView.Height = 8 * 80-100;
            }
            else
            {
            treeView.Height = parentControl.RenderSize.Height - 150;
            }
            e.Handled = true;
        }
    }
}

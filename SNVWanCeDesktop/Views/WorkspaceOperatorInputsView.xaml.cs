using Prism.Events;
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
    /// WorkspaceOperatorInputsView.xaml 的交互逻辑
    /// </summary>
    public partial class WorkspaceOperatorInputsView : UserControl
    {
        public readonly IEventAggregator eventAggregator;
        public WorkspaceOperatorInputsView(IEventAggregator aggregator)
        {
            eventAggregator = aggregator;
            InitializeComponent();
        }
        public void Init()
        {

        }

        private void Button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void MoveUp_Click(object sender, RoutedEventArgs e)
        {
            if (DeterMiniedParametersList.Items.Count > 1)
            {
                if(DeterMiniedParametersList.SelectedIndex == 0)
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
                if (DeterMiniedParametersList.SelectedIndex == DeterMiniedParametersList.Items.Count-1)
                {
                    return;
                }
                int index = DeterMiniedParametersList.SelectedIndex;
                ObservableCollection<WorkspaceInputTypeInfo> infos = (ObservableCollection<WorkspaceInputTypeInfo>)DeterMiniedParametersList.ItemsSource;
                WorkspaceInputTypeInfo info1 = infos[index];
                infos[index] = infos[index+1];
                infos[index + 1]= info1;
                DeterMiniedParametersList.ItemsSource = infos;
                DeterMiniedParametersList.SelectedIndex = index + 1;
            }
        }

        private void treeView_Collapsed(object sender, RoutedEventArgs e)
        {

        }

        private void treeView_Selected(object sender, RoutedEventArgs e)
        {
            //此处item定义的是一个类的成员变量，是一个TreeViewItem类型
            var item = GetParentObjectEx<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;
            //item.Visibility = Visibility.Collapsed;
        }
        //获取当前TreeView的TreeViewItem
        public TreeViewItem GetParentObjectEx<TreeViewItem>(DependencyObject obj) where TreeViewItem : FrameworkElement
        {
            DependencyObject parent = VisualTreeHelper.GetChild(obj,0);
            if (parent != null)
            {
                parent = VisualTreeHelper.GetParent(parent);
                return (TreeViewItem)parent;
            }
            //DependencyObject parent = VisualTreeHelper.GetParent(obj);
            while (parent != null)
            {
                if (parent is TreeViewItem)
                {
                    return (TreeViewItem)parent;
                }
                parent = VisualTreeHelper.GetParent(parent);
            }
            return null;
        }
        //获取ItemTemplate内部的各种控件
        private childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                    return (childItem)child;
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ContentControl contentControl = this.Parent as ContentControl;
            FrameworkElement parentControl = Tools.FindVisualParent<FrameworkElement>(contentControl, "IndexViewRegion");
            //OperatorInputsScroll.Height = parentControl.RenderSize.Height;
            //OperatorInputsScroll.Width = parentControl.RenderSize.Width - 200;
            OperatorInputsViewDescribetion.MaxWidth = parentControl.RenderSize.Width - 230;
            treeView.MinHeight = 8*80-200;
            treeView.Height= parentControl.RenderSize.Height-130;
            e.Handled = true;
        }
    }
}

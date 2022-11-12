using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WanCeDesktopApp.Views.Dialogs
{
    /// <summary>
    /// ChoiceInputsDialog.xaml 的交互逻辑
    /// </summary>
    public partial class ChoiceInputsDialogView : UserControl
    {
        DataTable table = new();
        int CurrenIndex = -1;
        string CurrentValue = "";
        public ChoiceInputsDialogView()
        {
            InitializeComponent();
        }

        private void DeleteRow_Click(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.CurrentItem == null)
            {
                return;
            }
            Int32 row = this.myDataGrid.Items.IndexOf(this.myDataGrid.CurrentItem);
            myDataGrid.Items.RemoveAt(row);
        }

        private void myDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            if (myDataGrid.CurrentCell == null || this.myDataGrid.CurrentItem==null)
            {
                return;
            }
            Int32 row = this.myDataGrid.Items.IndexOf(this.myDataGrid.CurrentItem);//获取当前行，列
            Int32 Col = this.myDataGrid.Columns.IndexOf(this.myDataGrid.CurrentColumn);
            var cell = GetCell(this.myDataGrid, row, Col);
            if (myDataGrid.CurrentCell.Column?.DisplayIndex == 0)
            {
                cell.Unselected += new RoutedEventHandler(cell_Unselected);
            }
            cell.Selected += new RoutedEventHandler(cell_Selected);
        }

        private void cell_Selected(object sender, RoutedEventArgs e)
        {
            CurrenIndex = this.myDataGrid.Items.IndexOf(this.myDataGrid.CurrentItem);
            this.myDataGrid.Tag = CurrenIndex;
        }

        private void cell_Unselected(object sender, RoutedEventArgs e)
        {
            DataGridCell gridCell = sender as DataGridCell;
            if (gridCell.Content.GetType() != typeof(TextBlock))
            {
                return;
            }
            TextBlock textBlock = (TextBlock)gridCell.Content;
            CurrentValue = textBlock.Text;
            //DataRowView rowView = myDataGrid.CurrentCell.Item as DataRowView;
            //if(rowView == null)
            //{
            //    return;
            //}
            //string value = rowView[0].ToString();
            //int index = this.myDataGrid.Items.IndexOf(this.myDataGrid.CurrentItem);
            //DataView dataView = (DataView)myDataGrid.ItemsSource;
            //for (int i = 0; i < dataView.Table.Rows.Count - 1; i++)
            //{
            //    if (i != CurrenIndex)
            //    {
            //        if (CurrentValue.Equals(dataView.Table.Rows[i][0]))
            //        {
            //            MessageBox.Show("The value already exists!");
            //            textBlock.Focus();
            //            this.myDataGrid.Tag = -1;
            //            return;
            //        }
            //    }
            //}
        }

        /// <summary>
        /// 回车将焦点移动到下一个单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ////没有进入编辑状态，上一个单元格还是选中的
                //var uie = e.OriginalSource as UIElement;
                //if (e.Key == Key.Enter)
                //{
                //    uie.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                //    e.Handled = true;
                //}
                if (e.Key == Key.Enter)
                {
                    e.Handled = true;
                    Int32 row = this.myDataGrid.Items.IndexOf(this.myDataGrid.CurrentItem);
                    Int32 Col = this.myDataGrid.Columns.IndexOf(this.myDataGrid.CurrentColumn);
                    var cell1 = GetCell(this.myDataGrid, row, Col);
                    cell1.IsSelected = false;
                    var cell = GetCell(this.myDataGrid, row, Col + 1);
                    if (cell != null)
                    {
                        cell.IsSelected = true;
                        cell.Focus();
                        this.myDataGrid.BeginEdit();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 根据行、列索引取的对应单元格对象
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public DataGridCell GetCell(DataGrid grid, int row, int column)
        {
            DataGridRow rowContainer = GetRow(grid, row);
            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);
                if (presenter == null)
                {
                    grid.ScrollIntoView(rowContainer, grid.Columns[column]);
                    presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);
                }
                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                return cell;
            }
            return null;
        }

        /// <summary>
        /// 根据行索引取的行对象
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public DataGridRow GetRow(DataGrid grid, int index)
        {
            DataGridRow row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
            if (row == null)
            {
                grid.ScrollIntoView(grid.Items[index]);
                row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
            }
            return row;
        }

        /// <summary>
        /// 获取指定类型的子元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <returns></returns>
        private T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual visual = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = visual as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(visual);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

    }
}

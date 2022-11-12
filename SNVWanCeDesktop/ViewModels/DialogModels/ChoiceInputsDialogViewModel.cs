using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Serilog;
using LoggingModule;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common;

namespace WanCeDesktopApp.ViewModels.DialogModels
{
    public class ChoiceInputsDialogViewModel : BindableBase, IDialogHostAware
    {
        private DataTable propertyTable = new DataTable();
        private static ILogger log = Log.ForContext<ChoiceInputsDialogViewModel>();
        public DataTable PropertyTable { get => propertyTable; set { propertyTable = value; RaisePropertyChanged(); } }
        private string prompt;
        public string Prompt { get => prompt; set { prompt = value; RaisePropertyChanged(); } }
        ObservableCollection<object> _choices;
        private DataRowView selectItem;
        public ObservableCollection<object> Choices { get => _choices; set { _choices = value; RaisePropertyChanged(); } }
        public DataRowView SelectItem { get => selectItem; set { selectItem = value; RaisePropertyChanged(); } }
        public int SelectItemIndex { get; set; } = -1;
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand AddRowCommand { get; set; }
        public DelegateCommand<object> DeleteRowCommand { get; set; }
        public DelegateCommand<object> MoveUpRowCommand { get; set; }
        public DelegateCommand<object> MoveDownRowCommand { get; set; }
        public DelegateCommand<object> LineColumnCommand { get; set; }
        public DelegateCommand<object> CurrentCellChangedCommand { get; set; }
        public ChoiceInputsDialogViewModel()
        {
            CancelCommand = new DelegateCommand(Canel);
            SaveCommand = new DelegateCommand(Save);
            AddRowCommand = new DelegateCommand(AddRow);
            DeleteRowCommand = new DelegateCommand<object>(DeleteRow);
            MoveUpRowCommand = new DelegateCommand<object>(MoveUpRow);
            MoveDownRowCommand = new DelegateCommand<object>(MoveDownRow);
            LineColumnCommand = new DelegateCommand<object>(LineColumn);
            CurrentCellChangedCommand = new DelegateCommand<object>(CellEditEnding);
        }

        private void CellEditEnding(object index)
        {
            int rowIndex = (int)index;
            if (rowIndex == -1)
            {
                return;
            }
            if (rowIndex< Choices.Count)
            {

                Choices[rowIndex] = PropertyTable.Rows[rowIndex][0];
            }
            else
            {
                Choices.Add(PropertyTable.Rows[rowIndex][0]);
            }
        }

        private void AddRow()
        {
            if (string.IsNullOrEmpty(PropertyTable.Rows[PropertyTable.Rows.Count - 1][0].ToString()))
            {
                return;
            }
            DataRow dataRow = PropertyTable.NewRow();
            PropertyTable.Rows.Add(dataRow);
        }

        private void DeleteRow(object index)
        {
            if (index == null)
            {
                return;
            }
            int rowIndex = (int)index;
            if (rowIndex == -1)
            {
                return;
            }
            PropertyTable.Rows.RemoveAt((int)index);
        }
        //向上移动
        private void MoveUpRow(object index)
        {
            if(index == null)
            {
                return;
            }
            int rowIndex = (int)index;
            if (PropertyTable.Rows.Count > 1)
            {
                if (rowIndex == 0 || rowIndex == -1)
                {
                    return;
                }
                DataRow info1 = PropertyTable.NewRow();
                info1.ItemArray = PropertyTable.Rows[rowIndex].ItemArray;
                PropertyTable.Rows.InsertAt(info1, rowIndex - 1);
                PropertyTable.Rows.RemoveAt(rowIndex + 1);
                SelectItemIndex = rowIndex - 1;
                //SelectItem = PropertyTable.Rows[rowIndex - 1];
            }
        }

        //向下移动
        private void MoveDownRow(object index)
        {
            if (index == null)
            {
                return;
            }
            int rowIndex = (int)index;
            if (PropertyTable.Rows.Count > 1)
            {
                if (rowIndex == PropertyTable.Rows.Count - 1 || rowIndex == -1)
                {
                    return;
                }
                DataRow info1 = PropertyTable.NewRow();
                info1.ItemArray = PropertyTable.Rows[rowIndex].ItemArray;
                PropertyTable.Rows.RemoveAt(rowIndex);
                PropertyTable.Rows.InsertAt(info1, rowIndex + 1);
                SelectItemIndex = rowIndex + 1;
                //SelectItem = PropertyTable.Rows[rowIndex + 1];
            }
        }

        private void LineColumn(object index)
        {

        }

        private void Save()
        {
            try
            {
                if (DialogHost.IsDialogOpen(DialogHostName))
                {
                    DialogParameters parameter = new DialogParameters();//点击确定时的参数
                    DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, parameter));
                }
            }
            catch (System.NullReferenceException ex)
            {
                log.Here().Error(ex, AppConstants.EXCEPTION_RAISED);
            }
            catch (Exception ex)
            {
                log.Here().Error(ex, AppConstants.EXCEPTION_RAISED);
            }
        }

        private void Canel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.No));
            }

        }


        public bool CanCloseDialog()//验证窗口是否允许被关闭
        {
            return true;
        }

        public void OnDialogClosed()//触发关闭的方法
        {

        }

        public string DialogHostName { get; set; }

        public void OnDialogOpend(IDialogParameters parameters)
        {
            Prompt = parameters.GetValue<string>("Prompt");
            ObservableCollection<object> objs = (ObservableCollection<object>)parameters.GetValue<object>("Choices");
            Choices = objs;
            //PropertyTable = parameters.GetValue<DataTable>("Table");
            PropertyTable.Columns.Add(new DataColumn("First", typeof(string)));
            PropertyTable.Columns.Add(new DataColumn("Second", typeof(string)));
            foreach (var item in objs)
            {
                PropertyTable.Rows.Add(item.ToString());
            }
            SelectItemIndex = 1;
            //SelectItem = PropertyTable.Rows[0].DataRowView;
        }
    }
}
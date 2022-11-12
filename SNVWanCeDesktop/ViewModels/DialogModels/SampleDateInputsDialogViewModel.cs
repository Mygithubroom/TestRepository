using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WanCeDesktopApp.Common;

namespace WanCeDesktopApp.ViewModels.DialogModels
{
    public class SampleDateInputsDialogViewModel :BindableBase, IDialogHostAware
    {
        private string currentData=DateTime.Now.ToShortDateString();

        #region 参数
        public ObservableCollection<string> DateFormatTypes { get; set; }
        public DelegateCommand<string> SelectChangedCommand { get; set; }
        public string CurrentDate
        {
            get => currentData;
            set { currentData = value;RaisePropertyChanged(); }
        }
        private string title;
        private string dateFormatType = "Short";
        private string head;

        public string Head
        {
            get { return head; }
            set { head = value; }
        }

        #endregion
        public SampleDateInputsDialogViewModel()
        {
            Init();
        }

        private void Init()
        {
            DateFormatTypes = new ObservableCollection<string>();
            List<string> formats = new List<string>();
            foreach (var item in Enum.GetValues(typeof(DatePickerFormat)))
            {
                formats.Add(item.ToString());
            }
            DateFormatTypes.AddRange(formats);
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
            SelectChangedCommand = new DelegateCommand<string>(SelectChanged);
        }

        private void SelectChanged(string obj)
        {
            if (obj == "Long")
            {
                CurrentDate = DateTime.Now.ToLongDateString();
            }
            if (obj == "Short")
            {
                CurrentDate = DateTime.Now.ToShortDateString();
            }
        }

        //btn按钮的取消与确定
        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.No));
            }
        }
        private void Save()
        {
            try
            {
                if (string.IsNullOrEmpty(Title)|| string.IsNullOrEmpty(DateFormatType))
                {
                    MessageBox.Show("Title or Date Format is empty!", "Tip",MessageBoxButton.OK,MessageBoxImage.Question);
                    return;
                }
                if (DialogHost.IsDialogOpen(DialogHostName))
                {
                    DialogParameters parameter = new DialogParameters();//点击确定时的参数
                    parameter.Add("Title", Title);
                    parameter.Add("DateFormatType", DateFormatType);
                    DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, parameter));
                }
            }
            catch (System.NullReferenceException ex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string DialogHostName { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public string Title { get => title; set { title = value; RaisePropertyChanged(); } }
        public string DateFormatType { get => dateFormatType; set { dateFormatType = value; RaisePropertyChanged(); } }

        public void OnDialogOpend(IDialogParameters parameters)
        {
            Head = parameters.GetValue<string>("Title");
            Title = parameters.GetValue<string>("Description");
            DateFormatType = string.IsNullOrEmpty(parameters.GetValue<string>("DateFormatType"))?"Short": parameters.GetValue<string>("DateFormatType");
            SelectChanged(DateFormatType);
        }
    }
}

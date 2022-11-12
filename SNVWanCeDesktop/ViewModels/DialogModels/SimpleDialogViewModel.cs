using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Services.Dialogs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WanCeDesktopApp.Common;

namespace WanCeDesktopApp.ViewModels.DialogModels
{
    public class SimpleDialogViewModel : IDialogHostAware
    {
        public SimpleDialogViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }
        //btn按钮的取消与确定
        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.Cancel));
            }
        }
        private void Save()
        {
            try
            {
                if (string.IsNullOrEmpty(Prompt))
                {
                    MessageBox.Show("Prompt is Empty!");
                    return;
                }
                if (DialogHost.IsDialogOpen(DialogHostName))
                {
                    DialogParameters parameter = new DialogParameters();//点击确定时的参数
                    parameter.Add("prompt", Prompt);
                    parameter.Add("defaultValue", DefaultValue);
                    DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, parameter));
                }
            }
            catch (System.NullReferenceException ex)
            {
                
            }
            catch (Exception ex)
            {
                
            }
        }

        public string DialogHostName { get; set; }
        public string Title { get; set; }
        public string Prompt { get; set; }
        public string DefaultValue { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public void OnDialogOpend(IDialogParameters parameters)// 主要用于接收弹窗传递过来的参数
        {
            string header = parameters.GetValue<string>("title");
            if (string.IsNullOrEmpty(header))
            {
                Title = "Properties - Sample note input";
            }
            else
            {
                Title = parameters.GetValue<string>("title");
            }
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }
        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}

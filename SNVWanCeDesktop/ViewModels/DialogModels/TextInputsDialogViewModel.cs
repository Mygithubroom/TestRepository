using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common;


namespace WanCeDesktopApp.ViewModels.DialogModels
{
    public class TextInputsDialogViewModel : IDialogHostAware
    {
        public TextInputsDialogViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }
        //btn按钮的取消与确定
        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                DialogHost.Close(DialogHostName,new DialogResult(ButtonResult.No));
            }
        }
        private void Save()
        {
            try { 
                if (DialogHost.IsDialogOpen(DialogHostName))
                {
                    DialogParameters parameter = new DialogParameters();//点击确定时的参数
                    DialogHost.Close(DialogHostName,new DialogResult(ButtonResult.OK, parameter));
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
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public void OnDialogOpend(IDialogParameters parameters)
        {
        }
    }
}

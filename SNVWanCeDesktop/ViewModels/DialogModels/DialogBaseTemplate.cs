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
    public class DialogBaseTemplate : IDialogAware
    {
        public string Title => throw new NotImplementedException();

        public event Action<IDialogResult> RequestClose;
        public DialogBaseTemplate()
        {
            CancelCommand = new DelegateCommand(Canel);
            SaveCommand = new DelegateCommand(Save);
        }

        private void Save()
        {
            RequestClose.Invoke(new DialogResult(ButtonResult.OK));
        }

        private void Canel()
        {
            RequestClose.Invoke(new DialogResult(ButtonResult.Cancel));

        }

        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }

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



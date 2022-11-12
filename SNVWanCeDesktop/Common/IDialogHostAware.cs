using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.Common
{
    public interface IDialogHostAware
    {
        string DialogHostName { get; set; }

        void OnDialogOpend(IDialogParameters parameters); // 主要用于接收弹窗传递过来的参数

        DelegateCommand SaveCommand { get; set; }
        DelegateCommand CancelCommand { get; set; }

    }
}

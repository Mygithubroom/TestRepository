using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common;

namespace WanCeDesktopApp.ViewModels
{
    public class MsgViewModel : BindableBase, IDialogHostAware
    {
        public MsgViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
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
            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                DialogParameters parameter = new DialogParameters();//点击确定时的参数
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, parameter));
            }
        }
        #region 属性
        public string content;
        public string Content {
            get { return content; }
            set { content = value; RaisePropertyChanged(); }
        }
        public string title;


        public string Title 
        {
            get { return title; }
            set {title = value; RaisePropertyChanged(); }
        }
        public string DialogHostName { get; set; } = "Root";
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        #endregion
        public void OnDialogOpend(IDialogParameters parameters)
        {

            if (parameters.ContainsKey("Title"))
            {
                Title = parameters.GetValue<string>("Title");
            }
            if (parameters.ContainsKey("Content"))
            {
                Content = parameters.GetValue<string>("Content");
            }
        }
    }
}

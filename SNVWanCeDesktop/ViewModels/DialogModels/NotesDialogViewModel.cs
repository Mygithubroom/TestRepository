using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common;

namespace WanCeDesktopApp.ViewModels.DialogModels
{
    public class NotesDialogViewModel:BindableBase,IDialogHostAware
    {
        
        public string DialogHostName { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        private readonly IEventAggregator eventAggregator;
        public string title = "";
        public string content = "";
        private string head;

        public string Head
        {
            get { return head; }
            set { head= value;RaisePropertyChanged(); }
        }

        public string Content
        {
            get { return content; }
            set { content = value;  }
        }
        public string Title
        {
            get { return title; }
            set { title = value;  }
        }

        public NotesDialogViewModel(IEventAggregator eventAggregator)
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
            this.eventAggregator = eventAggregator;
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
                if (DialogHost.IsDialogOpen(DialogHostName))
                {
                    DialogParameters parameter = new DialogParameters();//点击确定时的参数
                    parameter.Add("Prompt", Title);
                    parameter.Add("DefaultText", Content);
                    DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, parameter));

                    //eventAggregator.GetEvent<MessageEvent>().Publish(new Message{ Content = "Hello" });
                }
            }
            catch (System.NullReferenceException ex)
            {
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void OnDialogOpend(IDialogParameters parameters)
        {
            Head = parameters.GetValue<string>("Title") ;
        }
    }
}

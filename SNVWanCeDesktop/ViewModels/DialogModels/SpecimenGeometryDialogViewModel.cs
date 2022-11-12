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
    public class SpecimenGeometryDialogViewModel
        : BindableBase,
            IDialogHostAware
    {
        public string DialogHostName { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        private readonly IEventAggregator eventAggregator;

        public string Head { get; set; }
        public int SelectedGeometryIndex { get; set; }
        public string Title { get; set; }

        public SpecimenGeometryDialogViewModel(IEventAggregator eventAggregator)
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
            this.eventAggregator = eventAggregator;
            Head = string.Empty;
            Title = string.Empty;
            DialogHostName = string.Empty;
            SelectedGeometryIndex = -1;
        }

        //btn按钮的取消与确定
        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                DialogHost.Close(
                    DialogHostName,
                    new DialogResult(ButtonResult.No)
                );
            }
        }

        private void Save()
        {
            try
            {
                if (DialogHost.IsDialogOpen(DialogHostName))
                {
                    DialogParameters parameter = new DialogParameters(); //点击确定时的参数
                    parameter.Add("Prompt", Title);
                    parameter.Add(
                        "DefaultGeometryIndex",
                        SelectedGeometryIndex
                    );
                    DialogHost.Close(
                        DialogHostName,
                        new DialogResult(ButtonResult.OK, parameter)
                    );

                    //eventAggregator.GetEvent<MessageEvent>().Publish(new Message{ Content = "Hello" });
                }
            }
            catch (System.NullReferenceException _) { }
            catch (Exception _)
            {
                throw;
            }
        }

        public void OnDialogOpend(IDialogParameters parameters)
        {
            Head = parameters.GetValue<string>("Title");
        }
    }
}

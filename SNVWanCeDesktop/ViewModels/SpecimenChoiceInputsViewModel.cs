using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common;

namespace WanCeDesktopApp.ViewModels
{
    public class SpecimenChoiceInputsViewModel : BindableBase
    {


        private IDialogHostService _dialogService;
        private ObservableCollection<BaseInfo> specimenChoiceInputsArr;

        public SpecimenChoiceInputsViewModel(IDialogHostService dialogService)
        {
            _dialogService = dialogService;
            Init();
            RegisterCommand();
        }

        private void Init()
        {
            SpecimenChoiceInputsArr = new ObservableCollection<BaseInfo>();
            SpecimenChoiceInputsArr.Add(new BaseInfo() { Id = 0, Content = "", Description = "Label 1" });
            SpecimenChoiceInputsArr.Add(new BaseInfo() { Id = 1, Content = "", Description = "Label 2" });
            SpecimenChoiceInputsArr.Add(new BaseInfo() { Id = 2, Content = "", Description = "Label 3" });
            SpecimenChoiceInputsArr.Add(new BaseInfo() { Id = 3, Content = "", Description = "Label 4" });
            SpecimenChoiceInputsArr.Add(new BaseInfo() { Id = 4, Content = "", Description = "Label 5" });
            SpecimenChoiceInputsArr.Add(new BaseInfo() { Id = 5, Content = "", Description = "Label 6" });
        }
        private void RegisterCommand()
        {
            OpenDialogCommand = new DelegateCommand(OpenDialog);
        }


        public ObservableCollection<BaseInfo> SpecimenChoiceInputsArr { get => specimenChoiceInputsArr; set { specimenChoiceInputsArr = value; RaisePropertyChanged(); } }
        public DelegateCommand OpenDialogCommand { get; set; }

        private void OpenDialog()
        {

        }
    }
}

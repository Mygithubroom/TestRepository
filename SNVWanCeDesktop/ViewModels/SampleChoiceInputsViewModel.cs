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
using Serilog;
using LoggingModule;
using WanCeDesktopApp.Common.DAO;
using WanCeDesktopApp.Views.Dialogs;

namespace WanCeDesktopApp.ViewModels
{
    public class SampleChoiceInputsViewModel : BindableBase
    {
        private IDialogHostService dialogService;//自定义对话框
        private ILogger log = Log.ForContext<SampleChoiceInputsViewModel>();
        private ObservableCollection<ChoiceInputInfo> specimenChoiceInputsArr;
        public DelegateCommand<ChoiceInputInfo> ExecuteShowDialogCommand { get; private set; }


        public SampleChoiceInputsViewModel(IDialogHostService dialog)
        {
            this.dialogService = dialog;
            Init();
            ExecuteShowDialogCommand = new DelegateCommand<ChoiceInputInfo>(Excute);
            //RegisterCommand();
        }

        private void Init()
        {
            SpecimenChoiceInputsArr = new ObservableCollection<ChoiceInputInfo>();
            SpecimenChoiceInputsArr.Add(new ChoiceInputInfo()
            {
                Id = 0,
                Content = "",
                Description = "Label 1",
                Choices = null
            });
            SpecimenChoiceInputsArr.Add(new ChoiceInputInfo()
            {
                Id = 1,
                Content = "",
                Description = "Label 2",
                Choices = null
            });
            SpecimenChoiceInputsArr.Add(new ChoiceInputInfo()
            {
                Id = 2,
                Content = "",
                Description = "Label 3",
                Choices = null
            });
            SpecimenChoiceInputsArr.Add(new ChoiceInputInfo()
            {
                Id = 3,
                Content = "",
                Description = "Label 4",
                Choices = null
            });
            SpecimenChoiceInputsArr.Add(new ChoiceInputInfo()
            {
                Id = 4,
                Content = "",
                Description = "Label 5",
                Choices = null
            });
            SpecimenChoiceInputsArr.Add(new ChoiceInputInfo()
            {
                Id = 5,
                Content = "",
                Description = "Label 6",
                Choices = null
            });
        }


        public ObservableCollection<ChoiceInputInfo> SpecimenChoiceInputsArr
        {
            get => specimenChoiceInputsArr;
            set { specimenChoiceInputsArr = value; RaisePropertyChanged(); }
        }
        private void Excute(ChoiceInputInfo obj)
        {
            try
            {
                if (obj != null)
                {
                    obj.Choices = new ObservableCollection<object>();
                    obj.Choices.Add("testsss");
                    DialogParameters pairs = new DialogParameters();
                    pairs.Add("Prompt", obj.Description);
                    pairs.Add("Choices", obj.Choices);
                    dialogService.ShowDialog(nameof(ChoiceInputsDialogView), pairs, callback =>
                    {

                    });//自定义对话框
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
    }
}

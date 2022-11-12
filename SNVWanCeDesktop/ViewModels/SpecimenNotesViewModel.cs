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
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Views.Dialogs;

namespace WanCeDesktopApp.ViewModels
{
    public class SpecimenNotesViewModel : BindableBase
    {
        
        private IDialogHostService dialogService;//自定义对话框
        public DelegateCommand<ShowInfo> ExecuteShowDialogCommand { get; private set; }

        private ObservableCollection<ShowInfo> specimenNotesInputs = new ObservableCollection<ShowInfo>();//注册菜单
        #region
        public ObservableCollection<ShowInfo> SpecimenNotesInput
        {
            get { return specimenNotesInputs; }
            set { specimenNotesInputs = value; RaisePropertyChanged(); }
        }
        #endregion
        SpecimenNotesViewModel(IDialogHostService dialog)
        {
            this.dialogService = dialog;
            InitItem();
            ExecuteShowDialogCommand = new DelegateCommand<ShowInfo>(Excute);
        }
        void InitItem()
        {
            
            
            
            try
            {
                SpecimenNotesInput.Add(new ShowInfo() { Title = "Specimen description" });
                SpecimenNotesInput.Add(new ShowInfo() { Title = "Specimen node 1" });
                SpecimenNotesInput.Add(new ShowInfo() { Title = "Specimen node 2" });
                SpecimenNotesInput.Add(new ShowInfo() { Title = "Specimen node 3" });
            }
            catch (System.NullReferenceException ex)
            {
                
            }
            catch (Exception ex)
            {
                
            }
        }
        private void Excute(ShowInfo item)
        {
            try
            {
                if (item == null)
                {
                    return;
                }
                DialogParameters param = new DialogParameters();
                param.Add("Title", "Properties - Specimen note input");
                var dialogresult = dialogService.ShowDialog(nameof(NotesDialogView), param, callback =>
                {
                    if (callback.Result == ButtonResult.OK)
                    {
                        item.Title = callback.Parameters.GetValue<string>("Prompt");
                        item.Content = callback.Parameters.GetValue<string>("DefaultText");
                    }
                });
            }
            catch (System.NullReferenceException ex)
            {
                return ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

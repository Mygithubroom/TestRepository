using MaterialDesignThemes.Wpf;
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
    public class SampleNotesViewModel : BindableBase
    {


        private IDialogHostService dialogService;//自定义对话框
        public DelegateCommand<ShowInfo> ExecuteShowDialogCommand { get; private set; }
        private ObservableCollection<ShowInfo> sampleNotes = new ObservableCollection<ShowInfo>();//注册菜单
        #region
        public ObservableCollection<ShowInfo> SampleNotes
        {
            get { return sampleNotes; }
            set { sampleNotes = value; RaisePropertyChanged(); }
        }
        #endregion
        SampleNotesViewModel(IDialogHostService dialog)
        {
            this.dialogService = dialog;
            InitItem();
            ExecuteShowDialogCommand = new DelegateCommand<ShowInfo>(Excute);
        }
        void InitItem()
        {
            try
            {
                SampleNotes.Add(new ShowInfo() { Title = "Sample description" });
                SampleNotes.Add(new ShowInfo() { Title = "Sample node 1" });
                SampleNotes.Add(new ShowInfo() { Title = "Sample node 2" });
                SampleNotes.Add(new ShowInfo() { Title = "Sample node 3" });
            }
            catch (System.NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        private async void Excute(ShowInfo item)
        {
            try
            {
                if(item == null)
                {
                    return;
                }
                DialogParameters param = new DialogParameters();
                param.Add("Title", "Properties - Sample note input");
                var dialogresult =  dialogService.ShowDialog(nameof(NotesDialogView), param, callback =>
                {
                    if(callback.Result == ButtonResult.OK)
                    {
                        item.Title = callback.Parameters.GetValue<string>("Prompt"); 
                        item.Content = callback.Parameters.GetValue<string>("DefaultText"); 
                    }
                });
            }
            catch (System.NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

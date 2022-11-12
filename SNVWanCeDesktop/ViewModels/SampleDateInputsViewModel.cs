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
using WanCeDesktopApp.Extensions;
using WanCeDesktopApp.Views.Dialogs;

namespace WanCeDesktopApp.ViewModels
{
    public class SampleDateInputsViewModel : BindableBase
    {
        
        private ObservableCollection<DateInfo> sampleDateInputs = new ObservableCollection<DateInfo>();//注册菜单
       
        private IDialogHostService dialogService;//自定义对话框
        #region
        public DelegateCommand<DateInfo> ExecuteShowDialogCommand { get; private set; }

        public ObservableCollection<DateInfo> SampleDateInputs
        {
            get { return sampleDateInputs; }
            set { sampleDateInputs = value; RaisePropertyChanged(); }
        }

        #endregion
        SampleDateInputsViewModel(IDialogHostService dialog)
        {
            this.dialogService = dialog;
            InitItem();
            ExecuteShowDialogCommand = new DelegateCommand<DateInfo>(Excute);
        }

        void InitItem()
        {
            try
            {
                int i = 1;
                do
                {
                    SampleDateInputs.Add(new DateInfo() { Description = "Sample date input",DateFormatType="Short" });
                    i++;
                } while (i<10); 
                
                //SampleDateInputs.Add(new DateInfo() { Content = " Sample date input" });
            }
            catch (System.NullReferenceException ex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Excute(DateInfo item)
        {
            try
            {
                if (item == null)
                {
                    return;
                }
                DialogParameters param = new DialogParameters();
                param.Add("Title", "Properties - Sample date config");
                param.Add("DateFormatType", item.DateFormatType);
                param.Add("Description", item.Description);
                var dialogresult = dialogService.ShowDialog(nameof(SampleDateInputsDialogView), param, callback =>
                {
                    if (callback.Result == ButtonResult.OK)
                    {
                        item.Description = callback.Parameters.GetValue<string>("Title");
                        item.DateFormatType = callback.Parameters.GetValue<string>("DateFormatType");
                        if (item.DateFormatType == "Long")
                        {
                            item.Content = String.IsNullOrEmpty(item.Content)? "": DateTime.Parse(item.Content).ToLongTimeString();
                        }
                        if (item.DateFormatType == "Short")
                        {
                            item.Content = String.IsNullOrEmpty(item.Content) ? "" : DateTime.Parse(item.Content).ToShortDateString();
                        }
                    }
                });
            }
            catch (System.NullReferenceException ex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private void Excute(string str)
        //{
        //    try
        //    {
        //        if (str == "SampleDateInputsDialogView")
        //        {
        //            dialogService.ShowDialog("SampleDateInputsDialogView", null);//自定义对话框
        //        }
        //    }
        //    catch (System.NullReferenceException ex)
        //    {
        //        return;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}

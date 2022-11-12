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
using WanCeDesktopApp.Common.DAO;
using WanCeDesktopApp.Extensions;
using WanCeDesktopApp.Views.Dialogs;

namespace WanCeDesktopApp.ViewModels
{
    public class SampleTextInputsViewModel : BindableBase
    {
        
        private ObservableCollection<InputInfo> sampleTextInputs = new ObservableCollection<InputInfo>();//注册菜单
        public DelegateCommand<InputInfo> CheckCommand { get; private set; }
        private IDialogHostService dialogService;//自定义对话框
        #region
        public DelegateCommand<InputInfo> ExecuteShowDialogCommand { get; private set; }

        public ObservableCollection<InputInfo> SampleTextInputs
        {
            get { return sampleTextInputs; }
            set { sampleTextInputs = value; RaisePropertyChanged(); }
        }

        #endregion
        SampleTextInputsViewModel(IDialogHostService dialog)
        {
            this.dialogService = dialog;
            InitItem();
            CheckCommand = new DelegateCommand<InputInfo>(Check);
            ExecuteShowDialogCommand = new DelegateCommand<InputInfo>(Excute);
        }

        void InitItem()
        {
            
            
            
            try {
                SampleTextInputs.Add(new InputInfo() { DefaultTitleKey = "Sample text input", IsChecked = true, Content = "" });
                SampleTextInputs.Add(new InputInfo() { DefaultTitleKey = "Sample text input", IsChecked = false, Content = "" });
            }
            catch (System.NullReferenceException ex)
            {
                
            }
            catch (Exception ex)
            {
                
            }
        }
        private void Check(InputInfo obj)
        {
            
            
            
            try
            {
                if (obj.IsChecked)
                {
                    if (SampleTextInputs.IndexOf(obj) == SampleTextInputs.Count - 1)
                    {
                        SampleTextInputs.Add(new InputInfo() { DefaultTitleKey= "Sample text input", IsChecked = false, Content= "" });
                    }
                }
                else
                {
                    if (SampleTextInputs.IndexOf(obj) != SampleTextInputs.Count - 2)
                    {
                        return;
                    }
                    if (SampleTextInputs.Count >= 2)
                    {
                        for (int i = SampleTextInputs.Count - 1; i > 0; i--)
                        {
                            if (SampleTextInputs[i - 1].IsChecked)
                            {
                                break;
                            }
                            SampleTextInputs.RemoveAt(i);
                        }
                    }
                }
            }
            catch (System.NullReferenceException ex)
            {
                
            }
            catch (Exception ex)
            {
                
            }
        }
        private void Excute(InputInfo item)
        {
            try
            {
                if (item == null)
                {
                    return;
                }
                DialogParameters param = new DialogParameters();
                param.Add("Title", "Properties - Sample Text input");
                var dialogresult = dialogService.ShowDialog(nameof(NotesDialogView), param, callback =>
                {
                    if (callback.Result == ButtonResult.OK)
                    {
                        item.UserDefinedTitle = callback.Parameters.GetValue<string>("Prompt");
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
        //private void Excute(string str)
        //{
            
            
            
        //    try
        //    {
        //        if (str == "TextInputsDialogView")
        //        {
        //        dialogService.ShowDialog("TextInputsDialogView", null);//自定义对话框
        //        }
        //    }
        //    catch (System.NullReferenceException ex)
        //    {
                
        //    }
        //    catch (Exception ex)
        //    {
                
        //    }
        //}
    }
}

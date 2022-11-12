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
    public class SpecimenTextInputsViewModel : BindableBase
    {
        

        private ObservableCollection<InputInfo> textInputs = new ObservableCollection<InputInfo>();//注册菜单
        public DelegateCommand<InputInfo> CheckCommand { get; private set; }
        private IDialogHostService dialogService;//自定义对话框
        #region
        public DelegateCommand<InputInfo> ExecuteShowDialogCommand { get; private set; }

        public ObservableCollection<InputInfo> InputInfoItems
        {
            get { return textInputs; }
            set { textInputs = value; RaisePropertyChanged(); }
        }
        #endregion

        SpecimenTextInputsViewModel(IDialogHostService dialog)
        {
            this.dialogService = dialog;
            InitItem();
            CheckCommand = new DelegateCommand<InputInfo>(Check);
            ExecuteShowDialogCommand = new DelegateCommand<InputInfo>(Excute);

        }
        void InitItem()
        {
            try
            {
                InputInfoItems.Add(new InputInfo() { DefaultTitleKey = "Specimen text input", IsChecked = true, Content = "" });
                InputInfoItems.Add(new InputInfo() { DefaultTitleKey = "Specimen text input", IsChecked = false, Content = "" });
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
                    if (InputInfoItems.IndexOf(obj) == InputInfoItems.Count - 1)
                    {
                        InputInfoItems.Add(new InputInfo() { DefaultTitleKey = "Specimen text input", IsChecked = false, Content = "" });
                    }
                }
                else
                {
                    if (InputInfoItems.IndexOf(obj) != InputInfoItems.Count - 2)
                    {
                        return;
                    }
                    if (InputInfoItems.Count >= 2)
                    {
                        for (int i = InputInfoItems.Count - 1; i > 0; i--)
                        {
                            if (InputInfoItems[i - 1].IsChecked)
                            {
                                break;
                            }
                            InputInfoItems.RemoveAt(i);
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
                param.Add("Title", "Properties - Specimen Text input");
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
        //            dialogService.ShowDialog("TextInputsDialogView", null);//自定义对话框
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

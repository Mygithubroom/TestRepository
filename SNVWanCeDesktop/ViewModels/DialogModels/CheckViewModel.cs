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
using WanCeDesktopApp.Common;

namespace WanCeDesktopApp.ViewModels.DialogModels
{
    //检定与校准
    public class CheckValue
    {
        public uint StandardValue { get; set; }//标准值 
        public uint ReadValue { get; set; }//示值
        public uint CodeValue { get; set; } //码值 
        public uint DeviationValue { get; set; }//相对误差
        public uint AbsoluteValue { get; set; } //绝对误差
        public uint AverageValue { get; set; }// 平均值
    };
    public class CheckViewModel : BindableBase, IDialogHostAware
    {
        CheckValue cv;
        public string DialogHostName { get; set; }
        public string Title { get; set; }
        public string Prompt { get; set; }
        public string DefaultValue { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        public ObservableCollection<CheckValue> DataList { get; set; }
        //public CheckValue CheckTemp { get; set; }
        public CheckViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
            DataList = new ObservableCollection<CheckValue>();
            CheckFunction();
        }
        //btn按钮的取消与确定
        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.Cancel));
            }
        }
        private void Save()
        {
            try
            {
                if (string.IsNullOrEmpty(Prompt))
                {
                    //MessageBox.Show("Prompt is Empty!");
                    return;
                }
                if (DialogHost.IsDialogOpen(DialogHostName))
                {
                    DialogParameters parameter = new DialogParameters();//点击确定时的参数
                    parameter.Add("prompt", Prompt);
                    parameter.Add("defaultValue", DefaultValue);
                    DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, parameter));
                }
            }
            catch (System.NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        public void CheckFunction()
        {
            for (int i = 9; i < 10; i++)
            {
                DataList.Add(new CheckValue() { StandardValue = 128, ReadValue = 1239, CodeValue = 812, DeviationValue = 12, AbsoluteValue = 82, AverageValue = 9 });
                DataList.Add(new CheckValue() { StandardValue = 922, ReadValue = 10, CodeValue = 89, DeviationValue = 5, AbsoluteValue = 9, AverageValue = 9 });
                DataList.Add(new CheckValue() { StandardValue = 10, ReadValue = 10, CodeValue = 89, DeviationValue = 6, AbsoluteValue = 0, AverageValue = 9 });
                DataList.Add(new CheckValue() { StandardValue = 11, ReadValue = 11, CodeValue = 89, DeviationValue = 7, AbsoluteValue = 5, AverageValue = 9 });
                DataList.Add(new CheckValue() { StandardValue = 8, ReadValue = 922, CodeValue = 89, DeviationValue = 4, AbsoluteValue = 8, AverageValue = 9 });
                DataList.Add(new CheckValue() { StandardValue = 9, ReadValue = 2210, CodeValue = 89, DeviationValue = 5, AbsoluteValue = 9, AverageValue = 9 });
                DataList.Add(new CheckValue() { StandardValue = 10, ReadValue = 10, CodeValue = 89, DeviationValue = 6, AbsoluteValue = 0, AverageValue = 9 });
                DataList.Add(new CheckValue() { StandardValue = 11, ReadValue = 11, CodeValue = 8332, DeviationValue = 7, AbsoluteValue = 5, AverageValue = 9 });
                DataList.Add(new CheckValue() { StandardValue = 8, ReadValue = 9, CodeValue = 89, DeviationValue = 4, AbsoluteValue = 8, AverageValue = 9 });
                DataList.Add(new CheckValue() { StandardValue = 9, ReadValue = 10, CodeValue = 89, DeviationValue = 5, AbsoluteValue = 9, AverageValue = 9 });
            }
        }

        public void OnDialogOpend(IDialogParameters parameters)// 主要用于接收弹窗传递过来的参数
        {
            string header = parameters.GetValue<string>("title");
            if (string.IsNullOrEmpty(header))
            {
                Title = "Properties - Sample note input";
            }
            else
            {
                Title = parameters.GetValue<string>("title");
            }
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }
        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
        public void DeviationValueCalculation()//相对误差
        {
            cv.DeviationValue = (uint)Math.Abs(cv.ReadValue- cv.StandardValue); 
      
        }
        public void AbsoluteValueCalculation()//绝对误差
        {
            cv.AbsoluteValue = (uint)Math.Abs(cv.ReadValue - cv.StandardValue) / cv.ReadValue;
        }
    }
}

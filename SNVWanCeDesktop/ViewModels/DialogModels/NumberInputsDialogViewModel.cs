using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Spreadsheet;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UnitsProvider;
using UnitsProvider.Extend;
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Common.DAO;
using WanCeDesktopApp.Common.Enum;

namespace WanCeDesktopApp.ViewModels.DialogModels
{
    public class NumberInputsDialogViewModel : BindableBase,IDialogHostAware
    {
        //当前选中单位的索引
        public int SelectedUnitIndex { get; set; } = -1;
        //当前选中单位源的索引
        public int SelectedUnitSetIndex { get; set; } = -1;
        //当前选中小数位的索引
        public int SelectedDecimalplaceIndex { get; set; } = 5;
        public string DialogHostName { get; set; }
        //单位源名称集合
        public ObservableCollection<InputInfo> UnitSetItems { get; set; }
        //单位符号集合
        public ObservableCollection<string> UnitItems { get; set; }
        //小数集合
        public ObservableCollection<string> DecimalplaceItems { get; set; }
        //编辑对象的中介
        public GaugeItemInfo GaugeItem { get; set; }

        #region 命令
        //单位源切换事件
        public DelegateCommand<InputInfo> SelectChangedCommand { get; set; }
        //单位或者小数切换事件
        public DelegateCommand<object> SelectChangedCommand2 { get; set; }
        //窗体加载
        public DelegateCommand LoadedCommand { get; set; }
        //保存
        public DelegateCommand SaveCommand { get; set; }
        //取消
        public DelegateCommand CancelCommand { get; set; }
        #endregion
        public NumberInputsDialogViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
            SelectChangedCommand = new DelegateCommand<InputInfo>(SelectChanged);
            SelectChangedCommand2 = new DelegateCommand<object>(SelectChanged2);
            LoadedCommand = new DelegateCommand(Loaded);
            Init();
        }
        public void Loaded()
        {
            try
            {
                var input = UnitSetItems.FirstOrDefault(fild => fild.DefaultTitleKey == GaugeItem.UnitSetName);
                if (input != null)
                {
                    SelectedUnitSetIndex = UnitSetItems.IndexOf(input);
                    var unitset = UnitTools.GetUnitSet(GaugeItem.UnitSetName);
                    UnitItems.Clear();
                    foreach (var item in unitset.Units)
                    {
                        UnitItems.Add(item.Symbol);

                    }
                }
                if (GaugeItem != null)
                {
                    SelectedUnitIndex = UnitItems.IndexOf(GaugeItem.Unit);
                    SelectedDecimalplaceIndex = DecimalplaceItems.IndexOf(GaugeItem.DecimalPlaces + "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SelectChanged2(object obj)
        {
            try
            {
                if (obj == null)
                {
                    return;
                }
                int num = -1;
                if (int.TryParse(obj.ToString(), out num))
                {
                    GaugeItem.DecimalPlaces = num;//小数位
                }
                else
                {
                    GaugeItem.Unit = obj.ToString();//单位
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SelectChanged(InputInfo obj)
        {
            try
            {
                UnitSet info = UnitTools.GetUnitSet(obj.DefaultTitleKey);
                if (info == null)
                {
                    return;
                }
                UnitItems.Clear();
                GaugeItem.UnitSetName = obj.DefaultTitleKey;//单位源名
                foreach (var item in info.Units)
                {
                    UnitItems.Add(item.Symbol);//单位符号
                }
                SelectedUnitIndex = UnitItems.IndexOf(UnitTools.GetDefaultUnit(obj.DefaultTitleKey).Symbol);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Init()
        {
            try
            {
                //初始化
                UnitSetItems = new ObservableCollection<InputInfo>();
                UnitItems = new ObservableCollection<string>();
                GaugeItem = new GaugeItemInfo();
                DecimalplaceItems = new ObservableCollection<string>();
                foreach (var item in UnitsProvider.UnitTools.GetUnitSets())
                {
                    InputInfo inputInfo = new InputInfo();
                    inputInfo.DefaultTitleKey = item.SetName.DefaultKey;
                    inputInfo.UserDefinedTitle = item.SetName.UserDefinedContent;
                    UnitSetItems.Add(inputInfo);
                }
                DecimalplaceItems.Add("1");
                DecimalplaceItems.Add("2");
                DecimalplaceItems.Add("3");
                DecimalplaceItems.Add("4");
                DecimalplaceItems.Add("5");
                DecimalplaceItems.Add("6");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                throw;
            }
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
                    parameter.Add("Obj", GaugeItem);//编辑后的数据对象
                    DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, parameter));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

 
        public void OnDialogOpend(IDialogParameters parameters)
        {
            GaugeItemInfo info = parameters.GetValue<GaugeItemInfo>("Obj");
            if(info != null)
            {
                GaugeItem.Title = info.Title;
                GaugeItem.DecimalPlaces = info.DecimalPlaces;
                GaugeItem.DisplayValue = info.DisplayValue ;
                GaugeItem.IsPreTestLimit = info.IsPreTestLimit;
                GaugeItem.PreMaximum = info.PreMaximum ;
                GaugeItem.PreMinimum = info.PreMinimum;
                GaugeItem.Unit = info.Unit;
                GaugeItem.UnitSetName= info.UnitSetName;
            }
            
        }
    }
}

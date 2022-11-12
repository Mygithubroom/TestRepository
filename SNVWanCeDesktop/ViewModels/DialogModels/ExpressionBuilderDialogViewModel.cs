using DocumentFormat.OpenXml.Bibliography;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using UnitsProvider.Extend;
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Common.DAO;

namespace WanCeDesktopApp.ViewModels.DialogModels
{
    public class ExpressionBuilderDialogViewModel : BindableBase, IDialogHostAware
    {
        public ObservableCollection<TreeviewItemInfo> AvailableParametersArr { get; set; }
        public ObservableCollection<TreeviewItemInfo> UnitSetItems { get; set; }
        public ArrayList ArrList { get; set; }
        public string Expression { get; set; }
        public List<DictionaryExt> ExpressionParameters { get; set; }
        //计算结果的名称
        public string CalculateResultName { get; set; }
        public DelegateCommand LoadedCommand { get; private set; }
        public ExpressionBuilderDialogViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
            LoadedCommand = new DelegateCommand(Loaded);
            Init();
        }

        private void Init()
        {
            AvailableParametersArr = new ObservableCollection<TreeviewItemInfo>();
            UnitSetItems = new ObservableCollection<TreeviewItemInfo>();
            var items = UnitsProvider.UnitTools.GetUnitSets();
            foreach (var item in items)
            {
                InputInfo info = new InputInfo();
                info.IsParent = true;
                info.DefaultTitleKey = item.SetName.DefaultKey;
                info.UserDefinedTitle = item.SetName.UserDefinedContent;
                foreach (var temp in item.Units)
                {
                    InputInfo info2 = new InputInfo();
                    info2.UserDefinedTitle = temp.Symbol;
                    info.AvailableParametersItemsArr.Add(info2);
                }
                UnitSetItems.Add(info);
            }
        }
        public void Loaded()
        {
        }
        //btn按钮的取消与确定
        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.Cancel));
            }
        }
        //2022/11/12胡建国修改

        private void Save()
        {
            try
            {
                if (DialogHost.IsDialogOpen(DialogHostName))
                {
                    DialogParameters parameter = new DialogParameters();//点击确定时的参数
                    //parameter.Add("ArrList", ArrList);
                    parameter.Add("DispalyExpression", Expression);//表达式
                    //单位源
                    parameter.Add("UnitSetName", Expression);
                    //单位
                    parameter.Add("Unit", Expression);
                    DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, parameter));
                }
            }
            catch (System.NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string DialogHostName { get; set; }
        public string Title { get; set; }
        public string Prompt { get; set; }
        public string DefaultValue { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public void OnDialogOpend(IDialogParameters parameters)// 主要用于接收弹窗传递过来的参数
        {
            var objects = parameters.GetValue<object?[]>("ArrList");//计算结果的表达式
            if (ArrList == null)
            {
                ArrList = new ArrayList();
            }
            ArrList.Clear();
            if (objects != null)
            {
                ArrList.AddRange(objects);
            }
            //2022/11/12胡建国修改
            //缓存的注册参数
            ExpressionParameters = parameters.GetValue<List<DictionaryExt>>("ExpressionParameters");
            if (ExpressionParameters == null)
            {
                ExpressionParameters = new List<DictionaryExt>();
            }
            //可选参数集合
            List<GaugeItemInfo> infos = parameters.GetValue<List<GaugeItemInfo>>("AvailableParametersArr");
            if(infos.Count>0) AvailableParametersArr.AddRange(infos);
            foreach (var item in AvailableParametersArr)
            {

            }
            //Tools.GetVariableSet()
            //展示的表达式
            Expression = parameters.GetValue<string>("Expression");
            CalculateResultName = "" + "=";
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
            //ArrList
            ArrList = parameters.GetValue<ArrayList>("ArrList");
            if (ArrList == null)
            {
                ArrList = new ArrayList();
            }
            //ShowText
        }
    }
}

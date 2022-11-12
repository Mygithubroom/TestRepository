using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Common.DAO;
using WanCeDesktopApp.Views.Dialogs;

namespace WanCeDesktopApp.ViewModels
{
    public class CalculationsSetupViewModel : BindableBase
    {
        private string[] CalculationArray = { 
            "% of break", 
            "Area reduction", 
            "Area under curve", 
            "Average value",
            "Break",
            "UserDefine",
            "Break location",
            "Coefficientoffriction",
            "Compensated energy",
            "CreepRelaxation",
            "Elongation after fracture",
            "Fracture toughness conditional point",
            "Hold preset point",
            "Line intersection",
            "Modulus",
            "Non-proportional elongation",
            "N-value",
            "Peak first",
            "Peak local",
            "Peakmaximumminimum",
            "Poisson's ratio",
            "Polynomial fitting",
            "preset point",
            "R-value",};
        private ObservableCollection<GaugeItemInfo> availableCalculationLists = new ObservableCollection<GaugeItemInfo>();
        private ObservableCollection<GaugeItemInfo> selectedCalculationLists = new ObservableCollection<GaugeItemInfo>();
        private readonly IDialogHostService dialogHostService;

        private string inputText = "";
        public string InputText {
            get=>inputText;  
            set { inputText = value; RaisePropertyChanged(); }
        }
        //向右移动命令，可选参数移动到选定参数集合
        public DelegateCommand<GaugeItemInfo> MoveToRightCommand { get; private set; }
        //与上面相反
        public DelegateCommand<GaugeItemInfo> MoveToLeftCommand { get; private set; }
        //打开Dialog命令
        public DelegateCommand OpenDialogCommand { get; private set; }
        public DelegateCommand<GaugeItemInfo> UpDataText { get; private set; }//列表选择有更改的事件触发
        public GaugeItemInfo CurGaugeItem { get;set; }//当前编辑对象

        public ObservableCollection<GaugeItemInfo> AvailableCalculationLists
        {
            get => availableCalculationLists;
            set { availableCalculationLists = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<GaugeItemInfo> SelectedCalculationLists
        {
            get => selectedCalculationLists;
            set { selectedCalculationLists = value; RaisePropertyChanged(); }
        }
        public string TestValue { get; set; }
        CalculationsSetupViewModel(IDialogHostService dialogHostService)
        {
            InitCalculationList();
            this.dialogHostService = dialogHostService;
        }
        public void InitCalculationList()
        {
            MoveToRightCommand = new DelegateCommand<GaugeItemInfo>(MoveRight);
            MoveToLeftCommand = new DelegateCommand<GaugeItemInfo>(MoveLeft);
            OpenDialogCommand = new DelegateCommand(OpenDialog);
            UpDataText = new DelegateCommand<GaugeItemInfo>(upDateTextBox);
            Array.Sort(CalculationArray);
            foreach (string strValue in CalculationArray)
            {
                AvailableCalculationLists.Add(new GaugeItemInfo() { DefaultTitleKey= strValue });
            }
            SelectedCalculationLists = Collections.SelectedCalculationItems;
        }
        #region 2022/11/12胡建国修改
        //
        private void OpenDialog()
        {
            DialogParameters pairs = new DialogParameters();
            //pairs.Add("ArrList", CurGaugeItem.Expression?.ToArray());//当前计算结果的表达式
            pairs.Add("AvailableParametersArr", Tools.GetVariableSet("normal"));//可选参数
            CurGaugeItem.CacheType = "normal";
            pairs.Add("DispalyExpression", CurGaugeItem.DispalyExpression);//表达式

            dialogHostService.ShowDialog(nameof(ExpressionBuilderDialogView), pairs, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {
                    //单位集
                    //单位
                    var arrList = callback.Parameters.GetValue<ArrayList>("ArrList");
                    if (arrList == null)
                    {
                        CurGaugeItem.Expression = new ArrayList();
                    }
                    else
                    {
                        CurGaugeItem.Expression = arrList;
                        //禁用输入框
                    }
                    CurGaugeItem.DispalyExpression = callback.Parameters.GetValue<string>("DispalyExpression");
                    CurGaugeItem.UnitSetName = callback.Parameters.GetValue<string>("UnitSetName");
                    CurGaugeItem.Unit = callback.Parameters.GetValue<string>("Unit");

                }
            });
        } 
        #endregion

        private void upDateTextBox(GaugeItemInfo info)//选择后更新TextBox内容
        {
            if (info != null)
            {
                InputText = info.Content;
                CurGaugeItem = info;
            }
            else
            { return; }
        }

        private void MoveRight(GaugeItemInfo obj)
        {
            if(obj == null)
            {
                return;
            }
            GaugeItemInfo temp = (GaugeItemInfo)obj.Clone(); 
            SelectedCalculationLists.Add(temp);
        }
        private void MoveLeft(GaugeItemInfo obj)
        {
            if (obj == null)
            {
                return;
            }
            SelectedCalculationLists.Remove(obj);
            //AvailableCalculationLists.Add(new GaugeItemInfo() { Content = str });
        }
    }

}

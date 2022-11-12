using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Common.DAO;
using WanCeDesktopApp.Views.Dialogs;

namespace WanCeDesktopApp.ViewModels
{
    public class TabControlMeasurementsViewModel : BindableBase
    {
        private int[][] GaugeCount = new int[2][];
        private Dictionary<string, List<string>> GaugeCache = new Dictionary<string, List<string>>();
        private ObservableCollection<GaugeItemInfo> availableParametersArr;
        private ObservableCollection<GaugeItemInfo> deterMiniedParametersArr;
        private readonly IEventAggregator eventAggregator;
        private IDialogHostService dialoghostService;
        public DelegateCommand ExecuteShowDialogCommand { get; private set; }

        public DelegateCommand<GaugeItemInfo> MoveToRightCommand { get; private set; }
        public DelegateCommand<GaugeItemInfo> MoveToLeftCommand { get; private set; }
        public DelegateCommand<GaugeItemInfo> SelectionChangedCommand { get; private set; }
        public GaugeItemInfo DeterMiniedParametersItem { get; set; }
        public ObservableCollection<DictionaryExt> UnitItems { get; set; }
        public int Index { get; set; }
        ///// <summary>
        ///// 缓存删掉的父参数
        ///// </summary>
        private List<GaugeItemInfo> DeletedNodes = new List<GaugeItemInfo>();

        //测量参数[实物测量][虚拟测量]
        private string ActualMeasurement = @"Load;Strain;Torque;Temperature;UserDefined;;";
        private string SvirtualMeasurement = "CorrectionDisplacement;Expression;TransverseStrain;;;;;";


        public ObservableCollection<GaugeItemInfo> AvailableParametersArr { get => availableParametersArr; set { availableParametersArr = value; RaisePropertyChanged(); } }
        public ObservableCollection<GaugeItemInfo> DeterMiniedParametersArr { get => deterMiniedParametersArr; set { deterMiniedParametersArr = value; RaisePropertyChanged(); } }

        public TabControlMeasurementsViewModel(IEventAggregator aggregator, IDialogHostService dialog)
        {
            this.dialoghostService = dialog;
            this.eventAggregator = aggregator;
            Init();
            RegisterMommand();
        }

        private void RegisterMommand()
        {
            MoveToRightCommand = new DelegateCommand<GaugeItemInfo>(MoveRight);
            MoveToLeftCommand = new DelegateCommand<GaugeItemInfo>(MoveLeft);
            SelectionChangedCommand = new DelegateCommand<GaugeItemInfo>(SelectionChanged);
        }

        private void SelectionChanged(GaugeItemInfo obj)
        {
            if (obj == null)
            {
                return;
            }
            try
            {
                //OKInsertDB(obj); 已经测试过，暂未找到调用该方法的位置，暂时注释掉， 
                UnitInfo info = UnitSystemProvider.GetUnitInfo(obj.UnitSetName);
                if (info == null)
                {
                    return;
                }
                UnitItems.Clear();
                UnitItems.AddRange(info.Units);
                Index = info.Units.FindIndex(0, unit =>
                {
                    return string.IsNullOrWhiteSpace(obj.Unit) ? unit.Key == info.DefaultValue.Key :
                     unit.Value == obj.Unit;
                });
            }
            catch (System.NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }


        private void MoveLeft(GaugeItemInfo obj)
        {
            if (obj == null)
            {
                return;
            }
            try
            {
                string key = obj.Id + "_" + obj.Index;
                //string title = obj.Title + "_" + GaugeCount[obj.Id][obj.Index];
                GaugeCount[obj.Id][obj.Index]--;
                GaugeCache.GetValueOrDefault(key).Remove(obj.Tag?.ToString());
                int index = DeterMiniedParametersArr.IndexOf(obj);
                obj.UserDefinedTitle = null;//还原修改说明
                DeterMiniedParametersArr.Remove(obj);
                //通知使用该测量的地方
                eventAggregator.GetEvent<MessageEvent>().Publish(new Message() { Title = obj.Title ,Filter= "RemoveGauge" });
                if (index == DeterMiniedParametersArr.Count)
                {
                    if (DeterMiniedParametersArr.Count != 0)
                    {
                        DeterMiniedParametersItem = DeterMiniedParametersArr[index - 1];
                    }
                }
                else
                {
                    DeterMiniedParametersItem = DeterMiniedParametersArr[index];
                }
            }
            catch (System.NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }
        private void MoveRight(GaugeItemInfo obj)
        {
            if (obj == null)
            {
                return;
            }
            try
            {
                //是否是子节点
                if (!obj.IsParent)
                {
                    //克隆获得新对象
                    GaugeItemInfo GaugeItem = (GaugeItemInfo)obj.Clone();
                    //添加规则
                    GaugeCount[GaugeItem.Id][GaugeItem.Index]++;
                    //if (GaugeItem.Sensor != null)
                    //{
                    string key = GaugeItem.Id + "_" + GaugeItem.Index;
                    if (GaugeCache.ContainsKey(key))
                    {
                        List<string> list = GaugeCache.GetValueOrDefault(key);
                        for (int i = 1; i <= GaugeCount[GaugeItem.Id][GaugeItem.Index]; i++)
                        {
                            string title = "";
                            if (GaugeItem.Id == 1)
                            {
                                title = GaugeItem.Title + " " + i;
                            }
                            else
                            {
                                if (i == 1)
                                {
                                    title = GaugeItem.Title;//具体应该根据传感器获取
                                }
                                else
                                {
                                    title = GaugeItem.Title + "_" + i;
                                }
                            }
                            if (list.Contains(title))
                            {
                                continue;
                            }
                            GaugeItem.Title = title;
                            GaugeItem.Tag = title;
                            list.Add(title);
                            break;
                        }
                    }
                    else
                    {
                        string title = "";//具体应该根据传感器获取
                        if (GaugeItem.Id == 1)
                        {
                            title = GaugeItem.Title + " " + 1;
                        }
                        else
                        {
                            title = GaugeItem.Title;
                        }
                        GaugeItem.Title=title;
                        GaugeItem.Tag = title;
                        GaugeCache.Add(key, new List<string>() { title });
                    }
                    //GaugeItem.Title = GaugeItem.Title + "_" + GaugeCount[GaugeItem.Id][GaugeItem.Index];

                    //}
                    DeterMiniedParametersArr.Add(GaugeItem);
                    DeterMiniedParametersItem = DeterMiniedParametersArr[DeterMiniedParametersArr.Count - 1];
                }

            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }

        }

        public void Init()
        {
            AvailableParametersArr = new ObservableCollection<GaugeItemInfo>();
            DeterMiniedParametersArr = new ObservableCollection<GaugeItemInfo>();
            UnitItems = new ObservableCollection<DictionaryExt>();
            ExecuteShowDialogCommand = new DelegateCommand(Excute);
            //添加测量类型
            GaugeItemInfo typeInfo;
            ObservableCollection<TreeviewItemInfo> AvailableParametersItemsArr =
                new ObservableCollection<TreeviewItemInfo>();
            typeInfo = new GaugeItemInfo();
            typeInfo.Id = 0;
            typeInfo.InputTypeName = "Physical measurements";
            typeInfo.IsParent = true;
            string[] aActualMeasurement = Tools.ToList(ActualMeasurement);
            GaugeCount[0] = new int[aActualMeasurement.Length];
            for (int i = 0; i < aActualMeasurement.Length; i++)
            {
                AvailableParametersItemsArr.Add(new GaugeItemInfo()
                {
                    Id = 0,
                    Index = i,
                    InputTypeName = aActualMeasurement[i],
                    DefaultTitleKey = aActualMeasurement[i],
                    GaugeType = aActualMeasurement[i]
                });
            }
            typeInfo.AvailableParametersItemsArr = AvailableParametersItemsArr;
            AvailableParametersArr.Add(typeInfo);
            typeInfo = new GaugeItemInfo();
            AvailableParametersItemsArr = new ObservableCollection<TreeviewItemInfo>();
            typeInfo.Id = 1;
            typeInfo.InputTypeName = "Virtual measurements";
            typeInfo.IsParent = true;
            string[] aSvirtualMeasurement = Tools.ToList(SvirtualMeasurement);
            GaugeCount[1] = new int[aSvirtualMeasurement.Length];
            for (int i = 0; i < aSvirtualMeasurement.Length; i++)
            {
                AvailableParametersItemsArr.Add(new GaugeItemInfo()
                {
                    Id = 1,
                    Index = i,
                    InputTypeName = aSvirtualMeasurement[i],
                    DefaultTitleKey = aSvirtualMeasurement[i],
                    GaugeType = aSvirtualMeasurement[i]
                });
            }
            typeInfo.AvailableParametersItemsArr = AvailableParametersItemsArr;
            AvailableParametersArr.Add(typeInfo);
            DeterMiniedParametersArr = Collections.GaugeItems;

        }

        public void Excute()
        {
            dialoghostService.ShowDialog(nameof(ExpressionBuilderDialogView), null);
        }

        public void OKInsertDB(GaugeItemInfo info)
        {
            SQLiteHelper dbTable = new SQLiteHelper("TestMethodParamDataBase ");
            StringBuilder strCmd = new StringBuilder();
            //添加变量的有效判断，然后再执行写入数据库操作
            strCmd.Append("INSERT INTO MeasurementParamTable(" +
                "MethodID, " +
                "MeasurementParamID," +
                "MeasurementName, " +
                "MeasurementDescription, " +
                "PreTestLimitedMax," +
                "PreTestLimitedMin," +
                "RateDescript," +
                "DataPoint," +
                "TrueStrainControl," +
                "LinearRegression" +
                ") VALUES ");

            strCmd.Append("(");
            strCmd.Append("1123");
            strCmd.Append(", ");
            strCmd.Append("456");
            strCmd.Append(", ");
            strCmd.Append("\"");
            strCmd.Append(info.Title);
            strCmd.Append("\"");
            strCmd.Append(", ");
            strCmd.Append("\"");
            strCmd.Append("ghjnkl");
            strCmd.Append("\"");
            strCmd.Append(", ");
            strCmd.Append(info.PreMaximum);
            strCmd.Append(", ");
            strCmd.Append(info.PreMinimum);
            strCmd.Append(", ");
            strCmd.Append("\"");
            strCmd.Append(info.RateExplain);
            strCmd.Append("\"");
            strCmd.Append(", ");
            strCmd.Append(info.DataPointCount);
            strCmd.Append(", ");
            strCmd.Append(info.IsTrueStrainControl);
            strCmd.Append(",");
            strCmd.Append(info.IsUsingLinearRegression);
            strCmd.Append(");");
            string sqlStrCommande = strCmd.ToString();
            DataTable dt = dbTable.ExecuteDataTable(sqlStrCommande);
        }

    }
}

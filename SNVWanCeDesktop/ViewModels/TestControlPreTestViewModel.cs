using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common.DAO;

namespace WanCeDesktopApp.ViewModels
{
    public class TestControlPreTestViewModel : BindableBase
    {
        //试验前->
        public bool temperatureSoak;//热浸
        public bool preLoad;//预加载
        public string constrolMode;//控制模式
        public string rateText;//速率
        public string unitComboBox;//单位
        public string changeCriteria;//变更标准
        public string measureMent;//测量事件
        public string rate; //速率
        public string rateUnit;//单位
        public bool overtravel;//过载
        public bool precycl;//预循环
        public bool cyclicCollection;//循环采集
        public string cycleTime;//循环周期
        public string cycleControlMode;//循环控制模式
        public string cycleRate;//循环速率
        public string cycRateUnit;//速率单位
        public string maxMeasureMent;//最大测量
        public string max;//最大值 
        public string maxUnit;//最大值
        public string minMeasureMent;//最大测量
        public string min;//最大值
        public string minUnit;//最大值 


        public bool TemperatureSoak { get => temperatureSoak; set { temperatureSoak = value; RaisePropertyChanged(); } }
        public bool PreLoad { get => preLoad; set { preLoad = value;RaisePropertyChanged(); } }
        public string ConstrolMode { get => constrolMode; set { constrolMode = value; RaisePropertyChanged(); } }
        public string RateText { get => rateText; set { rateText = value; RaisePropertyChanged(); } }
        public string UnitComboBox { get => unitComboBox; set { unitComboBox = value; RaisePropertyChanged(); } }
        public string ChangeCriteria { get => changeCriteria; set { changeCriteria = value; RaisePropertyChanged(); } }
        public string MeasureMent { get => measureMent; set { measureMent = value; RaisePropertyChanged(); } }
        public string Rate { get => rate; set { rate = value; RaisePropertyChanged(); } }
        public string RateUnit { get => rateUnit; set { rateUnit = value; RaisePropertyChanged(); } }
        public bool Overtravel { get => overtravel; set { overtravel = value; RaisePropertyChanged(); } }
        public bool Precycl { get => precycl; set { precycl = value; RaisePropertyChanged(); } }
        public bool CyclicCollection { get => cyclicCollection; set { cyclicCollection = value; RaisePropertyChanged(); } }
        public string CycleTime { get => cycleTime; set { cycleTime = value; RaisePropertyChanged(); } }
        public string CycleControlMode { get => cycleControlMode; set { cycleControlMode = value; RaisePropertyChanged(); } }
        public string CycleRate { get => cycleRate; set { cycleRate = value; RaisePropertyChanged(); } }
        public string CycRateUnit { get => cycRateUnit; set { cycRateUnit = value; RaisePropertyChanged(); } }
        public string MaxMeasureMent { get => maxMeasureMent; set { maxMeasureMent = value; RaisePropertyChanged(); } }
        public string Max { get => max; set { max = value; RaisePropertyChanged(); } }
        public string MaxUnit { get => maxUnit; set { maxUnit = value; RaisePropertyChanged(); } }

        public string MinMeasureMent { get => maxMeasureMent; set { maxMeasureMent = value; RaisePropertyChanged(); } }
        public string Min { get => max; set { max = value; RaisePropertyChanged(); } }
        public string MinUnit { get => minUnit; set { minUnit = value; RaisePropertyChanged(); } }

        private ObservableCollection<WorkspaceInputTypeInfo> availableParametersArr;
        private ObservableCollection<WorkspaceInputTypeInfo> deterMiniedParametersArr;
        private readonly IEventAggregator eventAggregator;
        public TestControlPreTestViewModel(IEventAggregator aggregator)
        {
            Init();
            RegisterMommand();
            OKInsertDB();
        }

        private void RegisterMommand()
        {
            MoveToRightCommand = new DelegateCommand<WorkspaceInputTypeInfo>(MoveRight);
            MoveToLeftCommand = new DelegateCommand<WorkspaceInputTypeInfo>(MoveLeft);
            SelectionChangedCommand = new DelegateCommand<WorkspaceInputTypeInfo>(SelectionChanged);
        }

        private void SelectionChanged(WorkspaceInputTypeInfo obj)
        {
            if (obj == null)
            {
                return;
            }
            try
            {
                //nothing
            }
            catch (System.NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        public DelegateCommand<WorkspaceInputTypeInfo> MoveToRightCommand { get; private set; }
        public DelegateCommand<WorkspaceInputTypeInfo> MoveToLeftCommand { get; private set; }
        public DelegateCommand<WorkspaceInputTypeInfo> SelectionChangedCommand { get; private set; }

        private void MoveLeft(WorkspaceInputTypeInfo obj)
        {
            if (obj == null)
            {
                return;
            }
            try
            {
                DeterMiniedParametersArr.Remove(obj);
                //查找删除掉的父参数选项
                for (int i = 0; i < DeletedNodes.Count; i++)
                {
                    if (DeletedNodes[i].Id == obj.Id)
                    {
                        if (AvailableParametersArr.Count >= obj.Id)
                        {
                            AvailableParametersArr.Insert(obj.Id, DeletedNodes[i]);//加回来
                            DeletedNodes.RemoveAt(i);
                        }
                        else
                        {
                            AvailableParametersArr.Add(DeletedNodes[i]);
                            DeletedNodes.RemoveAt(i);
                        }
                        break;
                    }
                }
                int count = obj.Id;
                for (int i = 0; i < DeletedNodes.Count; i++)
                {
                    if (DeletedNodes[i].Id < obj.Id)
                    {
                        count--;
                    }
                }
                if (AvailableParametersArr[count].AvailableParametersItemsArr.Count >= obj.Index)
                {
                    AvailableParametersArr[count].AvailableParametersItemsArr.Insert(obj.Index, obj);
                }
                else
                {
                    AvailableParametersArr[count].AvailableParametersItemsArr.Add(obj);//原来的位置大于现有子参数个数
                }
            }
            catch (System.NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void MoveRight(WorkspaceInputTypeInfo obj)
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
                    DeterMiniedParametersArr.Add(obj);
                    int count = obj.Id;
                    for (int i = 0; i < DeletedNodes.Count; i++)
                    {
                        if (DeletedNodes[i].Id < obj.Id)
                        {
                            count--;
                        }
                    }
                    //DeterMiniedParametersArr.Add(new WorkspaceInputTypeInfo() { Index = DeterMiniedParametersArr.Count, Id = obj.Id, Content = obj.InputTypeName, Description = obj.InputTypeName });
                    AvailableParametersArr[count].AvailableParametersItemsArr.Remove(obj);
                    //AvailableParametersArr[count].AvailableParametersItemsArr[obj.Index].VisibilityType =Visibility.Collapsed;//隐藏子参数
                    if (!AvailableParametersArr[count].HasChildren)//可用参数类型下没有子参数时
                    {
                        DeletedNodes.Add(AvailableParametersArr[count]);
                        //AvailableParametersArr[count].VisibilityType = Visibility.Collapsed;//隐藏父参数
                        AvailableParametersArr.RemoveAt(count);
                    }
                }

            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }

        }
        ///// <summary>
        ///// 缓存删掉的父参数
        ///// </summary>
        private List<WorkspaceInputTypeInfo> DeletedNodes = new List<WorkspaceInputTypeInfo>();

        public ObservableCollection<WorkspaceInputTypeInfo> AvailableParametersArr { get => availableParametersArr; set { availableParametersArr = value; RaisePropertyChanged(); } }
        public ObservableCollection<WorkspaceInputTypeInfo> DeterMiniedParametersArr { get => deterMiniedParametersArr; set { deterMiniedParametersArr = value; RaisePropertyChanged(); } }

        public void Init()
        {
            AvailableParametersArr = new ObservableCollection<WorkspaceInputTypeInfo>();
            DeterMiniedParametersArr = new ObservableCollection<WorkspaceInputTypeInfo>();
            WorkspaceInputTypeInfo typeInfo;
            for (int i = 0; i < 5; i++)
            {
                typeInfo = new WorkspaceInputTypeInfo();
                typeInfo.Id = i;
                typeInfo.InputTypeName = "TestInputType" + i;
                typeInfo.IsParent = true;
                typeInfo.AvailableParametersItemsArr = new ObservableCollection<TreeviewItemInfo>()
                {
                    new WorkspaceInputTypeInfo() { Id = i, Index = 0, InputTypeName = "TestInputParameter1" },
                    new WorkspaceInputTypeInfo() { Id = i, Index = 1, InputTypeName = "TestInputParameter2" }
                };
                AvailableParametersArr.Add(typeInfo);
            }
        }
        public void OKInsertDB()
        {
            try
            {
                SQLiteHelper dbTable = new SQLiteHelper("TestControlDataBase ");
                StringBuilder strCmd = new StringBuilder();
                //添加变量的有效判断，然后再执行写入数据库操作
                //预加载
                {
                    strCmd.Clear();
                    strCmd.Append("INSERT INTO PreLoadTable (" +
                        "PreLoadID, " +
                        "MethodID," +
                        "ControlMode," +
                        "ControlRate, " +
                        "Criteria, " +
                        "Rate," +
                        "Overtravel," +
                        "TemperatureSoak" +
                        ") VALUES ");

                    strCmd.Append("(");
                    strCmd.Append("1123");//预加载ID
                    strCmd.Append(", ");
                    strCmd.Append("456");//方法ID
                    strCmd.Append(", ");
                    strCmd.Append("\"");
                    strCmd.Append("力控");//控制模式                                    
                    strCmd.Append("\"");
                    strCmd.Append(", ");
                    strCmd.Append("1000");//控制速率
                    strCmd.Append(", ");
                    strCmd.Append("564");//标准
                    strCmd.Append(", ");
                    strCmd.Append("200");//速率
                    strCmd.Append(", ");
                    strCmd.Append("false");// 过载
                    strCmd.Append(", ");
                    strCmd.Append("false");//热浸
                    strCmd.Append(");");
                    string sqlStrCommande = strCmd.ToString();
                    DataTable dt = dbTable.ExecuteDataTable(sqlStrCommande);
                }

                //自动平衡
                {
                    strCmd.Clear();
                    strCmd.Append("INSERT INTO AutoBlanceTable (" +
                                            "AutoBlanceID, " +
                                            "MethodID," +
                                            "MeasurementType," +
                                            "Descript, " +
                                            "Unit " +
                                            ") VALUES ");

                    strCmd.Append("(");
                    strCmd.Append("1123");//自动平衡ID
                    strCmd.Append(", ");
                    strCmd.Append("456");//方法ID
                    strCmd.Append(", ");
                    strCmd.Append("\"");
                    strCmd.Append("力控");//测量类型                                  
                    strCmd.Append("\"");
                    strCmd.Append(", ");
                    strCmd.Append("\"");
                    strCmd.Append("哈哈");//描述                                 
                    strCmd.Append("\"");
                    strCmd.Append(", ");
                    strCmd.Append("\"");
                    strCmd.Append("mm");//单位                           
                    strCmd.Append("\"");
                    strCmd.Append(");");
                    string sqlStrCommande = strCmd.ToString();
                    DataTable dt = dbTable.ExecuteDataTable(sqlStrCommande);
                }

                //预循环
                {
                    strCmd.Clear();
                    strCmd.Append("INSERT INTO PreCyclingTable (" +
                                            "PreCyclingID, " +
                                            "MethodID," +
                                            "CircleControlCollection," +
                                            "ControlMode, " +
                                            "Rate, " +
                                            "MaxMeasurement, " +
                                            "Max, " +
                                            "MinMeasurement, " +
                                            "Min " +
                                            ") VALUES ");

                    strCmd.Append("(");
                    strCmd.Append("1123");//PreCyclingIDID
                    strCmd.Append(", ");
                    strCmd.Append("456");//方法ID
                    strCmd.Append(", ");
                    strCmd.Append("false");//CircleControlCollection                                
                    strCmd.Append(", ");
                    strCmd.Append("\"");
                    strCmd.Append("力控"); //ControlMode
                    strCmd.Append("\"");
                    strCmd.Append(", ");
                    strCmd.Append("100");//Rate
                    strCmd.Append(", ");
                    strCmd.Append("34");//MaxMeasurement
                    strCmd.Append(", ");
                    strCmd.Append("43");//Max
                    strCmd.Append(", ");
                    strCmd.Append("43");//MinMeasurement
                    strCmd.Append(", ");
                    strCmd.Append("23");//Min
                    strCmd.Append(");");
                    string sqlStrCommande = strCmd.ToString();
                    DataTable dt = dbTable.ExecuteDataTable(sqlStrCommande);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
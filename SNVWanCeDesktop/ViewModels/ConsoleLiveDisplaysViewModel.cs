using Prism.Commands;
using Prism.Events;
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
    public class ConsoleLiveDisplaysViewModel : BindableBase,IDialogAware
    {

        private ObservableCollection<GaugeItemInfo> availableParametersArr;
        private ObservableCollection<GaugeItemInfo> deterMiniedParametersArr;
        private readonly IEventAggregator eventAggregator;
        private readonly IDialogHostService dialogHost;
        public string displayDescript;
        public string displayUnit;
        public string displayDecimalplaces;
        public string displayMax;
        public string displayMin;
        public string displayMaxColumns;

        public string DisplayDescript { get => displayDescript; set { displayDescript = value; RaisePropertyChanged(); } }
        public string DisplayUnit { get => displayUnit; set { displayUnit = value; RaisePropertyChanged(); } }
        public string DisplayDecimalplaces { get => displayDecimalplaces; set { displayDecimalplaces = value; RaisePropertyChanged(); } }
        public string DisplayMax { get => displayMax; set { displayMax = value; RaisePropertyChanged(); } }
        public string DisplayMin { get => displayMin; set { displayMin = value; RaisePropertyChanged(); } }
        public string DisplayMaxColumns { get => displayMaxColumns; set { displayMaxColumns = value; RaisePropertyChanged(); } }

        public GaugeItemInfo DeterMiniedParametersItem { get; set; }
        public DelegateCommand LoadedCommand { get; set; }
        public DelegateCommand<GaugeItemInfo> MaxCheckCommand { get; set; }
        public DelegateCommand<GaugeItemInfo> RateCheckCommand { get; set; }
        public ConsoleLiveDisplaysViewModel(IEventAggregator aggregator, IDialogHostService dialogHost)
        {
            eventAggregator = aggregator;
            this.dialogHost = dialogHost;
            //订阅单个实时显示通道的更新
            aggregator.GetEvent<MessageEvent>().Subscribe(UpdateDate,ThreadOption.PublisherThread,false,filter=> filter.Filter == "RemoveGauge" || filter.Filter == "UpdateGauge");
            Init();
            RegisterMommand();
        }
        //单词错了Data
        private void UpdateDate(Message obj)
        {
            if(obj == null)
            {
                return;
            }
            try
            {
                if (obj.Filter == "RemoveGauge")
                {
                    var info = DeterMiniedParametersArr.FirstOrDefault(o =>o.Title==obj.Title);
                    if(info != null)
                    {
                        DeterMiniedParametersArr.Remove(info);
                    }
                }
                if(obj.Filter == "UpdateGuage")
                {
                    var info = DeterMiniedParametersArr.FirstOrDefault(o => o.CacheTitle == obj.Content);
                    if (info != null)
                    {
                        info.CacheTitle = null;//缓存的用户定义标题标题
                        info.Title = obj.Title;//设置可以再次缓存自定义标题
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void RegisterMommand()
        {
            MoveToRightCommand = new DelegateCommand<GaugeItemInfo>(MoveRight);
            MoveToLeftCommand = new DelegateCommand<GaugeItemInfo>(MoveLeft);
            SelectionChangedCommand = new DelegateCommand<GaugeItemInfo>(SelectionChanged);
            LoadedCommand = new DelegateCommand(Load);
            MaxCheckCommand = new DelegateCommand<GaugeItemInfo>(MaxCheck);
            RateCheckCommand = new DelegateCommand<GaugeItemInfo>(RateCheck);
        }
        //是否显示速率
        private void RateCheck(GaugeItemInfo obj)
        {
            if (obj != null)
            {
                if (obj.IsShowRate == true)
                {
                    obj.IsShowRate = false;
                }
                else
                {
                    obj.IsShowRate = true;
                }
            }
        }
        //是否显示最大值
        private void MaxCheck(GaugeItemInfo obj)
        {
            if(obj != null)
            {
                if (obj.IsShowMax == true)
                {
                    obj.IsShowMax = false;
                }
                else
                {
                    obj.IsShowMax = true;
                }
            }
        }

        private void Load()
        {
            try
            {
                AvailableParametersArr.Clear();
                GaugeItemInfo typeInfo;
                typeInfo = new GaugeItemInfo();
                typeInfo.Id = 0;
                typeInfo.DefaultTitleKey = "GroupNameOfGauge";
                typeInfo.IsParent = true;
                ObservableCollection<GaugeItemInfo> temps = new ObservableCollection<GaugeItemInfo>();
                temps.AddRange(Collections.GaugeItems);
                temps.Add(new GaugeItemInfo() {  DefaultTitleKey = "CycleCount", DecimalPlaces = 0, DisplayValue = "0",IsAbsoluteValue=true });
                temps.Add(new GaugeItemInfo() {  DefaultTitleKey = "PIPCount", DecimalPlaces = 0, DisplayValue = "0", IsAbsoluteValue = true });
                temps.Add(new GaugeItemInfo() {  DefaultTitleKey = "TotalCycleCount", DecimalPlaces = 0, DisplayValue = "0", IsAbsoluteValue = true });
                //temps = new ObservableCollection<GaugeItemInfo>(temps.OrderBy(info => info.InputTypeName));
                for (int i = 0; i < temps.Count; i++)
                {
                    GaugeItemInfo info = (GaugeItemInfo)temps[i].Clone();
                    info.Id = 0;
                    info.Index = i;
                    typeInfo.AvailableParametersItemsArr.Add(info);
                    //typeInfo.AvailableParametersItemsArr.Add(new GaugeItemInfo()
                    //{
                    //    Id = 0,
                    //    Index = i,
                    //    Description = temps[i].Description,
                    //    DefaultTitleKey = temps[i].DefaultTitleKey,
                    //    UserDefinedTitle = temps[i].UserDefinedTitle,
                    //    DisplayValue = temps[i].DisplayValue,
                    //    UnitSetName = temps[i].UnitSetName
                    //});//时间
                }
                AvailableParametersArr.Add(typeInfo);

                for (int j = 0; j < DeterMiniedParametersArr.Count; j++)
                {
                    //bool istrue=   AvailableParametersArr[0].AvailableParametersItemsArr.Remove(DeterMiniedParametersArr[j]);
                    var temp = AvailableParametersArr[0].AvailableParametersItemsArr.FirstOrDefault(info => 
                    (info.Id == DeterMiniedParametersArr[j].Id)&&(info.Index == DeterMiniedParametersArr[j].Index ) );
                    if (temp != null)
                    {
                        DeterMiniedParametersArr[j] = (GaugeItemInfo)temp.Clone();
                        AvailableParametersArr[0].AvailableParametersItemsArr.Remove(temp);
                    }
                }
                DeterMiniedParametersItem = DeterMiniedParametersArr[0];
            }
            catch (Exception ex)
            {

            }

        }

        private void SelectionChanged(GaugeItemInfo obj)
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
                MessageBox.Show(ex.Message);
            }
        }

        public DelegateCommand<GaugeItemInfo> MoveToRightCommand { get; private set; }
        public DelegateCommand<GaugeItemInfo> MoveToLeftCommand { get; private set; }
        public DelegateCommand<GaugeItemInfo> SelectionChangedCommand { get; private set; }
        //向右移动处理
        private void MoveLeft(GaugeItemInfo obj)
        {
            if (obj == null)
            {
                return;
            }
            try
            {
                int index = DeterMiniedParametersArr.IndexOf(obj);
                obj.UserDefinedTitle = obj.CacheTitle;//还原修改说明
                obj.IsShowMax = false;
                obj.IsShowRate = false;
                DeterMiniedParametersArr.Remove(obj);
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
                PlushToLiveDisplay();//将DeterMiniedParametersArr推送给实时显示区域
            }
            catch (System.NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MoveRight(GaugeItemInfo obj)
        {
            if (obj == null)
            {
                return;
            }
            if (DeterMiniedParametersArr.Count == 12)
            {
                dialogHost.Question("提示", "最多添加十二个！");
                return;
            }
            try
            {
                //是否是子节点
                if (!obj.IsParent)
                {
                    DeterMiniedParametersArr.Add(obj);
                    //Collections.LiveDisplayGaugeItemInfos = DeterMiniedParametersArr;
                    DeterMiniedParametersItem = DeterMiniedParametersArr[DeterMiniedParametersArr.Count - 1];
                    PlushToLiveDisplay();//将DeterMiniedParametersArr推送给实时显示区域
                    int count = obj.Id;
                    for (int i = 0; i < DeletedNodes.Count; i++)
                    {
                        if (DeletedNodes[i].Id < obj.Id)
                        {
                            count--;
                        }
                    }
                    AvailableParametersArr[count].AvailableParametersItemsArr.Remove(obj);
                    if (!AvailableParametersArr[count].HasChildren)//可用参数类型下没有子参数时
                    {
                        DeletedNodes.Add(AvailableParametersArr[count]);
                        AvailableParametersArr.RemoveAt(count);
                    }
                }

            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void PlushToLiveDisplay()
        {
            List<GaugeItemInfo> list = new List<GaugeItemInfo>();
            foreach (GaugeItemInfo item in DeterMiniedParametersArr)
            {
                list.Add(item);
            }
            eventAggregator.GetEvent<GaugeItemInfosEvent>().Publish(list);
        }
        ///// <summary>
        ///// 缓存删掉的父参数
        ///// </summary>
        private List<GaugeItemInfo> DeletedNodes = new List<GaugeItemInfo>();

        public event Action<IDialogResult> RequestClose;

        public ObservableCollection<GaugeItemInfo> AvailableParametersArr { get => availableParametersArr; set { availableParametersArr = value; RaisePropertyChanged(); } }
        public ObservableCollection<GaugeItemInfo> DeterMiniedParametersArr { get => deterMiniedParametersArr; set { deterMiniedParametersArr = value; RaisePropertyChanged(); } }

        public string Title { get; set; }

        public void Init()
        {
            AvailableParametersArr = new ObservableCollection<GaugeItemInfo>();
            DeterMiniedParametersArr = new ObservableCollection<GaugeItemInfo>();
            DeterMiniedParametersArr = Collections.LiveDisplayGaugeItemInfos;
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
            Title = "控制台编辑";
        }
    }
}

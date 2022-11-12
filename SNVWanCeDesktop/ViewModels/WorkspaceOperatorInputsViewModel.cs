using DryIoc;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
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

namespace WanCeDesktopApp.ViewModels
{
    public class WorkspaceOperatorInputsViewModel : BindableBase
    {
        private ObservableCollection<WorkspaceInputTypeInfo> availableParametersArr;
        private ObservableCollection<WorkspaceInputTypeInfo> deterMiniedParametersArr;
        private IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private Visibility parameterSelected;
        private string parameterName;
        private bool isUnTested = false;
        private bool isTesting = false;
        private bool isTested = false;
        private bool needupdate = false;
        public WorkspaceOperatorInputsViewModel(IRegionManager manager,IEventAggregator aggregator)
        {
            this.regionManager = manager;
            Init();
            RegisterMommand();
        }

        private void RegisterMommand()
        {
            MoveToRightCommand = new DelegateCommand<WorkspaceInputTypeInfo>(MoveRight);
            MoveToLeftCommand = new DelegateCommand<WorkspaceInputTypeInfo>(MoveLeft);
            MoveUpCommand = new DelegateCommand<WorkspaceInputTypeInfo>(MoveUp);
            MoveDownCommand = new DelegateCommand<WorkspaceInputTypeInfo>(MoveDown);
            SelectionChangedCommand = new DelegateCommand<WorkspaceInputTypeInfo>(SelectionChanged);
            CheckedChangedCommand = new DelegateCommand<WorkspaceInputTypeInfo>(CheckedChanged);
        }

        private void CheckedChanged(WorkspaceInputTypeInfo obj)
        {
            if (needupdate)
            {
                obj.IsUnTested = IsUnTested;
                obj.IsTesting = IsTesting;
                obj.IsTested = IsTested;
            }
        }

        private void SelectionChanged(WorkspaceInputTypeInfo obj)
        {
            if (obj == null)
            {
                return;
            }
            //NavigationParameters parameters = new NavigationParameters();
            needupdate = false;
            ParameterName = obj.InputTypeName;
            IsUnTested = obj.IsUnTested;
            IsTesting = obj.IsTesting;
            IsTested = obj.IsTested;
            needupdate = true;
        }

        public DelegateCommand<WorkspaceInputTypeInfo> MoveToRightCommand { get; private set; }
        public DelegateCommand<WorkspaceInputTypeInfo> MoveToLeftCommand { get; private set; }
        public DelegateCommand<WorkspaceInputTypeInfo> MoveUpCommand { get; private set; }
        public DelegateCommand<WorkspaceInputTypeInfo> MoveDownCommand { get; private set; }
        public DelegateCommand<WorkspaceInputTypeInfo> SelectionChangedCommand { get; private set; }
        public DelegateCommand<WorkspaceInputTypeInfo> CheckedChangedCommand { get; private set; }

        private void MoveDown(WorkspaceInputTypeInfo obj)
        {
            if (obj == null)
            {
                return;
            }
        }

        private void MoveUp(WorkspaceInputTypeInfo obj)
        {
            if (obj == null)
            {
                return;
            }
        }
        
        private void MoveLeft(WorkspaceInputTypeInfo obj)
        {
            //向MessageEvent发布一个hello
            //eventAggregator.GetEvent<MessageEvent>().Publish(new PersonInfo() { Name="Hello"});//事件聚合器 用来订阅事件
            //eventAggregator.GetEvent<MessageEvent>().Subscribe(GetMessage);
            if (obj == null)
            {
                return;
            }
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
            //AvailableParametersArr[obj.Id].VisibilityType=Visibility.Visible;
            //AvailableParametersArr[obj.Id].AvailableParametersItemsArr[obj.Index].VisibilityType = Visibility.Visible;//显示
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

        private void MoveRight(WorkspaceInputTypeInfo obj)
        {
            if (obj == null)
            {
                return;
            }
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
        ///// <summary>
        ///// 缓存删掉的父参数
        ///// </summary>
        private List<WorkspaceInputTypeInfo> DeletedNodes = new List<WorkspaceInputTypeInfo>();
        private ObservableCollection<WorkspaceInputTypeInfo> subAvailableParametersArr;

        public ObservableCollection<WorkspaceInputTypeInfo> AvailableParametersArr { get => availableParametersArr; set { availableParametersArr = value; RaisePropertyChanged(); } }
        public ObservableCollection<WorkspaceInputTypeInfo> SubAvailableParametersArr { get => subAvailableParametersArr; set { subAvailableParametersArr = value; RaisePropertyChanged(); } }
        public ObservableCollection<WorkspaceInputTypeInfo> DeterMiniedParametersArr { get => deterMiniedParametersArr; set { deterMiniedParametersArr = value; RaisePropertyChanged(); } }

        public bool IsUnTested { get => isUnTested; set { isUnTested = value; RaisePropertyChanged(); } }
        public bool IsTesting { get => isTesting; set { isTesting = value; RaisePropertyChanged(); } }
        public bool IsTested { get => isTested; set { isTested = value; RaisePropertyChanged(); } }

        public string ParameterName { get => parameterName; set => parameterName = value; }

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
                typeInfo.AvailableParametersItemsArr = new ObservableCollection<TreeviewItemInfo>() { new WorkspaceInputTypeInfo() { Id = i, Index = 0, InputTypeName = "TestInputParameter1" }, new WorkspaceInputTypeInfo() { Id = i, Index = 1, InputTypeName = "TestInputParameter2" } };
                //typeInfo.Children = new ObservableCollection<string>() { "parameter 1", "parameter 2" };
                AvailableParametersArr.Add(typeInfo);
            }
        }
        public void GetMessage(string obj)
        {
            MessageBox.Show($"获取到消息:{obj.ToString()}");
        }
    }
}

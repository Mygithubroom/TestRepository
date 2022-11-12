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
using WanCeDesktopApp.Common.Enum;

namespace WanCeDesktopApp.ViewModels
{
    public class ConsoleSoftKeysViewModel:BindableBase, IDialogAware
    {
        private ObservableCollection<SoftKeyInfo> availableParametersArr;
        private ObservableCollection<SoftKeyInfo> deterMiniedParametersArr;
        public Visibility EditPanelVisibility { get; set; }
        public int AvailableListIndex { get; set; }
        public int DeterMiniedListIndex { get; set; }

        public ConsoleSoftKeysViewModel(IEventAggregator eventAggregator)
        {
            Init();
            RegisterMommand();
            this.eventAggregator = eventAggregator;
        }
        private void RegisterMommand()
        {
            MoveToRightCommand = new DelegateCommand<SoftKeyInfo>(MoveRight);
            MoveToLeftCommand = new DelegateCommand<SoftKeyInfo>(MoveLeft);
            SelectionChangedCommand = new DelegateCommand<SoftKeyInfo>(SelectionChanged);
        }

        private void SelectionChanged(SoftKeyInfo obj)
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

        public DelegateCommand<SoftKeyInfo> MoveToRightCommand { get; private set; }
        public DelegateCommand<SoftKeyInfo> MoveToLeftCommand { get; private set; }
        public DelegateCommand<SoftKeyInfo> SelectionChangedCommand { get; private set; }

        private void MoveLeft(SoftKeyInfo obj)
        {
            if (obj == null)
            {
                return;
            }
            try
            {
                DeterMiniedParametersArr.Remove(obj);
                if (DeterMiniedParametersArr.Count > 0)
                {
                    EditPanelVisibility = Visibility.Visible;
                    DeterMiniedListIndex = DeterMiniedParametersArr.Count - 1;
                }
                else
                {
                    EditPanelVisibility = Visibility.Collapsed;
                }
                eventAggregator.GetEvent<MessageEvent>().Publish(new Message() {Content ="SoftKey",Filter= "MainView" });
                ////查找删除掉的父参数选项
                //for (int i = 0; i < DeletedNodes.Count; i++)
                //{
                //    if (DeletedNodes[i].Id == obj.Id)
                //    {
                //        if (AvailableParametersArr.Count >= obj.Id)
                //        {
                //            AvailableParametersArr.Insert(obj.Id, DeletedNodes[i]);//加回来
                //            DeletedNodes.RemoveAt(i);
                //        }
                //        else
                //        {
                //            AvailableParametersArr.Add(DeletedNodes[i]);
                //            DeletedNodes.RemoveAt(i);
                //        }
                //        break;
                //    }
                //}
                //int count = obj.Id;
                //for (int i = 0; i < DeletedNodes.Count; i++)
                //{
                //    if (DeletedNodes[i].Id < obj.Id)
                //    {
                //        count--;
                //    }
                //}
                //if (AvailableParametersArr[count].AvailableParametersItemsArr.Count >= obj.Index)
                //{
                //    AvailableParametersArr[count].AvailableParametersItemsArr.Insert(obj.Index, obj);
                //}
                //else
                //{
                //    AvailableParametersArr[count].AvailableParametersItemsArr.Add(obj);//原来的位置大于现有子参数个数
                //}
            }
            catch (System.NullReferenceException ex)
            {
            }
            catch (Exception ex)
            {
            }
        }

        private void MoveRight(SoftKeyInfo obj)
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
                    DeterMiniedListIndex = DeterMiniedParametersArr.Count - 1;
                    if (DeterMiniedParametersArr.Count > 0)
                    {
                        EditPanelVisibility = Visibility.Visible;
                    }
                    else
                    {
                        EditPanelVisibility = Visibility.Collapsed;
                    }
                    //推送更新，
                    eventAggregator.GetEvent<MessageEvent>().Publish(new Message() { Content = "SoftKey", Filter = "MainView" });
                    //int count = obj.Id;
                    //for (int i = 0; i < DeletedNodes.Count; i++)
                    //{
                    //    if (DeletedNodes[i].Id < obj.Id)
                    //    {
                    //        count--;
                    //    }
                    //}
                    ////DeterMiniedParametersArr.Add(new SoftKeyInfo() { Index = DeterMiniedParametersArr.Count, Id = obj.Id, Content = obj.InputTypeName, Description = obj.InputTypeName });
                    //AvailableParametersArr[count].AvailableParametersItemsArr.Remove(obj);
                    ////AvailableParametersArr[count].AvailableParametersItemsArr[obj.Index].VisibilityType =Visibility.Collapsed;//隐藏子参数
                    //if (!AvailableParametersArr[count].HasChildren)//可用参数类型下没有子参数时
                    //{
                    //    DeletedNodes.Add(AvailableParametersArr[count]);
                    //    //AvailableParametersArr[count].VisibilityType = Visibility.Collapsed;//隐藏父参数
                    //    AvailableParametersArr.RemoveAt(count);
                    //}
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
        private List<SoftKeyInfo> DeletedNodes = new List<SoftKeyInfo>();
        private readonly IEventAggregator eventAggregator;

        public event Action<IDialogResult> RequestClose;

        public ObservableCollection<SoftKeyInfo> AvailableParametersArr { get => availableParametersArr; set { availableParametersArr = value; RaisePropertyChanged(); } }
        public ObservableCollection<SoftKeyInfo> DeterMiniedParametersArr { get => deterMiniedParametersArr; set { deterMiniedParametersArr = value; RaisePropertyChanged(); } }

        public string Title { get; set; }

        public void Init()
        {
            AvailableParametersArr = new ObservableCollection<SoftKeyInfo>();
            DeterMiniedParametersArr = new ObservableCollection<SoftKeyInfo>();
            SoftKeyInfo typeInfo;
            for (int i = 0; i < 6; i++)
            {
                typeInfo = new SoftKeyInfo();
                typeInfo.Id = i;
                typeInfo.DefaultTitle = i switch
                {
                    0 => "BalanceAll",
                    1 => "ExcludeSpecimen",
                    2 => "RemoveExtensometer",
                    3 => "ZeroExtension",
                    4 => "PauseTest",
                    5 => "ReverseDirection",
                    6 => "EndHold",
                    _ => throw new NotImplementedException()
                };
                typeInfo.InputTypeName = i switch
                {
                    0 => "BalanceAll",
                    1 => "ExcludeSpecimen",
                    2 => "RemoveExtensometer",
                    3 => "ZeroExtension",
                    4 => "PauseTest",
                    5 => "ReverseDirection",
                    6 => "EndHold",
                    _ => throw new NotImplementedException()
                };
                typeInfo.SoftKeyType = i switch
                {
                    0 => "BalanceAll",
                    1 => "ExcludeSpecimen",
                    2 => "RemoveExtensometer",
                    3 => "ZeroExtension",
                    4 => "PauseTest",
                    5 => "ReverseDirection",
                    6 => "EndHold",
                    _ => throw new NotImplementedException()
                };
                // Pause test/Resume test
                typeInfo.IsParent = false;
                //typeInfo.AvailableParametersItemsArr = new ObservableCollection<TreeviewItemInfo>();
                //typeInfo.AvailableParametersItemsArr = new ObservableCollection<TreeviewItemInfo>() { new SoftKeyInfo() { Id = i, Index = 0, InputTypeName = "TestInputParameter1" }, new SoftKeyInfo() { Id = i, Index = 1, InputTypeName = "TestInputParameter2" } };
                //typeInfo.Children = new ObservableCollection<string>() { "parameter 1", "parameter 2" };
                AvailableParametersArr.Add(typeInfo);
                AvailableListIndex = 0;
                DeterMiniedParametersArr = Collections.SoftKeyItems;
                if (DeterMiniedParametersArr.Count > 0)
                {
                    EditPanelVisibility = Visibility.Visible;
                    DeterMiniedListIndex = 0;
                }
                else
                {
                    EditPanelVisibility = Visibility.Collapsed;
                }
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
    }
}

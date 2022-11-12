using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using WanCeDesktopApp.Common.DAO;
using Prism.Mvvm;

namespace WanCeDesktopApp.ViewModels
{
    public class WorkflowBeforTestViewModel:BindableBase
    {
        /// <summary>
        /// 缓存删掉的父参数
        /// </summary>
        private List<WorkspaceInputTypeInfo> DeletedNodes = new List<WorkspaceInputTypeInfo>();
        
        private ObservableCollection<WorkspaceInputTypeInfo> availableParametersArr;
        private ObservableCollection<WorkspaceInputTypeInfo> selectedParametersArr;

        public ObservableCollection<WorkspaceInputTypeInfo> AvailableParametersArr
        {
            get { return availableParametersArr; }
            set { availableParametersArr = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<WorkspaceInputTypeInfo> SelectedParametersArr
        {
            get { return selectedParametersArr; }
            set { selectedParametersArr = value; RaisePropertyChanged(); }
        }

        public DelegateCommand<WorkspaceInputTypeInfo> MoveToRightCommand { get; private set; }
        public DelegateCommand<WorkspaceInputTypeInfo> MoveToLeftCommand { get; private set; }
        public DelegateCommand<object> MoveToTopCommand { get; private set; }
        public DelegateCommand<object> MoveToBottomCommand { get; private set; }
        public DelegateCommand<WorkspaceInputTypeInfo> SelectionChangedCommand { get; private set; }
        public WorkflowBeforTestViewModel()
        {
            Init();
            RegisterMommand();
        }

        public void Init()
        {
            
            
            
            AvailableParametersArr = new ObservableCollection<WorkspaceInputTypeInfo>();
            SelectedParametersArr = new ObservableCollection<WorkspaceInputTypeInfo>();
            WorkspaceInputTypeInfo typeInfo;
            for (int i = 0; i < 5; i++)
            {
                typeInfo = new WorkspaceInputTypeInfo();
                typeInfo.Id = i;
                typeInfo.InputTypeName = "TestInputType" + i;
                typeInfo.IsParent = true;
                typeInfo.AvailableParametersItemsArr = new ObservableCollection<TreeviewItemInfo>()
                {
                    new WorkspaceInputTypeInfo()
                    {
                        Id = i, Index = 0, InputTypeName = "TestInputParameter1"
                    },
                    new WorkspaceInputTypeInfo()
                    {
                        Id = i, Index = 1, InputTypeName = "TestInputParameter2"
                    }
                };
                AvailableParametersArr.Add(typeInfo);
            }
        }

        private void RegisterMommand()
        {
            MoveToRightCommand = new DelegateCommand<WorkspaceInputTypeInfo>(MoveRight);
            MoveToLeftCommand = new DelegateCommand<WorkspaceInputTypeInfo>(MoveLeft);
            MoveToTopCommand = new DelegateCommand<object>(MoveTop);
            MoveToBottomCommand = new DelegateCommand<object>(Bottom);
            SelectionChangedCommand = new DelegateCommand<WorkspaceInputTypeInfo>(SelectionChanged);
        }

        private void Bottom(object oIndex)
        {
            int iIndex = -1;
            if (!int.TryParse(oIndex.ToString(), out iIndex))
            {
                return;
            }
            if (iIndex < 0)
            {
                return;
            }
            if (selectedParametersArr.Count == (iIndex + 1))
            {
                return;
            }
            ObservableCollection<WorkspaceInputTypeInfo> infos = SelectedParametersArr;
            WorkspaceInputTypeInfo info1 = infos[iIndex];
            infos[iIndex] = infos[iIndex + 1];
            infos[iIndex + 1] = info1;
            SelectedParametersArr = infos;
        }

        private void MoveTop(object oIndex)
        {
            int iIndex = -1;
            if (!int.TryParse(oIndex.ToString(), out iIndex))
            {
                return;
            }
            if (iIndex <= 0)
            {
                return;
            }
            ObservableCollection<WorkspaceInputTypeInfo> infos = SelectedParametersArr;
            WorkspaceInputTypeInfo info1 = infos[iIndex];
            infos[iIndex] = infos[iIndex - 1];
            infos[iIndex - 1] = info1;
            SelectedParametersArr = infos;
        }

        private void MoveLeft(WorkspaceInputTypeInfo obj)
        {
            if (obj == null)
            {
                return;
            }
            try
            {
                SelectedParametersArr.Remove(obj);
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
                    //原来的位置大于现有子参数个数
                    AvailableParametersArr[count].AvailableParametersItemsArr.Add(obj);
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
                    SelectedParametersArr.Add(obj);
                    int count = obj.Id;
                    for (int i = 0; i < DeletedNodes.Count; i++)
                    {
                        if (DeletedNodes[i].Id < obj.Id)
                        {
                            count--;
                        }
                    }
                    AvailableParametersArr[count].AvailableParametersItemsArr.Remove(obj);
                    //可用参数类型下没有子参数时
                    if (!AvailableParametersArr[count].HasChildren)
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
                
            }

        }

        private void SelectionChanged(WorkspaceInputTypeInfo obj)
        {
            if (obj == null)
            {
                return;
            }
            try
            {

            }
            catch (System.NullReferenceException ex)
            {
                
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}

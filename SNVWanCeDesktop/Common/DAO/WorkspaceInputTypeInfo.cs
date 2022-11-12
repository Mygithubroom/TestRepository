using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WanCeDesktopApp.Common.DAO
{
    public class WorkspaceInputTypeInfo : TreeviewItemInfo
    {
        //private bool isParent = false;
        //private int index;//子参数索引
        //private ObservableCollection<WorkspaceInputTypeInfo> availableParametersItemsArr;
        //private bool hasChildren = false;
        //三种状态
        private bool isUnTested =false;
        private bool isTesting =false;
        private bool isTested =false;
        /// <summary>
        /// 参数类型名
        /// </summary>
        //public string InputTypeName { get => Content; set { Content = value; RaisePropertyChanged(); } }
        /// <summary>
        /// 类型子参数集合
        /// </summary>
        //public ObservableCollection<WorkspaceInputTypeInfo> AvailableParametersItemsArr { get => availableParametersItemsArr; set { availableParametersItemsArr = value; RaisePropertyChanged(); } }

        //public bool IsParent { get => isParent; set { isParent = value; RaisePropertyChanged(); } }
        //public int Index { get => index; set { index = value; RaisePropertyChanged(); } }

        //public bool HasChildren { 
        //    get { 
        //        return AvailableParametersItemsArr.Count>0;
        //    } 
        //}

        public bool IsUnTested { get => isUnTested; set { isUnTested = value; RaisePropertyChanged(); } }
        public bool IsTesting { get => isTesting; set { isTesting = value; RaisePropertyChanged(); } }
        public bool IsTested { get => isTested; set { isTested = value; RaisePropertyChanged(); } }
    }
}

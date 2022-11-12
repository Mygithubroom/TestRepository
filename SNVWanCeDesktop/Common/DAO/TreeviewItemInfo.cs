using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLocalizeExtension.Engine;

namespace WanCeDesktopApp.Common.DAO
{
    public class TreeviewItemInfo:BaseInfo, ICloneable
    {
        private bool isParent = false;
        private int index=-1;//子参数索引
        private bool hasChildren = false;
        private ObservableCollection<TreeviewItemInfo> availableParametersItemsArr;

        public TreeviewItemInfo()
        {
            AvailableParametersItemsArr = new ObservableCollection<TreeviewItemInfo>();
            DefaultTitleKey = "";
            LocalizeDictionary.Instance.PropertyChanged += (sender, args) =>
            {
                if (
                    args.PropertyName
                    == nameof(LocalizeDictionary.Instance.Culture)
                )
                {
                    RaisePropertyChanged(nameof(Title));
                }
            };
        }
        /// <summary>
        /// 用于绑定界面勾选
        /// </summary>
        public bool IsChecked { get; set; } = true;
        public bool IsParent { get => isParent; set { isParent = value; RaisePropertyChanged(); } }
        public int Index { get => index; set { index = value; RaisePropertyChanged(); } }
        /// <summary>
        /// 参数类型名
        /// </summary>
        public string InputTypeName { get => DefaultTitleKey; set { DefaultTitleKey = value; RaisePropertyChanged(); } }
        public ObservableCollection<TreeviewItemInfo> AvailableParametersItemsArr { get => availableParametersItemsArr; set { availableParametersItemsArr = value; RaisePropertyChanged(); } }
        public bool HasChildren
        {
            get
            {
                return AvailableParametersItemsArr.Count > 0;
            }
        }
        /// <summary>
        /// 自定义标题
        /// </summary>
        public string userDefinedTitle;
        public string? UserDefinedTitle
        {
            get { return userDefinedTitle; }
            set
            {
                userDefinedTitle = value;
                { if (string.IsNullOrEmpty(CacheTitle)) { CacheTitle = value; } }
            }
        }
        /// <summary>
        /// 缓存的修改的标题
        /// </summary>
        public string CacheTitle { get; set; }
        public string DefaultTitleKey { get; set; }
        /// <summary>
        /// 默认标题
        /// </summary>
        public string DefaultTitle =>
            CacheTitle ?? LocalizationProviderWrapper.GetLocalizedStr(DefaultTitleKey);
        /// <summary>
        /// 展示标题
        /// </summary>
        public string Title { get { return UserDefinedTitle ?? DefaultTitle; } set { UserDefinedTitle = value; RaisePropertyChanged(); } }
        /// <summary>
        /// 扩展字段
        /// </summary>
        public object Tag { get; set; }
        /// <summary>
        /// 用于区分唯一对象，一般使用时间戳赋值
        /// </summary>
        public string HashCodeCache { get; set; }

        public override string ToString()
        {
            return Title.ToString();
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

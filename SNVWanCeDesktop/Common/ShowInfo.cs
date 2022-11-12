using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

///ui 数据字典类
namespace WanCeDesktopApp.Common
{
    public class ShowInfo : BindableBase
    {
        private int id ;
        private UInt32 status ;

        private string icon = "";
        private string title = "";
        private string color = "";
        private string content = "";
        private string label= "";
        private string description="";
        private Visibility isVisibility = Visibility.Collapsed;

        private string nameSpace = "";
        private Double length = 0;

        private DateTime createDate;
        private DateTime upDateDate;

        private bool isChecked;
        /// <summary>
        /// 是否显示
        /// </summary>
        public Visibility IsVisibility
        {
            get => isVisibility;
            set { isVisibility = value; RaisePropertyChanged(); }
        }
        public bool IsChecked
        {
            get => isChecked;
            set { isChecked = value; RaisePropertyChanged(); }
        }
        public Double Length
        {
            get { return length; }
            set { length = value; }
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Label
        {
            get { return label; }
            set { label = value; RaisePropertyChanged(); }
        }
        public string Description
        {
            get { return description; }
            set { description = value; RaisePropertyChanged(); }
        }

        public DateTime GetCreateDate()
        { return createDate; }
        public void SetCreateDate(DateTime value)
        { upDateDate = value; }
        public DateTime GetUpDateDate()
        { return createDate; }
        public void SetUpDateDate(DateTime value)
        { upDateDate = value; }

        public DateTime UpDateDate
        {
            get { return upDateDate; }
            set { upDateDate = value; }
        }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public UInt32 Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// 内容描述
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 菜单命名空间
        /// </summary>
        public string NameSpace
        {
            get { return nameSpace; }
            set { nameSpace = value; }
        }
    }
}

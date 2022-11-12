using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using WanCeDesktopApp.Common.DAO;
using WPFLocalizeExtension.Engine;

namespace WanCeDesktopApp.Common
{
    public class SoftKeyInfo : TreeviewItemInfo
    {
        public string Title { get { return UserDefinedTitle ?? DefaultTitle; } set { UserDefinedTitle = value; RaisePropertyChanged(); } }
        public string DefaultTitle { get { return LocalizationProviderWrapper.GetLocalizedStr(definedTitle); } set { definedTitle = value; } }
        private string definedTitle;
        public string UserDefinedTitle { get; set; }
        /// <summary>
        /// 功能键类型，用于区分执行方法
        /// </summary>
        public string SoftKeyType = "";

        public SoftKeyInfo()
        {
            LocalizeDictionary.Instance.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(LocalizeDictionary.Instance.Culture))
                {
                    RaisePropertyChanged(nameof(Title));
                }
            };
        }

        /// <summary>
        /// 传感器
        /// </summary>
        public string Sensor { get; set; }

    }
    /// <summary>
    /// 功能键接口
    /// </summary>
    public interface ISoftKey
    {
        /// <summary>
        /// 具体功能实现
        /// </summary>
        void ToDo();
        //应该再写个带传参数的方法
    }
    /// <summary>
    /// 功能类型特性
    /// </summary>
    public class SoftKeyAttribute : Attribute
    {
        public SoftKeyAttribute(string type)
        {
            Type = type;
        }
        public string Type { get; }

    }
    //功能键工厂，实例化功能键对象
    public class SoftKeyFactory
    {
        public Dictionary<string, ISoftKey> softKeys = new Dictionary<string, ISoftKey>();
        public SoftKeyFactory()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (var item in assembly.GetTypes())
            {
                if (typeof(ISoftKey).IsAssignableFrom(item) && !item.IsInterface)
                {
                    SoftKeyAttribute attribute = item.GetCustomAttribute<SoftKeyAttribute>();
                    if (attribute.Type != null)
                    {
                        softKeys[attribute.Type] = Activator.CreateInstance(item) as ISoftKey;//实例化一个ISoftKey
                    }
                }
            }
        }
        //获取带对应的功能键对象
        public ISoftKey GetSoftKey(string type)
        {
            if (softKeys.ContainsKey(type))
            {
                return softKeys[type];
            }
            return null;
        }
    }
    [SoftKeyAttribute("BalanceAll")]
    public class BalanceAllKey : ISoftKey
    {
        public void ToDo()
        {
            //具体实现
            MessageBox.Show("执行全部调零");
        }
    }
    [SoftKeyAttribute("StopTest")]
    public class StopTestKey : ISoftKey
    {
        public void ToDo()
        {
            MessageBox.Show("执行暂停试验");
        }
    }
    [SoftKeyAttribute("RemoveExtensometer")]
    public class RemoveExtensometerKey : ISoftKey
    {
        public void ToDo()
        {
            MessageBox.Show("执行移除引伸计");
        }
    }
    [SoftKeyAttribute("ExcludeSpecimen")]
    public class ExcludeSpecimenKey : ISoftKey
    {
        public void ToDo()
        {
            MessageBox.Show("执行去除试样");
        }
    }
    [SoftKeyAttribute("ZeroExtension")]
    public class ZeroExtensionKey : ISoftKey
    {
        public void ToDo()
        {
            MessageBox.Show("执行零位移");
        }
    }
    [SoftKeyAttribute("PauseTest")]
    public class PauseTestKey : ISoftKey
    {
        public void ToDo()
        {
            MessageBox.Show("执行暂停测试");
        }
    }
    [SoftKeyAttribute("ReverseDirection")]
    public class ReverseDirection : ISoftKey
    {
        public void ToDo()
        {
            MessageBox.Show("执行反向");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.Common.DAO
{
    public class ChoiceInputInfo : InputInfo
    {
        /// <summary>
        /// 选择项链接的集合，和对应的默认值，<Key Obj,Value defaultValue>;实验选择带出并给对应集合值 赋值
        /// </summary>
        public ObservableCollection<object> Choices{get;set;}
    }
}

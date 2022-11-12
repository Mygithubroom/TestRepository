using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLocalizeExtension.Engine;

namespace WanCeDesktopApp.Common.DAO
{
    /// <summary>
    /// 输入对象
    /// </summary>
    public class InputInfo : TreeviewItemInfo
    {

        #region 判断可更改的阶段
        public bool IsUntestedReadOnly { get; set; } = false;//未测试
        public bool isTestingReadOnly { get; set; } = false;//测试中
        public bool isTestedReadOnly { get; set; } = false; //测试后
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.Common.Enum
{
    public enum SoftKeyEnum
    {
        //全部调零
        BalanceAll,
        //去除试样
        ExcludeSpecimen,
        //移除引伸计
        RemoveExtensometer,
        //零位移
        ZeroExtension,
        //暂停测试
        PauseTest,
        //恢复测试
        ResumeTest,
        //反向
        ReverseDirection,
        //结束保持
        EndHold,
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.Extensions
{
    /// <summary>
    /// 硬件配置结构
    /// </summary>
   public struct HardwareAnnex {
        public string Name; //附件名称
        public string CommonModele;//通信模块
        public UInt32 BaudRate;//波特率
        public string SerialPort;//串行端口
        public string Description;//描述
    }
    /// <summary>
    /// 传感器数据结构
    /// </summary>
    public struct Sensors {
        public string Name; //名称
        public UInt16 ChannelNO;//通道号
        public UInt32 CollectionRate;//采集速率
        public UInt32 MaxLoad;//最大载荷
        public UInt32 Sensitivity; //灵敏度
        public string Description;//描述
    }

    internal class DataStruct
    {
    }
}

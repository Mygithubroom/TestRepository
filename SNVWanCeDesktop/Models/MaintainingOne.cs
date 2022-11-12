using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp
{
    public class MaintainingOne
    {
        /// <summary>
        /// 日期（后期疑似索引）
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 开机总时长
        /// </summary>
        public string TotalStartupTime { get; set; }

        /// <summary>
        /// 作业总时长
        /// </summary>
        public string TotalOperationTime { get; set; }

        /// <summary>
        /// 试验总计次数
        /// </summary>
        public string TotalNumberOfTests { get; set; }

        /// <summary>
        /// 试验类型
        /// </summary>
        public string TypeOfTest { get; set; }

        /// <summary>
        /// 试验材料
        /// </summary>
        public string TestMaterial { get; set; }

    }
}

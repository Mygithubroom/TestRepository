using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.Models
{
        public struct SAuthority
        {
            public string unit ;
            public string setting ;
            public string calibration ;
            public string verification ;
            public string lineCorrection ;
            public string keyboardSpeed ;
            public string gBiso ;
            public string dataRounding ;
            public string accountManagement ;
            public string previewReport ;
            public string testMethod ;
            public string editReportTemplate ;
            public string dataManagerment ;
            public string curveAnalysis ;
            public string printReport ;
            public string languageManagement ;
        }
    public class UserInfo
    {

        public string Level { get; set; }
        /// <summary>
        /// 用户ID用于索引
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 方法ID
        /// </summary>
        public string MethodID { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 权限ID
        /// </summary>
        public string PermissionID { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
        public DateTime RegDate { get; set; }
        /// <summary>
        /// 登陆时间
        /// </summary>
        public DateTime LoginDateTime { get; set; }

        public SAuthority UserAutonority = new SAuthority();
    }
}

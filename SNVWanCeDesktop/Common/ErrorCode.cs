using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.Common
{
    class ErrorCode
    {
        public enum Option : uint
        {
            ObjectIsNull=1,
            ParamIsNullOrTypeError = 2,           
        }
    }
}

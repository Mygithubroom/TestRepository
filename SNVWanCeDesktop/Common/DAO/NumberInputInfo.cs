using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common.DAO;
using WPFLocalizeExtension.Engine;

namespace WanCeDesktopApp.Common
{
    /// <summary>
    /// 常规数值对象
    /// </summary>
    public class NumberInputInfo : InputInfo
    {
        private string unit;

        /// <summary>
        /// The number of decimal places
        /// </summary>
        public int DecimalPlaces { get; set; }
        /// <summary>
        /// The number of value
        /// </summary>
        public string Value { get;set; }
        /// <summary>
        /// Value corresponding to default unit
        /// </summary>
        public string DefaultUnitValue { get; set; }
        public string Unit { get => unit; set { unit = value; RaisePropertyChanged(); } }
        public string UnitSetName { get; set; }
        public decimal MaxValue { get; set; }
        public decimal MinValue { get; set; }
        public decimal DefaultValue { get; set; }
        public string Expression { get; set; }
        //上下限 ，表达式
       
    }
}

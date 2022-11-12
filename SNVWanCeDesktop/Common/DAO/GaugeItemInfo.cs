using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using WPFLocalizeExtension.Engine;

namespace WanCeDesktopApp.Common.DAO
{
    /// <summary>
    /// Measurement parameter information
    /// </summary>
    public class GaugeItemInfo : InputInfo
    {
        private string unit;

        private int decimalPlaces;
        /// <summary>
        /// 类型
        /// </summary>
        public string GaugeType { get; set; } = "";
        /// <summary>
        /// 是否设置预实验限位
        /// </summary>
        public bool IsPreTestLimit { get; set; }
        public double PreMaximum { get; set; }
        public double PreMinimum { get; set; }
        /// <summary>
        /// 量程
        /// </summary>
        public string TotalMaximum { get; set; } = "";
        /// <summary>
        /// 是否启用速率测量 
        /// </summary>
        public bool IsRate { get; set; }
        private string userDefinedRateExplain = null;

        public string RateExplain
        {
            get { return userDefinedRateExplain ?? DefaultTitle + LocalizationProviderWrapper.GetLocalizedStr("Rate"); }
            set { userDefinedRateExplain = value; RaisePropertyChanged(); }
        }
        public int DataPointCount { get; set; } = 10;
        /// <summary>
        /// 计算出来的速率
        /// </summary>
        public double RateValue { get; set; }
        /// <summary>
        /// 是否使用线性回归
        /// </summary>
        public bool IsUsingLinearRegression { get; set; }
        /// <summary>
        /// 是否启用真应变控制（只用于测试控制）
        /// </summary>
        public bool IsTrueStrainControl { get; set; }
        /// <summary>
        /// 传感器
        /// </summary>
        public string Sensor { get; set; } = "";
        /// <summary>
        /// 接头
        /// </summary>
        public string Joint { get; set; } = "";
        #region 2022/11/12胡建国修改
        /// <summary>
        /// 表达式
        /// </summary>
        public ArrayList Expression
        {
            get
            {
                //if (isFirstLoad && expression.Count > 0)
                //{
                //    Tools.UpDateArrayList(expression);//应该优化到方法加载一次后就不用去调用了
                //    isFirstLoad = false;
                //}
                return expression;
            }
            set { expression = value; }
        }
        [XmlIgnore]
        private bool isFirstLoad = true;
        private ArrayList expression = new ArrayList();
        /// <summary>
        /// 用于展示的表达式
        /// </summary>
        public string DispalyExpression { get; set; }
        /// <summary>
        /// 表达式中参数所属的集合类型
        /// </summary>
        public string CacheType { get; set; } 
        #endregion
        /// <summary>
        /// The number of decimal places
        /// </summary>
        public int DecimalPlaces { get; set; } = 5;
        private string displayValue = "0";
        /// <summary>
        /// 展示值，可以是符号，也可以是数值， 获取通道值的时候给Value属性赋值即可
        /// </summary>
        public string DisplayValue
        {
            get
            {
                if (Value == 0)
                {
                    double result;
                    if (double.TryParse(displayValue, out result))
                    {
                        return string.Format("{0:f" + DecimalPlaces + "}", result);
                    }
                    return displayValue;
                }
                else
                {
                    return string.Format("{0:f" + DecimalPlaces + "}", Value);
                }
            }
            set { displayValue = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 通道值
        /// </summary>
        public double ChannelValue { get; set; }
        /// <summary>
        /// 通道单位
        /// </summary>
        public string ChannelUnit { get; set; } = "";
        //private double ThoroughfareValue;
        #region 2022/11/12胡建国修改
        /// <summary>
        /// 通道值转换单位后的值。   注意！一定要设通道值的单位
        /// </summary>
        public double Value
        {
            get
            {
                if (string.IsNullOrEmpty(DispalyExpression))
                {
                    return UnitsProvider.UnitTools.UnitConvert(UnitSetName, ChannelUnit, Unit, ChannelValue);
                }
                else
                {
                    double num;
                    Tools.TryCalculated(DispalyExpression, CacheType, out num);
                    return num;
                }
            }
            set { ChannelValue = value; if (value > Max) { Max = value; } RaisePropertyChanged(); }
        }
        #endregion
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get => unit; set { unit = value; RaisePropertyChanged(); } }
        /// <summary>
        /// 单位源的KEY值 ，一定是Key值！
        /// </summary>
        public string UnitSetName { get; set; } = "";
        //已有值中的最大值
        public double Max { get; set; }
        private bool isShowMax;
        /// <summary>
        /// 是否显示最大值
        /// </summary>
        public bool IsShowMax
        {
            get { return isShowMax; }
            set
            {
                isShowMax = value; if (isShowMax)
                {
                    MaxVisibility = Visibility.Visible;
                }
                else
                {
                    MaxVisibility = Visibility.Collapsed;
                }
                RaisePropertyChanged();
            }
        }
        public Visibility MaxVisibility { get; set; } = Visibility.Collapsed;
        private bool isShowRate;
        /// <summary>
        /// 是否显示速率
        /// </summary>
        public bool IsShowRate
        {
            get { return isShowRate; }
            set
            {
                isShowRate = value; if (isShowRate)
                {
                    RateVisibility = Visibility.Visible;
                }
                else
                {
                    RateVisibility = Visibility.Collapsed;
                }
                RaisePropertyChanged();
            }
        }
        public Visibility RateVisibility
        {
            get; set;
        } = Visibility.Collapsed;
        /// <summary>
        /// 清零按钮显示控制
        /// </summary>
        public Visibility ClearBtnVisibility { get; set; } = Visibility.Visible;
        //展示背景
        public string ItemBackground { get { return UserDefinedBackground ?? ThemeBackground; } }
        //展示前景
        public string ItemForeground { get { return UserDefinedForeground ?? ThemeForeground; } }
        //主题背景和字体
        public string ThemeBackground { get; set; } = "White";
        public string ThemeForeground { get; set; } = "Black";
        //高亮背景
        public string UserDefinedBackground { get; set; } = "Red";
        //高亮前景
        public string UserDefinedForeground { get; set; } = "White";
        private bool isAbsoluteValue;

        //是否是绝对值
        public bool IsAbsoluteValue
        {
            get { return isAbsoluteValue; }
            set
            {
                isAbsoluteValue = value; if (!isAbsoluteValue)
                {
                    ClearBtnVisibility = Visibility.Visible;
                }
                else
                {
                    ClearBtnVisibility = Visibility.Collapsed;
                }
                RaisePropertyChanged();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WPFLocalizeExtension.Engine;

namespace WanCeDesktopApp.Common
{
    /// <summary>
    /// 将输入的本地化字串索引与 <see cref="CultureInfo"/> 转化为对应的本地化字串。
    /// </summary>
    public class LocalizationMultiConverter
        : DependencyObject,
            IMultiValueConverter
    {
        public object Convert(
            object[] values,
            Type targetType,
            object parameter,
            CultureInfo culture
        )
        {
            if (values.Length == 2)
            {
                string key = values[0].ToString();
                var cultureInfo = (CultureInfo)(values[1] ?? culture);
                string result = (string)
                    LocalizeDictionary.Instance.GetLocalizedObject(
                        key,
                        this,
                        cultureInfo
                    );
                return string.IsNullOrEmpty(result) ? $"key:{key}" : result;
            }

            return string.Empty;
        }

        /// <summary>
        /// 本地化字串更新无需逆向转换，此方法不应被调用。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetTypes"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object[] ConvertBack(
            object value,
            Type[] targetTypes,
            object parameter,
            CultureInfo culture
        )
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WanCeDesktopApp.Common
{
    internal class StringSepcialFormatConverter :  IMultiValueConverter
    {
        /// <summary>
        /// Special Formatting string ,e.g. Force[N]
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 0)
            {
                return string.Empty;
            }
            if(values.Length == 1 || string.IsNullOrEmpty(values[1]?.ToString()))
            {
                return values[0];
            }
            return values[0] + "(" + values[1] + ")";
        }

        public object[]? ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

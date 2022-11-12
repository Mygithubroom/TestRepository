using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WanCeDesktopApp.Common
{
    public class SpecialChartValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return ValidationResult.ValidResult;
            }
            Regex reg = new Regex(@"[/\\|*?;<>]");
            return reg.IsMatch(value?.ToString()) ? new ValidationResult(false, "Do not use these invalid characters \\ /;?\" <>| ") : ValidationResult.ValidResult;
        }
    }
}

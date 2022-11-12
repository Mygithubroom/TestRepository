using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLocalizeExtension.Engine;

namespace WanCeDesktopApp.Common
{
    internal static class LocalizationProviderWrapper
    {
        private const string ASSEMBLY_NAME = "WanCeDesktopApp";
        private const string DICTIONARY_NAME = "lang";

        /// <summary>
        /// 根据输入的 Key 与当前设定的 <see cref="System.Globalization.CultureInfo">CultureInfo</see> 和字典，获取本地化字串。
        /// </summary>
        /// <param name="key">本地化字串对应的 Key</param>
        /// <returns>本地化字串。若未找到对应的本地化字串，则返回 Key（例如，“Key:AAA”）。</returns>
        public static string GetLocalizedStr(string key)
        {
            string? result;
            result = (string)
                LocalizeDictionary.Instance.GetLocalizedObject(
                    ASSEMBLY_NAME,
                    DICTIONARY_NAME,
                    key,
                    LocalizeDictionary.Instance.Culture
                );
            return string.IsNullOrEmpty(result) ? $"key:{key}" : result;
        }
    }
}

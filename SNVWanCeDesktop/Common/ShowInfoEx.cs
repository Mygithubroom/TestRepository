using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLocalizeExtension.Engine;

namespace WanCeDesktopApp.Common
{
    public class ShowInfoEx : ShowInfo
    {
        public string? UserDefinedTitle { get; set; }
        public string DefaultTitleKey { get; set; }
        public string DefaultTitle =>
            LocalizationProviderWrapper.GetLocalizedStr(DefaultTitleKey);

        public new string Title => UserDefinedTitle ?? DefaultTitle;

        public ShowInfoEx() : base()
        {
            DefaultTitleKey = "";
            LocalizeDictionary.Instance.PropertyChanged += (sender, args) =>
            {
                if (
                    args.PropertyName
                    == nameof(LocalizeDictionary.Instance.Culture)
                )
                {
                    RaisePropertyChanged(nameof(Title));
                }
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLocalizeExtension.Engine;

namespace WanCeDesktopApp.Common.DAO
{
    public class SpecimenGeometryInfo : BaseInfo
    {
        public string? UserDefinedTitle { get; set; }
        public string DefaultTitleKey { get; set; }
        public string DefaultTitle =>
            LocalizationProviderWrapper.GetLocalizedStr(DefaultTitleKey);
        public string Title => UserDefinedTitle ?? DefaultTitle;

        public int SelectedGeometryIndex { get; set; }

        public SpecimenGeometryInfo() : base()
        {
            DefaultTitleKey = string.Empty;
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

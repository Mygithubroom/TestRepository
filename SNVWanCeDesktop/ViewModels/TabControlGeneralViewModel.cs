
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Common.Enum;
using WPFLocalizeExtension.Engine;

namespace WanCeDesktopApp.ViewModels
{
    public class TabControlGeneralViewModel : BindableBase
    {
        private IEventAggregator aggregator;
        public ObservableCollection<DictionaryExt> UnitSystemItems { get; set; }
        public ObservableCollection<DictionaryExt> SpecimenParameterSourceItems { get; set; }
        public DelegateCommand<DictionaryExt> SelectChangedCommand { get; set; }
        public TabControlGeneralViewModel(IEventAggregator eventAggregator)
        {
            aggregator = eventAggregator;
            UnitsProvider.UnitTools.GetUnitSystem();
            UnitSystemItems = new ObservableCollection<DictionaryExt>();
            UnitSystemItems.AddRange(Tools.EnumTypeToList(typeof(UnitSystemEnum)));
            SpecimenParameterSourceItems = new ObservableCollection<DictionaryExt>();
            SpecimenParameterSourceItems.AddRange(Tools.EnumTypeToList(typeof(SpecimenParameterSourceEnum)));
            LocalizeDictionary.Instance.PropertyChanged += (sender, args) =>
            {
                if (
                    args.PropertyName
                    == nameof(LocalizeDictionary.Instance.Culture)
                )
                {
                    UnitSystemItems.Clear();
                    UnitSystemItems.AddRange(Tools.EnumTypeToList(typeof(UnitSystemEnum)));
                    SpecimenParameterSourceItems.Clear();
                    SpecimenParameterSourceItems.AddRange(Tools.EnumTypeToList(typeof(SpecimenParameterSourceEnum)));
                }
            };
            SelectChangedCommand = new DelegateCommand<DictionaryExt>(SelectChanged);
        }

        private void SelectChanged(DictionaryExt obj)
        {
            if (obj == null)
            {
                return;
            }
            UnitSystemProvider.SelectUnitSystem = Enum.Parse<UnitSystemEnum>(obj.Key.ToString());
            Collections.InitLiveDisplayGaugeItemInfos();
            //aggregator.GetEvent<GaugeItemInfosEvent>().Publish(new List<Common.DAO.GaugeItemInfo>());

        }
    }
}

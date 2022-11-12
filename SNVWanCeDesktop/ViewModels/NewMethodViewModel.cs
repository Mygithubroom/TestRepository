using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WanCeDesktopApp.Common;
using Prism.Commands;
using Prism.Regions;
using WanCeDesktopApp.Extensions;
using Prism.Events;
using WanCeDesktopApp.Common.Enum;
using WPFLocalizeExtension.Engine;

namespace WanCeDesktopApp.ViewModels
{
    public class NewMethodViewModel : BindableBase
    {
        IEventAggregator aggregator;
        private readonly IRegionManager regionManager;
        public ObservableCollection<DictionaryExt> ApplicatonTypeItems { get; set; }
        public NewMethodViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            templatesBars = new ObservableCollection<ShowInfo>();
            adhesiveMethodsBars = new ObservableCollection<ShowInfo>();
            NavigateCommandIndexView = new DelegateCommand<string>(NavigateIndex);
            this.regionManager = regionManager;
            this.aggregator = eventAggregator;
            CreateTemplatesBars();
            CreateAdhesivesBars();
            Init();
        }

        private void Init()
        {
            ApplicatonTypeItems = new ObservableCollection<DictionaryExt>();
            ApplicatonTypeItems.AddRange(Tools.EnumTypeToList(typeof(ApplicationTypeEnum)));
            LocalizeDictionary.Instance.PropertyChanged += Instance_PropertyChanged;
        }
        private void Instance_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LocalizeDictionary.Instance.Culture))
            {
                ApplicatonTypeItems.Clear();
                ApplicatonTypeItems.AddRange(Tools.EnumTypeToList(typeof(ApplicationTypeEnum)));
            }
        }
        #region 属性
        public DelegateCommand<string> NavigateCommandIndexView { get; private set; }
        //标题列表
        private ObservableCollection<ShowInfo> templatesBars;
        public ObservableCollection<ShowInfo> TemplatesBars
        {
            get { return templatesBars; }
            set { templatesBars = value; RaisePropertyChanged(); }
        }
        //标题列表
        private ObservableCollection<ShowInfo> adhesiveMethodsBars;
        public ObservableCollection<ShowInfo> AdhesiveMethodsBars
        {
            get { return adhesiveMethodsBars; }
            set { adhesiveMethodsBars = value; RaisePropertyChanged(); }
        }
        #endregion

        void CreateTemplatesBars()
        {
            try
            {
                TemplatesBars.Add(new ShowInfo() { Icon = "home", Title = "Compression", Content = "TestCompress" });
                TemplatesBars.Add(new ShowInfo() { Icon = "home", Title = "Tension", Content = "TestTension" });
                TemplatesBars.Add(new ShowInfo() { Icon = "home", Title = "Flexure", Content = "TestFlexure" });
                TemplatesBars.Add(new ShowInfo() { Icon = "home", Title = "Torsion", Content = "TestTorsion" });
                TemplatesBars.Add(new ShowInfo() { Icon = "home", Title = "Impact", Content = "TestImpact" });
                TemplatesBars.Add(new ShowInfo() { Icon = "home", Title = "Friction", Content = "TestFriction" });
                TemplatesBars.Add(new ShowInfo() { Icon = "home", Title = "Other", Content = "TestOther" });
            }
            catch (System.NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }
        void CreateAdhesivesBars()
        {
            try
            {
                AdhesiveMethodsBars.Add(new ShowInfo() { Icon = "home", Title = "Criteria1", Content = "Describe" });
                AdhesiveMethodsBars.Add(new ShowInfo() { Icon = "home", Title = "Criteria2", Content = "Explain" });
                AdhesiveMethodsBars.Add(new ShowInfo() { Icon = "home", Title = "Criteria3", Content = "Detail" });
            }
            catch (System.NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }
        public void NavigateIndex(string Item)
        {
            try
            {
                if (Item == null || string.IsNullOrWhiteSpace(Item))
                {
                    return;
                }
                else
                {
                    regionManager.Regions[PrismManage.MainViewRegionName].RequestNavigate(Item);
                    aggregator.GetEvent<MessageEvent>().Publish(new Message() { Content = "EditMethod", Filter = "MainView" });
                    //aggregator.GetEvent<GaugeItemInfosEvent>().Publish(new List<Common.DAO.GaugeItemInfo>());
                }
            }
            catch (System.NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

    }
}

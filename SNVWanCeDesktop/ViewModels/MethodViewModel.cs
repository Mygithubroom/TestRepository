using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using WanCeDesktopApp.Common;
using WanCeDesktopApp.Common.Enum;
using WanCeDesktopApp.Extensions;
using WPFLocalizeExtension.Engine;

namespace WanCeDesktopApp.ViewModels
{
    public class MethodViewModel : BindableBase
    {

        private readonly IRegionManager regionManager;
        public ObservableCollection<DictionaryExt> ApplicatonTypeItems { get; set; }
        public ObservableCollection<DictionaryExt> SortTypeItems { get; set; }

        public MethodViewModel(IRegionManager regionManager)
        {
            try
            {
                AdhesiveMethodsBars = new ObservableCollection<ShowInfo>();
                TemplatesBars = new ObservableCollection<ShowInfo>();
                MethodBars = new ObservableCollection<ShowInfo>();
                NavigateCommandIndexView = new DelegateCommand<string>(NavigateIndex);
                this.regionManager = regionManager;
                Init();
                CreateTemplatesBars();
                CreateAdhesivesBars();
                CreateRecentBars();
            }
            catch (System.NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void Init()
        {
            ApplicatonTypeItems = new ObservableCollection<DictionaryExt>();
            ApplicatonTypeItems.AddRange(Tools.EnumTypeToList(typeof(ApplicationTypeEnum)));
            SortTypeItems = new ObservableCollection<DictionaryExt>();
            SortTypeItems.AddRange(Tools.EnumTypeToList(typeof(SortTypeEnum)));
            LocalizeDictionary.Instance.PropertyChanged += Instance_PropertyChanged;
        }

        private void Instance_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LocalizeDictionary.Instance.Culture))
            {
                ApplicatonTypeItems.Clear();
                ApplicatonTypeItems.AddRange(Tools.EnumTypeToList(typeof(ApplicationTypeEnum)));
                SortTypeItems.Clear();
                SortTypeItems.AddRange(Tools.EnumTypeToList(typeof(SortTypeEnum)));
            }
        }

        #region 属性
        //导航
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
        //内容列表
        private ObservableCollection<ShowInfo> methodBars;
        public ObservableCollection<ShowInfo> MethodBars
        {
            get { return methodBars; }
            set { methodBars = value; RaisePropertyChanged(); }
        }

        public int NegativeIndex { get; set; } = -1;
        #endregion

        void CreateTemplatesBars()
        {
            try
            {
                TemplatesBars.Add(new ShowInfo() { Icon = "Home", Title = "Compression", Content = "TestCompress" });
                TemplatesBars.Add(new ShowInfo() { Icon = "Home", Title = "Tension", Content = "TestTension" });
                TemplatesBars.Add(new ShowInfo() { Icon = "Home", Title = "Flexure", Content = "TestFlexure" });
                TemplatesBars.Add(new ShowInfo() { Icon = "Home", Title = "Torsion", Content = "TestTorsion" });
                TemplatesBars.Add(new ShowInfo() { Icon = "Home", Title = "Impact", Content = "TestImpact" });
                TemplatesBars.Add(new ShowInfo() { Icon = "Home", Title = "Friction", Content = "TestFriction" });
                TemplatesBars.Add(new ShowInfo() { Icon = "Home", Title = "Other", Content = "TestOther" });
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
                AdhesiveMethodsBars.Add(new ShowInfo()
                {
                    Icon = "home",
                    Title = "Criteria1",
                    Content = "Describe"
                });
                AdhesiveMethodsBars.Add(new ShowInfo() { Icon = "home", Title = "Criteria2", Content = "Explain" });
                AdhesiveMethodsBars.Add(new ShowInfo() { Icon = "home", Title = "Criteria3", Content = "Detail" });
                AdhesiveMethodsBars.Add(new ShowInfo() { Icon = "home", Title = "Criteria3", Content = "Detail" });
            }
            catch (System.NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }
        void CreateRecentBars()
        {
            try
            {
                MethodBars.Add(new ShowInfo() { Icon = "home", Title = "Compression", Content = "TestCompress" });
                MethodBars.Add(new ShowInfo() { Icon = "home", Title = "Tension", Content = "TestTension" });
                MethodBars.Add(new ShowInfo() { Icon = "home", Title = "Flexure", Content = "TestFlexure" });
                MethodBars.Add(new ShowInfo() { Icon = "home", Title = "Torsion", Content = "TestTorsion" });
                MethodBars.Add(new ShowInfo() { Icon = "home", Title = "Impact", Content = "TestImpact" });
                MethodBars.Add(new ShowInfo() { Icon = "home", Title = "Friction", Content = "TestFriction" });
                MethodBars.Add(new ShowInfo() { Icon = "home", Title = "Other", Content = "TestOther" });
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
                    NegativeIndex = -1;
                    //加载方法文件/读取数据库方法数据
                    CollectionsData? data = XmlProvider.Load<CollectionsData>("D:\\WANCE\\testFile.xml");
                    if(data != null)
                    {
                        Collections.Sample=data.Sample;
                        Collections.Specimen = data.Specimen;
                        Collections.SelectedCalculationItems = data.SelectedCalculationItems;
                    }
                    regionManager.Regions[PrismManage.MainViewRegionName].RequestNavigate(Item);
                    //加载对应方法参数

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

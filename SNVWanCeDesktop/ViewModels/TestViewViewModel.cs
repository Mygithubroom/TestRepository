using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common;

using Prism.Regions;
using Prism.Commands;
using WanCeDesktopApp.Extensions;

namespace WanCeDesktopApp.ViewModels
{
    public class TestViewViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public TestViewViewModel(IRegionManager regionManager)
        {
            try
            {
                TestBars = new ObservableCollection<ShowInfo>();
                MethodBars = new ObservableCollection<ShowInfo>();
                NavigateCommandIndexView = new DelegateCommand<string>(NavigateIndex);
                this.regionManager = regionManager;
                CreateTaskBars();
                CreateRecentBars();

            }
            catch (System.NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        #region 属性
        public DelegateCommand<string> NavigateCommandIndexView { get; private set; }

        //标题列表
        private ObservableCollection<ShowInfo> testBars;
        public ObservableCollection<ShowInfo> TestBars
        {
            get { return testBars; }
            set { testBars = value; RaisePropertyChanged(); }
        }
        //内容列表
        private ObservableCollection<ShowInfo> methodBars;
        public ObservableCollection<ShowInfo> MethodBars
        {
            get { return methodBars; }
            set { methodBars = value; RaisePropertyChanged(); }
        }
        #endregion

        void CreateTaskBars()
        {
            try
            {
                TestBars.Add(new ShowInfo() { Icon = "home", Title = "New Method", Content = "New Method" });
                TestBars.Add(new ShowInfo() { Icon = "home", Title = "QuickTestMethodTitle", Content = "QuickTestMethodDescription" });
                TestBars.Add(new ShowInfo()
                {
                    Icon = "home",
                    Title = "ContinueTestMethodTitle",
                    Content = "ContinueTestMethodDescription"
                });
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
                MethodBars.Add(new ShowInfo() { Icon = "home", Title = "Compression", Content = "CompressionMethodDescription" });
                MethodBars.Add(new ShowInfo() { Icon = "home", Title = "Tension", Content = "TensionMethodDescription" });
                MethodBars.Add(new ShowInfo() { Icon = "home", Title = "Flexure", Content = "FlexureMethodDescription" });
                MethodBars.Add(new ShowInfo() { Icon = "home", Title = "Torsion", Content = "TorsionMethodDescription" });
                MethodBars.Add(new ShowInfo() { Icon = "home", Title = "Impact", Content = "ImpactMethodDescription" });
                MethodBars.Add(new ShowInfo() { Icon = "home", Title = "Friction", Content = "FrictionMethodDescription" });
                MethodBars.Add(new ShowInfo() { Icon = "home", Title = "Other", Content = "OtherMethodDescription" });
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
                    regionManager.Regions[PrismManage.MainViewRegionName].RequestNavigate("NewMethodView");
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

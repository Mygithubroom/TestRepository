//using Prism.Commands;
//using Prism.Regions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Data;
//using WanCeDesktopApp.Extensions;

//namespace WanCeDesktopApp.ViewModels
//{
//    public class SystemManageViewModel
//    {
//        public readonly IRegionManager regionManager;
//        public DelegateCommand<string> OpenViewCommand { get; private set; }
//        SystemManageViewModel(IRegionManager regionManager)
//        {
//            this.regionManager = regionManager;
//            OpenViewCommand = new DelegateCommand<string>(OpenView);

//        }
//        public void OpenView(string strItem)//注册导航
//        {
//            try
//            {
//                if (strItem == null || string.IsNullOrWhiteSpace(strItem))
//                {
//                    return;
//                }
//                else
//                {
//                    this.regionManager.Regions[PrismManage.SystemManageRegionName].RequestNavigate(strItem);
//                }
//            }
//            catch (System.NullReferenceException ex)
//            {

//            }
//            catch (Exception ex)
//            {

//            }
//        }
//    }
//}

using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WanCeDesktopApp.Extensions;
using WanCeDesktopApp.Common;
using System.Windows;
using System.Collections.ObjectModel;
using WanCeDesktopApp.Common.DAO;
using WPFLocalizeExtension.Extensions;

namespace WanCeDesktopApp.ViewModels
{
    public class SystemManageViewModel : BindableBase, IConfigursIndexService
    {

        bool IsFirstLoad = true;//是否是第一次加载
        #region 属性
        private readonly IRegionManager regionManager;
        public DelegateCommand<string> OpenViewCommand { get; private set; }
        public DelegateCommand LoadedCommand { get; private set; }
        private ObservableCollection<ShowInfo> headMenus;//headMenu
        public ObservableCollection<ShowInfo> HeadMenus
        {
            get { return headMenus; }
            set
            {
                headMenus = value; RaisePropertyChanged();
            }
        }
        public DelegateCommand<NegativeBarInfos> SelectionChangedCommand { get; private set; }
        #endregion
        private ObservableCollection<NegativeBarInfos> negativeBarInfos;

        public ObservableCollection<NegativeBarInfos> NegativeBarInfos
        {
            get { return negativeBarInfos; }
            set { negativeBarInfos = value; RaisePropertyChanged(); }
        }
        public SystemManageViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            HeadMenus = new ObservableCollection<ShowInfo>();
            OpenViewCommand = new DelegateCommand<string>(OpenView);
            LoadedCommand = new DelegateCommand(Loaded);
            NegativeBarInfos = new ObservableCollection<NegativeBarInfos>();
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 0, NameSpace = "SoftwareManageView", Title = "SoftwareManagement" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 1, NameSpace = "HardWareManageView", Title = "HardwareManagement" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 1, NameSpace = "AuthorityManageView", Title = "AuthorityManagement" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 1, NameSpace = "DataManageView", Title = "DataManagerment" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 1, NameSpace = "InterfaceManageView", Title = "InterfaceManagement" });
            SelectionChangedCommand = new DelegateCommand<NegativeBarInfos>(SelectionChanged);
        }
        private void SelectionChanged(NegativeBarInfos obj)
        {
            try
            {
                if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
                {
                    return;
                }
                else
                {
                    this.regionManager.Regions[PrismManage.SystemManageRegionName].RequestNavigate(obj.NameSpace);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void Loaded()
        {
            if (IsFirstLoad)
            {
                regionManager.Regions[PrismManage.SystemManageRegionName].RequestNavigate("SoftwareManageView");
                IsFirstLoad = false;
            }
        }
        public void OpenView(string strItem)//注册导航
        {



            try
            {
                if (strItem == null || string.IsNullOrWhiteSpace(strItem))
                {
                    return;
                }
                else
                {
                    this.regionManager.Regions[PrismManage.SystemManageRegionName].RequestNavigate(strItem);
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


using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common.DAO;
using WanCeDesktopApp.Extensions;

namespace WanCeDesktopApp.ViewModels
{
    public class DataManageViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        #region
        public DelegateCommand<string> OpenViewCommand { get; private set; }
        //public DelegateCommand LoadedCommand { get; private set; }
        public DelegateCommand<NegativeBarInfos> SelectionChangedCommand { get; private set; }

        /// <summary>
        /// 界面加载
        /// </summary>
        public DelegateCommand LoadCommand { get; private set; }
        #endregion
        private ObservableCollection<NegativeBarInfos> negativeBarInfos;

        public ObservableCollection<NegativeBarInfos> NegativeBarInfos
        {
            get { return negativeBarInfos; }
            set { negativeBarInfos = value; RaisePropertyChanged(); }
        }
        public DataManageViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            OpenViewCommand = new DelegateCommand<string>(OpenView);
            //LoadedCommand = new DelegateCommand(Loaded);
            NegativeBarInfos = new ObservableCollection<NegativeBarInfos>();
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 0, NameSpace = "SettingsDatabaseView", Title = "DatabaseSettings" });
            SelectionChangedCommand = new DelegateCommand<NegativeBarInfos>(SelectionChanged);
            LoadCommand = new DelegateCommand(Load);
        }
        private void Load()
        {
            OpenView("SettingsDatabaseView");
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
                    this.regionManager.Regions[PrismManage.DataViewRegionName].RequestNavigate(obj.NameSpace);
                }
            }
            catch (Exception ex)
            {

            }
        }
        //private void Loaded()
        //{
        //    if (IsFirstLoad)
        //    {
        //        regionManager.Regions[PrismManage.HardWareItemViewRegionName].RequestNavigate("HardWareManageView");
        //        IsFirstLoad = false;
        //    }
        //}
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
                    this.regionManager.Regions[PrismManage.DataViewRegionName].RequestNavigate(strItem);
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

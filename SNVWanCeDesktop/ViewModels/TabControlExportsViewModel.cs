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
    public class TabControlExportsViewModel : BindableBase
    {
        
        private readonly IRegionManager regionManager;
        private bool IsFirstLoad = true;//是否第一次加载

        #region
        public DelegateCommand<string> OpenViewCommand { get; private set; }
        public DelegateCommand<NegativeBarInfos> SelectionChangedCommand { get; private set; }
        #endregion
        private ObservableCollection<NegativeBarInfos> negativeBarInfos;

        public ObservableCollection<NegativeBarInfos> NegativeBarInfos
        {
            get { return negativeBarInfos; }
            set { negativeBarInfos = value; RaisePropertyChanged(); }
        }

        public TabControlExportsViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            OpenViewCommand = new DelegateCommand<string>(OpenView);
            LoadedCommand = new DelegateCommand(Loaded);
            NegativeBarInfos = new ObservableCollection<NegativeBarInfos>();
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 0, NameSpace = "ExportFileSettingsView", Title = "File Settings" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 1, NameSpace = "ExportReportsView", Title = "Reports" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 2, NameSpace = "ExportDatabaseExportView", Title = "DatabaseExport" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 3, NameSpace = "ExportsExport1View", Title = "Export 1" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 4, NameSpace = "ExportsExport2View", Title = "Export 2" });
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
                    this.regionManager.Regions[PrismManage.ExportsViewRegionName].RequestNavigate(obj.NameSpace);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Loaded()
        {
            if (IsFirstLoad)
            {
                this.regionManager.Regions[PrismManage.ExportsViewRegionName].RequestNavigate("ExportFileSettingsView");
                IsFirstLoad = false;
            }
        }

        public DelegateCommand LoadedCommand { get; private set; }
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
                    this.regionManager.Regions[PrismManage.ExportsViewRegionName].RequestNavigate(strItem);
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

using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WanCeDesktopApp.Common.DAO;
using WanCeDesktopApp.Extensions;
using WanCeDesktopApp.Views;

namespace WanCeDesktopApp.ViewModels
{
    public class TabControlSpecimenItemViewModel:BindableBase
    {
        
        private readonly IRegionManager regionManager;
        bool IsFirstLoad = true;//是否是第一次加载
        #region
        public DelegateCommand<string> OpenViewCommand { get; private set; }
        public DelegateCommand LoadedCommand { get; private set; }
        public DelegateCommand<NegativeBarInfos> SelectionChangedCommand { get; private set; }
        #endregion
        private ObservableCollection<NegativeBarInfos> negativeBarInfos;

        

        public ObservableCollection<NegativeBarInfos> NegativeBarInfos
        {
            get { return negativeBarInfos; }
            set { negativeBarInfos = value; RaisePropertyChanged(); }
        }
        public TabControlSpecimenItemViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            OpenViewCommand = new DelegateCommand<string>(OpenView);
            LoadedCommand = new DelegateCommand(Loaded);
            NegativeBarInfos = new ObservableCollection<NegativeBarInfos>();
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 0, NameSpace = "SpecimenPropertiesView", Title = "TabSectionTitleProperties" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 1, NameSpace = "SpecimenNotesView", Title = "Notes" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 2, NameSpace = "SpecimenNumberInputsView", Title = "TabSectionTitleNumberInputs" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 3, NameSpace = "SpecimenTextInputsView", Title = "TabSectionTitleTextInputs" });
            NegativeBarInfos.Add(new NegativeBarInfos() { Id = 4, NameSpace = "SpecimenChoiceInputsView", Title = "TabSectionTitleChoiceInputs" });
            SelectionChangedCommand = new DelegateCommand<NegativeBarInfos>(SelectionChanged);

            CreateSpecmentParamTable();//创建试样参数表
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
                    this.regionManager.Regions[PrismManage.SpecimenItemViewRegionName].RequestNavigate(obj.NameSpace);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Loaded()
        {
            if (IsFirstLoad)
            {
                regionManager.Regions[PrismManage.SpecimenItemViewRegionName].RequestNavigate(nameof(SpecimenPropertiesView));
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
                    this.regionManager.Regions[PrismManage.SpecimenItemViewRegionName].RequestNavigate(strItem);
                }
            }
            catch (System.NullReferenceException ex)
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CreateSpecmentParamTable()
        {
            SQLiteHelper TestMethod = new SQLiteHelper("TestMethodParamDataBase");           
            //试样参数表 
            StringBuilder sbr2 = new StringBuilder();
            sbr2.AppendLine("CREATE TABLE IF NOT EXISTS `SpecmentParamTable`(");
            sbr2.AppendLine("`id` INTEGER PRIMARY KEY AUTOINCREMENT,");//自增id主键
            sbr2.AppendLine("`MethodID` CHAR(9) NOT NULL,");//方法ID
            sbr2.AppendLine("`SpecmentParamID` CHAR(9) NULL,"); //试样参数ID
            sbr2.AppendLine("`Geometry` CHAR(8) NULL,");//试样型态
            sbr2.AppendLine("`Width` CHAR(4) NULL,");//宽
            sbr2.AppendLine("`Thickness` CHAR(4) NULL,");//厚
            sbr2.AppendLine("`Length` CHAR(10) NULL,"); //长
            sbr2.AppendLine("`FixtureSeparation` CHAR(10) NULL,");//平行距离
            sbr2.AppendLine("`FinalWidth` CHAR(10) NULL,");//最终宽
            sbr2.AppendLine("`FinalThickness` CHAR(10) NULL,");//最终厚度
            sbr2.AppendLine("`FinalLength` CHAR(10) NULL,");//最终长度
            sbr2.AppendLine("`Pitch` CHAR(10) NULL,");//齿距
            sbr2.AppendLine("`LinearDensity` CHAR(10) NULL,");//线密度
            sbr2.AppendLine("`ExternalDiameter` CHAR(10) NULL,");//外径
            sbr2.AppendLine("`create_time` datetime DEFAULT CURRENT_TIMESTAMP,");
            sbr2.AppendLine("`update_time` datetime DEFAULT CURRENT_TIMESTAMP );");
            sbr2.AppendLine();
            string cmdText2 = sbr2.ToString();
            int val2;
            if (string.IsNullOrEmpty(cmdText2))
            {
                return;
            }
            else
            {
                val2 = TestMethod.ExecuteNonQuery(cmdText2);
            }
            
        }
    }
}

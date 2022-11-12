using Prism.Mvvm;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WanCeDesktopApp.Common.DAO;
using WanCeDesktopApp.Common.Enum;
using WanCeDesktopApp.Extensions;
using WanCeDesktopApp.ViewModels;

namespace WanCeDesktopApp.Common
{
    /// <summary>
    /// 具体方法对应的一个集合，包含方法的所有信息
    /// </summary>
    public static class Collections
    {
        /// <summary>
        /// 实时显示展示集合
        /// </summary>
        public static ObservableCollection<GaugeItemInfo> LiveDisplayGaugeItemInfos { get; set; }
        /// <summary>
        /// 方法测量模块选中的集合
        /// </summary>
        public static ObservableCollection<GaugeItemInfo> GaugeItems { get; set; }
        /// <summary>
        /// 功能键集合
        /// </summary>
        public static ObservableCollection<SoftKeyInfo> SoftKeyItems { get; set; }
        //选中可计算集合
        public static ObservableCollection<GaugeItemInfo> SelectedCalculationItems { get; set; }
        static Collections()
        {
            LiveDisplayGaugeItemInfos = new ObservableCollection<GaugeItemInfo>();
            GaugeItems = new ObservableCollection<GaugeItemInfo>();
            SoftKeyItems = new ObservableCollection<SoftKeyInfo>();
            Sample = new SampleModule();
            Specimen = new SpecimenModule();
            Init();
        }

        public static void InitLiveDisplayGaugeItemInfos()
        {
            foreach (var item in LiveDisplayGaugeItemInfos)
            {
                UnitInfo unitInfo = UnitSystemProvider.GetUnitInfo(item.UnitSetName);
                DictionaryExt dictionaryExt = unitInfo.DefaultValue;
                item.Unit = dictionaryExt.Value;
            }
        }
        /// <summary>
        /// 样品模块
        /// </summary>
        public static SampleModule Sample { get; set; }
        /// <summary>
        /// 试样模块
        /// </summary>
        public static SpecimenModule Specimen { get; set; }
        private static void Init()
        {

            if (Sample.NumberInputs == null)
            {
                Sample.NumberInputs = new ObservableCollection<GaugeItemInfo>();
                Sample.NumberInputs.Add(
                          new GaugeItemInfo()
                          {
                              Id = 1,
                              Index = 0,
                              DefaultTitleKey = "SampleNumberInput",
                              IsChecked = true,
                              DisplayValue = "0",
                          }
                      );
                Sample.NumberInputs.Add(
                    new GaugeItemInfo()
                    {
                        Id = 1,
                        Index = 1,
                        DefaultTitleKey = "SampleNumberInput",
                        IsChecked = false,
                        DisplayValue = "0"
                    }
                );
            }
            if (Specimen.NumberInputs == null)
            {
                Specimen.NumberInputs = new ObservableCollection<GaugeItemInfo>();
                Specimen.NumberInputs.Add(
                          new GaugeItemInfo()
                          {
                              Id = 2,
                              Index = 0,
                              DefaultTitleKey = "SpecimenNumberInput",
                              IsChecked = true,
                              DisplayValue = "0",
                          }
                      );
                Specimen.NumberInputs.Add(
                    new GaugeItemInfo()
                    {
                        Id = 2,
                        Index = 1,
                        DefaultTitleKey = "SpecimenNumberInput",
                        IsChecked = false,
                        DisplayValue = "0"
                    }
                );
            }
        }


    }
    //用于读写方法文件的载体
    public class CollectionsData
    {

        public SampleModule Sample { get; set; }
        public SpecimenModule Specimen { get; set; }
        /// <summary>
        /// 实时显示展示集合
        /// </summary>
        public ObservableCollection<GaugeItemInfo> LiveDisplayGaugeItemInfos { get; set; }
        //public ObservableCollection<GaugeItemInfo> LiveDisplayGaugeItemInfos { get; set; }
        /// <summary>
        /// 方法测量模块选中的集合
        /// </summary>
        public ObservableCollection<GaugeItemInfo> GaugeItems { get; set; }
        public ObservableCollection<SoftKeyInfo> SoftKeyItems { get; set; }
        public ObservableCollection<GaugeItemInfo> SelectedCalculationItems { get; set; }

    }
    public class SampleModule
    {
        public SampleModule()
        {
            Nodes = new ObservableCollection<InputInfo>();
            TextInputs = new ObservableCollection<InputInfo>();
            DateInputs = new ObservableCollection<DateInfo>();
            ChoiceInputs = new ObservableCollection<ChoiceInputInfo>();
        }
        
        public ObservableCollection<InputInfo> Nodes { get; set; }
        public ObservableCollection<GaugeItemInfo> NumberInputs { get; set; }
        public ObservableCollection<InputInfo> TextInputs { get; set; }
        public ObservableCollection<DateInfo> DateInputs { get; set; }
        public ObservableCollection<ChoiceInputInfo> ChoiceInputs { get; set; }

    }
    public class SpecimenModule
    {
        public SpecimenModule()
        {
            Properties = new SpecimenProperties();
            Nodes = new ObservableCollection<InputInfo>();
            TextInputs = new ObservableCollection<InputInfo>();
            ChoiceInputs = new ObservableCollection<ChoiceInputInfo>();
        }
        public SpecimenProperties Properties { get; set; }
        public ObservableCollection<InputInfo> Nodes { get; set; }
        public ObservableCollection<GaugeItemInfo> NumberInputs { get; set; }
        public ObservableCollection<InputInfo> TextInputs { get; set; }
        public ObservableCollection<ChoiceInputInfo> ChoiceInputs { get; set; }
    }
    public class SpecimenProperties
    {
        public SpecimenProperties()
        {
            Init();
        }

        private void Init()
        {
            SpecimenCurveIdentification = new InputInfo() { DefaultTitleKey = "Specimen label" };
            Length = new GaugeItemInfo() { DefaultTitleKey = "Length", DisplayValue = "100", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            FinalLength = new GaugeItemInfo() { DefaultTitleKey = "FinalLength", DisplayValue = "100", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            Width = new GaugeItemInfo() { DefaultTitleKey = "Width", DisplayValue = "10", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            FinalWidth = new GaugeItemInfo() { DefaultTitleKey = "FinalWidth", DisplayValue = "10", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            Thickness = new GaugeItemInfo() { DefaultTitleKey = "Thickness", DisplayValue = "1", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            FinalThickness = new GaugeItemInfo() { DefaultTitleKey = "FinalThickness", DisplayValue = "1", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            Diameter = new GaugeItemInfo() { DefaultTitleKey = "Diameter", DisplayValue = "10", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            FinalDiameter = new GaugeItemInfo() { DefaultTitleKey = "FinalDiameter", DisplayValue = "10", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            Area = new GaugeItemInfo() { DefaultTitleKey = "Area", DisplayValue = "10", DecimalPlaces = 5, UnitSetName = "Area", Unit = "mm^2" };
            FinalArea = new GaugeItemInfo() { DefaultTitleKey = "FinalArea", DisplayValue = "10", DecimalPlaces = 5, UnitSetName = "Area", Unit = "mm^2" };
            ExternalDiameter = new GaugeItemInfo() { DefaultTitleKey = "ExternalDiameter", DisplayValue = "60", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            FinalExternalDiameter = new GaugeItemInfo() { DefaultTitleKey = "FinalExternalDiameter", DisplayValue = "60", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            WallThickness = new GaugeItemInfo() { DefaultTitleKey = "WallThickness", DisplayValue = "1", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            FinalWallThickness = new GaugeItemInfo() { DefaultTitleKey = "FinalWallThickness", DisplayValue = "1", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            LinearDensity = new GaugeItemInfo() { DefaultTitleKey = "LinearDensity", DisplayValue = "100", DecimalPlaces = 5, UnitSetName = "Length", Unit = "tex" };
            FinalLinearDensity = new GaugeItemInfo() { DefaultTitleKey = "FinalLinearDensity", DisplayValue = "100", DecimalPlaces = 5, UnitSetName = "Length", Unit = "tex" };
            ThreadsPerInch = new GaugeItemInfo() { DefaultTitleKey = "ThreadsPerInch", DisplayValue = "16", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            Pitch = new GaugeItemInfo() { DefaultTitleKey = "Pitch", DisplayValue = "1.5", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            InnerDiameter = new GaugeItemInfo() { DefaultTitleKey = "InnerDiameter", DisplayValue = "30", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            FinalInnerDiameter = new GaugeItemInfo() { DefaultTitleKey = "FinalInnerDiameter", DisplayValue = "40", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            ExternalRadius = new GaugeItemInfo() { DefaultTitleKey = "ExternalRadius", DisplayValue = "30", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            FinalExternalRadius = new GaugeItemInfo() { DefaultTitleKey = "FinalExternalRadius", DisplayValue = "30", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            InsideRadius = new GaugeItemInfo() { DefaultTitleKey = "InsideRadius", DisplayValue = "25", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
            FinalInsideRadius = new GaugeItemInfo() { DefaultTitleKey = "FinalInsideRadius", DisplayValue = "25", DecimalPlaces = 5, UnitSetName = "Length", Unit = "mm" };
        }
        //获取试样属性
        public List<GaugeItemInfo> GetProperties()
        {
            List<GaugeItemInfo> infos = new List<GaugeItemInfo>();
            if (GeometryType == null)
            {
                return infos;
            }
            infos.Add(Length);
            switch (GeometryType)
            {
                case GeometryEnum.Rectangle:
                    infos.Add(Width);
                    infos.Add(Thickness);
                    infos.Add(FinalWidth);
                    infos.Add(FinalThickness);
                    break;
                case GeometryEnum.DoubleShearRing:
                case GeometryEnum.Round:
                    infos.Add(Diameter);
                    infos.Add(FinalDiameter);
                    break;
                case GeometryEnum.IrregularShape:
                    infos.Add(Area);
                    infos.Add(FinalArea);
                    break;
                case GeometryEnum.Siphonate:
                    infos.Add(ExternalDiameter);
                    infos.Add(WallThickness);
                    infos.Add(FinalWallThickness);
                    infos.Add(FinalExternalDiameter);

                    break;
                case GeometryEnum.Fiber:
                    infos.Add(LinearDensity);
                    infos.Add(FinalLinearDensity);

                    break;
                //case GeometryEnum.DoubleShearRing:

                //    break;
                case GeometryEnum.Fasteners_American:
                    infos.Add(Diameter);
                    infos.Add(ThreadsPerInch);//每英寸螺纹数
                    infos.Add(FinalDiameter);
                    break;
                case GeometryEnum.Fasteners_Metric:
                    infos.Add(Diameter);
                    infos.Add(Pitch);
                    infos.Add(FinalDiameter);
                    break;
                case GeometryEnum.ThePipeSection_TubeSection:
                    infos.Add(Width);
                    infos.Add(ExternalDiameter);
                    infos.Add(Thickness);
                    infos.Add(FinalWidth);
                    infos.Add(FinalExternalDiameter); 
                    infos.Add(FinalThickness);
                    break;
                case GeometryEnum.ThePipeSection_PipeSection:
                    infos.Add(Width);
                    infos.Add(ExternalRadius);
                    infos.Add(InsideRadius);
                    infos.Add(FinalWidth);
                    infos.Add(FinalExternalRadius);
                    infos.Add(FinalInsideRadius);
                    break;
                case GeometryEnum.Pipe:
                    infos.Add(InnerDiameter);
                    infos.Add(Thickness);
                    infos.Add(FinalInnerDiameter);
                    infos.Add(FinalThickness);

                    break;
            }
            infos.Add(FinalLength);
            return infos;
        }
        /// <summary>
        /// 试样标识用于曲线标记
        /// </summary>
        public InputInfo SpecimenCurveIdentification { get; set; }
        /// <summary>
        /// 几何形状
        /// </summary>
        public GeometryEnum GeometryType { get; set; }
        public GaugeItemInfo Width { get; set; }
        /// <summary>
        /// 最终宽度
        /// </summary>
        public GaugeItemInfo FinalWidth { get; set; }
        public GaugeItemInfo Length { get; set; }
        /// <summary>
        /// 最终长度
        /// </summary>
        public GaugeItemInfo FinalLength { get; set; }
        public GaugeItemInfo Area { get; set; }
        /// <summary>
        /// 最终面积
        /// </summary>
        public GaugeItemInfo FinalArea { get; set; }
        /// <summary>
        /// 高度或者厚度
        /// </summary>
        public GaugeItemInfo Thickness { get; set; }
        /// <summary>
        /// 最终高度或者厚度
        /// </summary>
        public GaugeItemInfo FinalThickness { get; set; }
        /// <summary>
        /// 壁厚
        /// </summary>
        public GaugeItemInfo WallThickness { get; set; }
        /// <summary>
        /// 最终壁厚
        /// </summary>
        public GaugeItemInfo FinalWallThickness { get; set; }
        /// <summary>
        /// 直径
        /// </summary>
        public GaugeItemInfo Diameter { get; set; }
        /// <summary>
        /// 最终直径
        /// </summary>
        public GaugeItemInfo FinalDiameter { get; set; }
        /// <summary>
        /// 外径
        /// </summary>
        public GaugeItemInfo ExternalDiameter { get; set; }
        /// <summary>
        /// 最终外径
        /// </summary>
        public GaugeItemInfo FinalExternalDiameter { get; set; }
        /// <summary>
        /// 内径
        /// </summary>
        public GaugeItemInfo InnerDiameter { get; set; }
        /// <summary>
        /// 最终内径
        /// </summary>
        public GaugeItemInfo FinalInnerDiameter { get; set; }
        /// <summary>
        /// 线密度
        /// </summary>
        public GaugeItemInfo LinearDensity { get; set; }
        /// <summary>
        /// 最终线密度
        /// </summary>
        public GaugeItemInfo FinalLinearDensity { get; set; }
        /// <summary>
        /// 外半径
        /// </summary>
        public GaugeItemInfo ExternalRadius { get; set; }
        /// <summary>
        /// 最终外半径
        /// </summary>
        public GaugeItemInfo FinalExternalRadius { get; set; }
        /// <summary>
        /// 内半径
        /// </summary>
        public GaugeItemInfo InsideRadius { get; set; }
        /// <summary>
        /// 最终外半径
        /// </summary>
        public GaugeItemInfo FinalInsideRadius { get; set; }
        /// <summary>
        /// 每英寸螺纹数
        /// </summary>
        public GaugeItemInfo ThreadsPerInch { get; set; }
        /// <summary>
        /// 齿距
        /// </summary>
        public GaugeItemInfo Pitch { get; set; }

    }
    public class GeneralModule
    {
        //试验类型
        public string TestType { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 修改者
        /// </summary>
        public string Updater { get; set; }
        /// <summary>
        /// 单位系统
        /// </summary>
        public string UnitSystem { get; set; }
        /// <summary>
        /// 试验参数源
        /// </summary>
        public string SampleParameterSource { get; set; }
        /// <summary>
        /// 启用多站点试验
        /// </summary>
        public bool MultiStationTesingEnable { get; set; }
        /// <summary>
        /// 方法描述
        /// </summary>
        public string FunctionDescription { get; set; }
    }

}

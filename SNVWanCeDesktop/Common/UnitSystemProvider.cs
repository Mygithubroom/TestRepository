using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WanCeDesktopApp.Common.Enum;

namespace WanCeDesktopApp.Common
{
    //遗弃该实现方式。该方式不能自由添加单位制和单位群，添加单位麻烦
    public static class UnitSystemProvider
    {
        public static UnitSystemEnum SelectUnitSystem;
        public static UnitSystem? UnitSystems;
        private static void Init()
        {
            //string directory =Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //string directory = @"WanCeDesktopApp\trunk\Common\XML";
            //string str_1 = System.AppDomain.CurrentDomain.BaseDirectory;
            //string str_2 = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            //string str_3 = System.Windows.Forms.Application.StartupPath;
            //string str_4 = System.Windows.Forms.Application.ExecutablePath;
            //string str_5 = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            //string str_6 = System.Environment.CurrentDirectory;
            //string str_8 = System.IO.Directory.GetCurrentDirectory();
            //string filePath = Path.Combine(directory, @"E:\WanCeSVN\WanCeDesktopApp\trunk\Common\XML\XMLUnitSystemResource.xml");
            //string filePath = @"E:\WanCeSVN\WanCeDesktopApp\trunk\Common\XML\UnitSystemResource.xml";
            string filePath = System.IO.Directory.GetCurrentDirectory(); 
            string path = Path.Combine(filePath.Substring(0, filePath.IndexOf("trunk")+5),@"Common\XML\UnitSystemResource.xml");
            UnitSystems = XmlProvider.Load<UnitSystem>(path);
        }
        /// <summary>
        /// 获取单位源集合
        /// </summary>
        /// <returns></returns>
        public static List<DictionaryExt> GetUnitSetList()
        {
            List<DictionaryExt> list = new List<DictionaryExt>();
            PropertyInfo[] properties = typeof(UnitSystemInfo).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                list.Add(new DictionaryExt() { Key = property.Name, Value = property.Name });
            }   
            return list;
        }
        /// <summary>
        /// 根据单位源获取单位集合
        /// </summary>
        /// <param name="unitsetName">单位源名</param>
        /// <returns></returns>
        public static UnitInfo GetUnitInfo(string unitsetName)
        {
            UnitInfo result = null;
            if (UnitSystems == null)
            {
                Init();
            }
            if (UnitSystems == null || string.IsNullOrEmpty(unitsetName))
            {
                return result;
            }
            switch (SelectUnitSystem)
            {
                case UnitSystemEnum.ALL:
                    result =UnitSystems.ALL.FindUnitSet(unitsetName);
                    break;
                case UnitSystemEnum.AmericanStandard:
                    result = UnitSystems.AmericanStandard.FindUnitSet(unitsetName);
                    break;
                case UnitSystemEnum.Metric:
                    result = UnitSystems.Metric.FindUnitSet(unitsetName);
                    break;
                case UnitSystemEnum.SI:
                    result = UnitSystems.SI.FindUnitSet(unitsetName);
                    break;
                default:
                    break;
            }
            return result;
        }

    }
    public class UnitSystem
    {
        public UnitSystemInfo ALL;
        public UnitSystemInfo AmericanStandard;
        public UnitSystemInfo Metric;
        public UnitSystemInfo SI;
        public UnitSystem()
        {
            //实例化
            ALL = new UnitSystemInfo();
            AmericanStandard = new UnitSystemInfo();
            Metric = new UnitSystemInfo();
            SI = new UnitSystemInfo();
        }
        //public void Init()
        //{
        //    #region ALL初始化
        //    //百分比
        //    ALL.Percentage.DefaultValue = new DictionaryExt() { Key = "Persent", Value = "%" };
        //    List<DictionaryExt> units = new List<DictionaryExt>();
        //    units.Add(new DictionaryExt() { Key = "Persent", Value = "%" });
        //    ALL.Percentage.Units = units;
        //    //比重
        //    ALL.SpecificGravity.DefaultValue = new DictionaryExt() { Key = "N_per_Pow_m_3", Value = "N/m^3" };
        //    units = new List<DictionaryExt>();
        //    units.Add(new DictionaryExt() { Key = "gf_per_Pow_cm_3", Value = "gf/cm^3" });
        //    units.Add(new DictionaryExt() { Key = "kgf_per_Pow_cm_3", Value = "kgf/cm^3" });
        //    units.Add(new DictionaryExt() { Key = "kgf_per_Pow_mm_3", Value = "kgf/mm^3" });
        //    units.Add(new DictionaryExt() { Key = "lbf_per_Pow_ft_3", Value = "lbf/ft^3" });
        //    units.Add(new DictionaryExt() { Key = "lbf_per_Pow_in_3", Value = "lbf/in^3" });
        //    units.Add(new DictionaryExt() { Key = "N_per_Pow_cm_3", Value = "N/cm^3" });
        //    units.Add(new DictionaryExt() { Key = "N_per_Pow_m_3", Value = "N/m^3" });
        //    units.Add(new DictionaryExt() { Key = "N_per_Pow_mm_3", Value = "N/mm^3" });
        //    units.Add(new DictionaryExt() { Key = "ozf_per_Pow_in_3", Value = "ozf/in^3" });
        //    ALL.SpecificGravity.Units = units;
        //    //比重率
        //    ALL.SpecificGravityRate.DefaultValue = new DictionaryExt() { Key = "N_per_Pow_m_3_per_min", Value = "N/m^3/min" };
        //    units = new List<DictionaryExt>();
        //    units.Add(new DictionaryExt() { Key = "gf_per_Pow_cm_3_per_min", Value = "gf/cm^3/min" });
        //    units.Add(new DictionaryExt() { Key = "gf_per_Pow_cm_3_per_s", Value = "gf/cm^3/s" });
        //    units.Add(new DictionaryExt() { Key = "kgf_per_Pow_mm_3_per_min", Value = "kgf/mm^3/min" });
        //    units.Add(new DictionaryExt() { Key = "kgf_per_Pow_mm_3_per_s", Value = "kgf/mm^3/s" });
        //    units.Add(new DictionaryExt() { Key = "lbf_per_Pow_in_3_per_min", Value = "lbf/in^3/min" });
        //    units.Add(new DictionaryExt() { Key = "lbf_per_Pow_in_3_per_s", Value = "lbf/in^3/s" });
        //    units.Add(new DictionaryExt() { Key = "N_per_Pow_cm_3_per_min", Value = "N/cm^3/min" });
        //    units.Add(new DictionaryExt() { Key = "N_per_Pow_m_3_per_min", Value = "N/m^3/min" });
        //    units.Add(new DictionaryExt() { Key = "N_per_Pow_m_3_per_s", Value = "N/m^3/s" });
        //    units.Add(new DictionaryExt() { Key = "N_per_Pow_mm_3_per_min", Value = "N/mm^3/min" });
        //    units.Add(new DictionaryExt() { Key = "N_per_Pow_mm_3_per_s", Value = "N/mm^3/s" });
        //    ALL.SpecificGravityRate.Units = units;
        //    //力
        //    ALL.Force.DefaultValue = new DictionaryExt() { Key = "N", Value = "N" };
        //    units = new List<DictionaryExt>();
        //    units.Add(new DictionaryExt() { Key = "cN", Value = "cN" });
        //    units.Add(new DictionaryExt() { Key = "daN", Value = "daN" });
        //    units.Add(new DictionaryExt() { Key = "dN", Value = "dN" });
        //    units.Add(new DictionaryExt() { Key = "dyn", Value = "dyn" });
        //    units.Add(new DictionaryExt() { Key = "gf", Value = "gf" });
        //    units.Add(new DictionaryExt() { Key = "kgf", Value = "kgf" });
        //    units.Add(new DictionaryExt() { Key = "kip", Value = "kip" });
        //    units.Add(new DictionaryExt() { Key = "kkgf", Value = "kkgf" });
        //    units.Add(new DictionaryExt() { Key = "kN", Value = "kN" });
        //    units.Add(new DictionaryExt() { Key = "lbf", Value = "lbf" });
        //    units.Add(new DictionaryExt() { Key = "Mgf", Value = "Mgf" });
        //    units.Add(new DictionaryExt() { Key = "mlbf", Value = "mlbf" });
        //    units.Add(new DictionaryExt() { Key = "MN", Value = "MN" });
        //    units.Add(new DictionaryExt() { Key = "mN", Value = "mN" });
        //    units.Add(new DictionaryExt() { Key = "N", Value = "N" });
        //    units.Add(new DictionaryExt() { Key = "ozf", Value = "ozf" });
        //    ALL.Force.Units = units;
        //    #endregion

        //    #region AmericanStandard初始化

        //    //百分比
        //    AmericanStandard.Percentage.DefaultValue = new DictionaryExt() { Key = "Persent", Value = "%" };
        //    units = new List<DictionaryExt>();
        //    units.Add(new DictionaryExt() { Key = "Persent", Value = "%" });
        //    AmericanStandard.Percentage.Units = units;
        //    //比重
        //    AmericanStandard.SpecificGravity.DefaultValue = new DictionaryExt() { Key = "N_per_Pow_m_3", Value = "N/m^3" };
        //    units = new List<DictionaryExt>();
        //    units.Add(new DictionaryExt() { Key = "lbf_per_Pow_ft_3", Value = "lbf/ft^3" });
        //    units.Add(new DictionaryExt() { Key = "lbf_per_Pow_in_3", Value = "lbf/in^3" });
        //    units.Add(new DictionaryExt() { Key = "ozf_per_Pow_in_3", Value = "ozf/in^3" });
        //    AmericanStandard.SpecificGravity.Units = units;
        //    //比重率
        //    AmericanStandard.SpecificGravityRate.DefaultValue = new DictionaryExt() { Key = "N_per_Pow_m_3_per_min", Value = "N/m^3/min" };
        //    units = new List<DictionaryExt>();
        //    units.Add(new DictionaryExt() { Key = "lbf_per_Pow_in_3_per_min", Value = "lbf/in^3/min" });
        //    units.Add(new DictionaryExt() { Key = "lbf_per_Pow_in_3_per_s", Value = "lbf/in^3/s" });
        //    AmericanStandard.SpecificGravityRate.Units = units;
        //    //力
        //    AmericanStandard.Force.DefaultValue = new DictionaryExt() { Key = "N", Value = "N" };
        //    units = new List<DictionaryExt>();
        //    units.Add(new DictionaryExt() { Key = "kip", Value = "kip" });
        //    units.Add(new DictionaryExt() { Key = "lbf", Value = "lbf" });
        //    units.Add(new DictionaryExt() { Key = "mlbf", Value = "mlbf" });
        //    units.Add(new DictionaryExt() { Key = "ozf", Value = "ozf" });
        //    AmericanStandard.Force.Units = units;
        //    #endregion

        //    #region MetricSystem初始化
        //    //百分比
        //    MetricSystem.Percentage.DefaultValue = new DictionaryExt() { Key = "Persent", Value = "%" };
        //    units = new List<DictionaryExt>();
        //    units.Add(new DictionaryExt() { Key = "Persent", Value = "%" });
        //    MetricSystem.Percentage.Units = units;
        //    //比重
        //    MetricSystem.SpecificGravity.DefaultValue = new DictionaryExt() { Key = "N_per_Pow_m_3", Value = "N/m^3" };
        //    units = new List<DictionaryExt>();
        //    units.Add(new DictionaryExt() { Key = "gf_per_Pow_cm_3", Value = "gf/cm^3" });
        //    units.Add(new DictionaryExt() { Key = "kgf_per_Pow_cm_3", Value = "kgf/cm^3" });
        //    units.Add(new DictionaryExt() { Key = "kgf_per_Pow_mm_3", Value = "kgf/mm^3" });
        //    MetricSystem.SpecificGravity.Units = units;
        //    //比重率
        //    MetricSystem.SpecificGravityRate.DefaultValue = new DictionaryExt() { Key = "N_per_Pow_m_3_per_min", Value = "N/m^3/min" };
        //    units = new List<DictionaryExt>();
        //    units.Add(new DictionaryExt() { Key = "gf_per_Pow_cm_3_per_min", Value = "gf/cm^3/min" });
        //    units.Add(new DictionaryExt() { Key = "gf_per_Pow_cm_3_per_s", Value = "gf/cm^3/s" });
        //    units.Add(new DictionaryExt() { Key = "kgf_per_Pow_mm_3_per_min", Value = "kgf/mm^3/min" });
        //    units.Add(new DictionaryExt() { Key = "kgf_per_Pow_mm_3_per_s", Value = "kgf/mm^3/s" });

        //    MetricSystem.SpecificGravityRate.Units = units;
        //    //力
        //    MetricSystem.Force.DefaultValue = new DictionaryExt() { Key = "N", Value = "N" };
        //    units = new List<DictionaryExt>();
        //    units.Add(new DictionaryExt() { Key = "dyn", Value = "dyn" });
        //    units.Add(new DictionaryExt() { Key = "gf", Value = "gf" });
        //    units.Add(new DictionaryExt() { Key = "kgf", Value = "kgf" });
        //    units.Add(new DictionaryExt() { Key = "kkgf", Value = "kkgf" });
        //    units.Add(new DictionaryExt() { Key = "Mgf", Value = "Mgf" });
        //    MetricSystem.Force.Units = units;
        //    #endregion

        //    #region InternationalUnitsSystem初始化
        //    //百分比
        //    InternationalUnitsSystem.Percentage.DefaultValue = new DictionaryExt() { Key = "Persent", Value = "%" };
        //    units = new List<DictionaryExt>();
        //    units.Add(new DictionaryExt() { Key = "Persent", Value = "%" });
        //    InternationalUnitsSystem.Percentage.Units = units;
        //    //比重
        //    InternationalUnitsSystem.SpecificGravity.DefaultValue = new DictionaryExt() { Key = "N_per_Pow_m_3", Value = "N/m^3" };
        //    units = new List<DictionaryExt>();
        //    units.Add(new DictionaryExt() { Key = "gf_per_Pow_cm_3", Value = "gf/cm^3" });
        //    units.Add(new DictionaryExt() { Key = "kgf_per_Pow_cm_3", Value = "kgf/cm^3" });
        //    units.Add(new DictionaryExt() { Key = "kgf_per_Pow_mm_3", Value = "kgf/mm^3" });
        //    units.Add(new DictionaryExt() { Key = "lbf_per_Pow_ft_3", Value = "lbf/ft^3" });
        //    units.Add(new DictionaryExt() { Key = "lbf_per_Pow_in_3", Value = "lbf/in^3" });
        //    units.Add(new DictionaryExt() { Key = "N_per_Pow_cm_3", Value = "N/cm^3" });
        //    units.Add(new DictionaryExt() { Key = "N_per_Pow_m_3", Value = "N/m^3" });
        //    units.Add(new DictionaryExt() { Key = "N_per_Pow_mm_3", Value = "N/mm^3" });
        //    units.Add(new DictionaryExt() { Key = "ozf_per_Pow_in_3", Value = "ozf/in^3" });
        //    InternationalUnitsSystem.SpecificGravity.Units = units;
        //    //比重率
        //    InternationalUnitsSystem.SpecificGravityRate.DefaultValue = new DictionaryExt() { Key = "N_per_Pow_m_3_per_min", Value = "N/m^3/min" };
        //    units = new List<DictionaryExt>();
        //    units.Add(new DictionaryExt() { Key = "gf_per_Pow_cm_3_per_min", Value = "gf/cm^3/min" });
        //    units.Add(new DictionaryExt() { Key = "gf_per_Pow_cm_3_per_s", Value = "gf/cm^3/s" });
        //    units.Add(new DictionaryExt() { Key = "kgf_per_Pow_mm_3_per_min", Value = "kgf/mm^3/min" });
        //    units.Add(new DictionaryExt() { Key = "kgf_per_Pow_mm_3_per_s", Value = "kgf/mm^3/s" });
        //    units.Add(new DictionaryExt() { Key = "lbf_per_Pow_in_3_per_min", Value = "lbf/in^3/min" });
        //    units.Add(new DictionaryExt() { Key = "lbf_per_Pow_in_3_per_s", Value = "lbf/in^3/s" });
        //    units.Add(new DictionaryExt() { Key = "N_per_Pow_cm_3_per_min", Value = "N/cm^3/min" });
        //    units.Add(new DictionaryExt() { Key = "N_per_Pow_m_3_per_min", Value = "N/m^3/min" });
        //    units.Add(new DictionaryExt() { Key = "N_per_Pow_m_3_per_s", Value = "N/m^3/s" });
        //    units.Add(new DictionaryExt() { Key = "N_per_Pow_mm_3_per_min", Value = "N/mm^3/min" });
        //    units.Add(new DictionaryExt() { Key = "N_per_Pow_mm_3_per_s", Value = "N/mm^3/s" });
        //    InternationalUnitsSystem.SpecificGravityRate.Units = units;
        //    //力
        //    InternationalUnitsSystem.Force.DefaultValue = new DictionaryExt() { Key = "N", Value = "N" };
        //    units = new List<DictionaryExt>();
        //    units.Add(new DictionaryExt() { Key = "cN", Value = "cN" });
        //    units.Add(new DictionaryExt() { Key = "daN", Value = "daN" });
        //    units.Add(new DictionaryExt() { Key = "dN", Value = "dN" });
        //    units.Add(new DictionaryExt() { Key = "dyn", Value = "dyn" });
        //    units.Add(new DictionaryExt() { Key = "gf", Value = "gf" });
        //    units.Add(new DictionaryExt() { Key = "kgf", Value = "kgf" });
        //    units.Add(new DictionaryExt() { Key = "kip", Value = "kip" });
        //    units.Add(new DictionaryExt() { Key = "kkgf", Value = "kkgf" });
        //    units.Add(new DictionaryExt() { Key = "kN", Value = "kN" });
        //    units.Add(new DictionaryExt() { Key = "lbf", Value = "lbf" });
        //    units.Add(new DictionaryExt() { Key = "Mgf", Value = "Mgf" });
        //    units.Add(new DictionaryExt() { Key = "mlbf", Value = "mlbf" });
        //    units.Add(new DictionaryExt() { Key = "MN", Value = "MN" });
        //    units.Add(new DictionaryExt() { Key = "mN", Value = "mN" });
        //    units.Add(new DictionaryExt() { Key = "N", Value = "N" });
        //    units.Add(new DictionaryExt() { Key = "ozf", Value = "ozf" });
        //    InternationalUnitsSystem.Force.Units = units;
        //    #endregion
        //}
    }
    public class UnitSystemInfo
    {
        #region 单位源对象集
        //百分号
        public UnitInfo Percentage { get; set; } = new UnitInfo();
        //比重
        public UnitInfo SpecificGravity { get; set; } = new UnitInfo();
        //比重率
        public UnitInfo SpecificGravityRate { get; set; } = new UnitInfo();
        public UnitInfo Length { get; set; } = new UnitInfo();
        //力
        public UnitInfo Force { get; set; } = new UnitInfo();
        #endregion
        /// <summary>
        /// 根据单位源获取单位集合
        /// </summary>
        /// <param name="unitsetName">单位源名</param>
        /// <returns></returns>
        public UnitInfo FindUnitSet(string unitsetName)
        {
            UnitInfo unitInfo =null;
            PropertyInfo[] propertyInfos = this.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if(propertyInfo.Name == unitsetName)
                {
                    Object value = propertyInfo.GetValue(this);
                    unitInfo = (UnitInfo)value;
                }
            }
            return unitInfo;
        }
    }

    public class UnitInfo
    {
        //默认单位
        public DictionaryExt DefaultValue { get; set; }
        //单位集合
        public List<DictionaryExt> Units { get; set; }
    }
}

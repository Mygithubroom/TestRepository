using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.Common.Enum
{
    public enum UnitSystemEnum
    {
        ALL,
        //U.S. Customary Units  美国单位制
        AmericanStandard,
        //公制
        Metric,
        //SI Units国际单位制
        //InternationalUnitsSystem
        SI
    }
    /// <summary>
    /// 用于区分默认值设置规则
    /// </summary>
    public enum SpecimenParameterSourceEnum
    {
        DefaultValue,//默认值
        LastTestedSpecimen//上次试样设置的值
    }
    /// <summary>
    /// 
    /// </summary>
    public enum ApplicationTypeEnum
    {
        Blomedical,
        Composites,
        Elastomers,
        Plastics,
        Textiles,
        Torsion
    }
    /// <summary>
    /// 排序的类型
    /// </summary>
    public enum SortTypeEnum
    {
        //根据方法名升降序
        AscendingName,
        DescendingName,
        //根据方法类型名升降序
        AscendingType,
        DescendingType,
        //根据方法创建时间升降序
        AscendingTime,
        DescendingTime
    }
    public enum GeometryEnum
    {
        Rectangle,
        Round,
        /// <summary>
        /// 不规则形状
        /// </summary>
        IrregularShape,
        /// <summary>
        /// 管状
        /// </summary>
        Siphonate,
        /// <summary>
        /// 纤维
        /// </summary>
        Fiber,
        /// <summary>
        /// 双剪切环
        /// </summary>
        DoubleShearRing,
        /// <summary>
        /// 紧固件（美制）
        /// </summary>
        Fasteners_American,
        /// <summary>
        /// 紧固件（公制）
        /// </summary>
        Fasteners_Metric,

        /// <summary>
        /// 管截面（Tube Section）
        /// </summary>
        ThePipeSection_TubeSection,
        /// <summary>
        /// 管截面（Pipe Section）
        /// </summary>
        ThePipeSection_PipeSection,
        /// <summary>
        /// 管(Pipe)
        /// </summary>
        Pipe
        /**
         * Tube和Pipe区别
         * 1. 形状不同：tube有正方形管口的，有长方形管口的，也有圆形的；pipe都是圆形的；
         * 2. 韧性不同：tube有刚性的，也有紫铜、黄铜做的挠性tube；pipe都是刚性的，抗弯折；
         * 3. 分类方式不同：tube按外径和壁厚；pipe按壁厚代码pipe schedule和nominal diameter(欧标)=national pipe size(美标)
         * 4. 使用环境不同：tube用于需要小管径的情况，10英寸的tube罕见；pipe用于需要大管径的情况，10英寸的pipe很常见，从半英寸到几英尺的pipe都有；
         * 5. 要求侧重点不一样：tube注重外径精确，因为这牵涉到承压，用于cooler tube, heat exchanger tube，boiler tube；pipe注重壁厚，因为pipe主要输送流体，对内部受压能力要求高；
         * 6. 壁厚等级后壁厚的关系不同：tube的壁厚级别升高1级，壁厚增加1mm或者2mm，增幅固定不变；而pipe的壁厚用schedule来表示，各个等级数值关系不定，比如1/8〞(NPS)=6mm(DN)的Sch.20的壁厚大概是1.245mm，而Sch.30的壁厚大概是1.448mm，但是Sch.40却是1.727mm，增幅不一致，因为Sch实际是（设计压力/设计温度允许的应力）x 1000
         * 7. 连接方式不一样：tube可以快速连接，连接不费劲，可以用扩口，也可以铜焊，还可以用coupling；pipe的连接属于费劳力型的，可以焊接，也可以用螺纹连接，还可以用法兰连接；
         * **/
    }
}

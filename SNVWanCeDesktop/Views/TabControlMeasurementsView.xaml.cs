using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Common.DAO;
using WanCeDesktopApp.Extensions;

namespace WanCeDesktopApp.Views
{
    /// <summary>
    /// TabControlMeasurementsView.xaml 的交互逻辑
    /// </summary>
    public partial class TabControlMeasurementsView : UserControl
    {
        private int loadCount;

        public TabControlMeasurementsView()
        {
            InitializeComponent();
            DeterMiniedParamePanel.Visibility = Visibility.Collapsed;
            if (DeterMiniedParametersList.Items.Count > 0)
            {
                DeterMiniedParametersList.SelectedItem = DeterMiniedParametersList.Items[0];
                DeterMiniedParamePanel.Visibility = Visibility.Visible;
            }
            Init();
        }

        private void Init()
        {
            //UnitItems.
        }

        public void SetCollapsed()
        {
            //传感器配置
            SensorSettingPanel.Visibility = Visibility.Collapsed;
            //接头
            JointPanel.Visibility = Visibility.Collapsed;
            BasicSourcePanel.Visibility = Visibility.Collapsed;
            UnitGroupPanel.Visibility = Visibility.Collapsed;
            DisplacementSourcePanel.Visibility = Visibility.Collapsed;
            LoadSourcePanel.Visibility = Visibility.Collapsed;
            SourceOfStrainPanel.Visibility = Visibility.Collapsed;
            TrueStrainControlPanel.Visibility = Visibility.Collapsed;
            TransverseStrainPanel.Visibility = Visibility.Collapsed;
            DataPointNumberPanel.Visibility = Visibility.Collapsed;
            PoissionRatePanel.Visibility = Visibility.Collapsed;
            //表达式
            ExpressionPanel.Visibility = Visibility.Collapsed;
            ComplianceFilePanel.Visibility = Visibility.Collapsed;
            EliminationOfElasticStrainPanel.Visibility= Visibility.Collapsed;
            TransverseStrainGaugeWidthPanel.Visibility = Visibility.Collapsed;
            //预实验限位
            PreTestLimitPanel.Visibility = Visibility.Collapsed;
            //速率
            RatePanel.Visibility = Visibility.Collapsed;

        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox box = sender as CheckBox;
            string temp = box.Tag?.ToString();
            if (!string.IsNullOrEmpty(temp))
            {
                var panel = this.FindName(temp) as Panel;
                panel.Visibility = Visibility.Collapsed;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox box = sender as CheckBox;
            string temp = box.Tag?.ToString();
            if (!string.IsNullOrEmpty(temp))
            {
                var panel = this.FindName(temp) as Panel;
                panel.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// 跳转界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DeterMiniedParametersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetCollapsed();
            GaugeItemInfo itemInfo = DeterMiniedParametersList.SelectedItem as GaugeItemInfo;
            if (itemInfo == null)
            {
                DeterMiniedParamePanel.Visibility = Visibility.Collapsed;
                return;
            }
            else
            {
                DeterMiniedParamePanel.Visibility = Visibility.Visible;
            }
            if (itemInfo.Index == -1)
            {
                btnMoveToLeft.IsEnabled = false;
            }
            else
            {
                btnMoveToLeft.IsEnabled = true;
            }
            if (itemInfo.Id == 0)//实物测量
            {
                //读取部分ViewModel实现
                switch (itemInfo.GaugeType)
                {
                    //时间
                    case "Time":
                        break;
                        //载荷
                    case "Load":
                        //传感器配置
                        SensorSettingPanel.Visibility = Visibility.Visible;
                        //读取传感器
                        List<DictionaryExt> dictionaries = new List<DictionaryExt>();
                        dictionaries.Add(new DictionaryExt() { Key = "Sensor2", Value = "载荷 2" });
                        dictionaries.Add(new DictionaryExt() { Key = "Sensor3", Value = "载荷 3" });
                        CMBSensor.ItemsSource = dictionaries;
                        CMBSensor.SelectedIndex = 0;
                        //itemInfo.Title = 
                        //接头
                        JointPanel.Visibility = Visibility.Visible;
                        //读取接头
                        List<DictionaryExt>  dictionaries1 = new List<DictionaryExt>();
                        dictionaries1.Add(new DictionaryExt() { Key = "Joint1", Value = "接头 1" });
                        dictionaries1.Add(new DictionaryExt() { Key = "Joint2", Value = "接头 2" });
                        CMBJoint.ItemsSource = dictionaries1;
                        CMBJoint.SelectedIndex = 0;

                        //说明赋值规则：传感器名字_数值

                        PreTestLimitPanel.Visibility = Visibility.Visible;
                        RatePanel.Visibility = Visibility.Visible;
                        break;
                        //应变
                    case "Strain":
                        //传感器配置
                        SensorSettingPanel.Visibility = Visibility.Visible;
                        //读取传感器
                        List<DictionaryExt> list = new List<DictionaryExt>();
                        list.Add(new DictionaryExt() { Key = "Strain1", Value = "应变 1" });
                        list.Add(new DictionaryExt() { Key = "Strain2", Value = "应变 2" });
                        CMBSensor.ItemsSource = list;
                        CMBSensor.SelectedIndex = 0;
                        //接头
                        JointPanel.Visibility = Visibility.Visible;
                        //读取接头
                        list = new List<DictionaryExt>();
                        list.Add(new DictionaryExt() { Key = "Joint1", Value = "接头 1" });
                        list.Add(new DictionaryExt() { Key = "Joint2", Value = "接头 2" });
                        CMBJoint.ItemsSource = list;
                        CMBJoint.SelectedIndex = 0;
                        //说明赋值规则：传感器名字_数值

                        PreTestLimitPanel.Visibility = Visibility.Visible;
                        RatePanel.Visibility = Visibility.Visible;
                        TrueStrainControlPanel.Visibility = Visibility.Visible;
                        break;
                        //扭矩
                    case "Displacement":
                        PreTestLimitPanel.Visibility = Visibility.Visible;
                        RatePanel.Visibility = Visibility.Visible;
                        TrueStrainControlPanel.Visibility = Visibility.Visible;
                        UnitInfo info = UnitSystemProvider.GetUnitInfo(itemInfo.UnitSetName);
                        //EditUnit.SelectedItem = info.DefaultValue;
                        //EditUnit.SelectedValue = info.DefaultValue;
                        //EditUnit.Text = info.DefaultValue.Value;
                        //EditUnit.SelectedIndex = 2;
                        //if (itemInfo.IsPreTestLimit)
                        //{

                        //}
                        //速率说明，测量说明+速率
                        break;
                    case "Torque":
                        MessageBox.Show("此物理测量没有传感器配置。必须创建扭矩传感器配置。请在“管理“选项卡上的“配置>传感器“屏幕中创建传感器配置。\n如果已启用“安全性“，则您必须具有管理员权限，才能访问“配置 > 传感器“屏幕。", "Tips");
                        break;

                    case "UserDesign":
                        break;
                    default:
                        break;
                }
            }
            else//虚拟测量
            {
                switch (itemInfo.GaugeType)
                {
                    case "Stress":
                        break;
                    case "Strain(Displacement)":
                        break;
                    case "Displacement":
                        break;
                    case "Expression":
                        UnitGroupPanel.Visibility = Visibility.Visible;
                        ExpressionPanel.Visibility = Visibility.Visible;
                        PreTestLimitPanel.Visibility = Visibility.Visible;
                        RatePanel.Visibility = Visibility.Visible;
                        break;
                    default:
                        break;
                }
            }
            //WorkspaceInputTypeInfo pWorkspaceInputTypeInfo = (WorkspaceInputTypeInfo)DeterMiniedParametersList.SelectedItem;
            //if (pWorkspaceInputTypeInfo == null)
            //{
            //    return;
            //}
            //ChangePanel(Tools.ToString(pWorkspaceInputTypeInfo.Content));
        }

        /// <summary>
        /// 判断是否是第一次添加参数，因为第一次添加参数不会触发SelectionChanged事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstDeterMiniedParameMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DeterMiniedParametersList.Items.Count <= 0)
            {
                DeterMiniedParamePanel.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// 根据名称调整界面是否显示
        /// </summary>
        /// <param name="sName"></param>
        private void ChangePanel(string sName)
        {
            ////如果没有找到对应的界面就用基础界面代替
            //BaseParamentPanel.Visibility = sName == "" ? Visibility.Visible : Visibility.Collapsed;
        }

        private void BtnMove_Click(object sender, RoutedEventArgs e)
        {
            if (DeterMiniedParametersList.Items.Count <= 0)
            {
                DeterMiniedParamePanel.Visibility = Visibility.Visible;
            }
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ContentControl contentControl = this.Parent as ContentControl;
            FrameworkElement parentControl = Tools.FindVisualParent<FrameworkElement>(contentControl, "IndexViewRegion");
            treeView.Height = parentControl.RenderSize.Height - 120;
            DeterMiniedParametersList.Height = parentControl.RenderSize.Height - 120;
            EditPanelScroll.Height = parentControl.RenderSize.Height - 120;
        }

        private void EditUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            GaugeItemInfo itemInfo = DeterMiniedParametersList.SelectedItem as GaugeItemInfo;
            if(itemInfo == null || EditUnit.SelectedValue == null) { return; }
            itemInfo.Unit = EditUnit.SelectedValue.ToString();
        }
    }
}


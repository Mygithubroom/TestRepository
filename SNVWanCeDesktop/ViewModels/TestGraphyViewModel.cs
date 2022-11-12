using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using WanCeDesktopApp.Common;
using PlotControlLibrary.Events;
using PlotControlLibrary.Events.Payloads;
using PlotControlLibrary.Common;
using OxyPlot.Axes;
using OxyPlot;
using Prism.Regions;
using System.IO;
using System.Linq;

namespace WanCeDesktopApp.ViewModels
{
    //曲线模块导入
    public class TestGraphyViewModel : BindableBase
    {
        public ObservableCollection<SoftKeyInfo> SoftKeyBars { get; set; }
        public DelegateCommand<object> RunFunction { get; private set; }
        public DelegateCommand<object> StopFunction { get; private set; }
        public DelegateCommand SendMessageCommand { get; private set; }

      

        TestGraphyViewModel(IEventAggregator eventAggregator)
        {
            SoftKeyBars = new ObservableCollection<SoftKeyInfo>();
            SoftKeyBars = Collections.SoftKeyItems;
            RunFunction = new DelegateCommand<object>(Run);
            StopFunction = new DelegateCommand<object>(Stop);
            init(eventAggregator);


        }
        public void init(IEventAggregator eventAggregator)
        {
            try
            {
                ////曲线控件初始化
                var channelDataBundle = new List<TestChannelData>()
                {  new TestChannelData(
                                "Force",
                                "力",
                                "N",
                                OxyColors.Black,
                                AxisPosition.Left,
                                ChannelInitMode.DisplayOnStart
                                    | ChannelInitMode.NeedLogarithmicAxis
                            ),
                 new TestChannelData(
                                    "Time",
                                    "时间",
                                    "s",
                                    OxyColors.Black,
                                    AxisPosition.Bottom,
                                    ChannelInitMode.DisplayOnStart
                                    )
                };

                var components = new BuiltinComponents[]
                {
                  new BuiltinComponents(channelDataBundle)
                };

                string[] BuildTargetList(string target)
                {
                    string[] targetList;
                    if (target == "Both")
                    {
                        targetList = new[] { "LeftPlot", "RightPlot" };
                    }
                    else
                    {
                        targetList = new[] { target };
                    }
                    return targetList;
                }
                string target = new string("MyPlot");
                OxyInitMode initMode;
                initMode = OxyInitMode.SingleYAxis;
                string[] targetList = BuildTargetList(target);
                eventAggregator.GetEvent<InitEvent>().Publish(new InitEventPayload(targetList, initMode, components));
            }
            catch (Exception ex)
            {

            }
        }


        public void Run(object sender) //点击开始试验
        {
            //操作曲线方式以发送事件为主
            //绘制曲线
        }

        public void Stop(object sender)//点击停止试验
        {
            //试验停止
        }
    }
}

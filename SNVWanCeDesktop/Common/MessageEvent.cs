using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common.DAO;

namespace WanCeDesktopApp.Common
{
    public class Message
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Filter { get; set; }

        private string[] BuildTargetList(string target)
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

    }

    public class MessageEvent : PubSubEvent<Message>
    {

    }
    public class GaugeItemInfosEvent : PubSubEvent<List<GaugeItemInfo>>
    {

    }

  
    public class GaugeItemInfoEvent : PubSubEvent<GaugeItemInfo>
    {

    }
}

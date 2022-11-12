using Prism.Mvvm;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp
{
    public class ShutdownRemindViewModel : BindableBase
    {
        private List<ShutdownRemind> lstShutdownRemind = new List<ShutdownRemind>();
        public List<ShutdownRemind> LstShutdownRemind
        {
            get { return lstShutdownRemind; }
            set { lstShutdownRemind = value; RaisePropertyChanged(); }
        }
        public ShutdownRemindViewModel()
        {
            Init();

        }

        private void Init()
        {
            InitData();
        }

        private void InitData()
        {
            LstShutdownRemind.Clear();
            ShutdownRemind pModel = new ShutdownRemind();
            pModel.Describe = "机器清洁";
            pModel.Remind = "是";
            LstShutdownRemind.Add(pModel);
            pModel = new ShutdownRemind();
            pModel.Describe = "是否关闭电源";
            pModel.Remind = "否";
            lstShutdownRemind.Add(pModel);
        }
    }

    public class ShutdownRemind
    {
        public string Describe { get; set; }

        public string Remind { get; set; }

    }
}

using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp
{
    public class MaintainingViewModel : BindableBase
    {

        private List<MaintainingOne> lstMaintainingOne = new List<MaintainingOne>();
        private List<MaintainingTwo> lstMaintainingTwo = new List<MaintainingTwo>();
        public List<MaintainingOne> LstMaintainingOne
        {
            get { return lstMaintainingOne; }
            set { lstMaintainingOne = value; RaisePropertyChanged(); }
        }

        public List<MaintainingTwo> LstMaintainingTwo
        {
            get { return lstMaintainingTwo; }
            set { lstMaintainingTwo = value; RaisePropertyChanged(); }
        }

        public MaintainingViewModel()
        {
            Init();
        }

        private void Init()
        {
            InitData();
        }

        private void InitData()
        {
            LstMaintainingOne.Clear();
            LstMaintainingTwo.Clear();
            MaintainingOne pModel = new MaintainingOne();
            pModel.Date = DateTime.Now.ToString();
            pModel.TotalStartupTime = "20H59m59s";
            pModel.TotalOperationTime = "10h";
            pModel.TotalNumberOfTests = "56";
            pModel.TypeOfTest = "未知";
            pModel.TestMaterial = "塑料";
            LstMaintainingOne.Add(pModel);

            MaintainingTwo pMaintainingTwo = new MaintainingTwo();
            pMaintainingTwo.ParetsName = "钳口";
            pMaintainingTwo.TheWearTypes = "磨粒磨损";
            pMaintainingTwo.DegreeOfWear = "一般";
            pMaintainingTwo.WearRate = "10";
            pMaintainingTwo.WearFactors = "力";
            pMaintainingTwo.MaintenanceAdvice = "清洁";
            pMaintainingTwo.AReminderDate = DateTime.Now.ToString();
            LstMaintainingTwo.Add(pMaintainingTwo);
        }
    }
}

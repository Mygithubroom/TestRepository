
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.ViewModels
{
    public class TestControlStartTestViewModel: BindableBase
    {

        public string startTestFlage;
        public string SetOut;
        public string StartTestFlage { get=> startTestFlage; set { startTestFlage = value; RaisePropertyChanged(); } }

    }
}

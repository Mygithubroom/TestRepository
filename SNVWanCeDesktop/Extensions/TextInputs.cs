using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.Extensions
{
    public class TextInputs:BindableBase
    {
        #region
        private string content = "";
        private string text = "";
        private bool isCheck;
        private string unit = "";
        public string Content
        { get { return content; }
            set { content = value;RaisePropertyChanged(); } 
        }

        public bool IsCheck
        { get { return isCheck; }
        set { isCheck = value; } 
        }

        public string Text { 
            get { return text; } 
            set { text = value; RaisePropertyChanged(); } 
        }

        #endregion
    }
}

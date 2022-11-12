using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WanCeDesktopApp.Common
{
    public class BaseInfo : BindableBase
    {

        private int id;
        private string description = "";
        private string content = "";
        //id
        public int Id { get => id; set => id = value; }
        //描述
        public string Description { get => description; set { description = value; RaisePropertyChanged(); } }
        //内容
        public string Content { get => content; set { content = value; RaisePropertyChanged(); } }
        public override string ToString()
        {
            return Content;
        }
    }
}

using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Views.Dialogs;

namespace WanCeDesktopApp.ViewModels
{
 
    public class SetSensorViewModel : BindableBase
    {
        public static UInt16 i = 0;

        public IDialogHostService dialog;
        private string[] SersorArray = {
            "温度" ,
            "扭矩",
            "应变",
            "力",            
            "用户自定义",
         };
        private ObservableCollection<ShowInfo> availableSersorLists = new ObservableCollection<ShowInfo>();
        private ObservableCollection<ShowInfo> selectedSersorLists = new ObservableCollection<ShowInfo>();
        private string inputText = "";
        private List<string> list = new List<string>();
        public DelegateCommand<ShowInfo> MoveToRightCommand { get; private set; } //向右穿梭按钮绑定
        public DelegateCommand<ShowInfo> MoveToLeftCommand { get; private set; } //向左穿梭按钮绑定
        public DelegateCommand<ShowInfo> UpDataText { get; private set; } //列表选择有更改的事件触发
        public DelegateCommand OpenDialogCommand { get; private set; } //检定与校准


        public string InputText //TextBox 绑定的属性
        {
            get => inputText;
            set { inputText = value; 
                if(SelectedShowInfo!=null)
                SelectedShowInfo.Content = value;
                RaisePropertyChanged(); }
        }
        public ObservableCollection<ShowInfo> AvailableSersorLists//左侧可选列表绑定
        {
            get => availableSersorLists;
            set { availableSersorLists = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<ShowInfo> SelectedSersorLists //右侧已选择的列表绑定
        {
            get => selectedSersorLists;
            set { selectedSersorLists = value; RaisePropertyChanged(); }
        }

        private ShowInfo selectedShowInfo;
        /// <summary>
        /// 已选中元素
        /// </summary>
        public ShowInfo SelectedShowInfo
        {
            get { return selectedShowInfo; }
            set { selectedShowInfo = value;RaisePropertyChanged(); }
        }

        SetSensorViewModel(IDialogHostService dialogHostService)
        {
            InitCalculationList();
            this.dialog = dialogHostService;
        }
        public void InitCalculationList()
        {
            MoveToRightCommand = new DelegateCommand<ShowInfo>(MoveRight);
            MoveToLeftCommand = new DelegateCommand<ShowInfo>(MoveLeft);
            UpDataText = new DelegateCommand<ShowInfo>(UpText);
            OpenDialogCommand = new DelegateCommand(OpenDialog);



            Array.Sort(SersorArray);
            foreach (string strValue in SersorArray)
            {
                AvailableSersorLists.Add( new ShowInfo() { Content = strValue });
            }
        }
        private void MoveRight(ShowInfo obj)
        {
            if (obj == null)
            {
                return;
            }
            bool btemp = list.Contains(obj.Content);

            ShowInfo tmpShowInfo = new ShowInfo();
            tmpShowInfo.Content = obj.Content;

            if (btemp) //判断是否有重复
            {
                for (int i = 1; i <= list.Count; i++)
                {
                    string stmp = tmpShowInfo.Content + i.ToString();

                    bool btmp = list.Contains(stmp);

                    if (btmp)
                    {
                        continue;
                    }
                    else
                    {
                        list.Add(stmp);
                        tmpShowInfo.Content = stmp;
                        SelectedSersorLists.Add(tmpShowInfo);
                        break;
                    }
                }
            }
            else
            {
                list.Add(tmpShowInfo.Content);
                SelectedSersorLists.Add(tmpShowInfo);
            }
        }
        private void MoveLeft(ShowInfo obj)
        {
            if (obj == null)
            {
                return;
            }
            string str = obj.Content;
            SelectedSersorLists.Remove(obj);
            list.Remove(obj.Content);
        }
        private void UpText(ShowInfo info) //列表选择有更改时的触发事件处理。
        {
            if (info == null)
            {
                return;
            }
            else
            {
                InputText = info.Content;  //可正常获取到列表所选择的内容，赋值给TextBox的绑定属性。更新TextBox文本
            }
        }
        //系统调用，打开检定程序
        [DllImport("kernel32.dll")] public static extern int WinExec(string programPath, int operType);
        private void OpenDialog()//传感器检定逻辑实现//暂时使用老软件进行配置
        {
            string pathStr = @"D:\TestPilot_X10A\DTC500 Installation Center.exe";
            var result = WinExec(pathStr, 5);
            
        }
    }
}

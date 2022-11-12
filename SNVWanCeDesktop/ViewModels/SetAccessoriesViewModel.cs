using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common;

namespace WanCeDesktopApp.ViewModels
{
    public class SetAccessoriesViewModel : BindableBase
    {
        private string[] AccessoriesArray = {
            "高温炉" ,
            "引伸计",
            "大变型",
            "视频引伸计",
            "用户自定义",                
         };
        private ObservableCollection<ShowInfo> availableAccessoriesLists = new ObservableCollection<ShowInfo>();
        private ObservableCollection<ShowInfo> selectedAccessoriesLists = new ObservableCollection<ShowInfo>();
        private string inputText = "";
        public DelegateCommand<ShowInfo> MoveToRightCommand { get; private set; }
        public DelegateCommand<ShowInfo> MoveToLeftCommand { get; private set; }
        public DelegateCommand<ShowInfo> UpDataText { get; private set; }
        
        public string InputText
        {
            get => inputText;
            set { inputText = value;RaisePropertyChanged(); }
        }
        public ObservableCollection<ShowInfo> AvailableAccessoriesLists
        {
            get => availableAccessoriesLists;
            set { availableAccessoriesLists = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<ShowInfo> SelectedAccessoriesLists
        {
            get => selectedAccessoriesLists;
            set { selectedAccessoriesLists = value; RaisePropertyChanged(); }
        }

        SetAccessoriesViewModel()
        {
            InitCalculationList();
        }
        public void InitCalculationList()
        {
            MoveToRightCommand = new DelegateCommand<ShowInfo>(MoveRight);
            MoveToLeftCommand = new DelegateCommand<ShowInfo>(MoveLeft);
            UpDataText = new DelegateCommand<ShowInfo>(UpText);
            Array.Sort(AccessoriesArray);
            foreach (string strValue in AccessoriesArray)
            {
                AvailableAccessoriesLists.Add(new ShowInfo() { Content = strValue });
            }
        }
        private void MoveRight(ShowInfo obj)
        {
            if (obj == null)
            {
                return;
            }
            string str = obj.Content;
            AvailableAccessoriesLists.Remove(obj);
            SelectedAccessoriesLists.Add(new ShowInfo() { Content = str });
        }
        private void MoveLeft(ShowInfo obj)
        {
            if (obj == null)
            {
                return;
            }
            string str = obj.Content;
            SelectedAccessoriesLists.Remove(obj);
            AvailableAccessoriesLists.Add(new ShowInfo() { Content = str });
        }
        private void UpText(ShowInfo info)
        {
            if (info == null)
            {
                return;
            }
            else
            {
                InputText = info.Content;
            }            
        }
    }
}

using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Spreadsheet;
using ImTools;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Common.DAO;
using WanCeDesktopApp.Extensions;
using WanCeDesktopApp.Views;
using WanCeDesktopApp.Views.Dialogs;

namespace WanCeDesktopApp.ViewModels
{
    public class SampleNumberInputsViewModel : BindableBase
    {
        private ObservableCollection<GaugeItemInfo> sampleNumberInputs =
            new ObservableCollection<GaugeItemInfo>(); //注册菜单
        public DelegateCommand<GaugeItemInfo> CheckCommand { get; private set; }
        private IDialogHostService dialogService; //自定义对话框
        private readonly IEventAggregator aggregator;
        #region
        public DelegateCommand<GaugeItemInfo> ExecuteShowDialogCommand
        {
            get;
            private set;
        }

        public ObservableCollection<GaugeItemInfo> SampleNumberInputs
        {
            get { return sampleNumberInputs; }
            set
            {
                sampleNumberInputs = value;
                RaisePropertyChanged();
            }
        }

        #endregion
        SampleNumberInputsViewModel(IDialogHostService dialog, IEventAggregator eventAggregator)
        {
            this.dialogService = dialog;
            this.aggregator = eventAggregator;
            InitItem();
            CheckCommand = new DelegateCommand<GaugeItemInfo>(Check);
            ExecuteShowDialogCommand = new DelegateCommand<GaugeItemInfo>(Excute);
        }

        void InitItem()
        {
            try
            {
                SampleNumberInputs = Collections.Sample.NumberInputs;
            }
            catch (System.NullReferenceException ex) { }
            catch (Exception ex) { }
        }

        private void Check(GaugeItemInfo obj)
        {
            try
            {
                if (obj.IsChecked)
                {
                    if (
                        SampleNumberInputs.IndexOf(obj)
                        == SampleNumberInputs.Count - 1
                    )
                    {
                        int mark = SampleNumberInputs.Count;
                        GaugeItemInfo inputInfo = new GaugeItemInfo() {Id=obj.Id, DefaultTitleKey = "SampleNumberInput", IsChecked = false, DisplayValue = "0", Index = mark };
                        SampleNumberInputs.Add(inputInfo);
                    }
                }
                else
                {
                    if (
                        SampleNumberInputs.IndexOf(obj)
                        != SampleNumberInputs.Count - 2
                    )
                    {
                        return;
                    }
                    if (SampleNumberInputs.Count >= 2)
                    {
                        for (int i = SampleNumberInputs.Count - 1; i > 0; i--)
                        {
                            if (SampleNumberInputs[i - 1].IsChecked)
                            {
                                break;
                            }
                            SampleNumberInputs.RemoveAt(i);
                        }
                        //试样数字输入等有关表达式的参数删除时处理
                        //coding
                    }
                }
            }
            catch (System.NullReferenceException ex) { }
            catch (Exception ex) { }
        }

        private void Excute(GaugeItemInfo item)
        {
            try
            {
                if (item == null)
                {
                    return;
                }
                DialogParameters param = new DialogParameters();
                param.Add("Title", "Properties - Sample Number input");
                param.Add("Obj", item);
                var dialogresult = dialogService.ShowDialog(
                    nameof(NumberInputsDialogView),
                    param,
                    callback =>
                    {
                        if (callback.Result == ButtonResult.OK)
                        {
                            var obj = callback.Parameters.GetValue<GaugeItemInfo>("Obj");
                            if (obj != null)
                            {
                                item.Title = obj.Title;
                                item.DecimalPlaces = obj.DecimalPlaces;
                                item.DisplayValue = obj.DisplayValue;
                                item.IsPreTestLimit = obj.IsPreTestLimit;
                                item.PreMaximum = obj.PreMaximum;
                                item.PreMinimum = obj.PreMinimum;
                                item.Unit = obj.Unit;
                                item.UnitSetName = obj.UnitSetName;
                                aggregator.GetEvent<MessageEvent>().Publish(new Message() { Title = item.UnitSetName, Content = item.Unit, Filter = "SampleNumberInputsView" });
                            }
                        }
                    }
                );
            }
            catch (System.NullReferenceException ex) { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

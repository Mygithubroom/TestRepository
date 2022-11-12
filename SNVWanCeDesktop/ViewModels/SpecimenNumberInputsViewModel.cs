using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
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
using WanCeDesktopApp.Views.Dialogs;

namespace WanCeDesktopApp.ViewModels
{
    public class SpecimenNumberInputsViewModel : BindableBase
    {
        
        private ObservableCollection<GaugeItemInfo> specimenNumberInputs = new ObservableCollection<GaugeItemInfo>();//注册菜单
        public DelegateCommand<GaugeItemInfo> CheckCommand { get; private set; }
        private IDialogHostService dialogService;//自定义对话框
        private IEventAggregator aggregator;
        #region
        public DelegateCommand<GaugeItemInfo> ExecuteShowDialogCommand { get; private set; }

        public ObservableCollection<GaugeItemInfo> SpecimenNumberInputs
        {
            get { return specimenNumberInputs; }
            set { specimenNumberInputs = value; RaisePropertyChanged(); }
        }

        #endregion
        SpecimenNumberInputsViewModel(IDialogHostService dialog, IEventAggregator eventAggregator)
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
                //Collections.Specimen.NumberInputs.Add(new GaugeItemInfo() { DefaultTitleKey = "SpecimenNumberInput", IsChecked = true, DisplayValue = "0" ,Index=0});
                //Collections.Specimen.NumberInputs.Add(new GaugeItemInfo() { DefaultTitleKey = "SpecimenNumberInput", IsChecked = false, DisplayValue = "0", Index = 1 });
                SpecimenNumberInputs = Collections.Specimen.NumberInputs;
            }
            catch (System.NullReferenceException ex)
            {
                
            }
            catch (Exception ex)
            {
                
            }
        }

        private void Check(GaugeItemInfo obj)
        {
            try
            {
                if (obj.IsChecked)
                {
                    if (SpecimenNumberInputs.IndexOf(obj) == SpecimenNumberInputs.Count - 1)
                    {
                        int mark = SpecimenNumberInputs.Count;
                        GaugeItemInfo inputInfo = new GaugeItemInfo() { Id = obj.Id, DefaultTitleKey = "SpecimenNumberInput", IsChecked = false, DisplayValue = "0",Index=mark };
                        //if (SpecimenNumberInputs.ToList().Exists(fild=>fild.DefaultTitleKey== "SpecimenNumberInput")) inputInfo.Tag ="("+ mark + ")";
                        SpecimenNumberInputs.Add(inputInfo);
                    }
                }
                else
                {
                    if (SpecimenNumberInputs.IndexOf(obj) != SpecimenNumberInputs.Count - 2)
                    {
                        return;
                    }
                    if (SpecimenNumberInputs.Count >= 2)
                    {
                        for (int i = SpecimenNumberInputs.Count - 1; i > 0; i--)
                        {
                            if (SpecimenNumberInputs[i - 1].IsChecked)
                            {
                                break;
                            }
                            SpecimenNumberInputs.RemoveAt(i);
                        }
                    }
                }
            }
            catch (System.NullReferenceException ex)
            {
                
            }
            catch (Exception ex)
            {
                
            }
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
                param.Add("Title", "Properties - Specimen Number input");
                param.Add("Obj", item);
                var dialogresult = dialogService.ShowDialog(nameof(NumberInputsDialogView), param, callback =>
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
                            aggregator.GetEvent<MessageEvent>().Publish(new Message() { Title = item.UnitSetName, Content = item.Unit, Filter = "SpecimenNumberInputsView" });
                        }
                    }
                });
            }
            catch (System.NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private void Excute(string str)
        //{
            
            
            
        //    try
        //    {
        //        if (str == "NumberInputsDialogView")
        //        {
        //            dialogService.ShowDialog("NumberInputsDialogView", null);//自定义对话框
        //        }
        //    }
        //    catch (System.NullReferenceException ex)
        //    {
                
        //    }
        //    catch (Exception ex)
        //    {
                
        //    }
        //}
    }
}

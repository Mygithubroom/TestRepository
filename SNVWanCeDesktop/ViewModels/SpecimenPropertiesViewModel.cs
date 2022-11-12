using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Common.DAO;
using WanCeDesktopApp.Extensions;
using WanCeDesktopApp.Views.Dialogs;

namespace WanCeDesktopApp.ViewModels
{
    public class SpecimenPropertiesViewModel : BindableBase
    {
        /// <summary>
        /// 数据与控件绑定的属性 start
        /// </summary>
        public string methodid; //方法id
        public string specmentparamid; //试样参数id
        public string geometry;//试样型态
        public string width;//宽
        public string thickness;//厚
        public string length; //长
        public string fixtureseparation;//平行距离
        public string finalwidth;//最终宽
        public string finalthickness;//最终厚度
        public string finallength;//最终长度
        public string pitch; //齿距
        public string lineardensity;//线密度
        public string externaldiameter; //外径

        public string MethodID { get => methodid; set { methodid = value; RaisePropertyChanged(); } } //方法ID
        public string SpecmentParamID { get => specmentparamid; set { specmentparamid = SpecmentParamID; RaisePropertyChanged(); } } //试样参数ID
        public string Geometry { get => geometry; set { geometry = value; RaisePropertyChanged(); } }//试样型态
        public string Width { get => width; set { width = value; RaisePropertyChanged(); } }//宽
        public string Thickness { get => thickness; set { thickness = value; RaisePropertyChanged(); } }//厚
        public string Length { get => length; set { length = value; RaisePropertyChanged(); } } //长
        public string FixtureSeparation { get => fixtureseparation; set { fixtureseparation = value; RaisePropertyChanged(); } }//平行距离
        public string FinalWidth { get => finalwidth; set { finalwidth = value; RaisePropertyChanged(); } }//最终宽
        public string FinalThickness { get => finalthickness; set { finalthickness = value; RaisePropertyChanged(); } }//最终厚度
        public string FinalLength { get => finallength; set { finallength = value; RaisePropertyChanged(); } }//最终长度
        public string Pitch { get => pitch; set { pitch = value; RaisePropertyChanged(); } } //齿距
        public string LinearDensity { get => lineardensity; set { lineardensity = value; RaisePropertyChanged(); } }//线密度
        public string ExternalDiameter { get => externaldiameter; set { externaldiameter = value; RaisePropertyChanged(); } } //外径
        /// <summary>
        /// 数据与控件绑定的属性 end
        /// </summary>


        public DelegateCommand<object> SelectionChangedCommand
        {
            get;
            private set;
        }

        private IDialogHostService dialogService;
        private ObservableCollection<ShowInfo> lstGenmetryProperties =
            new ObservableCollection<ShowInfo>(); //注册菜单
        public ObservableCollection<ShowInfo> LstGenmetryProperties
        {
            get => lstGenmetryProperties;
            set
            {
                lstGenmetryProperties = value;
                RaisePropertyChanged();
            }
        }
        public ShowInfoEx SpecimenPropNote { get; set; }
        public SpecimenGeometryInfo SpecimenPropGeometry { get; set; }
        public ICommand ExecuteShowNoteDialogCommand { get; private set; }
        public ICommand ExecuteShowGeometryDialogCommand { get; private set; }
        public ICommand ExecuteShowGeometryPropDialogCommand
        {
            get;
            private set;
        }
        public ICommand StartTextChangedCommand {
            get;
            private set;
        }
        
        //几何图形所必备的基本属性数组
        private string[][] aGenmetryProperties;

        SpecimenPropertiesViewModel(IDialogHostService dialogService)
        {
            Init();
            this.dialogService = dialogService;

            SpecimenPropNote = new() { DefaultTitleKey = "Specimen label" };
            SpecimenPropGeometry = new() { DefaultTitleKey = "Geometry" };

            ExecuteShowNoteDialogCommand = new DelegateCommand<ShowInfoEx>(
                ExecuteShowNoteDialog
            );
            ExecuteShowGeometryDialogCommand =
                new DelegateCommand<SpecimenGeometryInfo>(
                    ExecuteShowGeometryDialog
                );
            ExecuteShowGeometryPropDialogCommand =
                new DelegateCommand<ShowInfo>(ExecuteShowGeometryPropDialog);
        }

        private void ExecuteShowGeometryPropDialog(ShowInfo item)
        {
            try
            {
                if (item == null)
                {
                    return;
                }
                DialogParameters param =
                    new()
                    {
                        {
                            "Title",
                            LocalizationProviderWrapper.GetLocalizedStr(
                                "ParameterSettings"
                            )
                        }
                    };
                var dialogresult = dialogService.ShowDialog(
                    nameof(NumberInputsDialogView),
                    param,
                    callback =>
                    {
                        if (callback.Result == ButtonResult.OK)
                        {
                            //var prompt = callback.Parameters.GetValue<string>(
                            //    "Prompt"
                            //);
                            //var defaultSelection =
                            //    callback.Parameters.GetValue<int>(
                            //        "DefaultGeometryIndex"
                            //    );
                            //item.UserDefinedTitle = string.IsNullOrEmpty(prompt)
                            //    ? null
                            //    : prompt;
                            //item.SelectedGeometryIndex =
                            //    item.SelectedGeometryIndex == -1
                            //        ? defaultSelection
                            //        : item.SelectedGeometryIndex;
                        }
                    }
                );
            }
            catch (System.NullReferenceException _) { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExecuteShowGeometryDialog(SpecimenGeometryInfo item)
        {
            try
            {
                if (item == null)
                {
                    return;
                }
                DialogParameters param =
                    new()
                    {
                        {
                            "Title",
                            LocalizationProviderWrapper.GetLocalizedStr(
                                "ParameterSettings"
                            )
                        }
                    };
                var dialogresult = dialogService.ShowDialog(
                    nameof(SpecimenGeometryDialogView),
                    param,
                    callback =>
                    {
                        if (callback.Result == ButtonResult.OK)
                        {
                            var prompt = callback.Parameters.GetValue<string>(
                                "Prompt"
                            );
                            var defaultSelection =
                                callback.Parameters.GetValue<int>(
                                    "DefaultGeometryIndex"
                                );
                            item.UserDefinedTitle = string.IsNullOrEmpty(prompt)
                                ? null
                                : prompt;
                            item.SelectedGeometryIndex =
                                item.SelectedGeometryIndex == -1
                                    ? defaultSelection
                                    : item.SelectedGeometryIndex;
                        }
                    }
                );
            }
            catch (NullReferenceException _) { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExecuteShowNoteDialog(ShowInfoEx item)
        {
            try
            {
                if (item == null)
                {
                    return;
                }
                DialogParameters param =
                    new()
                    {
                        {
                            "Title",
                            LocalizationProviderWrapper.GetLocalizedStr(
                                "ParameterSettings"
                            )
                        }
                    };
                var dialogresult = dialogService.ShowDialog(
                    nameof(NotesDialogView),
                    param,
                    callback =>
                    {
                        if (callback.Result == ButtonResult.OK)
                        {
                            var prompt = callback.Parameters.GetValue<string>(
                                "Prompt"
                            );
                            var defaultText =
                                callback.Parameters.GetValue<string>(
                                    "DefaultText"
                                );
                            item.UserDefinedTitle = string.IsNullOrEmpty(prompt)
                                ? null
                                : prompt;
                            item.Content = string.IsNullOrEmpty(item.Content)
                                ? defaultText
                                : item.Content;
                        }
                    }
                );
            }
            catch (NullReferenceException _) { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Init()
        {
            InitData();
            InitItem();
            InitCommand();
        }

        private void InitData()
        {
            aGenmetryProperties = new string[20][];
            for (int i = 0; i < aGenmetryProperties.Length; i++)
            {
                aGenmetryProperties[i] = new string[] { "", "" };
            }
            aGenmetryProperties[0] = new string[]
            {
                "矩形",
                "Width，Thickness，Length，Final Width，Final Thickness，Final Length"
            };
            aGenmetryProperties[1] = new string[]
            {
                "圆形",
                "Diameter，Length，Final Length，Final Diameter"
            };
            aGenmetryProperties[2] = new string[]
            {
                "不规则形状",
                "Area，Length，Final Area，Final Length"
            };
            aGenmetryProperties[3] = new string[]
            {
                "管状",
                "External Diameter，Wall Thickness，Length，Final External Diameter，"
                    + "Final Wall Thickness，Final Length"
            };
            aGenmetryProperties[4] = new string[]
            {
                "纤维",
                "Linear Density，Length，Final Linear Density，Final Length"
            };
            aGenmetryProperties[5] = new string[]
            {
                "双剪切环",
                "Diameter，Length，Final Diameter，Final Length"
            };
            aGenmetryProperties[6] = new string[]
            {
                "紧固件（美制）",
                "Diameter，Threads per inch，Length，Final Diameter，Final Length"
            };
            aGenmetryProperties[7] = new string[]
            {
                "紧固件（公制）",
                "Diameter，Teeth space，Length，Final Diameter，Final Length"
            };
            aGenmetryProperties[9] = new string[]
            {
                "管截面（Tube Section）",
                "Width，External Diameter，Wall Thickness，Length，Final Width，Final External Diameter，Final Wall Thickness，Final Length"
            };
            aGenmetryProperties[10] = new string[]
            {
                "管截面（Pipe Section）",
                "Width，external radius，inside radius，Length，Final Width，Final external radius，Final inside radius，Final Length"
            };
            aGenmetryProperties[11] = new string[]
            {
                "管(Pipe)",
                "inner diameter，Wall Thickness，Length，Final inner diameter，Final Wall Thickness，Final Length"
            };
        }

        private void InitCommand()
        {
            SelectionChangedCommand = new DelegateCommand<object>(
                SelectionChanged
            );

            StartTextChangedCommand = new DelegateCommand<string>(
                StartTextChanged
                );
        }

        private void SelectionChanged(object obj)
        {
            if (obj == null)
            {
                return;
            }
            ComboBoxItem cmb = (ComboBoxItem)obj;
            AddLstGenmetryProperties(Tools.ToString(cmb.Tag));
        }
        private void StartTextChanged(string str)
        {
            if (str != "")
            {
                string str1 = str;
                
            }
        }

        private void AddLstGenmetryProperties(string sGenmetryProperties = "矩形")
        {
            LstGenmetryProperties = new ObservableCollection<ShowInfo>();
            try
            {
                for (int i = 0; i < aGenmetryProperties.Length; i++)
                {
                    if (aGenmetryProperties[i][0] == sGenmetryProperties)
                    {
                        string[] aGP = aGenmetryProperties[i][1].Split('，');
                        for (int j = 0; j < aGP.Length; j++)
                        {
                            LstGenmetryProperties.Add(
                                new ShowInfo() { Title = aGP[j] }
                            );
                        }
                    }
                }
            }
            catch (System.NullReferenceException ex) { }
            catch (Exception ex) { }
        }

        void InitItem()
        {
            AddLstGenmetryProperties();
        }

        //几何图形所需属性
    }
}

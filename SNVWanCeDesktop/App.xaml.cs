using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Windows;
using WanCeDesktopApp.Common;
using WanCeDesktopApp.ViewModels;
using WanCeDesktopApp.Views;
using WanCeDesktopApp.ViewModels.DialogModels;
using WanCeDesktopApp.ViewModels.Dialogs;
using WanCeDesktopApp.Views.Dialogs;
using Serilog;
using LoggingModule;

namespace WanCeDesktopApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        private static ILogger log = Log.ForContext<App>();

        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            log.Here().Information("App exits");
            Log.CloseAndFlush();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                // 配置 Serilog
                // Info 及以上级别的日志走 "logs/Info.txt"
                // Debug 级别的日志走 "logs/Debug.txt"
                LoggerConfig.Default();
                log = Log.ForContext<App>();

                base.OnStartup(e);
            }
            catch (System.NullReferenceException ex)
            {
                log.Here().Error(ex, AppConstants.EXCEPTION_RAISED);
            }
            catch (Exception ex)
            {
                log.Here().Error(ex, AppConstants.EXCEPTION_RAISED);
            }
        }

        protected override void OnInitialized()
        {
            var service =
                App.Current.MainWindow.DataContext as IConfigursIndexService;

            try
            {
                if (service != null)
                {
                    service.Configure();
                }
                else { }
                base.OnInitialized();
            }
            catch (System.NullReferenceException ex)
            {
                log.Here().Error(ex, AppConstants.EXCEPTION_RAISED);
            }
            catch (Exception ex)
            {
                log.Here().Error(ex, AppConstants.EXCEPTION_RAISED);
            }
        }

        //注册导航
        protected override void RegisterTypes(
            IContainerRegistry containerRegistry
        ) //视图与后台处理的注册
        {
            try
            {
                containerRegistry.RegisterForNavigation<
                    TestView,
                    TestViewViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    TestGraphyView,
                    TestGraphyViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    MethodView,
                    MethodViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    NewMethodView,
                    NewMethodViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    SystemManageView,
                    SystemManageViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    IndexView,
                    IndexViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    MsgView,
                    MsgViewModel
                >();

                //主UI的tabControl 选项UI注册
                containerRegistry.RegisterForNavigation<
                    TabControlView,
                    TabControlViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    TabControlGeneralView,
                    TabControlGeneralViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    TabControlSampleItemView,
                    TabControlSampleItemViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    TabControlSpecimenItemView,
                    TabControlSpecimenItemViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    TabControlMeasurementsView,
                    TabControlMeasurementsViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    TabControlCalculationsView,
                    TabControlCalculationsViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    TabControlTestControlView,
                    TabControlTestControlViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    TabControlConsoleView,
                    TabControlConsoleViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    TabControlWorkspaceView,
                    TabControlWorkspaceViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    TabControlExportsView,
                    TabControlExportsViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    TabControlWorkflowView,
                    TabControlWorkflowViewModel
                >();

                //Sample
                containerRegistry.RegisterForNavigation<
                    SampleNotesView,
                    SampleNotesViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    SampleNumberInputsView,
                    SampleNumberInputsViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    SampleTextInputsView,
                    SampleTextInputsViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    SampleChoiceInputsView,
                    SampleChoiceInputsViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    SampleDateInputsView,
                    SampleDateInputsViewModel
                >();

                //Sepcimen
                containerRegistry.RegisterForNavigation<
                    SpecimenPropertiesView,
                    SpecimenPropertiesViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    SpecimenNotesView,
                    SpecimenNotesViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    SpecimenNumberInputsView,
                    SpecimenNumberInputsViewModel
                >();

                containerRegistry.RegisterForNavigation<
                    SpecimenTextInputsView,
                    SpecimenTextInputsViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    SpecimenChoiceInputsView,
                    SpecimenChoiceInputsViewModel
                >();

                containerRegistry.RegisterForNavigation<
                    MultiSpecimenGraphPropertiesDialogView,
                    MultiSpecimenGraphPropertiesDialogViewModel
                >();

                //Calculation
                containerRegistry.RegisterForNavigation<
                    CalculationsSetupView,
                    CalculationsSetupViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    CalculationsRoundingView,
                    CalculationsRoundingViewModel
                >();

                //Test Control
                containerRegistry.RegisterForNavigation<
                    TestControlStartTestView,
                    TestControlStartTestViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    TestControlStrainView,
                    TestControlStrainViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    TestControlPreTestView,
                    TestControlPreTestViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    TestControlTestView,
                    TestControlTestViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    TestControlEndOfTestView,
                    TestControlEndOfTestViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    TestControlDataView,
                    TestControlDataViewModel
                >();

                //Console
                containerRegistry.RegisterForNavigation<
                    ConsoleLiveDisplaysView,
                    ConsoleLiveDisplaysViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    ConsoleSoftKeysView,
                    ConsoleSoftKeysViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    ConsoleFrameView,
                    ConsoleFrameViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    ConsoleGripsView,
                    ConsoleGripsViewModel
                >();

                //Worksapce
                containerRegistry.RegisterForNavigation<
                    WorkspaceOperatorInputsView,
                    WorkspaceOperatorInputsViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkspaceResults1View,
                    WorkspaceResults1ViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkspaceResults2View,
                    WorkspaceResults2ViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkspaceGraph1View,
                    WorkspaceGraph1ViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkspaceGraph2View,
                    WorkspaceGraph2ViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkspaceRawDataView,
                    WorkspaceRawDataViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkspaceLayoutView,
                    WorkspaceLayoutViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkspaceView,
                    WorkspaceViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkspaceGraph_AdvancedView,
                    WorkspaceGraph_AdvancedViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkspaceGraph_TypeView,
                    WorkspaceGraph_TypeViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkspaceGraph_XDataView,
                    WorkspaceGraph_XDataViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkspaceGraph_YDataView,
                    WorkspaceGraph_YDataViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkspaceLayoutView,
                    WorkspaceLayoutViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkspaceResult_ColumnsView,
                    WorkspaceResult_ColumnsViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkspaceResults_StatisticsView,
                    WorkspaceResults_StatisticsViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkspaceResults_FormatView,
                    WorkspaceResults_FormatViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkspacePassFailView,
                    WorkspacePassFailViewModel
                >();

                //Export
                containerRegistry.RegisterForNavigation<
                    ExportFileSettingsView,
                    ExportFileSettingsViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    ExportReportsView,
                    ExportReportsViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    ExportDatabaseExportView,
                    ExportDatabaseExportViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    ExportsExport1View,
                    ExportsExport1ViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    ExportsExport2View,
                    ExportsExport2ViewModel
                >();

                //workflow
                containerRegistry.RegisterForNavigation<
                    WorkflowStartSampleView,
                    WorkflowStartSampleViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkflowEditWorkflowView,
                    WorkflowEditWorkflowViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkflowBeforeTestView,
                    WorkflowBeforeTestViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkflowBeforeAnalysisView,
                    WorkflowBeforeAnalysisViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkflowFinishView,
                    WorkflowFinishViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkflowStartSampleView,
                    WorkflowStartSampleViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkflowTestingView,
                    WorkflowTestingViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    WorkflowTestNotesView,
                    WorkflowTestNotesViewModel
                >();

                containerRegistry.RegisterForNavigation<
                    SystemInfoView,
                    SystemInfoViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    SystemManageView,
                    SystemManageViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    HardWareManageView,
                    HardWareManageViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    AuthorityManageView,
                    AuthorityManageViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    DataManageView,
                    DataManageViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    InterfaceManageView,
                    InterfaceManageViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    InsertionOtherSystemView,
                    InsertionOtherSystemViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    SetAccessoriesView,
                    SetAccessoriesViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    SetSensorView,
                    SetSensorViewModel
                >();

                //root Dialog
                containerRegistry.Register<
                    IDialogHostService,
                    DialogHostService
                >();

                //user Dialog
                //SampleDialog
                containerRegistry.RegisterForNavigation<
                    SimpleDialogView,
                    SimpleDialogViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    NotesDialogView,
                    NotesDialogViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    TextInputsDialogView,
                    TextInputsDialogViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    NumberInputsDialogView,
                    NumberInputsDialogViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    SampleDateInputsDialogView,
                    SampleDateInputsDialogViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    ChoiceInputsDialogView,
                    ChoiceInputsDialogViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    ExpressionBuilderDialogView,
                    ExpressionBuilderDialogViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    SpecimenGeometryDialogView,
                    SpecimenGeometryDialogViewModel
                >();

                containerRegistry.RegisterForNavigation<
                    SettingsUserView,
                    SettingsUserViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    SettingsDatabaseView,
                    SettingsDatabaseViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    SoftwareManageView,
                    SoftwareManageViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    MaintainingView,
                    MaintainingViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    CheckView,
                    CheckViewModel
                >();

                //测试
                containerRegistry.RegisterForNavigation<
                    DevGenerateTool,
                    DevGenerateToolViewModel
                >();
                containerRegistry.RegisterForNavigation<
                    ConsoleEditView,
                    ConsoleEditViewModel
                >();
            }
            catch (System.NullReferenceException ex)
            {
                log.Here().Error(ex, AppConstants.EXCEPTION_RAISED);
            }
            catch (Exception ex)
            {
                log.Here().Error(ex, AppConstants.EXCEPTION_RAISED);
            }
        }
    }
}

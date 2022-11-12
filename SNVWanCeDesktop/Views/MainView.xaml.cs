using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using Infrastructure;
using Prism.Regions;
using Prism.Services.Dialogs;
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Extensions;
using WanCeDesktopApp.ViewModels;
using Prism.Ioc;

namespace WanCeDesktopApp.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        private readonly IDialogHostService dialogHostService;
        private readonly IDialogService dialogService;
        private bool firstLoad = true;
        private DevGenerateTool generateToolView = null;
        private ConsoleEditView editView = null;

        #region 解决窗口最大化相关问题
        private bool mRestoreIfMove = false;

        void Window_SourceInitialized(object sender, EventArgs e)
        {
            IntPtr mWindowHandle = (new WindowInteropHelper(this)).Handle;
            HwndSource
                .FromHwnd(mWindowHandle)
                .AddHook(new HwndSourceHook(WindowProc));
        }

        private static System.IntPtr WindowProc(
            IntPtr hwnd,
            int msg,
            IntPtr wParam,
            IntPtr lParam,
            ref bool handled
        )
        {
            switch (msg)
            {
                case 0x0024:
                    WmGetMinMaxInfo(hwnd, lParam);
                    break;
            }

            return IntPtr.Zero;
        }

        private static void WmGetMinMaxInfo(
            System.IntPtr hwnd,
            System.IntPtr lParam
        )
        {
            POINT lMousePosition;
            GetCursorPos(out lMousePosition);

            IntPtr lPrimaryScreen = MonitorFromPoint(
                new POINT(0, 0),
                MonitorOptions.MONITOR_DEFAULTTOPRIMARY
            );
            MONITORINFO lPrimaryScreenInfo = new MONITORINFO();
            if (GetMonitorInfo(lPrimaryScreen, lPrimaryScreenInfo) == false)
            {
                return;
            }

            IntPtr lCurrentScreen = MonitorFromPoint(
                lMousePosition,
                MonitorOptions.MONITOR_DEFAULTTONEAREST
            );

            MINMAXINFO lMmi;
            var temp = Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));
            if (temp is null)
                return;
            lMmi = (MINMAXINFO)temp;

            if (lPrimaryScreen.Equals(lCurrentScreen) == true)
            {
                lMmi.ptMaxPosition.X = lPrimaryScreenInfo.rcWork.Left;
                lMmi.ptMaxPosition.Y = lPrimaryScreenInfo.rcWork.Top;
                lMmi.ptMaxSize.X =
                    lPrimaryScreenInfo.rcWork.Right
                    - lPrimaryScreenInfo.rcWork.Left;
                lMmi.ptMaxSize.Y =
                    lPrimaryScreenInfo.rcWork.Bottom
                    - lPrimaryScreenInfo.rcWork.Top;
            }
            else
            {
                lMmi.ptMaxPosition.X = lPrimaryScreenInfo.rcMonitor.Left;
                lMmi.ptMaxPosition.Y = lPrimaryScreenInfo.rcMonitor.Top;
                lMmi.ptMaxSize.X =
                    lPrimaryScreenInfo.rcMonitor.Right
                    - lPrimaryScreenInfo.rcMonitor.Left;
                lMmi.ptMaxSize.Y =
                    lPrimaryScreenInfo.rcMonitor.Bottom
                    - lPrimaryScreenInfo.rcMonitor.Top;
            }

            Marshal.StructureToPtr(lMmi, lParam, true);
        }

        private void SwitchWindowState()
        {
            switch (WindowState)
            {
                case WindowState.Normal:
                    {
                        WindowState = WindowState.Maximized;
                        break;
                    }
                case WindowState.Maximized:
                    {
                        WindowState = WindowState.Normal;
                        break;
                    }
            }
        }

        private void rctHeader_PreviewMouseLeftButtonDown(
            object sender,
            MouseButtonEventArgs e
        )
        {
            if (e.ClickCount == 2)
            {
                if (
                    (ResizeMode == ResizeMode.CanResize)
                    || (ResizeMode == ResizeMode.CanResizeWithGrip)
                )
                {
                    SwitchWindowState();
                }

                return;
            }
            else if (WindowState == WindowState.Maximized)
            {
                mRestoreIfMove = true;
                return;
            }

            DragMove();
        }

        private void rctHeader_PreviewMouseLeftButtonUp(
            object sender,
            MouseButtonEventArgs e
        )
        {
            mRestoreIfMove = false;
        }

        private void rctHeader_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (mRestoreIfMove)
            {
                mRestoreIfMove = false;

                double percentHorizontal = e.GetPosition(this).X / ActualWidth;
                double targetHorizontal =
                    RestoreBounds.Width * percentHorizontal;

                double percentVertical = e.GetPosition(this).Y / ActualHeight;
                double targetVertical = RestoreBounds.Height * percentVertical;

                WindowState = WindowState.Normal;

                POINT lMousePosition;
                GetCursorPos(out lMousePosition);

                Left = lMousePosition.X - targetHorizontal;
                Top = lMousePosition.Y - targetVertical;

                DragMove();
            }
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr MonitorFromPoint(POINT pt, MonitorOptions dwFlags);

        enum MonitorOptions : uint
        {
            MONITOR_DEFAULTTONULL = 0x00000000,
            MONITOR_DEFAULTTOPRIMARY = 0x00000001,
            MONITOR_DEFAULTTONEAREST = 0x00000002
        }

        [DllImport("user32.dll")]
        static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MONITORINFO
        {
            public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
            public RECT rcMonitor = new RECT();
            public RECT rcWork = new RECT();
            public int dwFlags = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left,
                Top,
                Right,
                Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                this.Left = left;
                this.Top = top;
                this.Right = right;
                this.Bottom = bottom;
            }
        }

        #endregion

        public MainView(IDialogHostService dialogHostService, IDialogService service)
        {
            InitializeComponent();
            dialogService = service;
            ///dump fiel
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(
                    (obj, args) => MiniDump.TryDump("error.dmp")
                );
            this.WindowState = WindowState.Maximized;

            triangle.Click += (s, e) =>
            {
                this.WindowState = WindowState.Minimized;
            };

            btnMin.Click += (s, e) =>
            {
                this.WindowState = WindowState.Minimized;
            };
            btnMax.Click += (s, e) =>
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }
            };
            btnClose.Click += async (s, e) =>
            {
                try
                {
                    var dialogResult = await this.dialogHostService.Question(
                        "提示",
                        "确认退出系统吗?"
                    );
                    if (
                        dialogResult.Result
                        != Prism.Services.Dialogs.ButtonResult.OK
                    )
                    {
                        return;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                catch (System.NullReferenceException ex) { }
                catch (Exception ex) { }
            };
            //ColorZone.MouseMove += (s, e) =>
            //{
            //    if (e.LeftButton == MouseButtonState.Pressed)
            //    {
            //        //this.WindowState = WindowState.Normal;//去掉最大化的拖拽
            //        this.DragMove();
            //    }
            //    else { }
            //};
            //ColorZone.MouseDoubleClick += (s, e) =>
            //{
            //    if (this.WindowState == WindowState.Normal)
            //    {
            //        this.WindowState = WindowState.Maximized;
            //    }
            //    else
            //    {
            //        this.WindowState = WindowState.Normal;
            //    }
            //};

            this.dialogHostService = dialogHostService;
            this.PreviewKeyDown += MainView_PreviewKeyDown;
            Init();
        }

        private void Init()
        {
           
        }

        private void MainView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //取出是否是ctrl，不是则会给出None
            //var keydown1 = Keyboard.Modifiers & ModifierKeys.Control;
            //取出alt 
            //var keydown = Keyboard.Modifiers & ModifierKeys.Alt; keydown ==ModifierKeys.Alt
            if (Keyboard.IsKeyDown(Key.RightCtrl) && Keyboard.IsKeyDown(Key.F7))
            {
                if (generateToolView == null)
                {
                    return;
                }
                generateToolView.ShowDialog();
            }
        }

        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    base.OnMouseMove(e);
        //    if (e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        this.DragMove();
        //    }
        //}
        //最后的宽度（Last Width）
        private int LastWidth;

        //最后的高度（Last Height）
        private int LastHeight;

        //这个属性是指 窗口的宽度和高度的比例（宽度/高度）(4:3)
        //This property refers to the aspect ratio (width / height) of the window (4: 3)
        private float AspectRatio = 4.0f / 3.0f;

        /// <summary>
        /// 捕获窗口拖拉消息
        /// (Capturing window drag messages)
        /// </summary>
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource source = HwndSource.FromVisual(this) as HwndSource;
            if (source != null)
            {
                //source.AddHook(new HwndSourceHook(WinProc));
            }
        }

        public const Int32 WM_EXITSIZEMOVE = 0x0232;

        public MouseButtonEventHandler HandleMouseDown { get; private set; }

        private async void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel model = HomeButton.DataContext as MainViewModel;
            if (model.HomeIcon == "Close")
            {
                var dialogResult = await this.dialogHostService.Question(
                    "提示",
                    "确认退出系统吗?"
                );
                if (dialogResult.Result != ButtonResult.OK)
                {
                    return;
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void ItemsControl_MouseDoubleClick(
            object sender,
            MouseButtonEventArgs e
        )
        {
            UnitInfo info = UnitSystemProvider.GetUnitInfo("Percentage");
        }
        private UserControl consoleEditView = null;
        private void listBoxData_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            //RegionManager.SetRegionManager(window, regionManager);
            //dialogHostService.ShowDialog("ConsoleEditView");
            //}
            //if (consoleEditView ==null)
            //{
            //    var provider = ContainerLocator.Container.Resolve<IContainerProvider>();
            //    var regionManager = ContainerLocator.Container.Resolve<IRegionManager>();
            //    var view = provider.Resolve<object>(nameof(ConsoleEditView));
            //    //var view = provider.Resolve<object>(nameof(ConsoleEditView), new (Type Type, object Instance)[] { (typeof(string), menuItem.Tag) });
            //    if (view is Window window)
            //    {
            //        //window = new ConsoleEditView();
            //        if (!firstLoad)
            //        {
            //            regionManager.Regions.Remove("ConsoleEditRegionName");
            //        }
            //        RegionManager.SetRegionManager(window, regionManager);
            //        consoleEditView = (ConsoleEditView)window;
            //        firstLoad = false;
            //    }
            //    //RegionManager.SetRegionManager(window, regionManager);
            //    //dialogHostService.ShowDialog("ConsoleEditView");
            //}
            dialogService.ShowDialog(menuItem.Tag.ToString());
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Button button = sender as Button;
        //    SoftKeyInfo info = button.DataContext as SoftKeyInfo;
        //    SoftKeyFactory factory = new SoftKeyFactory();
        //    ISoftKey softKey = factory.GetSoftKey(info.SoftKeyType);
        //    softKey?.ToDo();
        //}

        /// <summary>
        /// 重载窗口消息处理函数
        /// (Overload window message processing function)
        /// </summary>
        //private IntPtr WinProc(IntPtr hwnd, Int32 msg, IntPtr wParam, IntPtr lParam, ref Boolean handled)
        //{
        //    IntPtr result = IntPtr.Zero;
        //    switch (msg)
        //    {
        //        //处理窗口消息 (Handle window messages)
        //        case WM_EXITSIZEMOVE:
        //            {
        //                //上下拖拉窗口 (Drag window vertically)
        //                if (this.Height != LastHeight)
        //                {
        //                    this.Width = this.Height * AspectRatio;
        //                }
        //                // 左右拖拉窗口 (Drag window horizontally)
        //                else if (this.Width != LastWidth)
        //                {
        //                    this.Height = this.Width / AspectRatio;
        //                }

        //                LastWidth = (int)this.Width;
        //                LastHeight = (int)this.Height;
        //                break;
        //            }
        //    }
        //    return result;
        //}
    }
}

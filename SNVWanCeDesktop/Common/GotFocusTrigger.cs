using MaterialDesignThemes.Wpf;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace WanCeDesktopApp.Common
{
    internal class GotFocusTrigger : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            if (((RoutedEventArgs)parameter).OriginalSource is TextBox textBox)
            {
                var source = (HwndSource)PresentationSource.FromVisual(textBox);
                if (source != null)
                {
                    SetFocus(source.Handle);
                    textBox.Focus();
                }
            }
        }

        [DllImport("User32.dll")]
        private static extern IntPtr SetFocus(IntPtr hWnd);
    }
}

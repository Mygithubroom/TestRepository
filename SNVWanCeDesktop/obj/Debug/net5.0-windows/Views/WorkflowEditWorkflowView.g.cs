﻿#pragma checksum "..\..\..\..\Views\WorkflowEditWorkflowView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9AA6646ACFCDCE551AA35C9CED251E0AA40B4ACC"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WPFLocalizeExtension.Deprecated.Engine;
using WPFLocalizeExtension.Deprecated.Extensions;
using WPFLocalizeExtension.Deprecated.Providers;
using WPFLocalizeExtension.Engine;
using WPFLocalizeExtension.Extensions;
using WPFLocalizeExtension.Providers;
using WPFLocalizeExtension.TypeConverters;
using WPFLocalizeExtension.ValueConverters;
using WanCeDesktopApp.Views;


namespace WanCeDesktopApp.Views {
    
    
    /// <summary>
    /// WorkflowEditWorkflowView
    /// </summary>
    public partial class WorkflowEditWorkflowView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 142 "..\..\..\..\Views\WorkflowEditWorkflowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ckbRunPrompted;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\..\Views\WorkflowEditWorkflowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel RunPromptedPanel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WanCeDesktopApp;component/views/workfloweditworkflowview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\WorkflowEditWorkflowView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ckbRunPrompted = ((System.Windows.Controls.CheckBox)(target));
            
            #line 144 "..\..\..\..\Views\WorkflowEditWorkflowView.xaml"
            this.ckbRunPrompted.Checked += new System.Windows.RoutedEventHandler(this.ckbRunPrompted_Checked);
            
            #line default
            #line hidden
            
            #line 148 "..\..\..\..\Views\WorkflowEditWorkflowView.xaml"
            this.ckbRunPrompted.Unchecked += new System.Windows.RoutedEventHandler(this.ckbRunPrompted_Unchecked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RunPromptedPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

﻿#pragma checksum "..\..\..\..\Views\WorkspaceResults_StatisticsView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E9F9E45E9B432B60183B8BD03AE6969F59C3E61A"
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
using Microsoft.Xaml.Behaviors;
using Microsoft.Xaml.Behaviors.Core;
using Microsoft.Xaml.Behaviors.Input;
using Microsoft.Xaml.Behaviors.Layout;
using Microsoft.Xaml.Behaviors.Media;
using Prism.DryIoc;
using Prism.Interactivity;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Regions.Behaviors;
using Prism.Services.Dialogs;
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
using WanCeDesktopApp.Common.DAO;
using WanCeDesktopApp.Extensions;
using WanCeDesktopApp.Views;


namespace WanCeDesktopApp.Views {
    
    
    /// <summary>
    /// WorkspaceResults_StatisticsView
    /// </summary>
    public partial class WorkspaceResults_StatisticsView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 117 "..\..\..\..\Views\WorkspaceResults_StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView treeView;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\..\..\Views\WorkspaceResults_StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox DeterMiniedParametersList;
        
        #line default
        #line hidden
        
        
        #line 204 "..\..\..\..\Views\WorkspaceResults_StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MoveUp;
        
        #line default
        #line hidden
        
        
        #line 210 "..\..\..\..\Views\WorkspaceResults_StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MoveDown;
        
        #line default
        #line hidden
        
        
        #line 217 "..\..\..\..\Views\WorkspaceResults_StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid detailedArea;
        
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
            System.Uri resourceLocater = new System.Uri("/WanCeDesktopApp;component/views/workspaceresults_statisticsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\WorkspaceResults_StatisticsView.xaml"
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
            this.treeView = ((System.Windows.Controls.TreeView)(target));
            return;
            case 2:
            this.DeterMiniedParametersList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.MoveUp = ((System.Windows.Controls.Button)(target));
            
            #line 206 "..\..\..\..\Views\WorkspaceResults_StatisticsView.xaml"
            this.MoveUp.Click += new System.Windows.RoutedEventHandler(this.MoveUp_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MoveDown = ((System.Windows.Controls.Button)(target));
            
            #line 212 "..\..\..\..\Views\WorkspaceResults_StatisticsView.xaml"
            this.MoveDown.Click += new System.Windows.RoutedEventHandler(this.MoveDown_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.detailedArea = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


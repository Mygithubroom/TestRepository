﻿#pragma checksum "..\..\..\..\Views\TabControlMeasurementsView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52A67B86665DD7DBC95FB25ACAAC914F0D08F1BB"
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
using WanCeDesktopApp;
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Extensions;
using WanCeDesktopApp.ViewModels;


namespace WanCeDesktopApp.Views {
    
    
    /// <summary>
    /// TabControlMeasurementsView
    /// </summary>
    public partial class TabControlMeasurementsView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainGrd;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView treeView;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMoveToLeft;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox DeterMiniedParametersList;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid DeterMiniedParamePanel;
        
        #line default
        #line hidden
        
        
        #line 189 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer EditPanelScroll;
        
        #line default
        #line hidden
        
        
        #line 220 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel DescriptionPanel;
        
        #line default
        #line hidden
        
        
        #line 233 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel SensorSettingPanel;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CMBSensor;
        
        #line default
        #line hidden
        
        
        #line 245 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel JointPanel;
        
        #line default
        #line hidden
        
        
        #line 251 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CMBJoint;
        
        #line default
        #line hidden
        
        
        #line 257 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel BasicSourcePanel;
        
        #line default
        #line hidden
        
        
        #line 268 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel UnitGroupPanel;
        
        #line default
        #line hidden
        
        
        #line 279 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel DisplacementSourcePanel;
        
        #line default
        #line hidden
        
        
        #line 290 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel LoadSourcePanel;
        
        #line default
        #line hidden
        
        
        #line 301 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ExpressionPanel;
        
        #line default
        #line hidden
        
        
        #line 331 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ComplianceFilePanel;
        
        #line default
        #line hidden
        
        
        #line 392 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel SourceOfStrainPanel;
        
        #line default
        #line hidden
        
        
        #line 403 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TransverseStrainGaugeWidthPanel;
        
        #line default
        #line hidden
        
        
        #line 431 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid PreTestLimitPanel;
        
        #line default
        #line hidden
        
        
        #line 444 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PreTestLimitEditPanel;
        
        #line default
        #line hidden
        
        
        #line 458 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox EditUnit;
        
        #line default
        #line hidden
        
        
        #line 487 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid RatePanel;
        
        #line default
        #line hidden
        
        
        #line 502 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel RateEditPanel;
        
        #line default
        #line hidden
        
        
        #line 537 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox TrueStrainControlPanel;
        
        #line default
        #line hidden
        
        
        #line 543 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel TransverseStrainPanel;
        
        #line default
        #line hidden
        
        
        #line 555 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel DataPointNumberPanel;
        
        #line default
        #line hidden
        
        
        #line 567 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel EliminationOfElasticStrainPanel;
        
        #line default
        #line hidden
        
        
        #line 571 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel PoissionRatePanel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WanCeDesktopApp;component/views/tabcontrolmeasurementsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.mainGrd = ((System.Windows.Controls.Grid)(target));
            
            #line 20 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
            this.mainGrd.SizeChanged += new System.Windows.SizeChangedEventHandler(this.Grid_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.treeView = ((System.Windows.Controls.TreeView)(target));
            
            #line 64 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
            this.treeView.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.FirstDeterMiniedParameMouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 97 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnMove_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnMoveToLeft = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
            this.btnMoveToLeft.Click += new System.Windows.RoutedEventHandler(this.BtnMove_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DeterMiniedParametersList = ((System.Windows.Controls.ListBox)(target));
            
            #line 147 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
            this.DeterMiniedParametersList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DeterMiniedParametersList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DeterMiniedParamePanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.EditPanelScroll = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 8:
            this.DescriptionPanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 9:
            this.SensorSettingPanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 10:
            this.CMBSensor = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.JointPanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 12:
            this.CMBJoint = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 13:
            this.BasicSourcePanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 14:
            this.UnitGroupPanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 15:
            this.DisplacementSourcePanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 16:
            this.LoadSourcePanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 17:
            this.ExpressionPanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 18:
            this.ComplianceFilePanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 19:
            this.SourceOfStrainPanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 20:
            this.TransverseStrainGaugeWidthPanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 21:
            this.PreTestLimitPanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 22:
            
            #line 438 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 442 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 23:
            this.PreTestLimitEditPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 24:
            this.EditUnit = ((System.Windows.Controls.ComboBox)(target));
            
            #line 465 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
            this.EditUnit.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.EditUnit_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 25:
            this.RatePanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 26:
            
            #line 496 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 500 "..\..\..\..\Views\TabControlMeasurementsView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 27:
            this.RateEditPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 28:
            this.TrueStrainControlPanel = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 29:
            this.TransverseStrainPanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 30:
            this.DataPointNumberPanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 31:
            this.EliminationOfElasticStrainPanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 32:
            this.PoissionRatePanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WanCeDesktopApp.CommonWanCeDesktopApp.Common  5      G(clr-namespace:WanCeDesktopApp.ExtensionsWanCeDesktopApp.Extensions  5      1clr-namespace:WanCeDesktopAppWanCeDesktopApp  5
      G(clr-namespace:WanCeDesktopApp.ViewModelsWanCeDesktopApp.ViewModels  5      2    ,WanCeDesktopApp.Views.Dialogs.DialogBaseView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      3cv$clr-namespace:WanCeDesktopApp.Common     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8ext(clr-namespace:WanCeDesktopApp.Extensions     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5	      )localclr-namespace:WanCeDesktopApp  5
      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5      ;
viewmodels(clr-namespace:WanCeDesktopApp.ViewModels 	 
 5      $	??600??5      $	??500??5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ GotFocus??6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      ,  &WanCeDesktopApp.Common.GotFocusTrigger  5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $??* ?6   ?? 5      $
??auto ?6   .+?5   
   ? $??0??6   .+?5      ?? $??60??5       ???#626367 ?? CornerRadius$ 3,3,0,0??5"      ._?5#      ]? .+?5$      '  !MaterialDesignThemes.Wpf.PackIcon  $??60??5%      $??60??5&      
???????   Kind$ 	PencilBox=?5(      ?? 5)      $??6,8,0,0q?5*      
???????$&??  Properties - Sample note input ??5,      5-      5.      5/      ?? 50   
   $??1??6   .+?51      ]? 52      ]? 53   
   $??2??54      $??70??55      $
??20,0q?56      $??Center=?57      $??False??58      .+?59      ?? $??49??6   ??6!   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ QuestionMark=?   Size 24?? 5:      $??Right=?6   	 ?? Orientation$	 
Horizontal=?60   .+?5;      ?? $??49??5<      $
??20,0q?5=          MaterialDesignOutlinedButton#??[  5@      ??5>      ?? *CancelCommand+??5?      2  ,WPFLocalizeExtension.Extensions.LocExtension  *CancelTwoSpacing+5@      ?? 5A      $??49??5B      
 ? Cursor$

 Hand??5E      ??5C      ?? *SaveCommand+??5D        *OK+5E      5F      5G      5H      5I      
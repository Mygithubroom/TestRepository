   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WanCeDesktopApp.CommonWanCeDesktopApp.Common  5      G(clr-namespace:WanCeDesktopApp.ExtensionsWanCeDesktopApp.Extensions  5      1clr-namespace:WanCeDesktopAppWanCeDesktopApp  5
      G(clr-namespace:WanCeDesktopApp.ViewModelsWanCeDesktopApp.ViewModels  5      3    -WanCeDesktopApp.Views.Dialogs.NotesDialogView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      3cv$clr-namespace:WanCeDesktopApp.Common     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8ext(clr-namespace:WanCeDesktopApp.Extensions     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5	      )localclr-namespace:WanCeDesktopApp  5
      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5      ;
viewmodels(clr-namespace:WanCeDesktopApp.ViewModels 	 
 5      $	??600??5      $	??500??5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ GotFocus??6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      ,  &WanCeDesktopApp.Common.GotFocusTrigger  5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $??* ?6   .+?5   
   ? $??0??6   .+?5      (  "MaterialDesignThemes.Wpf.ColorZone  -   5          Name$ 	ColorZone??5   '   .??5       ?? $??60??5!      ???#626367 ?? CornerRadius$ 3,3,0,0??5#      ._?5$      ]? .+?5%      '  !MaterialDesignThemes.Wpf.PackIcon  $??60??5&      $??60??5'      
???????   Kind$ 	PencilBox=?5)      ?? 5*      $??6,8,0,0q?5+      $??16(?5-      $
??Bold"?5.      
?????????5,      ?? *Head+5/      50      51      52      53      ?? 54   
   $??1??6   $
??20,0q?6"   .+?55      ]? .+?56      ?? $??0,20,0,0q?6   ??6.   2  ,WPFLocalizeExtension.Extensions.LocExtension  *Prompt+?? 57      $??	30,10,0,0q?58      $??16(?59       !  MaterialDesignOutlinedTextBox#??[  5:      ??5;      ?? *Title+5<      ?? 5=      .+?5>      ?? $??0,10,0,0q?6   ??6.     *Default Text+?? 5?      $	??200??5@      $??0,10,0,0q?5A      $??16(?5B      #??[  5C      ??5D      ?? *	Content+5E      5F      ]? 5G   
   $??2??5H      $
??20,0q?5I      $??False??5J      .+?5K      ?? $??Right=?6    ?? Orientation$ 
Horizontal=?60   .+?5L      ?? $??49??5M      $
??20,0q?5N         MaterialDesignOutlinedButton#??[ 5Q      ??5O      ?? *CancelCommand+??5P        *CancelTwoSpacing+5Q      ?? 5R      $??49??5S      	 ? Cursor$
	 Hand??5V      ??5T      ?? *SaveCommand+??5U        *OK+5V      5W      5X      5Y      5Z      
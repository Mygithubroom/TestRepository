   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WanCeDesktopApp.CommonWanCeDesktopApp.Common  5      G(clr-namespace:WanCeDesktopApp.ExtensionsWanCeDesktopApp.Extensions  5      1clr-namespace:WanCeDesktopAppWanCeDesktopApp  5
      G(clr-namespace:WanCeDesktopApp.ViewModelsWanCeDesktopApp.ViewModels  5      3    -WanCeDesktopApp.Views.Dialogs.NotesDialogView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      3cv$clr-namespace:WanCeDesktopApp.Common     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8ext(clr-namespace:WanCeDesktopApp.Extensions     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5	      )localclr-namespace:WanCeDesktopApp  5
      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5      ;
viewmodels(clr-namespace:WanCeDesktopApp.ViewModels 	 
 5      $	??600??5      $	??500??5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $??* ?6   .+?5   
   ? $??0??6   .+?5      (  "MaterialDesignThemes.Wpf.ColorZone  -   5          Name$ 	ColorZone??5   '   .??5      ?? $??60??5      ???#626367 ?? CornerRadius$ 3,3,0,0??5      ._?5      ]? .+?5       '  !MaterialDesignThemes.Wpf.PackIcon  $??60??5!      $??60??5"      
???????   Kind$ 	PencilBox=?5$      ?? 5%      $??6,8,0,0q?5&      $??16(?5(      $
??Bold"?5)      
?????????5'      ?? *Head+5*      5+      5,      5-      5.      ?? 5/   
   $??1??6   $
??20,0q?6"   .+?50      ]? .+?51      ?? $??0,20,0,0q?6   ??6.   2  ,WPFLocalizeExtension.Extensions.LocExtension  *Prompt+?? 52      $??	30,10,0,0q?53      $??16(?54       !  MaterialDesignOutlinedTextBox#??[  55      ??56      ?? *Title+57      ?? 58      .+?59      ?? $??0,10,0,0q?6   ??6.     *Default Text+?? 5:      $	??200??5;      $??0,10,0,0q?5<      $??16(?5=      #??[  5>      ??5?      ?? *	Content+5@      5A      ]? 5B   
   $??2??5C      $
??20,0q?5D      $??False??5E      .+?5F      ?? $??Right=?6    ?? Orientation$ 
Horizontal=?60   .+?5G      ?? $??49??5H      $
??20,0q?5I         MaterialDesignOutlinedButton#??[ 5L      ??5J      ?? *CancelCommand+??5K        *CancelTwoSpacing+5L      ?? 5M      $??49??5N       ? Cursor$
 Hand??5Q      ??5O      ?? *SaveCommand+??5P        *OK+5Q      5R      5S      5T      5U      
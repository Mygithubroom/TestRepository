   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WanCeDesktopApp.ViewsWanCeDesktopApp.Views  5      1    +WanCeDesktopApp.Views.TestControlStrainView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5      /local#clr-namespace:WanCeDesktopApp.Views  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       ? 	Resources 5      ??%    .??5      ? -   5           PrimaryHueGridBrush#???   5      .+?5      ?? -   5         ??Name$ StrainViewScroll??5      $
??Auto=?5      $
??Auto=?5      .??5      ?  ? RowDefinitions 5      ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      .+?5      ?? $??1??5      $??10,0,0,0q?5      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=?5      .+?5       ?? ??6   2  ,WPFLocalizeExtension.Extensions.LocExtension  *Tensile strain (displacement)+?? 5!      $
??1300??5"      $??0,10,0,0q?5#      $
??Left=?5$      $
??Wrap=?5&      ??5%        *TextControlStrainDescribe+5&      ? 5'       ? ColumnDefinitions 5(      ?? 5)   	   ?? 5*   	    5,      ?? 5-   	   $
??auto ?6   ?? 5.   	   $
??auto ?6   ?? 5/   	   $
??auto ?6   .+?51      ?? $??Center=?6   ??6-     *The basic source+?? 52      $??1??53      $??	0,5,200,0q?54       ?? SelectedValue 55      ?? *BaseSourceComboBox+?? 56      -   5         ??Name$ chkBox??57      $??1??58      -  'MaterialDesignThemes.Wpf.CheckBoxAssist   CheckBoxSize$ 30Q?59      $|?False??5<      
	 ? Tag$	 StrainPanel??5>      ??5;        *0.Remove the extensometer during the measurement+
 d? 	IsChecked
 5=      ?? *RemoveCheckBox+5?      A? 5@      -   5        $??StrainPanel??5A      $??2??5B      $??0??5C      $??2??5D      $??20,0,0,0q?5E       A? Columns$ 2??5F       A? Rows$ 5??5G      $y?	Collapsed=?5H      .+?5I   	   ?? $??Center=?6   ??6.     *Remove the criteria+?? 5J   	   $	??0,5q?6    6   ?? *RemovCriteriaComboBox+?? 5K   	   $??Center=?6   ??6.     *Measurement+?? 5L   	   $	??0,5q?6    6   ?? *MeasuremetnComboBox+?? 5M   	   $??Center=?6   ??6.     *value+? 5N   	   $	??0,5q?6    5O   
   ?? 5P      ?? 5Q      $
??auto ?6   .+?5S   
   ?? .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True??6   ??6G   ?? *ValueTextBox+?? 5T   
   $??1??6    ?? Orientation$ 
Horizontal=?6%   .+?5U      ?? $	??100??6    6    ?? *
UintComBox+?? 5V      $??45??5W      $??5q?5X      ??5Y      0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Keyboard=?   Size 245[      5\   
   ?? 5]   	   $??Center=?6   ??6.     *Action during removal+?? 5^   	   $	??0,5q?6    6   ?? *ActionDuringComboBox+?? 5_   	   $ 30Q?5`   	   ??5a   	     *(&Lock tensile strain during disassembly+
 5b   	   ?? *LockTensileComboBox+5c   	   5d      5e      ?? 5f      $??2??6   .+?5g      ?? $??	10,10,0,0q?5h      $ 30Q?5i      $??18(?5k      $
??Bold"?5l      ??5j        *,*Remove transverse extensometer during test+
 5m      ?? *RemoveTransverseComboBox+?? 5n      $??	10,10,0,0q?5o      $
??Wrap=?5q      ??5p        *+)TestControlStrainTransverseStrainDescribe+5q      5r      5s      5t      5u      5v      
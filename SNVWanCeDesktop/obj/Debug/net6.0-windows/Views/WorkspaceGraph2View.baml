   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WanCeDesktopApp.ViewsWanCeDesktopApp.Views  5      G(clr-namespace:WanCeDesktopApp.ExtensionsWanCeDesktopApp.Extensions  5
      /    )WanCeDesktopApp.Views.WorkspaceGraph2View   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:WanCeDesktopApp.Views     5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      2ext(clr-namespace:WanCeDesktopApp.Extensions  5
      _	 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 	 5      [
 WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com 
 5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      ???#626367 ? 	Resources 5         myCheckGroupButton ?? 
TargetType - )MaterialDesignChoiceChipAccentRadioButton ?? BasedOn ?? Property ?? Value ?? RelativeSource ?? Mode ?? Path??%?  &	        7  ?? 5   
   " 	?5      8   .?5      ??  ?@	?	GroupName$ GroupChoiceChip??5      ?? 5       ? ??$	 100??5      ?? 5       ? ??$ 40??5      ?? 5       ? ??
 ??·?5      ?? 5       ? ??
 ?????5      ?? 5       ? ?? 5       ?? *WorkRegionNavigateCommand+?? 5!       ? ?? 5"      ??  ?? $
 Self=?$	 Tag??? 5#       ? ??$ 5q?5$      5%      5&      .??5'      ? * 	 $Microsoft.Xaml.Behaviors.Interaction	   Triggers	 5(   
   + 	 %Microsoft.Xaml.Behaviors.EventTrigger  5)      
   	EventName$
 Loaded??6   * 	 $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5*      2 	 ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6(   ?? *LoadedCommand+5+       ? RowDefinitions 5-   
   ?? 5.      $
??auto ?6   ?? 5/      .+?51   
   A?  A? Columns$ 5??6   .+?52      	? #??[  6   
 ? Tag$ WorkspaceGraph_TypeView??54       d? 	IsChecked$
 TrueY?55       ? Cursor$
 Hand??56      ??53      2 
 ,WPFLocalizeExtension.Extensions.LocExtension  *Type+56      	? 57      #??[  6   $ WorkspaceGraph_XDataView??59      $
 Hand??5:      ??58        *XData+5:      	? 5;      #??[  6   $ WorkspaceGraph_YDataView??5=      ??5<        *YData+5=      	? 5>      #??[  6   $! WorkspaceGraph_AdvancedView??5@      ??5?        *
Advanced+5@      5A      ? 5B   
   $??1??6    ? ColumnDefinitions 5C      ?? 5D      $??5* ?6#   ?? 5E      $??2* ?6#   .+?5G      ]? .+?5H      ?? ,   &WanCeDesktopApp.Extensions.PrismManage   WorkRegionName2!  Prism.Regions.RegionManager   
RegionName# Z 6!   5I      ]? 5J      $??1??6   5L      5M      5N      5O      
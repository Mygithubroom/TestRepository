   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WanCeDesktopApp.ViewsWanCeDesktopApp.Views  5      3    -WanCeDesktopApp.Views.WorkspaceGraph_TypeView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5      /local#clr-namespace:WanCeDesktopApp.Views  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5
      ! 	 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .??5      ? $??10,0,0,0q?6    ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      .+?5   
   ?? $??Center=?6   ??6/   2  ,WPFLocalizeExtension.Extensions.LocExtension  *$"WorkspaceGraphTypeGraphDescribeOne+]? 5   
   $??1??5      $??0,5,0,0q?5       $??False??5!      .+?5"      ?? $??Center=?6   ??63     *Select a graph type+?? 5#      $	??500??6   $??Right=?6#   5$      ]? 5%   
   $??2??5&      $??0,5,0,0q?5'      $??Center=?5(      $??False??5)      .+?5*      ?? $??Center=?5+      $??Center=?5,      ??5-        *$"WorkspaceGraphTypeGraphDescribeTwo+5.      ]? 5/   
   $??3??50      $??0,5,0,0q?51      $??False??52      .+?53      ?? $??Center=?6   ??63     *Graph title+?? 54      $	??500??55      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True??56      $??Right=?57      58      ]? 59   
   $??4??5:      $??0,5,0,0q?5;      $??False??5<      .+?5=      ?? $??Center=?6   ??63     *Domain+?? 5>      $??65??5?      $??5,0,0,0q?5@      $??Right=?5C      ??5A      0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ FunctionVariant=?   Size 245C      ?? 5D      $	??430??5E      $??Right=?5F      ${?False??5G      5H      ]? 5I   
   $??5??5J      $??0,5,0,0q?5K      $??False??5L      .+?5M      ?? $??Center=?6   ??63     *Curves per graph+?? 5N      $	??500??5O      $
 True??5P      $??Right=?5Q      5R      ]? 5S   
   $??6??5T      $??0,5,0,0q?5U      $??False??5V      .+?5W      ?? $??Center=?6   ??63     *Offset each curve by+?? 5X      $	??500??6   $??Right=?6#   5Y      ]? 5Z   
   $??7??5[      $??0,5,0,0q?5\      $??False??5]      .+?5^      ?? $??Center=?6   ??63     *Show excluded specimens+?? 5_      $??	0,0,470,0q?5`      -  'MaterialDesignThemes.Wpf.CheckBoxAssist   CheckBoxSize$ 30Q?5a      $??Right=?5b      5c      ]? 5d   
   $??8??5e      $??0,5,0,0q?5f      $??False??5g      .+?5h      ?? $??Center=?6   ??63     *Enable data point selector+?? 5i      $??	0,0,470,0q?5j      $ 30Q?5k      $??Right=?5l      5m      ]? 5n   
   $??9??5o      $??0,5,0,0q?5p      $??False??5q      .+?5r      ?? $??Center=?6   ??63     *Show average curve+?? 5s      $??	0,0,470,0q?5t      $ 30Q?5u      $??Right=?5v      5w      5x      5y      
   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WanCeDesktopApp.ViewsWanCeDesktopApp.Views  5      /    )WanCeDesktopApp.Views.WorkspaceLayoutView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5      /local#clr-namespace:WanCeDesktopApp.Views  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      .+?5   
   ??  ?? Orientation$ 
Horizontal=?6   .+?5      ?? $	??300??5      $
??10,5q?5      ??5      2  ,WPFLocalizeExtension.Extensions.LocExtension  *Basic+?? 5      $	??300??5      $
??10,5q?5      ??5        *Custom+5      ?? 5    
   $??1??6   .+?5!      ?? $??Center=?6   ??63     *WorkspaceLayoutDescribeOne+?? 5"      $??Center=?6   ??63     *WorkspaceLayoutDescribeTwo+5#      ? 5$   
   $??2??6    ? ColumnDefinitions 5%      ?? 5&      $??* ?6#   ?? 5'      $??* ?6#   .+?5)      ]? $??Right=?6   .+?5*      ?? $	??650??5+      $
??Auto=?5,      $
??Auto=?5-      .??5.      ?? ??6#   ?? *LayoutInfos+??5/      ?? 50      .R?51   "   A?  A? Columns$ 5??6.   52      ??54      ?? 55      .R?56   "   ? .+?57   &   ?? $	??130??58   )   $	??150??59   )   $??10q?5:   )   $??Center=?5;   )   $??Center=?5<   )   
 ? Tag 5=   )   ?? *Type+??5>   *   ?? 5?   .   $??
0,0,90,100q?65   .+?5@   2   '  !MaterialDesignThemes.Wpf.PackIcon   ?? Left$ 0??5A   5   
 ?? Top$ 0??5B   5   $??50??5C   5   $??60??5D   5   $??Center=?5E   5      Kind 5F   5   ?? *Type+  5G   2   $ 55??5H   5   $??50??5I   5   $??60??5J   5   $??0,0,0,15q?5K   5   $??Center=?5L   5   $ AccountConvertOutline=?5M   5   5N   /   5P   '   5Q   #   5R      5T      5U      5V      ]? 5W      $??1??5X      $??5q?5Y      $
??Left=?5Z      .+?5[      ?? $	??600??5\      $	??550??5]      
???????	 ?? CornerRadius$	 5??5_      5c      5d      5e      5f      
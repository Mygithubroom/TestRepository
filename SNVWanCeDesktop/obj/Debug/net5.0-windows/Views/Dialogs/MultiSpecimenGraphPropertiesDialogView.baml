   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:WanCeDesktopApp.Views.DialogsWanCeDesktopApp.Views.Dialogs  5   	   J    DWanCeDesktopApp.Views.Dialogs.MultiSpecimenGraphPropertiesDialogView   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:WanCeDesktopApp.Views.Dialogs     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     ? Title$,  &MultiSpecimenGraphPropertiesDialogView??5	   	   $	??450??68   $	??800??6E    ? WindowStyle$
 None=?5
   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? AllowsTransparency$
 True??5   	   .??5      ? ???#626367 ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      ?? 5      $
??auto ?6   .+?5   
   (  "MaterialDesignThemes.Wpf.ColorZone  -   5          Name$ 	ColorZone??5   +   $??1q?5   #      Mode$ 
PrimaryMid=?5   +   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=?5   +   $	??Top=?5   +   .??5      ??  ?? Orientation$ 
Horizontal=?6   ???#FF0000.+?5      '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 	ChartLine=?6*   $??35??6;   $??50??6F   $??	10,0,10,0q?6R   ?? 5       .+?5!      ?? $%??Multi-specimen graph properties??6    $??5q?6I   ?? 5"      $??Graph1??6    $	??5,0q?6.   5#      5$      5%      A? 5(   
   $??10q?6   $??1??6"   
 A? Columns$
 4??6/   .+?5)      ?? $??10q?6   $
??Type??6"   ?? 5*      $??10q?6   $??X-Data??6"   ?? 5+      $??10q?6   $??Y-Data??6"   ?? 5,      $??10q?6   $??Advanced??6"   5-      ?? 50   
   $??2??6   .+?51      ?? $??Y-axis definition??6   $
??Bold"?61   $
??20,0q?6D   52      ? 55   
   $??3??6    56      ?? 57      $
??auto ?6    ?? 58      $
??auto ?6     ? ColumnDefinitions 5:      ?? 5;      $	??600 ?6#   ?? 5<      $	??200 ?6#   .+?5>      ?? $??Measurement:??6   $
??20,0q?6,   ?? 5?      $??Units??6   $??0??6&   $??1??63   ?? 5@      $??1??6   $??0??6$   $??20,10q?64    ?? SelectedIndex$ 0??6C   .@?5A      ?? .??6   	选项16$   ?? 5B      .??6   	选项26$   ?? 5C      .??6   	选项36$   ?? 5D      .??6   	选项46$   5E      ?? 5F      $??1??6   $??1??6$   $??
0,10,20,10q?64   $ 0??6H   .@?5G      ?? .??6   	选项16$   ?? 5H      .??6   	选项26$   ?? 5I      .??6   	选项36$   ?? 5J      .??6   	选项46$   5K      5L      ?? 5O   
   $ Vertical=?6   $??4??6,   .+?5P      ?? $??Y-axis scaling:??6   $
??20,0q?60   ?? 5Q      $??20,10q?6   $ 0??6&   .@?5R      ?? .??6   	选项16$   ?? 5S      .??6   	选项26$   ?? 5T      .??6   	选项36$   ?? 5U      .??6   	选项46$   5V      5W      ]? 5Z   
   $??5??6   $??False??6!   .+?5[      ?? $
??20,5q?6   .??5\        $	 HelpCircleOutline=?6*   $??25??6C   $??25??6O   5]      ?? 5^      -   5         ??Name$ Close??5`      $??Right=?5^      $
??20,5q?6,   $	??100??6:   $??Close??5_      5`      5a      5b      5c      
   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WanCeDesktopApp.CommonWanCeDesktopApp.Common  5      =#clr-namespace:WanCeDesktopApp.ViewsWanCeDesktopApp.Views  5	      ,    &WanCeDesktopApp.Views.SettingsUserView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7domain$clr-namespace:WanCeDesktopApp.Common     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5      /local#clr-namespace:WanCeDesktopApp.Views  5	      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :md1http://materialdesigninxaml.net/winfx/xaml/themes  5      .??5      ?? $
??Auto=?6   $
??Auto=?65   .??5      ? ???#626367  ? RowDefinitions  5      ?? 5      $
??auto ?6   ?? 5      .+?5      ? $??0??6
   $??0,20,0,0q?6    ? ColumnDefinitions 5      ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   .+?5      ? $??0??6   .+?5       ?? .+?5!      &   System.Windows.Controls.DataGrid  -   5          Name$ UserDataGrid??5"      $	??400??5#      $??10,0,0,0q?5$      $
??Left=?5%         AutoGenerateColumns$ False??5&         
IsReadOnly$
 True??5(      ??5)      ?? *LstUserModelsData+   ColumnHeaderStyle 5*   	   ?? 5+   
    ?? 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .?5,      ??  ?? Property ? ?? ?? Value$ Center=?68   ?? 5-       ? ?? ?#2226276(   ?? 5.       ? ??$ 	0,10,0,10q?6%   5/      	   Columns	 51   	   0  *System.Windows.Controls.DataGridTextColumn  52   
   ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID??64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6   ?? *ID+64     53   
    6   ?? *	Account+
 69   2  ,WPFLocalizeExtension.Extensions.LocExtension  *	Account+  54   
    6   ?? *
Password+
 6:     *
Password+  55   
    6   ?? *Grade+
 67     *Grade+  56   
    6   ?? *Name+
 66     *Name+  57   
    6   ?? *Phone+
 67     *Phone+  58   
    6   ?? *EndOfDateTime+
 6?     *EndOfDateTime+5:   	   5;      5<      ? 5?      $??1??6   $??50,0,0,0q?6     5@      ?? 5A      $
??auto ?6   ?? 5B      $
??auto ?6   ?? 5C      $
??auto ?6   ?? 5D      $
??auto ?6   ?? 5E      $
??auto ?6   ?? 5F      $
??auto ?6   ?? 5G      $
??auto ?6   ?? 5H      $
??auto ?6   ?? 5I      $
??auto ?6   ?? 5J      $
??auto ?6   ?? 5K      .+?5M      ??  ?? Orientation$ 
Horizontal=?6   .+?5N      ?? $	??150??6   $	??ID:??6!   ?? 5O      -   5         ??Name$ ID??5P      $	??150??5Q      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True??5R         MaterialDesignTextBox#??[  5S      ??5T      ??  ?? Path$ ID? ?? Mode$ TwoWay=?5U      ?? 5V      $??1??6   $ 
Horizontal=?6   .+?5W      ?? $	??150??5X      $??0,10,0,0q?5Y      ??5Z        *	Account+?? 5[      -   5        $ Account??5\      $	??150??5]      $??0,10,0,0q?5^      #??[  5_      5`      ?? 5a      $??2??6   $ 
Horizontal=?6   .+?5b      ?? $	??150??5c      $??0,10,0,0q?5d      ??5e        *
Password+G? 5f      -   5         G?Name$ Password??5f      $	??150??6&   5g      ?? 5h      $??4??6   $ 
Horizontal=?6   .+?5i      ?? $	??150??5j      $??0,10,0,0q?5k      ??5l        *Grade+?? 5m      -   5         ??Name$ Grade??5n      $	??150??5o      $??0,10,0,0q?5p        MaterialDesignComboBox#??[ 5q      .@?5r   	   ?? .??6   06   ?? 5s   	   .??6   106   ?? 5t   	   .??6   206   ?? 5u   	   .??6   306   ?? 5v   	   .??6   406   5w   	   5x      ?? 5y      $??5??6   $ 
Horizontal=?6   .+?5z      ?? $	??150??5{      $??0,10,0,0q?5|      ??5}        *
UserName+?? 5~      -   5        $ UserName??5      $	??150??5?      $??0,10,0,0q?5?      #??[  5?      5?      ?? 5?      $??6??6   $ 
Horizontal=?6   .+?5?      ?? $	??150??5?      $??0,10,0,0q?5?      ??5?        *Phone+?? 5?      -   5        $ Phone??5?      $	??150??5?      $??0,10,0,0q?5?      #??[  5?      5?      ?? 5?      $??9??5?      $??0,10,0,0q?5?      $ 
Horizontal=?5?      .+?5?      ?? $??0,0,0,0q?6   ??6      *Add+?? 5?      $??45,0,0,0q?6   ??6!     *Delete+?? 5?      $??45,0,0,0q?5?      ??5?      ?? *TestSqlcommand+??5?        *	OKNoSpace+5?      5?      5?      ]? 5?      $??	10,50,0,0q?6   $??False??6"   .+?5?      A? $??1??6   $??	0,250,0,0q?6   .+?5?      ?? -  'MaterialDesignThemes.Wpf.CheckBoxAssist   CheckBoxSize$ 30Q?5?      ??5?        *Test+ d? 	IsChecked 5?      ?? *Test+?? 5?      $ 30Q?5?      ??5?        *Method+ 5?      ?? *Method+?? 5?      $ 30Q?5?      ??5?        *SystemManagement+ 5?      ?? *SystemManagement+?? 5?      $ 30Q?5?      ??5?        *Unit+ 5?      ?? *Unit+?? 5?      $ 30Q?5?      ??5?        *	Setting+ 5?      ?? *	Setting+?? 5?      $ 30Q?5?      ??5?        *Calibration+ 5?      ?? *Calibration+?? 5?      $ 30Q?5?      ??5?        *Verification+ 5?      ?? *Verification+?? 5?      $ 30Q?5?      ??5?        *LineCorrection+ 5?      ?? *LineCorrection+?? 5?      $ 30Q?5?      ??5?        *KeyboardSpeed+ 5?      ?? *KeyboardSpeed+?? 5?      $ 30Q?5?      ??5?        *GBiso+ 5?      ?? *GBiso+?? 5?      $ 30Q?5?      ??5?        *DataRounding+ 5?      ?? *DataRounding+?? 5?      $ 30Q?5?      ??5?        *AccountManagement+ 5?      ?? *AccountManagement+?? 5?      $ 30Q?5?      ??5?        *PreviewReport+ 5?      ?? *PreviewReport+?? 5?      $ 30Q?5?      ??5?        *
TestMethod+ 5?      ?? *
TestMethod+?? 5?      $ 30Q?5?      ??5?        *EditReportTemplate+ 5?      ?? *EditReportTemplate+?? 5?      $ 30Q?5?      ??5?        *DataManagerment+ 5?      ?? *DataManagerment+?? 5?      $ 30Q?5?      ??5?        *CurveAnalysis+ 5?      ?? *CurveAnalysis+?? 5?      $ 30Q?5?      ??5?        *Print Report+ 5?      ?? *PrintReport+?? 5?      $ 30Q?5?      ??5?        *languageManagement+ 5?      ?? *LanguageManagement+5?      5?      5?      5?      5?      
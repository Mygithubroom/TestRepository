   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WanCeDesktopApp.CommonWanCeDesktopApp.Common  5      =#clr-namespace:WanCeDesktopApp.ViewsWanCeDesktopApp.Views  5	      ,    &WanCeDesktopApp.Views.SettingsUserView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7domain$clr-namespace:WanCeDesktopApp.Common     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5      /local#clr-namespace:WanCeDesktopApp.Views  5	      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :md1http://materialdesigninxaml.net/winfx/xaml/themes  5      .??5      ?? $
??Auto=?6   $
??Auto=?65   .??5      ? ???#626367  ? RowDefinitions  5      ?? 5      $
??auto ?6   ?? 5      .+?5      ? $??0??6
   $??0,20,0,0q?6    ? ColumnDefinitions 5      ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   .+?5      ? $??0??6   .+?5       ?? .+?5!      &   System.Windows.Controls.DataGrid  -   5          Name$ UserDataGrid??5"      $	??525??5#      $	??200??5$      $??10,0,0,0q?5%      $
??Left=?5&         AutoGenerateColumns$ False??5'         
IsReadOnly$
 True??5(      $
??Auto=?5*      ??5)      ?? *LstUserModelsData+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5+   	   +  %Microsoft.Xaml.Behaviors.EventTrigger  5,   
      	EventName$ SelectionChanged??6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5-      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6!   ?? *CurrentCellChanged+	   CommandParameter	 6H   ?? 
 ?? ElementName$
 UserDataGrid?? ?? Path$ SelectedItem?5.         ColumnHeaderStyle 51   	   ?? 52   
    ?? 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .?53      ??  ?? Property ? ?? ?? Value$ Center=?68   ?? 54       ? ?? ?#2226276(   ?? 55       ? ??$ 
30,10,0,10q?6%   56         Columns 58   	   0  *System.Windows.Controls.DataGridTextColumn  59   
   ,  &System.Windows.Controls.DataGridColumn   Header$ ID??68   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6   ?? *UserID+68     5:   
    6   ?? *
Password+ 6:   2
  ,WPFLocalizeExtension.Extensions.LocExtension
  *
Password+  5;   
    6   ?? *Level+ 67   
  *Grade+  5<   
    6   ?? *
UserName+ 6:   
  *Name+  5=   
    6   ?? *Phone+ 67   
  *Phone+  5>   
    6   ?? *LoginDateTime+ 6?   
  *LoginDateTime+5@   	   5A      5B      ? 5E      $??1??6   $??50,0,0,0q?6     5F      ?? 5G      $
??auto ?6   ?? 5H      $
??auto ?6   ?? 5I      $
??auto ?6   ?? 5J      $
??auto ?6   ?? 5K      $
??auto ?6   ?? 5L      $
??auto ?6   ?? 5M      $
??auto ?6   ?? 5N      $
??auto ?6   ?? 5O      $
??auto ?6   ?? 5P      $
??auto ?6   ?? 5Q      .+?5S      ??  ?? Orientation$ 
Horizontal=?6   .+?5T      ?? $	??150??6   $	??ID:??6!   ?? 5U      $	??150??5V      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True??5W         MaterialDesignTextBox#??[  5X      ??5Y      ?? *UserID+5Z      ?? 5\      $??2??6   $ 
Horizontal=?6   .+?5]      ?? $	??150??5^      $??0,10,0,0q?5_      ??5`      
  *
Password+?? 5a      $	??150??5b      #??[  5c      ??5d      ?? *
Password+5e      ?? 5f      $??4??6   $ 
Horizontal=?6   .+?5g      ?? $	??150??5h      $??0,10,0,0q?5i      ??5j      
  *Grade+?? 5k      $	??150??5l      $??0,10,0,0q?5m      #??[  5n      ??5o      ?? *Level+5p      ?? 5q      $??5??6   $ 
Horizontal=?6   .+?5r      ?? $	??150??5s      $??0,10,0,0q?5t      ??5u      
  *
UserName+?? 5v      $	??150??5w      $??0,10,0,0q?5x      #??[  5y      ??5z      ?? *
UserName+5{      ?? 5|      $??6??6   $ 
Horizontal=?6   .+?5}      ?? $	??150??5~      $??0,10,0,0q?5      ??5?      
  *Phone+?? 5?      $	??150??5?      $??0,10,0,0q?5?      #??[  5?      ??5?      ?? *	UserPhone+5?      ?? 5?      $??9??5?      $??0,10,0,0q?5?      $ 
Horizontal=?5?      .+?5?      ?? $??0,0,0,0q?5?      ??5?      ?? *AddUserInfo+??5?      
  *Add+?? 5?      $??45,0,0,0q?5?      ??5?      ?? *UpDateUserInfo+??5?      
  *Update+?? 5?      $??45,0,0,0q?5?      ??5?      ?? *	OKcommand+??5?      
  *	OKNoSpace+5?      5?      5?      ]? 5?      $??	10,50,0,0q?6   $??False??6"   .+?5?      A? $??1??6   $??	0,250,0,0q?6   .+?5?      ?? -  'MaterialDesignThemes.Wpf.CheckBoxAssist   CheckBoxSize$ 30Q?5?      ??5?      
  *Test+ d? 	IsChecked 5?      ?? *Test+?? 5?      $ 30Q?5?      ??5?      
  *Method+ 5?      ?? *Method+?? 5?      $ 30Q?5?      ??5?      
  *SystemManagement+ 5?      ?? *SystemManagement+?? 5?      $ 30Q?5?      ??5?      
  *Unit+ 5?      ?? *Unit+?? 5?      $ 30Q?5?      ??5?      
  *	Setting+ 5?      ?? *	Setting+?? 5?      $ 30Q?5?      ??5?      
  *Calibration+ 5?      ?? *Calibration+?? 5?      $ 30Q?5?      ??5?      
  *Verification+ 5?      ?? *Verification+?? 5?      $ 30Q?5?      ??5?      
  *LineCorrection+ 5?      ?? *LinearCorrection+?? 5?      $ 30Q?5?      ??5?      
  *KeyboardSpeed+ 5?      ?? *KeyboardSpeed+?? 5?      $ 30Q?5?      ??5?      
  *GBiso+ 5?      ?? *GBiso+?? 5?      $ 30Q?5?      ??5?      
  *DataRounding+ 5?      ?? *DataRounding+?? 5?      $ 30Q?5?      ??5?      
  *AccountManagement+ 5?      ?? *AccountManagement+?? 5?      $ 30Q?5?      ??5?      
  *PreviewReport+ 5?      ?? *PreviewReport+?? 5?      $ 30Q?5?      ??5?      
  *
TestMethod+ 5?      ?? *
TestMethod+?? 5?      $ 30Q?5?      ??5?      
  *EditReportTemplate+ 5?      ?? *EditReportTemplate+?? 5?      $ 30Q?5?      ??5?      
  *DataManagement+ 5?      ?? *DataManagement+?? 5?      $ 30Q?5?      ??5?      
  *CurveAnalysis+ 5?      ?? *CurveAnalysis+?? 5?      $ 30Q?5?      ??5?      
  *Print Report+ 5?      ?? *PrintReport+?? 5?      $ 30Q?5?      ??5?      
  *languageManagement+ 5?      ?? *LanguageManagement+5?      5?      5?      5?      5?      
   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WanCeDesktopApp.CommonWanCeDesktopApp.Common  5      G(clr-namespace:WanCeDesktopApp.ExtensionsWanCeDesktopApp.Extensions  5      1clr-namespace:WanCeDesktopAppWanCeDesktopApp  5
      )    #WanCeDesktopApp.Views.SetSensorView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      3cv$clr-namespace:WanCeDesktopApp.Common     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8ext(clr-namespace:WanCeDesktopApp.Extensions     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5	      )localclr-namespace:WanCeDesktopApp  5
      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .??5      ? .+?5      #  MaterialDesignThemes.Wpf.Card  .??5      ? ???#626367 ? RowDefinitions 5      ?? 5      $??50 ?6   ?? 5      $??* ?6   .+?5      ?? $??0??5      $??	10,10,0,0q?5      $
??Wrap=?5      ??5      2  ,WPFLocalizeExtension.Extensions.LocExtension  *SelectSetSensors+5      ? 5      $??1??6    ? ColumnDefinitions 5       ?? 5!      ?? 5"      $??80 ?6   ?? 5#      ?? 5$      .+?5&      ?? $??0??5'      $??	10,10,0,0q?5(      $	??Top=?5)         txbkFirstTitle#??[  5*      ??5+        *AvailableSensors+?? 5,      $??0??5-      $??
10,40,0,10q?5.      ???#222627 ?? CornerRadius$ 5??50      ]? 51      $??0??6   $??
10,40,0,10q?6!   .+?52      ?? -   5         ??Name$ listBoxLeft??52      ??6%   ?? *AvailableSersorLists+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 53   	   +  %Microsoft.Xaml.Behaviors.EventTrigger  54   
      	EventName$ MouseDoubleClick??6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 55      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6!   ?? *MoveToRightCommand+	   CommandParameter	 6H   ?? 
 ?? ElementName$
 listBoxLeft?? ?? Path$ SelectedItem?56      ??58   	   ?? 59   
   .R?5:      ?? $??5,0,0,0q?6   ??6&   ?? *	Content+5;      5=   	   5>      ?? 5?      $??1??5@      $??Center=?5A      $??Center=?5B      .+?5C      ?? $??70??5D      $??46??5E      $??0,0,0,10q?5F      ??5G      ?? *MoveToRightCommand+??5H      ?? $
 listBoxLeft??$ SelectedItem???5I      0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ 
ArrowRight=?   Size 40?? 5K      $??70??5L      $??46??5M      $??0,0,0,0q?5N      ??5O      ?? *MoveToLeftCommand+??5P      ?? $
 listBoxRight??$ SelectedItem???5Q        $ 	ArrowLeft=? 405S      ?? 5T      $??2??5U      $??0,10,0,0q?5V      $	??Top=?5W      #??[  5X      ??5Y        *SelectedSensors+?? 5Z      $??2??5[      $??	0,40,0,10q?5\      ???#222627$ 5??5^      ]? 5_      $??2??6   $??	0,40,0,10q?6!   .+?5`      ?? -   5        $ listBoxRight??5a      ??5b      ?? *SelectedSersorLists+ ?? SelectedItem 5c      ?? *SelectedShowInfo+ 5d   	     5e   
   $ MouseDoubleClick??6   . 5f         6!   ?? *MoveToLeftCommand+	 6G   ?? $
 listBoxRight??$ SelectedItem?5g        5h   
   $ SelectionChanged??6   . 5i         6!   ?? *
UpDataText+	 6@   ?? $
 listBoxRight??$ SelectedItem?5j      ??5l   	   ?? 5m   
   .R?5n      ?? $??5,0,0,0q?6   ??6&   ?? *	Content+5o      5q   	   5r      ? 5s      $??3??6    5t      ?? 5u   	   $??40 ?6   ?? 5v   	   .+?5x      ?? $??Center=?6   .+?5y   	   ?? $??2??5z   	   $??10,0,0,0q?5{   	   $??Center=?5|   	   #??[  5}   	   ??5~   	     *ParameterSettings+5   	   ?? 5?      $??1??6   $??10,0,0,0q?6    .+?5?   	   ?? $	??0,5q?6    ?? Orientation$ 
Horizontal=?6!   .+?5?   
   ?? $	??200??5?   
   $??Center=?5?   
   ??5?   
     *SensorsName+?? 5?   
   -   5         ??Name$ Texti??5?   
   $	??200??5?   
   .	  (MaterialDesignThemes.Wpf.TextFieldAssist 	  HasClearButton$ False??5?   
    ? Cursor$ Arrow??5?   
   ??5?   
   ?? *	InputText+ ?? UpdateSourceTrigger$ PropertyChanged=?5?   
   ?? 5?   	   $	??0,5q?6   $ 
Horizontal=?6!   .+?5?   
   ?? $	??200??5?   
   $??Center=?5?   
   ??5?   
     *	Precision+?? 5?   
   $	??200??6   $ Arrow??6"   .@?5?      ?? .??6   标准采集6   ?? 5?      .??6   间隔采集6   ?? 5?      .??6   高精度采集6   5?      5?   
   ?? 5?   	   $	??0,5q?6   $ 
Horizontal=?6!   .+?5?   
   ?? $	??200??5?   
   $??Center=?5?   
   ??5?   
     *Rate+?? 5?   
   $	??200??5?   
   $ Arrow??5?   
    ?? IsInputMethodEnabled$ False??5?   
   5?   
   ?? 5?   	   $??0,10,0,0q?6   $ 
Horizontal=?6&   .+?5?   
   ?? $	??150??5?   
   $??46??5?   
   ??5?   
   ?? *OpenDialogCommand+??5?   
     *CheckSencor+?? 5?   
   $	??150??5?   
   $??46??5?   
   $??	100,0,0,0q?5?   
   ??5?   
     *OK+5?   
   ?? 5?   	   .+?5?   
   ?? $
??0,10q?6   ??6"     *
Describe+?? 5?   
   $	??400??5?   
   $	??250??5?   
   $
??Left=?5?   
   
???   ?$??1,1,1,1q?5?   
   $ 5??5?   
   5?   
   5?   	   5?      5?      5?      5?      5?      5?      
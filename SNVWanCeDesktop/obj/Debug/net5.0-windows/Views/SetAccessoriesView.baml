   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WanCeDesktopApp.CommonWanCeDesktopApp.Common  5      G(clr-namespace:WanCeDesktopApp.ExtensionsWanCeDesktopApp.Extensions  5      1clr-namespace:WanCeDesktopAppWanCeDesktopApp  5
      G(clr-namespace:WanCeDesktopApp.ViewModelsWanCeDesktopApp.ViewModels  5      .    (WanCeDesktopApp.Views.SetAccessoriesView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      3cv$clr-namespace:WanCeDesktopApp.Common     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8ext(clr-namespace:WanCeDesktopApp.Extensions     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5	      )localclr-namespace:WanCeDesktopApp  5
      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5      ;
viewmodels(clr-namespace:WanCeDesktopApp.ViewModels 	 
 5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .??5      ? .+?5      #  MaterialDesignThemes.Wpf.Card  .??5      ? ???#626367 ? RowDefinitions 5      ?? 5      $??50 ?6   ?? 5      $??* ?6   .+?5      ?? $??0??5      $??	10,10,0,0q?5      $
??Wrap=?5      ??5      2  ,WPFLocalizeExtension.Extensions.LocExtension  *SelectSetAccessories+5      ? 5       $??1??6    ? ColumnDefinitions 5!      ?? 5"      ?? 5#      $??80 ?6   ?? 5$      ?? 5%      .+?5'      ?? $??0??5(      $??	10,10,0,0q?5)      $	??Top=?5*         txbkFirstTitle#??[  5+      ??5,        *AvailableAccessories+?? 5-      $??0??5.      $??
10,40,0,10q?5/      ???#222627 ?? CornerRadius$ 5??51      ]? 52      $??0??6   $??
10,40,0,10q?6!   .+?53      ?? -   5         ??Name$ listBoxLeft??53      ??6%   ?? *AvailableAccessoriesLists+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 54   	   +  %Microsoft.Xaml.Behaviors.EventTrigger  55   
      	EventName$ MouseDoubleClick??6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 56      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6!   ?? *MoveToRightCommand+	   CommandParameter	 6H   ?? 
 ?? ElementName$
 listBoxLeft?? ?? Path$ SelectedItem?57      ??59   	   ?? 5:   
   .R?5;      ?? $??5,0,0,0q?6   ??6&   ?? *	Content+5<      5>   	   5?      ?? 5@      $??1??5A      $??Center=?5B      $??Center=?5C      .+?5D      ?? $??70??5E      $??46??5F      $??0,0,0,10q?5G      ??5H      ?? *MoveToRightCommand+??5I      ?? $
 listBoxLeft??$ SelectedItem???5J      0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ 
ArrowRight=?   Size 40?? 5L      $??70??5M      $??46??5N      $??0,0,0,0q?5O      ??5P      ?? *MoveToLeftCommand+??5Q      ?? $
 listBoxRight??$ SelectedItem???5R        $ 	ArrowLeft=? 405T      ?? 5U      $??2??5V      $??0,10,0,0q?5W      $	??Top=?5X      #??[  5Y      ??5Z        *SelectedAccessories+?? 5[      $??2??5\      $??	0,40,0,10q?5]      ???#222627$ 5??5_      ]? 5`      $??2??6   $??	0,40,0,10q?6!   .+?5a      ?? -   5        $ listBoxRight??5a      ??6&   ?? *SelectedAccessoriesLists+ 5b   	     5c   
   $ MouseDoubleClick??6   . 5d         6!   ?? *MoveToLeftCommand+	 6G   ?? $
 listBoxRight??$ SelectedItem?5e        5f   
   $ SelectionChanged??6   . 5g         6!   ?? *
UpDataText+	 6@   ?? $
 listBoxRight??$ SelectedItem?5h      ??5j   	   ?? 5k   
   .R?5l      ?? $??5,0,0,0q?6   ??6&   ?? *	Content+5m      5o   	   5p      ]? 5q      $??3??6   .+?5r      ?  5s   	   ?? 5t   
   $??40 ?6   ?? 5u   
   .+?5w   	   ?? $??Center=?6   .+?5x   
   ?? $??2??5y   
   $??10,0,0,0q?5z   
   $??Center=?5{   
   #??[  5|   
   ??5}   
     *ParameterSettings+5~   
   ?? 5   	   $??1??6   $??10,0,0,0q?6!   .+?5?   
   ?? $	??0,5q?6    ?? Orientation$ 
Horizontal=?6"   .+?5?      ?? $	??200??5?      $??Center=?5?      ??5?        *AccessoriesName+?? 5?      $??45??5?      $	??200??5?      $??10,8,2,2q?5?      .	  (MaterialDesignThemes.Wpf.TextFieldAssist 	  HasClearButton$ False??5?       ? Cursor$ Arrow??5?      $??25(?5?       ?? 
IsReadOnly$
 true??5?       ! MaterialDesignOutlinedTextBox#??[ 5?      ??5?      ?? *	InputText+5?      ?? 5?   
   $	??0,5q?6   $ 
Horizontal=?6"   .+?5?      ?? $	??200??5?      $??Center=?5?      ??5?        *CommunicationsModule+?? 5?      $	??200??6   $ Arrow??6#   .@?5?      ?? .??6   Serial RS-4856(   ?? 5?      .??6   Serial RS-2326(   ?? 5?      .??6   USB6   5?      5?      ?? 5?   
   $	??0,5q?6   $ 
Horizontal=?6"   .+?5?      ?? $	??200??5?      $??Center=?5?      ??5?        *
BaudRate+?? 5?      $??45??5?      $	??200??5?      $??10,8,2,2q?5?      $
 true??5?      $ Arrow??5?      $??25(?5?      #??[ 5?      5?      ?? 5?   
   $	??0,5q?6   $ 
Horizontal=?6"   .+?5?      ?? $	??200??5?      $??Center=?5?      ??5?        *	ParityBit+?? 5?      $	??200??6   .@?5?      ?? .??6   COM16   ?? 5?      .??6   COM26   ?? 5?      .??6   COM36   ?? 5?      .??6   COM46   ?? 5?      .??6   COM56   5?      5?      ?? 5?   
   $??0,10,0,0q?6   $ 
Horizontal=?6'   .+?5?      ?? $	??150??5?      $??46??5?      ??5?        *ResetTwoSpacing+?? 5?      $	??150??5?      $??46??5?      $??	100,0,0,0q?5?      ??5?        *OK+5?      ?? 5?   
   .+?5?      ?? $
??0,10q?6   ??6#     *
Describe+?? 5?      $	??400??5?      $	??190??5?      $
??Left=?5?      
???   ?$??1,1,1,1q?5?      $ 5??5?      5?      5?   
   5?   	   5?      5?      5?      5?      5?      5?      
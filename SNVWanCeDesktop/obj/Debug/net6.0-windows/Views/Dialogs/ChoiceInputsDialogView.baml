   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WanCeDesktopApp.CommonWanCeDesktopApp.Common  5      G(clr-namespace:WanCeDesktopApp.ExtensionsWanCeDesktopApp.Extensions  5      1clr-namespace:WanCeDesktopAppWanCeDesktopApp  5
      G(clr-namespace:WanCeDesktopApp.ViewModelsWanCeDesktopApp.ViewModels  5      :    4WanCeDesktopApp.Views.Dialogs.ChoiceInputsDialogView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      3cv$clr-namespace:WanCeDesktopApp.Common     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8ext(clr-namespace:WanCeDesktopApp.Extensions     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5	      )localclr-namespace:WanCeDesktopApp  5
      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5      ;
viewmodels(clr-namespace:WanCeDesktopApp.ViewModels 	 
 5      $	??600??5      $	??500??5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $??* ?6   .+?5   
   ? $??0??6   .+?5      ?? $??60??5      ???#626367 ?? CornerRadius$ 3,3,0,0??5      ._?5      ]? .+?5      '  !MaterialDesignThemes.Wpf.PackIcon  $??60??5       $??60??5!      
???????   Kind$ 	PencilBox=?5#      ?? 5$      $??6,8,0,0q?5%      
???????$!?? Properties - Choice input ??5'      5(      5)      5*      ?? 5+   
   $??1??6   $
??20,0q?6"   .+?5,      ?  5-      ?? 5.      $
??auto ?6$   ?? 5/      .+?51      ?? .+?52      ??  ?? Orientation$ 
Horizontal=?6!   .+?53      ?? $	??110??54      $??Center=?55      $
??Wrap=?57      ??56      2  ,WPFLocalizeExtension.Extensions.LocExtension  *Prompt+57      ?? 58      $	??400??59      $??0,10,0,0q?5:      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True??5;      5<      ]? 5=      $
??0,10q?6    $??False??6.   .+?5>      ?? $	??110??5?      $??Center=?5@      $
??Wrap=?5B      ??5A        *Defaultvalue+5B      ?? 5C      $	??400??5D      $
 True??5E      ??5F      ?? *	Choices+5G      ]? 5H      .+?5I      ?? -  'MaterialDesignThemes.Wpf.CheckBoxAssist   CheckBoxSize$ 30Q?6#   ??6S     *Allow None as a chioce+5J      5K      ? 5L      $??1??6   $??0,0,0,10q?6$    ? ColumnDefinitions 5M      ?? 5N      ?? 5O      $
??auto ?6+   .+?5Q      ?? $??Disabled=?6#   $
??Auto=?6L   .??5S      &   System.Windows.Controls.DataGrid  -   5          Name$ 
myDataGrid??5T      $
??auto??5U      $	??200??5V      $??5,0,10,0q?5W      
???   ?$??1q?5Z      	   CanUserAddRows$	 False??5[      
   CanUserDeleteRows$

 True??5\         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 120 5]      $|?False??5_         GridLinesVisibility$ Vertical=?5`         SelectionMode$ Extended=?5c         SelectionUnit$
 Cell=?5d         MaterialDesignDataGrid#??[  5e      ??5a      ?? *PropertyTable+
 ? Tag 5f      ?? *SelectItemIndex+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5g      +	  %Microsoft.Xaml.Behaviors.EventTrigger	  5h   "    	  	EventName$ 
Unselected??61   *
  $Microsoft.Xaml.Behaviors.TriggerBase 
  Actions. 5i   &   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6<   ?? *CurrentCellChangedCommand+   CommandParameter 6j   ??  ?? RelativeSource ??  ?? Mode$ FindAncestor=? ?? AncestorType DataGrid ?? Path$	 Tag?5j   #   5l      5m      ?? 5n      $??1??6!   .+?5o      ?? $??41??5p      $??35??5q      $??0,0,0,0q?5r      $??0,3,0,0q?5s       ? Cursor$
 Hand??5w      ??5t      ?? *AddRowCommand+??5u      0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$	 Add=?   Size 245w      ?? 5x      -   5         ??Name$ 	DeleteRow??5y      $??41??5z      $??35??5{      $??0,8,0,0q?5|      $??0,0,0,0q?5}      $
 Hand??5?      ??5~      ?? *DeleteRowCommand+??5      ??  ?? $
 Self=?$	 Tag???5?        $ Delete=? 24 5?      ??  ?? ElementName$ 
myDataGrid??$	 Tag??? 5?      -   5        $ 	MoveUpRow??5?      $??41??5?      $??35??5?      $??0,8,0,0q?5?      $??0,0,0,0q?5?      ??5?      ?? *MoveUpRowCommand+??5?      ??  ?? $
 Self=?$	 Tag???5?        $ ArrowTop=? 24 5?      ?? $ 
myDataGrid??$	 Tag??? 5?      -   5        $ MoveDownRow??5?      $??41??5?      $??35??5?      $??0,8,0,0q?5?      $??0,0,0,0q?5?      $
 Hand??5?      ??5?      ?? *MoveDownRowCommand+??5?      ??  ?? $
 Self=?$	 Tag???5?        $ ArrowBottom=? 24 5?      ?? $ 
myDataGrid??$	 Tag??? 5?      $??41??5?      $??35??5?      $??0,8,0,0q?5?      $??0,0,0,0q?5?      ??5?      ?? *LineColumnCommand+??5?      ?? $ 
myDataGrid??$ SelectedValue???5?        $
 Link=? 24 5?      ?? $ 
myDataGrid??$	 Tag?5?      5?      5?      5?      ]? 5?   
   $??2??5?      $??70??5?      $
??20,0q?5?      $??Center=?5?      $??False??5?      .+?5?      ?? $??49??6   ??6!     $ QuestionMark=? 24?? 5?      $??Right=?6   $ 
Horizontal=?60   .+?5?      ?? $??49??5?      $??0,0,20,0q?5?         MaterialDesignOutlinedButton#??[ 5?      ??5?      ?? *CancelCommand+??5?        *CancelTwoSpacing+5?      ?? 5?      $??49??5?      $
 Hand??5?      ??5?      ?? *SaveCommand+??5?        *OK+5?      5?      5?      5?      5?      
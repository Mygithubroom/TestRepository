   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WanCeDesktopApp.ViewsWanCeDesktopApp.Views  5      -    'WanCeDesktopApp.Views.ExportReportsView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5      /local#clr-namespace:WanCeDesktopApp.Views  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	        ? 	Resources  5         TextBoxStyle ?? 
TargetType ?? Property ?? Value  ButtonStyle ?? 
TargetType ?? CornerRadius ?? Triggers P? Property P? Value??%?  &	        &	 ?     ?? 5      " ??6   .?5      ??  ? ??$
 Left=?6+   ?? 5       ? ??$ Center=?6)   ?? 5       ? ??$ Center=?60   5      ?? 5      " ??6   .?5      ??  ?@?Cursor$
 Hand??6   ?? 5       ? ??$ 60??6   ?? 5       ? ??$ 30??6   ?? 5       ? ??$ 15(?6    ?? 5       ? ?? 5      ?? 5      " ??6   .R?5      ? .+?5   	   ?? #??z??5   	   #??z??5   	   $??0,0,0,0q?5    	   $??Center=?5!   	   $??Center=?5"   	   
???????$??1q?5$   	   $ 5,5,5,5??5%   	   ._?5&   
   ?? $??1??5'   
   $??Center=?5(   
   $??Center=?5)   
   
???   ?#??z??5+   
   5,   
   5-   	    5.      P? 50   	    ?@J?IsMouseOver$
 True??6/   . ?51   
   ??  ?@J?Opacity$ 1Q?6$   ?? 52   
    ? ??$
 Bold"?6'   53   
   5D      5F      5G      5H      .??5I      ? ???#626367	 ? RowDefinitions	 5J      ?? 5K      $
??auto ?6   ?? 5L      $??* ?6   .+?5O      ?? $??	10,10,0,0q?6   
 ?? Orientation$
 Vertical=?6"   .+?5P      ?? ??6   2  ,WPFLocalizeExtension.Extensions.LocExtension  *Edit report Settings+?? 5Q      $
??1300??5R      $
??Left=?5S      $
??Wrap=?5U      ??5T        *ExportReportsDescribeOne+5U      5V      ? 5X      $??1??6	   $??	10,10,0,0q?6    ? ColumnDefinitions 5Y      ?? 5Z      ?? 5[      $
??auto ?6   .+?5]      ? ?? 5^      $??0??6   $
 Vertical=?6    .+?5_      ?? $
 
Horizontal=?6   .+?5`      ?? $	??200??5a      $??Center=?5b      ??5c        *Report Settings+?? 5d      $	??400??5e      $??14(?5f       ! MaterialDesignOutlinedTextBox#??[ 5g      ??5h      ?? *	ReportSet+?? 5i      $	??100??5j      $??50??5k      $??10,0,0,0q?5l      ??5m        *Change+5n      ?? 5o      $??0,10,0,0q?6   $
 
Horizontal=?6#   .+?5p      ?? $	??200??5q      $
??Left=?5r      ??5s        *
Template+?? 5t      $	??400??6    ?? SelectedValue 6   ?? *ReportTemplate+5u      ?? 5v      $
??Left=?6   ??6&     *Report format+?? 5w      $??	10,10,0,0q?5x      -  'MaterialDesignThemes.Wpf.CheckBoxAssist   CheckBoxSize$ 30Q?5y      $??14(?5{      ??5z        *Save Report+ d? 	IsChecked 5|      ?? *
SaveReport+?? 5}      $??	10,10,0,0q?5~      $ 30Q?5      $??14(?5?      ??5?        *Print Report+ 5?      ?? *PrintReport+?? 5?      $??0,10,0,0q?6   ??6"     *Print graph+?? 5?      $??	10,10,0,0q?5?      $ 30Q?5?      ??5?        *Print graph1+ 5?      ?? *PrintGraphice1+?? 5?      $??	10,10,0,0q?5?      $ 30Q?5?      ??5?        *Print graph2+ 5?      ?? *PrintGraphice2+5?      ?? 5?      $??1??6   $??	0,10,20,0q?6   ._?5?      ]? $??False??6   .+?5?      ?? $??0,5,0,20q?5?      $??Center=?5?      $??Bottom=?5?      ??5?        *Print+?? 5?      $??0,10,0,0q?5?      $??Bottom=?5?       & "MaterialDesignFloatingActionButton#??[ 5?       ? ToolTip$( "MaterialDesignFloatingActionButton??5?      {?5?      ?? *DataContext.ControlsEnabled+ ?? RelativeSource ?? *FindAncestor+ ?? AncestorType
 Window.??5?      '  !MaterialDesignThemes.Wpf.PackIcon  $??30??5?      $??30??5?         Kind$ PrinterSettings=?5?      5?      ?? 5?      $??0,5,0,20q?5?      $??Center=?5?      $??Bottom=?5?      ??5?        *	Save as+?? 5?      $??0,10,0,0q?5?      $??Bottom=?5?      #??[ 5?      $( "MaterialDesignFloatingActionButton??5?      {?5?      ?? *DataContext.ControlsEnabled+ ?? *FindAncestor+
 Window.??5?        $??30??5?      $??30??5?      $  ContentSaveSettingsOutline=?5?      5?      5?      5?      5?      5?      5?      
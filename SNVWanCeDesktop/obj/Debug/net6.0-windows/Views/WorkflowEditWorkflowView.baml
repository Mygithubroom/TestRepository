   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WanCeDesktopApp.ViewsWanCeDesktopApp.Views  5      4    .WanCeDesktopApp.Views.WorkflowEditWorkflowView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5      /local#clr-namespace:WanCeDesktopApp.Views  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	        ? 	Resources  5       "  MaterialDesignOutlinedComboBox ?? 
TargetType ?? Property ?? Value ?? 
TargetType ?Name ? ColumnDefinitions ??Name ?? CornerRadius	 ??Name
 T? X K? ZIndex ?? Triggers P? Property P? Value ?? 
TargetName :? RoutedEvent ?? 
TargetName ?? TargetProperty	 W? To g? Duration	 ?? To??%?  &	        ?? 5   
   " ??67   .?5      ??  ? ??$ 15(?6)   ?? 5       ?@?Cursor$
 Hand??6'   ?? 5       ? ?? 5      ?? 5      " ??6&   .R?5      ? $ templateRoot??6    5      ?? 5   "   $
??auto ?63   ?? 5   "   $
??auto ?63   .+?5      ? $ border??5   !   $??50??5   !   #??z??5   !   .+?5   "   (? .??5   &   ? .+?5   *   ?? $
 back??5    -   $??50??5!   -   
???????$ 9??5#   -   ?? 5$   *   $
	 text??5%   -   $??0,0,0,0q?5&   -   $??Center=?5'   -   $	??OFF??5(   -   z?5)   .   T? 5*   2   	transText??$
 20Q?6X   5,   +   ?? 5-   *   $ ToggleButton??5.   -   $??18??5/   -   $??18??50   -   $??1,0,0,0q?51   -   $
??Left=?52   -   
???????$ 18??54   -   z?55   .   T? 56   2   transBorder??$
 0Q?6Z   58   +   59   '   5:   #   5;      ?? 5<      $??1??5=   !   $??3,0,0,0q?5>   !   $
??Left=?5?   !   $??Center=?5@   !   $	 100??5A   !   5B       5C      P? 5D       ?@d?	IsChecked$
 TrueY?6;   . ?5E   "   ?? $
 text??6)    ? ??$ ON??6K   5F      P? 5G       ?@d?	IsChecked$ FalseY?6;   . ?5H   "   ?? $
 text??6)    ? ??$	 OFF??6K   5I      :? 5K      $ 	Unchecked??6+   .[?5L   "   ?? .??5M   &   ?? $ 	transText??61   $ X?6S   .??5N   *   W?  206:   $ 0:0:0.2D?6B   5O   '   5P   #   ?? 5Q   "   .??5R   &   ?? $ transBorder??61   $ X?6U   .??5S   *   W?  06:   $ 0:0:0.2D?6A   5T   '   5U   #   ?? 5V   "   .??5W   &   ?? $
 back??61   $ Background.Color?6N   .??5Y   *   ??  Gray69   $ 0:0:0.2D?6C   5Z   '   5[   #   5\      :? 5]      $ Checked??6+   .[?5^   "   ?? .??5_   &   ?? $ 	transText??61   $ X?6S   .??5`   *   W?  56:   $ 0:0:0.2D?6A   5a   '   5b   #   ?? 5c   "   .??5d   &   ?? $ transBorder??61   $ X?6U   .??5e   *   W?  306:   $ 0:0:0.2D?6B   5f   '   5g   #   ?? 5h   "   .??5i   &   ?? $
 back??61   $ Background.Color?6N   .??5k   *   ??  #00c00069   $ 0:0:0.2D?6F   5l   '   5m   #   5n      P? 5o       ? {?$ False??6;   . ?5p   "   ?? $ templateRoot??6)    ?@J?Opacity$	 0.6Q?6V   5q      5s      5u      5v      5w      .??5x      ? .+?5y   
   ??  ?? Orientation$ Vertical=?6   .+?5z      ?? $??	10,10,0,0q?5{        txbkFirstTitle#??[ 5|      ??5}      2  ,WPFLocalizeExtension.Extensions.LocExtension  *Edit Workflow+]? 5~      $??10,0,0,0q?6   $??False??6*   .+?5      ?? $??Center=?6   ??67     *Sample size+?? 5?      $	??700??6   $??	200,0,0,0q?6'   .@?5?      ?? $??Item 1??6#   ?? 5?      $??Item 2??6#   ?? 5?      $??Item 3??6#   5?      5?      ]? 5?      $??	10,10,0,0q?6   $??False??6+   .+?5?      ?? -  'MaterialDesignThemes.Wpf.CheckBoxAssist   CheckBoxSize$ 30Q?5?      $??16(?5?      ??5?        */-Automatically start a new sample after Finish+5?      5?      ]? 5?      $??	10,10,0,0q?6   .+?5?      ?? -   5         ??Name$ ckbRunPrompted??5?      $ 30Q?5?      $??16(?5?      
 ? Tag$ RunPromptedPanel??5?      ??5?        *Run as a prompted+5?      5?      ?? 5?      -   5         ??Name$ RunPromptedPanel??5?      $
??60,0q?5?      $ Vertical=?5?      $y?	Collapsed=?5?      .+?5?      ?? $??0,10,0,0q?6   $ 
Horizontal=?6/   .+?5?      ?? $	??150??6    ??6/     *Start Sample+?? 5?      $ 30Q?6   5?      ?? 5?      $??0,10,0,0q?6   $ 
Horizontal=?6/   .+?5?      ?? $	??150??6    ??6/     *Before Test+?? 5?      $ 30Q?6   5?      ?? 5?      $??0,10,0,0q?6   $ 
Horizontal=?6/   .+?5?      ?? $	??150??6    ??6/     *	Testing+?? 5?      $ 30Q?6   5?      ?? 5?      $??0,10,0,0q?6   $ 
Horizontal=?6/   .+?5?      ?? $	??150??6    ??6/     *Before Analysis+?? 5?      $ 30Q?6   5?      ?? 5?      $??0,10,0,0q?6   $ 
Horizontal=?6/   .+?5?      ?? $	??150??6    ??6/     *
Test Notes+?? 5?      $ 30Q?6   5?      ?? 5?      $??0,10,0,0q?6   $ 
Horizontal=?6/   .+?5?      ?? $	??150??6    ??6/     *Finish+?? 5?      $ 30Q?6   5?      5?      5?      5?      5?      
   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:WanCeDesktopApp.Common.DAOWanCeDesktopApp.Common.DAO  5      G(clr-namespace:WanCeDesktopApp.ExtensionsWanCeDesktopApp.Extensions  5      =#clr-namespace:WanCeDesktopApp.ViewsWanCeDesktopApp.Views  5
      ;    5WanCeDesktopApp.Views.WorkspaceResults_StatisticsView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8dao(clr-namespace:WanCeDesktopApp.Common.DAO     5      8ext(clr-namespace:WanCeDesktopApp.Extensions     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5	      /local#clr-namespace:WanCeDesktopApp.Views  5
      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5      <system1,http://schemas.microsoft.com/winfx/2009/xaml 	 
 5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       ? 	Resources 5         TreeViewTemplate1 ?? DataType7   1WanCeDesktopApp.Common.DAO.WorkspaceInputTypeInfo ?? ItemsSource  TreeViewTemplate  MaterialDesignTreeViewItem ?? BasedOn ?? 
TargetType ?? Property ?? Value ?? 
TargetType  showtype	 ?? Triggers
 ?? Binding ?? ElementName ?? Path ?? Value  c1 ?? RelativeSource ?? Mode??%?  &	        &	 ?     7  &	 l    &	 ?    7  ?? 5   
   "  5       5      ?? *AvailableParametersItemsArr+.R?5      ?? ??6   ?? *InputTypeName+5      ?? 5   
   8   " Q?5      .?5       ??  ? ?? 6,   ?? *AvailableParametersArr+?? 5!       ? ?? 5"      ?? 5#      " Q?6&   .R?5$      ?? ??6)   ?? *	Content+5%      5'      5(      ?? 5)   
   " ??6!   	 5*      ?? 5+      
 6   ?? $ DeterMiniedParametersList??$ 
IsSelected?	 false6i   .a?5,      ??  ? y?$ Visible=?63   5-      ?? 5.      
 6   ?? $ DeterMiniedParametersList??$ 
IsSelected? true6i   .a?5/      ??  ? y?$ Visible=?63   50      52      ?? 53   
   8   " Q?56      	 57      ?? 59      
 6   ?? *
Visibility+ ?? $
 Self=? 	Collapsed6h   .a?5:      ??  ? ?? 5;      ?? 5<      .R?5=   "   ?? $y?	Collapsed=?6E   ??61   ?? 6E   5>      5@      5A      ?? 5C      
 6   ?? *
Visibility+$
 item?? Visible6O   .a?5D      ??  ? ?? 5E      ?? 5F      .R?5G   "   ?? $y?	Collapsed=?6E   ??61   ?? 6E   5H      5J      5K      5M      5N      .??5O      ?  ? RowDefinitions 5P   
   ?? 5Q      $
??auto ?6   ?? 5R      ?? 5S      $
??auto ?6   .+?5U   
   ?? $??5q?6   .+?5V      ?? $??10,0,0,0q?6   ??6*   2  ,WPFLocalizeExtension.Extensions.LocExtension  *'%WorkspaceResultsStatisticsDescribeOne+5W      ? 5X   
   $??1??6   $??	10,0,0,10q?6    ? ColumnDefinitions 5Y      ?? 5Z      $??3* ?6#   ?? 5[      $
??auto ?6#   ?? 5\      $??3* ?6#   ?? 5]      $
??auto ?6#   ?? 5^      $??3* ?6#   .+?5a      ?  5b      ?? 5c      $
??auto ?6$   ?? 5d      .+?5f      ??   txbkFirstTitle#??[ 6   ??6D     *Available results+?? 5g      $??1??5h      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=?5i      
???????
???????$??2q?5l       ?? CornerRadius$ 10??5m       J? Opacity$	 0.5Q?5n      ._?5o      #  MaterialDesignThemes.Wpf.Card  $??8q?5p       ! MaterialDesignLightBackground#???  5q       ! MaterialDesignLightForeground#???  5r         UniformCornerRadius$ 6Q?5s      .??5u      R? -   5        $??treeView??5u   #   ??63   ?? *AvailableParametersArr+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5v      +  %Microsoft.Xaml.Behaviors.EventTrigger  5w   "      	EventName$ DoubleClick??61   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5x   &   2	  ,Microsoft.Xaml.Behaviors.InvokeCommandAction	   	  Command 6<   ?? *MoveToRightCommand+ 	  CommandParameter 6c   ?? $ treeView??$ SelectedItem?5y   #   ??5{      ?? 5|   "    6;   ?? *AvailableParametersItemsArr+.R?5}   &   ?? $
??item??65   ??5~   *   `? 5   .     LocMultiConverter `? 	Converter# [ 6;   1?5?   2   ?? 5?   6   $ InputTypeName?6>   ?? 5?   6   $ Culture?6>   4
  .WPFLocalizeExtension.Engine.LocalizeDictionary 
  Instance ?? Source# Z 6M   5?   /   5?   '   5?   #   5?      5?      5?      5?      ?? 5?      $??1??6   $??Center=?6)   .+?5?      ?? $??5,0,5,5q?5?       ? Cursor$
 Hand??5?      ??5?      0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ 
ArrowRight=?    Size  24 5?        5?      $ Click??6)   . 5?      	   64   ?? *MoveToRightCommand+ 6[   ?? $ treeView??$ SelectedItem?5?      5?      ?? 5?      $??5,5,5,0q?6   ??6*     $ 	ArrowLeft=?  24 5?        5?      $ Click??6)   . 5?      	   64   ?? *MoveToLeftCommand+ 6Z   ?? $ DeterMiniedParametersList??$ SelectedItem?5?      5?      5?      ? 5?      $??2??6    5?      ?? 5?      $
??auto ?6$   ?? 5?      .+?5?      ?? #??[ 6   ??6D     *Selected results+?? 5?      $??1??5?      $ Depth2=?5?      
???????
???????$??2q?5?      $ 10??5?      $	 0.5Q?5?      ._?5?        $??8q?5?      #???  5?      #???  5?      $ 6Q?5?      .??5?      ?? -   5        ! ??Name$! DeterMiniedParametersList??5?      $??0q?5?      ??5?      ?? *DeterMiniedParametersArr+ 5?        5?   "   $ SelectionChanged??61   . 5?   &   	   6<   ?? *SelectionChangedCommand+ 6h   ?? $ DeterMiniedParametersList??$ SelectedItem?5?   #   ??5?      ?? 5?   "   .R?5?   &   ?? ??65   ?? *InputTypeName+5?   #   5?      5?      5?      5?      ?? 5?      $??3??6   $??Center=?6)   .+?5?      ?? -   5        " ??Name$" MoveUp??5?      $??5,0,5,5q?5?      ??5?        $ ArrowTop=?  24?? 5?      -   5        $" MoveDown??5?      $??5,5,5,0q?5?      ??5?        $ 	ArrowDown=?  245?      ? 5?      -   5        # ?Name$# detailedArea??5?      $??4??6)    5?      ?? 5?      $
??auto ?6$   ?? 5?      .+?5?      ?? ??6   ?? $ DeterMiniedParametersList??$ SelectedValue??? 5?      $??1??6   .+?5?      ]? $	??0,5q?6    $??False??6-   .+?5?      ?? $	??140??5?      $??Center=?5?      ??5?        *Prompt+?? 5?      $	??200??5?      .  (MaterialDesignThemes.Wpf.TextFieldAssist$   HasClearButton$
$ True??5?      $ Arrow??5?      ??5?      ?? $ DeterMiniedParametersList??$ SelectedValue?5?      ]? 5?      $	??0,5q?6    $??False??6-   .+?5?      ?? $	??140??5?      $??Center=?5?      ??5?        *Decimalplaces+?? 5?      $	??200??6#   % ?? SelectedIndex$% 0??6/   .@?5?      ?? .??6+   06.   ?? 5?      .??6+   16.   ?? 5?      .??6+   26.   ?? 5?      .??6+   36.   ?? 5?      .??6+   46.   ?? 5?      .??6+   56.   5?      5?      5?      5?      5?      5	     5
     
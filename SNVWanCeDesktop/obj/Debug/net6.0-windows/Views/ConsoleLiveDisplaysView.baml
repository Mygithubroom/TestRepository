   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:WanCeDesktopApp.Common.DAOWanCeDesktopApp.Common.DAO  5      G(clr-namespace:WanCeDesktopApp.ExtensionsWanCeDesktopApp.Extensions  5      =#clr-namespace:WanCeDesktopApp.ViewsWanCeDesktopApp.Views  5
      3    -WanCeDesktopApp.Views.ConsoleLiveDisplaysView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8dao(clr-namespace:WanCeDesktopApp.Common.DAO     5      8ext(clr-namespace:WanCeDesktopApp.Extensions     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5	      /local#clr-namespace:WanCeDesktopApp.Views  5
      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5      <system1,http://schemas.microsoft.com/winfx/2009/xaml 	 
 5      H
viewmodels5[viewmodels ]clr-namespace:WanCeDesktopApp.ViewModels 	 
 5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       ? 	Resources 5         TreeViewTemplate1 ?? DataType7   1WanCeDesktopApp.Common.DAO.WorkspaceInputTypeInfo ?? ItemsSource  TreeViewTemplate  MaterialDesignTreeViewItem ?? BasedOn ?? 
TargetType ?? Property ?? Value ?? 
TargetType  showtype	 ?? Triggers
 ?? Binding ?? ElementName ?? Path ?? Value  c1 ?? RelativeSource ?? Mode??%?  &	        &	 ?     7  &	 l    &	 ?    7  ?? 5      "  5       5      ?? *AvailableParametersItemsArr+.R?5      ?? ??6   ?? *InputTypeName+5      ?? 5      8   " Q?5       .?5!      ??  ? ?? 6#   ?? *AvailableParametersArr+?? 5"       ? ?? 5#      ?? 5$      " Q?6   .R?5%      ?? ??6   ?? *	Content+5&      5(      5)      ?? 5*      " ??6   	 5+      ?? 5,      
 6   ?? $ DeterMiniedParametersList??$ 
IsSelected?	 false6]   .a?5-      ??  ? y?$ Visible=?6$   5.      ?? 5/      
 6   ?? $ DeterMiniedParametersList??$ 
IsSelected? true6]   .a?50      ??  ? y?$ Visible=?6$   51      53      ?? 54      8   " Q?57      	 58      ?? 5:      
 6   ?? *
Visibility+ ?? $
 Self=? 	Collapsed6\   .a?5;      ??  ? ?? 5<      ?? 5=   	   .R?5>   
   ?? $y?	Collapsed=?6-   ??6   ?? 6-   5?   
   5A      5B      ?? 5D      
 6   ?? *
Visibility+$
 item?? Visible6C   .a?5E      ??  ? ?? 5F      ?? 5G   	   .R?5H   
   ?? $y?	Collapsed=?6-   ??6   ?? 6-   5I   
   5K      5L      5N      5O      .??5P      ? -   5          PrimaryHueGridBrush#???  5P      .+?5Q      ?? -   5         ??Name$ SetupViewScroll??5R      $
??Auto=?5S      $
??Auto=?5T      .??5U      ? *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5V      +  %Microsoft.Xaml.Behaviors.EventTrigger  5W         	EventName$ Loaded??6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5X      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6   ?? *LoadedCommand+5Y       ? RowDefinitions 5[      ?? 5\      $
??auto ?6   ?? 5]      ?? 5^      $
??auto ?6   .+?5`      ?? .+?5a      ?? $??	10,10,0,0q?6   ??6$   2  ,WPFLocalizeExtension.Extensions.LocExtension  * ConsoleLiveDisplaysDecsribeOne+?? 5b      $
??1300??5c      $??	10,10,0,0q?5d      $
??Left=?5e      $
??Wrap=?5g      ??5f        * ConsoleLiveDisplaysDecsribeTwo+5g      5h      ? 5i      $??1??6   $??0,10,0,0q?6    ? ColumnDefinitions 5j      ?? 5k      ?? 5l      $??80 ?6   ?? 5m      ?? 5n      $??80 ?6   ?? 5o      .+?5r      ?  5s      ?? 5t   	   $
??auto ?6   ?? 5u   	   .+?5w      ?? $??10,0,0,0q?5x        txbkFirstTitle#??[ 5y      ??5z        *AvailableLiveDisplay+?? 5{      $??1??5|      $??0??5}      $??10,0,0,0q?5~      ???#222627 ?? CornerRadius$ 5??5?      ]? 5?      $??1??6   $??0??6   .+?5?   	   R? -   5        $??treeView??5?   	   $??10,0,0,0q?5?   	   $??18(?5?   	   ??5?   	   ?? *AvailableParametersArr+ 5?   
     5?      $ DoubleClick??6   . 5?         6"   ?? *MoveToRightCommand+   CommandParameter 6I   ?? $ treeView??$ SelectedItem?5?      ??5?   
   ?? 5?       6$   ?? *AvailableParametersItemsArr+.R?5?      ?? $
??item??6   ??6'   ?? *Title+5?      5?      5?   
   5?   	   5?      ?? 5?      $??1??6   $??Center=?6"   .+?5?      ?? $??70??5?      $??46??5?      $??5,0,5,5q?5?       ? Cursor$
 Hand??5?      ??5?      0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ 
ArrowRight=?   Size 24 5?   	     5?   
   $ Click??6   . 5?         6!   ?? *MoveToRightCommand+ 6H   ?? $ treeView??$ SelectedItem?5?      5?   	   ?? 5?      $??70??5?      $??46??5?      $??5,5,5,0q?5?      ??5?        $ 	ArrowLeft=? 24 5?   	     5?   
   $ Click??6   . 5?         6!   ?? *MoveToLeftCommand+ 6G   ?? $ DeterMiniedParametersList??$ SelectedItem?5?      5?   	   5?      ? 5?      $??2??6    5?      ?? 5?   	   $
??auto ?6   ?? 5?   	   .+?5?      ?? #??[ 6   ??6:     *SelectedLiveDispalys+?? 5?      $??1??5?      $??2??5?      ???#222627$ 5??5?      ]? 5?      $??1??6   $??2??6   .+?5?   	   ?? $
??Auto=?6   $
??Auto=?6;   .??5?   
   ?? -   5         ??Name$ DeterMiniedParametersList??5?   
   $??0q?5?   
    ?? 
IsSelected$
 True??5?   
   ??5?   
   ?? *DeterMiniedParametersArr+ ?? SelectedItem 5?   
   ?? *DeterMiniedParametersItem+ 5?        5?      $ SelectionChanged??6   . 5?         6#   ?? *SelectionChangedCommand+ 6O   ?? $ DeterMiniedParametersList??$ SelectedItem?5?      ??5?      ?? 5?      .R?5?      ?? $??18(?66   ??6   ?? *Title+5?      5?      5?      5?   
   5?   	   5     ?? 5     $??3??6   $??Center=?6"   .+?5     ?? -   5         ??Name$ MoveUp??5     $??60??5     $??46??5     $??5,0,10,5q?5     $
 Hand??5      ??5       $ ArrowTop=? 245      ?? 5!     -   5        $ MoveDown??5"     $??60??5#     $??46??5$     $??5,5,10,0q?5%     ??5'       $ 	ArrowDown=? 245)     ? 5+     -   5          ?Name$  detailedArea??5+     $??4??6"    5,     ?? 5-  	   $
??auto ?6   ?? 5.  	   .+?50     ?? -   5        ! ??Name$! ParameterLable??51     #??[ 52     ??53       *ConsoleDescripe+?? 54     $??1??6   .+?55  	   ]? $??0,5,5,5q?6   $??False??6$   .+?56  
   ?? $	??140??57  
   $??Center=?58  
   ??59  
     *Prompt+?? 5:  
   -	   5        " ??Name$" 	txtPrompt??5;  
   $	??200??5<  
   .	  (MaterialDesignThemes.Wpf.TextFieldAssist# 	  HasClearButton$
# True??5=  
   $ Arrow??5>  
    ! MaterialDesignOutlinedTextBox#??[ 5?  
   5@  
   5A  
   ?? 5B  	   -
   5        $ ??Name$$ detailedExplan??5B     $	??0,5q?6,   .+?5C  
   ]? $??0,5,5,5q?6   $??False??6%   .+?5D     ?? $	??140??5E     $??Center=?5F     ??5G       *Unit+?? 5H     -   5        % ??Name$
% Unit??5I     $	??200??5J     5K     5L     ]? 5M  
   $??0,5,5,5q?6   $??False??6%   .+?5N     ?? $	??140??5O     $??Center=?5P     ??5Q       *Decimalplaces+?? 5R     -   5        $% DecimalNumber??5S     $	??200??5T     & ?? SelectedIndex$& 1??5U     .@?5W     ?? .??6   46   ?? 5X     .??6   56   ?? 5Y     .??6   66   5Z     5[     ?? 5\  
   -   5        ' ??Name$' maxCheck??5]  
   $	??0,5q?5^  
   -
  'MaterialDesignThemes.Wpf.CheckBoxAssist( 
  CheckBoxSize$( 30Q?5_  
   ??5`  
   ?? *MaxCheckCommand+??5a  
   ?? $ DeterMiniedParametersList??$ SelectedItem???5b  
     *	ShowMax+?? 5c  
   -   5        $' 	rateCheck??5d  
   $	??0,5q?5e  
   $( 30Q?5f  
   ??5g  
   ?? *RateCheckCommand+??5h  
   ?? $ DeterMiniedParametersList??$ SelectedItem???5i  
     *
ShowRate+5j  
   5k  	   5l     5m     ]? 5o     $??2??5p     $??10,10q?5q     $??False??5r     .+?5s     ?? $	??200??5t     $??Center=?5u     $??Maximum columns:??5v     $
??Wrap=?5w     ?? 5x     $	??300??6   5y     5z     5{     5|     5}     
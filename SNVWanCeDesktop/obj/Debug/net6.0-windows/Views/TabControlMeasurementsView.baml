   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WanCeDesktopApp.CommonWanCeDesktopApp.Common  5      G(clr-namespace:WanCeDesktopApp.ExtensionsWanCeDesktopApp.Extensions  5      1clr-namespace:WanCeDesktopAppWanCeDesktopApp  5
      G(clr-namespace:WanCeDesktopApp.ViewModelsWanCeDesktopApp.ViewModels  5      6    0WanCeDesktopApp.Views.TabControlMeasurementsView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      3cv$clr-namespace:WanCeDesktopApp.Common     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8ext(clr-namespace:WanCeDesktopApp.Extensions     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5	      )localclr-namespace:WanCeDesktopApp  5
      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5      :	viewmodel(clr-namespace:WanCeDesktopApp.ViewModels 	 
 5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .??5      ? -   5         ?Name$ mainGrd??5      .+?5   
   #  MaterialDesignThemes.Wpf.Card  .??5      ? ???#626367 ? RowDefinitions 5      ?? 5      $
??auto ?6$   ?? 5      $??* ?6$   .+?5      ?? $??0??5      $
??1300??5      $??	10,10,0,0q?5      $
??Left=?5      $
??Wrap=?5!      ??5       2  ,WPFLocalizeExtension.Extensions.LocExtension  *Measurements Describe+5!      ? 5#      $??1??6    ? ColumnDefinitions 5$      ?? 5%      $??* ?6+   ?? 5&      $??80 ?6+   ?? 5'      $??* ?6+   ?? 5(      $??* ?6+   .+?5*      ?  5+      ?? 5,      $
??auto ?6,   ?? 5-      .+?5/      ?? $??0??50      $
??10,5q?51      $	??Top=?52         txbkFirstTitle#??[  53      ??54        *Measurement type+?? 55      $??1??56      $??10q?57      ???#222627 ?? CornerRadius$ 5??59      ._?5:      ]? .+?5;   "   ?? $
??Auto=?6/   .??5<   &   R? -   5        $??treeView??5=   )   $??5q?5>   )   ??5?   )   ?? *AvailableParametersArr+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5A   *   +  %Microsoft.Xaml.Behaviors.EventTrigger  5B   .      	EventName$ MouseDoubleClick??6=   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5C   2   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6H   ?? *MoveToRightCommand+	   CommandParameter	 6o   ?? 
 ?? ElementName$
 treeView?? ?? Path$ SelectedItem?5D   /   ??5F   *   ?? 5G   .    ?? ItemsSource 6G   ?? *AvailableParametersItemsArr+.R?5H   2   ?? $
??item??6A   ??5I   6   `? 5J   :     LocMultiConverter `? 	Converter# [ 6G   1?5K   >   ?? 5L   B   $ InputTypeName?6J   ?? 5M   B   $ Culture?6J   4  .WPFLocalizeExtension.Engine.LocalizeDictionary   Instance ?? Source# Z 6Y   5O   ;   5Q   3   5R   /   5T   '   5U   #   5V      5W      5X      ?? 5Y      $??1??5Z      $??Center=?5[      $??Center=?5\      .+?5]      ?? -   5        $??70??5^      $??46??5_      $??0,0,0,10q?5`       ? Cursor$
 Hand??5d       ? ToolTip$ To Right??5e      ??5b      0	  *MaterialDesignThemes.Wpf.PackIconExtension	   	  Kind$ 
ArrowRight=? 	  Size 40 5f        5g   "   $ Click??61   . 5h   &      6<   ?? *MoveToRightCommand+	 6c   ?? $
 treeView??$ SelectedItem?5i   #   5k      ?? 5l      -   5         ??Name$ btnMoveToLeft??5m      $??70??5n      $??46??5o      $??0,0,0,0q?5p      $ To Left??5t      ??5r      	  $ 	ArrowLeft=? 40 5u        5v   "   $ Click??61   . 5w   &      6<   ?? *MoveToLeftCommand+	 6b   ?? $
 DeterMiniedParametersList??$ SelectedItem?5x   #   5z      5{      ? 5|      $??2??6    5}      ?? 5~      $
??auto ?6,   ?? 5      .+?5?      ?? $
??10,5q?5?      $	??Top=?5?      #??[  5?      ??5?        *%#Measurement available in the method+?? 5?      $??1??5?      $??10q?5?      ???#222627$ 5??5?      ._?5?      ]? .+?5?   "   ?? $
??Auto=?6/   .??5?   &   ?? -   5         ??Name$ DeterMiniedParametersList??5?   )   $??5q?5?   )   $??18(?5?   )   ??5?   )   ?? *DeterMiniedParametersArr+ ?? SelectedItem 5?   )   ?? *DeterMiniedParametersItem+ 5?   *     5?   .   $ SelectionChanged??6=   . 5?   2      6H   ?? *SelectionChangedCommand+	 6t   ?? $
 DeterMiniedParametersList??$ SelectedItem?5?   /   ??5?   *   ?? 5?   .   .R?5?   2   ?? ??6A   ?? *Title+5?   3   5?   /   5?   '   5?   #   5?      5?      5?      ? 5?      -   5        $ DeterMiniedParamePanel??5?      $??3??5?       ? DataContext 5?      ?? $
 DeterMiniedParametersList??$ SelectedItem? 5?      ?? 5?      $
??auto ?6,   ?? 5?      .+?5?      ?? $
??10,5q?5?      $	??Top=?5?      #??[  5?      ??5?      `? 5?   "   # [ 6/   .1?5?   &   ?? $ InputTypeName?6.   ?? 5?   &   $ Culture?6.   # Z 6=   5?   #   5?      ? 5?      $??1??6   .+?5?      ?? -   5        $??EditPanelScroll??5?   !   $??1??5?   !   $??0,0,10,0q?5?   !   $
??Auto=?5?   !   .??5?   "   ?? .+?5?   &   ]? -   5         ]?Name$ DescriptionPanel??5?   0   .+?5?   *   ?? $	??150??5?   -   $??Center=?5?   -   ??5?   -     *Description+?? 5?   *   $	??200??5?   -   $??5q?5?   -   .
  (MaterialDesignThemes.Wpf.TextFieldAssist 
  HasClearButton$
 True??5?   -   ??5?   -   ?? *Title+5?   '   ]? 5?   &   -	   5        $??SensorSettingPanel??5?   0   $??1??6J   .+?5?   *   ?? $	??150??5?   -   $??Center=?5?   -   ??5?   -     *ConfigureSensors+?? 5?   *   -
   5        $??	CMBSensor??5?   -   $	??200??5?   -   $??5q?5?   -   $
 True??5?   -   5?   '   ]? 5?   &   -   5        $??
JointPanel??5?   0   $??2??6B   .+?5?   *   ?? $	??150??5?   -   $??Center=?5?   -   ??5?   -     *Splice+?? 5?   *   -   5         ??Name$ CMBJoint??5?   -   $	??200??5?   -   $??5q?5?   -   $
 True??5?   -   5?   '   ]? 5  &   -   5        $??BasicSourcePanel??5  0   $??3??6H   .+?5  *   ?? $	??150??5  -   $??Center=?5  -   ??5  -     *	基本源+?? 5  *   $	??200??5  -   $??5q?5  -   $
 True??5	  -   5
  '   ]? 5  &   -   5        $??UnitGroupPanel??5  0   $??4??6F   .+?5  *   ?? $	??150??5  -   $??Center=?5  -   ??5  -     *	单位群+?? 5  *   $	??200??5  -   $??5q?5  -   $
 True??5  -   5  '   ]? 5  &   -   5        $??DisplacementSourcePanel??5  0   $??5??6O   .+?5  *   ?? $	??150??5  -   $??Center=?5  -   ??5  -     *	位移源+?? 5  *   $	??200??5  -   $??5q?5  -   $
 True??5  -   5   '   ]? 5"  &   -   5        $??LoadSourcePanel??5"  0   $??6??6G   .+?5#  *   ?? $	??150??5$  -   $??Center=?5%  -   ??5&  -     *	载荷源+?? 5'  *   $	??200??5(  -   $??5q?5)  -   $
 True??5*  -   5+  '   ? 5-  &   -   5        $??ExpressionPanel??5-  +   $??7??6B    5.  *   ?? 5/  .   $
??auto ?6?   ?? 50  .   ?? 51  .   $
??auto ?6?   .+?53  *   ?? $	??150??54  -   $??Center=?55  -   ??56  -     *
Expression+?? 57  *   $??2??58  -   $??50??59  -   $??5q?5:  -   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 5??5;  -   ??5<  -   ?? *ExecuteShowDialogCommand+??5=  -   	  $ FunctionVariant=? 305D  +   ?? 5E  *   $??1??5F  -   $??5q?5G  -   $
 True??5H  -   5I  '   ? 5K  &   -   5        $??ComplianceFilePanel??5K  +   $??7??6F    5L  *   ?? 5M  .   $
??auto ?6<   ?? 5N  .   $
??auto ?6<   .+?5P  *   ?? ??64     *ComplianceFile+? 5Q  *   $??1??6/   $??25,0,0,0q?6<    5R  .   ?? 5S  2   ?? 5T  2   ?? 5U  2    5W  .   ?? 5X  2   $
??auto ?6C   ?? 5Y  2   $??3* ?6C   ?? 5Z  2   $??* ?6C   .+?5]  .   ?? $	??150??5^  1   $??Center=?5_  1   ??5`  1     *
FileName+?? 5a  .   $??1??5b  1   $	??200??5c  1   $??5q?5d  1   $
 True??5e  1   ?? 5f  .   $??2??5g  1   $??50??5h  1   $	??100??5i  1   $??5q?5j  1   ??5k  1     *Import+?? 5m  .   $??1??5n  1   $	??150??5o  1   $??Center=?5p  1   ??5q  1     *LastModified+?? 5r  .   $??1??5s  1   $??1??5t  1   $	??200??5u  1   $??5q?5v  1   $
 True??5w  1   ?? 5y  .   $??2??5z  1   $	??150??5{  1   $??Center=?5|  1   ??5}  1     *
FileSize+?? 5~  .   $??2??5  1   $??1??5?  1   $	??200??5?  1   $??5q?5?  1   $
 True??5?  1   5?  +   5?  '   ]? 5?  &   -   5        $??SourceOfStrainPanel??5?  0   $??8??6K   .+?5?  *   ?? $	??150??5?  -   $??Center=?5?  -   ??5?  -     *SourceOfStrain+?? 5?  *   $	??200??5?  -   $??5q?5?  -   $
 True??5?  -   5?  '   ? 5?  &   -   5        $%??TransverseStrainGaugeWidthPanel??5?  +   $??9??6R    5?  *   ?? 5?  .   $
??auto ?6?   ?? 5?  .   ?? 5?  .   ?? 5?  .   $
??auto ?6?   .+?5?  *   ?? $	??150??5?  -   $??Center=?5?  -   ??5?  -     *Transverse strain gauge width+?? 5?  *   $??1??5?  -   $	??150??5?  -   $??5,5,0,5q?5?  -   ?? 5?  *   $??2??5?  -   $??60??5?  -   $??5q?5?  -   $
 True??5?  -   ?? 5?  *   $??3??5?  -   $??50??5?  -   $??5q?5?  -   ??5?  -   	  $ 
Calculator=? 205?  '   ? 5?  &   -   5        $??PreTestLimitPanel??5?  +   $??10??6D    5?  *   ?? 5?  .   $
??auto ?6<   ?? 5?  .   .+?5?  *   ?? -   5        -  'MaterialDesignThemes.Wpf.CheckBoxAssist   CheckBoxSize$ 30Q?5?  -   
 ? Tag$ PreTestLimitEditPanel??5?  -   ??5?  -     *Pre-test limit+ d? 	IsChecked 5?  -   ?? *IsPreTestLimit+5?  -   ?? 5?  *   -   5         ??Name$ PreTestLimitEditPanel??5?  -   $??1??5?  -   $y?	Collapsed=?5?  -   .+?5?  .   ]? $??25,0,0,0q?68   .+?5?  2   ?? $	??150??5?  5   $??Center=?5?  5   ??5?  5     *	Maximum+?? 5?  2   $	??200??5?  5   $??5q?5?  5   $
 True??5?  5   ??5?  5   ?? *
PreMaximum+?? 5?  2   -   5        $??EditUnit??5?  5   $??50??5?  5   $??60??5?  5   $  ?? IsSynchronizedWithCurrentItem$
  TrueY?5?  5    5?  5   ?? $
 mainGrd??$ DataContext???5?  5   ?? *	UnitItems+! ?? SelectedIndex! 5?  5   ?? *Index+5?  5   5?  /   ]? 5?  .   $??25,0,0,0q?68   .+?5?  2   ?? $	??150??5?  5   $??Center=?5?  5   ??5?  5     *	Minimum+?? 5?  2   $	??200??5?  5   $??5q?5?  5   $
 True??5?  5   ??5?  5   ?? *
PreMinimum+?? 5?  2   $??50??5?  5   $??60??5?  5   $
  TrueY?5?  5    5?  5   ?? $
 mainGrd??$ DataContext???5?  5   ?? *	UnitItems+5?  /   5?  +   5?  '   ? 5?  &   -   5        $??	RatePanel??5?  +   $??11??6<    5?  *   ?? 5?  .   $
??auto ?6<   ?? 5?  .   $
??auto ?6<   ?? 5?  .   $
??auto ?6<   ?? 5?  .   $
??auto ?6<   .+?5?  *   ?? -   5        $ 30Q?5?  -   $ RateEditPanel??5?  -   ??5?  -     *Rate+ 5?  -   ?? *IsRate+5?  -   ?? 5?  *   -   5        $ RateEditPanel??5?  -   $??1??5?  -   $y?	Collapsed=?5?  -   .+?5?  .   ]? $??25,0,0,0q?68   .+?5?  2   ?? $	??150??5?  5   $??Center=?5?  5   ??5?  5     *Description+?? 5?  2   $	??200??5?  5   $??5q?5   5   $
 True??5  5   ??5  5   ?? *RateExplain+5  /   ]? 5  .   $??25,0,0,0q?68   .+?5  2   ?? $	??150??5  5   $??Center=?5  5   ??5  5     *	DataPoint+?? 5	  2   $	??200??5
  5   $??5q?5  5   $
 True??5  5   ??5  5   ?? *DataPointCount+5  /   ?? 5  .   $??25,0,0,0q?5  1   $
??Left=?5  1   $ 30Q?5  1   ??5  1     *Using linear regression+ 5  1   ?? *IsUsingLinearRegression+5  +   5  '   ?? 5  &   -   5        " ??Name$" TrueStrainControlPanel??5  )   $??12??5  )   $ 30Q?5  )   ??5  )     *True strain control+ 5  )   ?? *IsTrueStrainControl+]? 5  &   -   5        $??TransverseStrainPanel??5  0   $??13??6M   .+?5   *   ?? $	??150??5!  -   $??Center=?5"  -   ??5#  -     *TransverseStrain+?? 5$  *   $	??200??5%  -   $??5q?5&  -   $
 True??5'  -   # W? CultureSource$
# Text=?5(  -   5)  '   ]? 5+  &   -   5        $??DataPointNumberPanel??5+  0   $??14??6L   .+?5,  *   ?? $	??150??5-  -   $??Center=?5.  -   ??5/  -     *DataPointNumber+?? 50  *   $	??200??51  -   $??5q?52  -   $
 True??53  -   $
# Text=?54  -   55  '   ]? 57  &   -   5        $%??EliminationOfElasticStrainPanel??57  0   $??15??6W   .+?58  *   ?? ??63     *消除弹性应变+59  '   ]? 5;  &   -    5        $??PoissionRatePanel??5;  0   $??16??6I   .+?5<  *   ?? $	??200??5=  -   $??5q?5>  -   $
 True??5?  -   ??5@  -     *泊松(Poission)比+5A  '   5B  #   5D     5E     5F     5      5!     5"     5#     5%     
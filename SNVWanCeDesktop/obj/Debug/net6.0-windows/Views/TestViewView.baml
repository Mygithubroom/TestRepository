   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WanCeDesktopApp.CommonWanCeDesktopApp.Common  5      $    WanCeDesktopApp.Views.TestView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5      0local$clr-namespace:WanCeDesktopApp.Common  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      :md1http://materialdesigninxaml.net/winfx/xaml/themes  5      [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5      .??5      ??    PrimaryHueGridBrush#???   5   	   $??Disabled=?5   	   $
??Auto=?5   	   .??5   
   ?   ? RowDefinitions  5      ?? 5      $
??Auto ?6    ?? 5      $
??Auto ?6    ?? 5      $
??Auto ?6    ?? 5      $
??Auto ?6     ? ColumnDefinitions 5      ?? 5      $??* ?6#   ?? 5      $??* ?6#   .+?5       ?? $??0??6    ?? Orientation$ Vertical=?6&   .+?5!      ?? $??	10,20,0,0q?5"        txbkFirstTitle#??[ 5#      ??5$      2  ,WPFLocalizeExtension.Extensions.LocExtension  *
New Sample+?? 5%      $??	10,10,0,0q?6   ??6/     *$"TestViewMethodSelectionDescription+5&      ? 5'      $??1??6    5(      ?? 5)      $??* ?6'   ?? 5*      $??* ?6'   ?? 5+      $??* ?6'   ?? 5,      $??* ?6'   .+?5.      ?? $??30??5/      $
??10,0q?50      $??Stretch=?51      $??Bottom=?52        SecondaryHueMidBrush#???  53      #???  54      $??1q?55      ??56        *!TestViewMethodBrowseButtonTitle+?? 57      $??1??58      $??Bottom=?59      $ Vertical=?5:      .+?5;      ?? $
??10,5q?6    ??6.     *Sortby+?? 5<      $??30??5=      $
??10,0q?5>        MaterialDesignComboBox#??[ 5?      .@?5@      ?? .??6'   	选项16,   ?? 5A      .??6'   	选项26,   ?? 5B      .??6'   	选项36,   ?? 5C      .??6'   	选项46,   5D      5E      ?? 5F      $??2??5G      $??Bottom=?5H      $ Vertical=?5I      .+?5J      ?? $
??10,5q?6    ??6.     *
Filterby+?? 5K      $??30??5L      $
??10,0q?5M      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True??5O        MaterialDesignTextBox#??[ 5P      )  #MaterialDesignThemes.Wpf.HintAssist   Hint 5N        *HintMessage+5P      5Q      ?? 5R      $??3??5S      $
??10,0q?5T      $??Bottom=?5U        SecondaryHueDarkBrush#???  5V      #???  5W      $??1q?5X      ??5Y        *	ClearList+5Z      ? 5\      $??1??6     5]      ?? 5^      $
??Auto ?6$   ?? 5_      $
??Auto ?6$   .+?5a      ?? $??	10,20,0,0q?6   ??6/     *TestViewFunctionSectionTitle+?? 5b      -   5         ??Name$ listTest??5c      $??1??5d      $??0??5e        myMethodItem#??[ 5f      $??Disabled=?5h      ??5g      ?? *
TestBars+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5i      +  %Microsoft.Xaml.Behaviors.EventTrigger  5j         	EventName$ MouseDoubleClick??6)   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5k      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  	   CommandParameter$	 NewMethodView??6a   
   Command
 64   ?? *NavigateCommandIndexView+6a   5m      ??5o      ?? 5p      .R?5q      ? 5r      5?      5?      ? 5?      $??1??6   $??1??6      5?      ?? 5?      $
??Auto ?6$   ?? 5?      $
??Auto ?6$   .+?5?      ?? $??	10,20,0,0q?6   ??6/     *Method+?? 5?      $??1??5?      #??[ 5?      $??Disabled=?5?      ??5?      ?? *
MethodBars+??5?      ?? 5?      .R?5?      ? 5?      5?      5?      ?? 5?      $??2??6   $ Vertical=?6&   .+?5      ?? $??	10,20,0,0q?5     #??[ 5     ??5       *TestViewContinueSampleTitle+?? 5     $??	10,10,0,0q?6   ??6/     *#!TestViewContinueSampleDescription+5     ? 5     $??2??6   $??1??6     5     ?? 5     $??* ?6'   ?? 5	     $??* ?6'   ?? 5
     $??* ?6'   ?? 5     $??* ?6'   .+?5     ?? $??30??5     $
??10,0q?5     $??Stretch=?5     $??Bottom=?5     #???  5     #???  5     $??1q?5     ??5       *!TestViewBrowseSampleButtonTitle+?? 5     $??1??5     $??Bottom=?5     $ Vertical=?5     .+?5     ?? $
??10,5q?6    ??6.     *Sortby+?? 5     $??30??5     $
??10,0q?5     #??[ 5     .@?5     ?? .??6'   	选项16,   ?? 5      .??6'   	选项26,   ?? 5!     .??6'   	选项36,   ?? 5"     .??6'   	选项46,   5#     5$     ?? 5%     $??2??5&     $??Bottom=?5'     $ Vertical=?5(     .+?5)     ?? $
??10,5q?6    ??6.     *
Filterby+?? 5*     $??30??5+     $
??10,0q?5,     $
 True??5.      ? Cursor$ Arrow??5/     #??[ 50      5-       *HintMessage+50     51     ?? 52     $??3??53     $
??10,0q?54     $??Bottom=?55     #???  56     #???  57     $??1q?58     ??59       *	ClearList+5:     ? 5<     $??3??6   $??2??6      5=     ?? 5>     $
??Auto ?6$   ?? 5?     $
??Auto ?6$   .+?5A     ?? $??	10,20,0,0q?6   ??6/     *TestViewSampleSectionTitle+?? 5C     $??1??5D     #??[ 5E     $??Disabled=?5G     ??5F     ?? *
MethodBars+??5H     ?? 5I     .R?5J     ?  K? IsItemsHost$
 True??5K  !    ? Orientation$ 
Horizontal=?5L  !   $
??True??5M  !   5N     5?     5?     5?     5?     5?     
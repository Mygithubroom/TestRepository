   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WanCeDesktopApp.CommonWanCeDesktopApp.Common  5      &     WanCeDesktopApp.Views.MethodView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5      0local$clr-namespace:WanCeDesktopApp.Common  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      :md1http://materialdesigninxaml.net/winfx/xaml/themes  5      .??5      ??    PrimaryHueGridBrush#???   5   	   $??Disabled=?5   	   $
??Auto=?5   	   .??5   
   ?   ? RowDefinitions  5      ?? 5      $
??Auto ?6    ?? 5      $
??Auto ?6    ?? 5      $
??Auto ?6    ?? 5      $
??Auto ?6     ? ColumnDefinitions 5      ?? 5      $??* ?6#   ?? 5      $??* ?6#   .+?5      ??  ?? Orientation$ Vertical=?6   .+?5       ?? $??	10,20,0,0q?5!        txbkFirstTitle#??[ 5"      ??5#      2  ,WPFLocalizeExtension.Extensions.LocExtension  *
New Method+?? 5$      $??	10,10,0,0q?6   ??6/     *><MothodViewChooseamethodtemplateoranapplicationspecificmethod+5%      ? 5&      $??1??6    5'      ?? 5(      $??* ?6'   ?? 5)      $??* ?6'   ?? 5*      $??* ?6'   ?? 5+      $??* ?6'   .+?5-      ?? $??2??5.      $??0,0,10,0q?5/      $??Bottom=?50      $ Vertical=?51      .+?52      ?? ??6      *
Filterby+?? 53      $??30??54      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True??56        MaterialDesignTextBox#??[ 57      )  #MaterialDesignThemes.Wpf.HintAssist   Hint 55        *HintMessage+57      58      ?? 59      $??3??5:      $??0,0,10,0q?5;      $??Bottom=?5<      $ Vertical=?5=      .+?5>      ?? ??6      *MethodViewApplicationType+?? 5?      $??30??5@        MaterialDesignComboBox#??[ 5B      ??5A      ?? *ApplicatonTypeItems+5B      5C      5D      ? 5F      $??1??6     5G      ?? 5H      $
??Auto ?6$   ?? 5I      $
??Auto ?6$   .+?5K      ?? $??	10,20,0,0q?6   ??6/     *
Template+?? 5L      $??1??5M        myMethodItem#??[ 5N      $??Disabled=?5P      ??5O      ?? *TemplatesBars+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5Q      +  %Microsoft.Xaml.Behaviors.EventTrigger  5R         	EventName$ MouseDoubleClick??6)   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5S      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     CommandParameter$ NewMethodView??6a   	   Command	 64   ?? *NavigateCommandIndexView+6a   5U      ??5W      ?? 5X      .R?5Y      ? 5Z      5?      5?      ? 5?      $??1??6   $??1??6      5?      ?? 5?      $
??Auto ?6$   ?? 5?      $
??Auto ?6$   .+?5?      ?? $??	10,20,0,0q?6   ??6/     *AdhesivesMethods+?? 5?      $??1??5?      $??1??5?      #??[ 5?      $??Disabled=?5?      ??5?      ?? *AdhesiveMethodsBars+??5?      ?? 5?      .R?5?      ? 5?      5?      5?      ?? 5?      $??2??6   $ Vertical=?6&   .+?5?      ?? $??	10,20,0,0q?5?      #??[ 5?      ??5?        *
Editmethod+?? 5?      $??	10,10,0,0q?6   ??6/     *-+MethodViewChoosearecentmethodorbrowseforone+5?      ? 5?      $??2??6   $??1??6     5?      ?? 5?      $??* ?6'   ?? 5?      $??* ?6'   ?? 5?      $??* ?6'   ?? 5?      $??* ?6'   .+?5?      ?? $??30??5?      $
??10,0q?5?      $??Bottom=?5?        PrimaryHueDarkBrush#???  5?      #???  5?      $??1q?5?      ??5        *	ClearList+?? 5     $??1??5     $??Bottom=?5     $ Vertical=?5     .+?5     ?? $
??10,5q?6    ??6.     *
Filterby+?? 5     $??30??5     $
??10,0q?5     $
 True??5
     #??[ 5      5	       *HintMessage+5     5     ?? 5     $??2??5     $??Bottom=?5     $ Vertical=?5     .+?5     ?? $
??10,5q?6    ??6.     *Sortby+?? 5     -   5        $??30??5     $
??10,0q?5     #??[ 5     ??5     ?? *SortTypeItems+5     5     ?? 5     $??3??5     $??30??5      $
??10,0q?5!     $??Bottom=?5"     #???  5#     #???  5$     $??1q?5%     ??5&       *BrowseMethods+5'     ? 5)     $??5??6   $??2??6      5*     ?? 5+     $
??Auto ?6$   ?? 5,     $
??Auto ?6$   .+?5.     ?? $??	10,20,0,0q?6   ??6/     *	Methods+?? 5/     -   5        $??RecentSpecimenItems??50     $??1??51     #??[ 52     $??Disabled=?54     ??53     ?? *
MethodBars+ 55       56     $ MouseDoubleClick??6)   . 57       $ NewMethodView??6a   	 64   ?? *NavigateCommandIndexView+6a   59     ??5;     ?? 5<     .R?5=     ? 
 K? IsItemsHost$

 True??5>  !    ? Orientation$ 
Horizontal=?5?  !   $
??True??5@  !   5A     5{     5}     ? 5     $??6??6   5?     5?     5?     5?     
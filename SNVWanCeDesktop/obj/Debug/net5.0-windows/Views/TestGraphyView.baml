   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:WanCeDesktopApp.ExtensionsWanCeDesktopApp.Extensions  5      ?$clr-namespace:WanCeDesktopApp.CommonWanCeDesktopApp.Common  5	      M IPlotControlLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Bclr-namespace:PlotControlLibrary.Views;assembly=PlotControlLibraryPlotControlLibrary.Views 5      *    $WanCeDesktopApp.Views.TestGraphyView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8ext(clr-namespace:WanCeDesktopApp.Extensions     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5      0local$clr-namespace:WanCeDesktopApp.Common  5	      _	 [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5
      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	 5      :md1http://materialdesigninxaml.net/winfx/xaml/themes 	 5      MplotBclr-namespace:PlotControlLibrary.Views;assembly=PlotControlLibrary 	 5      [
 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 
  5      .??5      ? ???#626367  ? RowDefinitions  5      ?? 5      $??* ?6   ?? 5      $
??auto ?6   .+?5      ?  ? ColumnDefinitions 5      ?? 5      $??* ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   .+?5      ?? $??0??6   .+?5      ]? $??0??6   $??False??6    .+?5      ]? $??10,5,0,0q?5       $	??Top=?5!      $??False??5"      .+?5#      ?? $??45??5$      $??40??5%      $??0,0,0,0q?5&      $??0,-2,0,0q?5'      $??30(?5(      
???????.??5*   	   ' 	 !MaterialDesignThemes.Wpf.PackIcon  $??30??5+   	   $??30??5,   	   
???????   Kind$ Pencil=?5.   	   5/   	   ?? 50      $??45??51      $??40??52      $??10,0,0,0q?53      $??0,-5,0,0q?54      $	??✣??55      $??40(?56      
???????57      ?? 58      $??45??59      $??40??5:      $??10,0,0,0q?5;      $??0,-2,0,0q?5<      $	??☰??5=      $??30(?5>      
???????5?      ?? 5@      $??
350,10,0,0q?6   $??Graph 1??6&   ?? 5A      $??45??5B      $??40??5C      $??0,0,10,0q?5D      $??0,-2,0,0q?5E      $	??☰??5F      $??Right=?5G      $??30(?5H      
???????5I      ?? 5J      $??45??5K      $??40??5L      $??0,0,10,0q?5M      $??5,0,0,5q?5N      $	??◹??5O      $??Right=?5P      $??30(?5Q      
???????5R      5S      5T      ? 5U        5V      ?? 5W      $	??220 ?6   ?? 5X      $??50 ?6   ?? 5Y      $	??250 ?6   .+?5[      ?? $??0??6   $??5,5,0,0q?6   ._?5\      *  $PlotControlLibrary.Views.PlotControl  	   ID$ MyPlot??6   5]      ]? 5`      $??1??6   $??False??6   .+?5a      ?? $??
500,10,0,0q?6   $??Result 1??6&   ?? 5b      $??45??5c      $??40??5d      $??0,0,10,0q?5e      $??0,-2,0,0q?5f      $	??☰??5g      $??Right=?5h      $??30(?5i      
???????5j      ?? 5k      $??45??5l      $??40??5m      $??0,0,10,0q?5n      $??5,0,0,5q?5o      $	??◹??5p      $??Right=?5q      $??30(?5r      
???????5s      5t      &   System.Windows.Controls.DataGrid  5u      $??2??5v      $??5,0,0,0q?5w      
???????
???   ?$??1q?5z         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 50 5{      $|?False??5|      $
??Auto=?5}         SelectionMode$ Extended=?5~         SelectionUnit$
 Cell=?5         MaterialDesignDataGrid#??[  5?      5?      5?      ?? 5?      $??1??5?      $??2??5?      $??0,55,0,0q?5?      ???#A9AAAC$??0,3,0,0q?5?      ?? 5?      $??2??6   $??5q?6    .+?5?      ]? $??0,5,0,0q?6   .+?5?      ?? $??45??5?      $??40??5?      $??0,-5,0,0q?5?      $??+??5?      $??40(?5?      ?? 5?      $??45??5?      $??40??5?      $??5,0,0,0q?5?      $??0,-2,0,0q?5?      $	??☰??5?      $??30(?5?      
???????5?      5?      5?      ?? 5?      $??1??5?      ???#A9AAAC$??0,0,3,0q?5?      ?? 5?      $??1??6   $??5,5,0,0q?6    .+?5?      ]? $??0,5,0,0q?6   .+?5?      ?? $??30,8,0,0q?6   $??Operator inputs ??6#   ?? 5?      $??45??5?      $??40??5?      $??50,0,0,0q?5?      $??5,0,0,5q?5?      $	??◹??5?      $??30(?5?      
???????5?      ?? 5?      $??45??5?      $??40??5?      $??5,0,0,0q?5?      $??0,-2,0,0q?5?      $	??☰??5?      $??30(?5?      
???????5?      5?      ]? 5?      $??	0,10,10,0q?6   .+?5?      ?? $??45??5?      $??40??5?      $??5,0,0,0q?5?      $??0,0,0,0q?5?      $	??◀??5?      $??18(?5?      ?? 5?      $	??200??5?      $??47??5?      $??5,0,0,0q?5?      $??5,8,5,5q?5?      $??25(?5?      
??????? ! MaterialDesignOutlinedTextBox#??[ 5?      ?? 5?      $??45??5?      $??40??5?      $??5,0,0,0q?5?      $??0,0,0,0q?5?      $	??▶??5?      $??18(?5?      5?      ?? 5?      $??5,10,0,0q?6   $??batch number??6"   ]? 5?      .+?5?      ?? $	??250??5?      $??47??5?      $??5,0,0,0q?5?      $??5,8,5,5q?5?      $??25(?5?      
???????#??[ 5?      ?? 5?      $??45??5?      $??40??5?      $??0,0,0,0q?5?      $	??✖??5?      $??18(?5?      5?      ?? 5?      $??5,10,0,0q?6   $??Batch creation date:??6"   ]? 5?      .+?5?      ?? $	??200??5?      $??47??5?      $??5,0,0,0q?5?      $??5,8,5,5q?5?      $??25(?5?      
???????#??[ 5?      ?? 5?      $??45??5?      $??40??5?      $??5,0,0,0q?5?      $??0,0,0,0q?5?      $	??✖??5?      $??18(?5?      ?? 5?      $??45??5?      $??40??5?      $??0,0,0,0q?5?      $	??▦??5?      $??20(?5?      5?      ?? 5?      $??5,10,0,0q?6   $??
Thickness:??6"   ]? 5?      .+?5?      ?? $	??200??5?      $??47??5?      $??5,0,0,0q?5?      $??5,8,5,5q?5?      $??25(?5?      
???????#??[ 5?      ?? 5?      $	??100??5?      $??
10,10,15,5q?5      $??25(?5      " MaterialDesignOutlinedComboBox#??[ 5     .@?5     ?? .??6   mm6   ?? 5     .??6   cm6   5     5     ?? 5     $??5,10,0,0q?6   $??Width:??6"   ]? 5     .+?5	     ?? $	??200??5
     $??47??5     $??5,0,0,0q?5     $??5,8,5,5q?5     $??25(?5     
???????#??[ 5     ?? 5     $	??100??5     $??
10,10,15,5q?5     $??25(?5     #??[ 5     .@?5     ?? .??6   mm6   ?? 5     .??6   cm6   5     5     5     5     ? 5     $??2??6	    5     ?? 5     ?? 5      $
??auto ?6     5"     ?? 5#     $??5 ?6   ?? 5$     $
??auto ?6   .+?5&     ?? $??2??5'     $??2??5(     ???#D01A335)     F? 5*     $??1??5+     r????     ???        ӂ?*    ?R??* ?3:'joK_??S???;[?z?????0?) ????g??@?Lw???? р? ??	  PrimaryHueGridBrush#???  5-      ?? Stretch$
 Fill=?5.     
???   ?5/     ?? 51     $??1??52     $??	5,0,180,0q?53     ??54     ?? *SoftKeyBars+??55     ?? 56     .R?57     A?  A? Rows$ 1??6   58     ??5:     ?? 5;     .R?5<     ? $??20,10q?6   .+?5?  	   ?? -   5        $??50??5@  	   $??Stretch=?5A  	   + 	 %MaterialDesignThemes.Wpf.ButtonAssist	   CornerRadius$	 5??5B  	   + 	 %MaterialDesignThemes.Wpf.ShadowAssist
   ShadowDepth$
 Depth3=?5C  	   #???  5D  	   
???   ???5F  	   ?? *Title+5G  	   5H  	    ?? Triggers 5I     5O     5Q     ?? 5R     $??1??5S     $??1??5T      ?? Orientation$ 
Horizontal=?5U     .+?5V     	? $	??100??5W     $??60??5X     $??10q?5Y      	? 	GroupName$ 
RunControl??5[      d? 	IsChecked$
 TrueY?5\     ??5Z     ?? *StopFunction+??5]     ?? 5^      ?? 
TargetType" 	?6   .?5_  	   ??  ?? Property ? ?? ?? Value 5`  
   ?? 5a      ?? 
TargetType" 	?6   .R?5b     ? .+?5c     ??  ??Name$ border??5d     ???#D01A33
???   ?$??2q?5g      ?? CornerRadius$ 10??5h     ?? 5i     $??Center=?6   .+?5j       $??25??5k     $??25??5l     $??Center=?5m     $ 	Rectangle=?5n     ?? 5o     $??Center=?5p     $??20(?5q     $
??Stop??5r     5s     5t      ?? Triggers 5u     P? 5v      P? Property ?@d?	IsChecked P? Value$
 TrueY?6*   . ?5w     ??  ? ??
 ?   ?6+   5x     P? 5y      ?@d?	IsChecked$ FalseY?6*   . ?5z     ??  ? ??
 ?????6+   5{     5}     5  
   5?  	   5?     	? 5?     $	??100??5?     $??60??5?     $??10q?5?     $ 
RunControl??5?     ??5?     ?? *RunFunction+??5?     ?? 5?     " 	?6   .?5?  	   ??  ? ?? 5?  
   ?? 5?     " 	?6   .R?5?     ? .+?5?     ?? $ border??5?     ???#D01A33
???   ?$??2q?5?     $ 10??5?     ?? 5?     $??Center=?6   .+?5?       $??25??5?     $??25??5?     $??Center=?5?     $
 Play=?5?     ?? 5?     $??Center=?5?     $??20(?5?     $??Start??5?     5?     5?      5?     P? 5?      ?@d?	IsChecked$
 TrueY?6*   . ?5?     ??  ? ??
 ?   ?6+   5?     P? 5?      ?@d?	IsChecked$ FalseY?6*   . ?5?     ??  ? ??
 ?????6+   5?     5?     5?  
   5?  	   5?     5?     5?     5?     5?     
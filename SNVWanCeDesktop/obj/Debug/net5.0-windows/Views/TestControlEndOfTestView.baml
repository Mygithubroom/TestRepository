   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WanCeDesktopApp.ViewsWanCeDesktopApp.Views  5      4    .WanCeDesktopApp.Views.TestControlEndOfTestView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5      /local#clr-namespace:WanCeDesktopApp.Views  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .??5      ? -   5           PrimaryHueGridBrush#???   5      .+?5      ?? -   5         ??Name$ EndOfTestViewScroll??5      $
??Auto=?5      $
??Auto=?5      .??5      ? -   5         ?Name$ WorkArea??5   
   $??10,0,0,0q?6    ? RowDefinitions 5      ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      .+?5      ?? $??1??6   .+?5      ?? $
??1300??5      $
??Left=?5      $
??Wrap=?5       ??5      2  ,WPFLocalizeExtension.Extensions.LocExtension  *!TestControlEndOfTestDescribeOne+5       ?? 5!        txbkFirstTitle#??[ 6   ??69     *
Criteria+?? 5"      .+?5#      ?? -   5        $	??0,5q?5$      -  'MaterialDesignThemes.Wpf.CheckBoxAssist   CheckBoxSize$ 30Q?5%      $??16(?5(      
 ? Tag$ 
testPanel1??5*      ??5'        *End of test1+ d? 	IsChecked 5)      ?? *
TestEnd1+5+      ?? 5,      -   5         ??Name$ 
testPanel1??5,      $y?	Collapsed=?6'   .+?5-   	   ]? $??20,0,0,0q?6   $??False??6%   .+?5.   
   ?? $	??200??5/   
   $??Center=?50   
   ??51   
     *	Criteria1+?? 52   
   $	??500??53   
   $??	150,0,0,0q?54   
    ?? SelectedValue 55   
   ?? *TestEndCriteria1+56   
   ]? 57   	   $??40,5,0,0q?6   $??False??6%   .+?58   
   ?? $	??180??59   
   $??Center=?5:   
   ??5;   
     *Measurement+?? 5<   
   $	??500??5=   
   $??	150,0,0,0q?5>   
    5?   
   ?? *TestEndMeasurement1+5@   
   ]? 5A   	   $??40,5,0,0q?6   $??False??6%   .+?5B   
   ?? $	??180??5C   
   $??Center=?5D   
   ??5E   
     *Sensitivity+?? 5F   
   $	??500??5G   
   $??	150,0,0,0q?5H   
    5I   
   ?? *TestEndSensitivity1+5J   
   5K   	   ?? 5L      -   5        $	??0,5q?5M      $ 30Q?5N      $??16(?5Q      $ 
testPanel2??5S      ??5P        *End of test2+ 5R      ?? *
TestEnd2+5T      ?? 5U      -   5        $ 
testPanel2??5U      $y?	Collapsed=?6'   .+?5V   	   ]? $??20,0,0,0q?6   $??False??6%   .+?5W   
   ?? $	??200??5X   
   $??Center=?5Y   
   ??5Z   
     *	Criteria2+?? 5[   
   $	??500??5\   
   $??	150,0,0,0q?5]   
    5^   
   ?? *TestEndCriteria2+5_   
   ]? 5`   	   $??40,5,0,0q?6   $??False??6%   .+?5a   
   ?? $	??180??5b   
   $??Center=?5c   
   ??5d   
     *Measurement+?? 5e   
   $	??500??5f   
   $??	150,0,0,0q?5g   
    5h   
   ?? *TestEndMeasurement2+5i   
   ]? 5j   	   $??40,5,0,0q?6   $??False??6%   .+?5k   
   ?? $	??180??5l   
   $??Center=?5m   
   ??5n   
     *Sensitivity+?? 5o   
   $	??500??5p   
   $??	150,0,0,0q?5q   
    5r   
   ?? *TestEndSensitivity2+5s   
   5t   	   5u      5v      ?? 5w      $??2??6   .+?5x      ?? #??[ 6   ??69     *Action+]? 5y      $??0,10,0,0q?6   $??False??6#   .+?5z      ?? $	??200??5{      $??Center=?5|      ??5}        *End of test+?? 5~      $	??500??5      $??	170,0,0,0q?5?       5?      ?? *TestEndAction+5?      ?? 5?      $ 30Q?5?      ??5?        *Enable Specimen Protection+ 5?      ?? ?? 5?      $ 30Q?5?      ??5?        *Release Pneumatic Grips+ 5?      ?? 5?      5?      5?      5?      5?      
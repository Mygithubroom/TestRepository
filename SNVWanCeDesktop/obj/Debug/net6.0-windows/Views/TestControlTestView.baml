   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WanCeDesktopApp.ViewsWanCeDesktopApp.Views  5      /    )WanCeDesktopApp.Views.TestControlTestView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5      /local#clr-namespace:WanCeDesktopApp.Views  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       ? 	Resources 5      ??%    .??5      ? -   5           PrimaryHueGridBrush#???   5      .+?5      ?? -   5         ??Name$ TestViewScroll??5      $
??Auto=?5      $
??Auto=?5      .??5      ? -   5         ?Name$ WorkArea??5   
    ? RowDefinitions 5      ?? 5      $
??auto ?6   ?? 5       ? ColumnDefinitions 5      ?? 5      ?? 5      .+?5      ]? $??2??6   $??10,0,0,0q?6$   .+?5       ?? ??6   2  ,WPFLocalizeExtension.Extensions.LocExtension  *TestControlTestDescribe+5!      ]? 5"      $??1??6   .+?5#      ?? $	??600??6   $??10,0,0,0q?6!   .+?5$      ?? -   5         ??Name$	 mmm??5$      ?? 5%      -   5         ??Name$	 ccc??5&      -  'MaterialDesignThemes.Wpf.CheckBoxAssist   CheckBoxSize$ 30Q?5'      $??16(?5*      $
??Bold"?5+      	 d? 	IsChecked$
	 TrueY?5,      

 ? Tag$
 
RampPanel1??5-      ??5)        *Ramp1+5.      ?? 5/      -   5         ??Name$ 
RampPanel1??5/      $y?Visible=?6'   .+?50   	   ??  ?? Orientation$ 
Horizontal=?6   .+?51   
   ?? $	??150??52   
   $??20,0,0,0q?53   
   $??Center=?54   
   $
??Wrap=?56   
   ??55   
     *Control mode+56   
   ?? 57   
   -   5         ??Name$	 cmx??58   
   $	??390??59   
   $??20,0,0,0q?5:   
   5;   
   ?? 5<   	   $
??0,10q?6   $ 
Horizontal=?6"   .+?5=   
   ?? $	??150??5>   
   $??20,0,0,0q?5?   
   $??Center=?5@   
   $
??Wrap=?5B   
   ??5A   
     *Rate1+5B   
   ?? 5C   
   $	??100??5D   
   $??20,0,5,0q?5E   
   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True??5F   
   ?? 5G   
   $??50??5H   
   $??0,0,5,0q?5I   
   ??5J   
   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ FunctionVariant=?   Size 24?? 5L   
   $??50??6   ??6     $ Keyboard=? 24?? 5M   
   -   5        $
 cmx2??5N   
   $	??100??5O   
   $	??5,0q?5P   
   ?? 5Q   
   $??50??5R   
    ? Cursor$
 Hand??5U   
   ??5S   
     $ Pencil=? 245U   
   5V   
   5W   	   5X      5Y      ]? 5Z      $??1??6   $??1??6   .+?5[      ?? $??10,0,0,0q?6   .+?5\      ?? ?? 5]      -	   5        $ 30Q?5^      $??16(?5a      $
??Bold"?5b      $
	 TrueY?5c      $
 
RampPanel2??5d      ??5`        *Ramp2+5e      ?? 5f      -
   5        $ 
RampPanel2??5f      $y?Visible=?6'   .+?5g   	   ?? $ 
Horizontal=?6   .+?5h   
   ?? $	??150??5i   
   $??20,0,0,0q?5j   
   $??Center=?5k   
   $
??Wrap=?5m   
   ??5l   
     *Control mode+5m   
   ?? 5n   
   $	??390??6   $??20,0,0,0q?6   5o   
   ?? 5p   	   $
??0,10q?6   $ 
Horizontal=?6"   .+?5q   
   ?? $	??150??5r   
   $??20,0,0,0q?5s   
   $??Center=?5t   
   $
??Wrap=?5v   
   ??5u   
     *Rate2+5v   
   ?? 5w   
   $	??100??5x   
   $??20,0,5,0q?5y   
   $
 True??5z   
   ?? 5{   
   $??50??5|   
   $??0,0,5,0q?5}   
   ??5~   
     $ FunctionVariant=? 24?? 5?   
   $??50??6   ??6     $ Keyboard=? 24?? 5?   
   $	??100??6   $	??5,0q?6   ?? 5?   
   $??50??5?   
   $
 Hand??5?   
   ??5?   
     $ Pencil=? 245?   
   5?   
   5?   	   5?      5?      5?      5?      5?      5?      
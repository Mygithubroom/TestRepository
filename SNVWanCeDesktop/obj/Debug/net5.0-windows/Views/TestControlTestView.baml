   M S B A M L   `   `   `  ????J  FWanCeDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WanCeDesktopApp.ViewsWanCeDesktopApp.Views  5      /    )WanCeDesktopApp.Views.TestControlTestView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WWPFLocalizeExtension, Version=3.9.4.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  5      /local#clr-namespace:WanCeDesktopApp.Views  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       ? 	Resources 5      ??%    .??5      ? -   5           PrimaryHueGridBrush#???   5      .+?5      ?? -   5         ??Name$ TestViewScroll??5      $
??Auto=?5      $
??Auto=?5      .??5      ? -   5         ?Name$ WorkArea??5   
    ? RowDefinitions 5      ?? 5      $
??auto ?6   ?? 5       ? ColumnDefinitions 5      ?? 5      ?? 5      .+?5      ]? $??2??6   $??10,0,0,0q?6$   .+?5       ?? ??6   2  ,WPFLocalizeExtension.Extensions.LocExtension  *TestControlTestDescribe+5!      ]? 5"      $??1??6   .+?5#      ?? $	??600??6   $??10,0,0,0q?6!   .+?5$      ?? -   5         ??Name$	 mmm??5$      ?? 5%      -   5         ??Name$	 ccc??5&      -  'MaterialDesignThemes.Wpf.CheckBoxAssist   CheckBoxSize$ 30Q?5'      $??16(?5*      $
??Bold"?5+      
	 ? Tag$	 
RampPanel1??5-      ??5)        *Ramp1+
 d? 	IsChecked
 5,      ?? *Ramp1Control+5.      ?? 5/      -   5         ??Name$ 
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
    ?? SelectedValue 5;   
   ?? *Ramp1Controlmode+5<   
   ?? 5=   	   $
??0,10q?6   $ 
Horizontal=?6"   .+?5>   
   ?? $	??150??5?   
   $??20,0,0,0q?5@   
   $??Center=?5A   
   $
??Wrap=?5C   
   ??5B   
     *Rate1+5C   
   ?? 5D   
   $	??100??5E   
   $??20,0,5,0q?5F   
   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True??5G   
   ??5H   
   ?? *	Ramp1Rate+?? 5I   
   $??50??5J   
   $??0,0,5,0q?5K   
   ??5L   
   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ FunctionVariant=?   Size 24?? 5N   
   $??50??6   ??6     $ Keyboard=? 24?? 5O   
   -   5        $
 cmx2??5P   
   $	??100??5Q   
   $	??5,0q?5R   
    5S   
   ?? *	Ramp1Unit+?? 5T   
   $??50??5U   
    ? Cursor$
 Hand??5X   
   ??5V   
     $ Pencil=? 245X   
   5Y   
   5Z   	   5[      5\      ]? 5]      $??1??6   $??1??6   .+?5^      ?? $??10,0,0,0q?6   .+?5_      ?? ?? 5`      -	   5        $ 30Q?5a      $??16(?5d      $
??Bold"?5e      $	 
RampPanel2??5g      ??5c        *Ramp2+
 5f      ?? *Ramp2Control+5h      ?? 5i      -
   5        $ 
RampPanel2??5i      $y?Visible=?6'   .+?5j   	   ?? $ 
Horizontal=?6   .+?5k   
   ?? $	??150??5l   
   $??20,0,0,0q?5m   
   $??Center=?5n   
   $
??Wrap=?5p   
   ??5o   
     *Control mode+5p   
   ?? 5q   
   $	??390??5r   
   $??20,0,0,0q?5s   
    5t   
   ?? *Ramp2Controlmode+5u   
   ?? 5v   	   $
??0,10q?6   $ 
Horizontal=?6"   .+?5w   
   ?? $	??150??5x   
   $??20,0,0,0q?5y   
   $??Center=?5z   
   $
??Wrap=?5|   
   ??5{   
     *Rate2+5|   
   ?? 5}   
   $	??100??5~   
   $??20,0,5,0q?5   
   $
 True??5?   
   ??5?   
   ?? *	Ramp2Rate+?? 5?   
   $??50??5?   
   $??0,0,5,0q?5?   
   ??5?   
     $ FunctionVariant=? 24?? 5?   
   $??50??6   ??6     $ Keyboard=? 24?? 5?   
   $	??100??5?   
   $	??5,0q?5?   
    5?   
   ?? *	Ramp2Unit+?? 5?   
   $??50??5?   
   $
 Hand??5?   
   ??5?   
     $ Pencil=? 245?   
   5?   
   5?   	   5?      5?      5?      5?      5?      5?      
   M S B A M L   `   `   `  ????K  GTwitchSweepStake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TwitchSweepStakeTwitchSweepStake  5   	   !    TwitchSweepStake.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:TwitchSweepStake     5   	   -   5          ? WindowStyle$
  None=?5   	   $	??720??5      $
??1280??6'    ? 
ResizeMode$ NoResize=?64    ? Title$ StartScreen??5	   	    ? Triggers 5      :? 5   
    :? RoutedEvent$ Window.Loaded??6   .[?5      ?? .??5      ?? .??5      W?  ?? TargetProperty$ (Window.Opacity)?6&    W? From 0.05   "   	 W? To 1.06-    g? Duration$ 0:0:1D?66   	 g? AutoReverse$	 False??5   "   5      5      5      ??5      ?? 5   
   
 ?? ImageSource$
 /Images/eft_bg1.jpg??6    ? 	Resources 5       
  bender??%0   &	        *?5   
   /Fonts/#bender)?65   5      .??5      ? .+?5    
   ]? $??False??6   .+?5!      ?? -   5        $??Jelentkezések indítása??5"      $??Bottom=?5#      $??50??6)   
???????
?????????5$      Z? ??5'      ?? 5(       ?? 
TargetType" ??6   .?5)      ??  ?? Property ? ?? ?? Value
 ?????68   ?? 5*       ? ??
 ?????67   ?? 5+       ? ??# [  6C   ?? 5,       ? ??$ 18(?6A   ?? 5-       ? ?? 5.      ?? 5/   "    ?? 
TargetType" ??62   .R?50   &   ??  ??Name$ Border??51   )   #??z??52   )   #??z??53   )   #??z??54   )   ._?55   *   ?? $??Center=?56   -   $??Center=?57   -   #??z??58   -   #??z??59   -    ? Cursor# z 5:   -   #??z??5;   -   5=   '    ?? Triggers 5>   &   P? 5?   *    P? Property ?@J?IsMouseOver P? Value$
 True??6I   . ?5@   .   ??  ?? 
TargetName$ Border??6]    ? ?? ?	#2F3434345A   +   5C   #   5E      5F      5H      5I      ?? 5K   
   -   5         ??Name$ 
MainCanvas??5K      $??0??5L   	   $??2??5M   	   $??0??5N   	   $??3??5O   	   .+?5P      A? -   5         A?Name$ 	close_img??5Q      $??24??5R      $??24??5S      
???????
 ?? Top$ 16??5U       ?? Right$ 16??5V      ??5W      ?? 5X      $
 /Images/cancel_button.png??6!   5Z      ?? 5\      -   5         ??Name$ 	sound_img??5]      $??/Images/volume_up.png??5^      $??24??5_      $??24??5`      $ 16??5a      $ 50??5b      6#   ?? 5e      -   5        $??Label1??5f      $?? ??5g      $ 16??5h       ?? Bottom$ 60??5i      #??[  5j      $??20(?5k      
???????5m      5p      5r      5u      
   M S B A M L   `   `   `  ????K  GTwitchSweepStake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TwitchSweepStakeTwitchSweepStake  5   	   !    TwitchSweepStake.ListWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:TwitchSweepStake     5   	   -   5          ? WindowStyle$
  None=?5   	   $	??720??6   $
??1280??6)    ? 
ResizeMode$ NoResize=?66    ? Title$ 
ListWindow??5	   	   ??5      ?? 5   
    ?? ImageSource$ /Images/eft_bg3.jpg??6    ? 	Resources 5       
  bender  ScrollThumbs ?? 
TargetType ?? Property ?? Value ?Name	 ??Name
 ?? CornerRadius ?? Triggers P? Property P? Value ?? 
TargetName ?? 
TargetType ]?Name ]? Thumb n?Name ]? IncreaseRepeatButton ??Name J? Opacity ]? DecreaseRepeatButton P? 
SourceName  ButtonSelectBrush  	DarkBrush ?? Angle?? 5   
   %T	  &	        &	 &     '?? s    *?5      /Fonts/#bender)?69   ?? 5      " n?6)   .?5      ??  ? ?? 5      ?? 5      .R?5   "   ? $
 Grid??6'   .+?5   &   ?? $??Stretch=?60   $??Stretch=?6N   $
??Auto??6j   $
??Auto??5   ,   
?????? 6:   ?? 5   &   $	 
Rectangle1??6-   $
 	10 0 0 10??6A   $??Stretch=?6Z   $??Stretch=?5   )   $
??Auto??6E   $
??Auto??6R   #??z??5   )   5   #    5   "   P? 5    &    ?@?Tag$ 
Horizontal??6=   . ?5!   *   ?? $ 
Rectangle1??61    ? ??$
 Auto??6Z   ?? 5"   *   $ 
Rectangle1??61    ? ??$ 7??6[   5#   '   5%      5'      5(      ?? 5+      " ??63   .?5,      ??  ?@??IsFlicksEnabled$ False??6?   ?? 5-       ? ?? ?	#AAA8341A63   ?? 5.       ? ??
 ?????63   ?? 5/       ? ??$ 10??6.   ?? 50       ? ?? 51      ?? 52      " ??6.   .R?53   "   ? $ GridRoot??6'   $??12??69   ??6D   Z? .+?54   &   ]? $ 
PART_Track??6,   $??0??6@   $
??true??6M   $|?False??6h    55   *   n? 56   .   $ Thumb??64   #??z??6C   #???  57   0    59   *   ?? 5:   .   $ PageUp??6;   $??ScrollBar.PageDownCommand??6K   $ 0Q?6o   $|?False??6{    5<   *   ?? 5=   .   $ PageDown??6;   $??ScrollBar.PageUpCommand??6M   $ 0Q?6o   $|?False??6{   5?   '   5@   #    5B   "   P? 5C   &   $ Thumb??6.    ?@J?IsMouseOver$
 true??6X   . ?5D   *   ?? # ?  61   $ Thumb??5E   -    ? ??6@   5F   '   P? 5G   &   $ Thumb??6.    ?@n?
IsDragging$
 true??6W   . ?5H   *   ?? # ?  61   $ Thumb??6U    ? ??6h   5I   '   P? 5K   &    ? {?$ false??6C   . ?5L   *   ?? $ Thumb??61    ? y?$ 	Collapsed=?6Z   5M   '   P? 5N   &    ?@??Orientation$ 
Horizontal=?6E   . ?5O   *   ?? $ GridRoot??61    ?@?LayoutTransform 5P   .   ?? 5Q   2   $	 -90Q?6B   5S   +   ?? 5T   *   $ 
PART_Track??61    ?@?LayoutTransform 5U   .   ?? 5V   2   $	 -90Q?6B   5X   +   ?? 5Y   *    ? ??$
 Auto??6B   ?? 5Z   *    ? ??$ 12??6C   ?? 5[   *   $ Thumb??61    ?@?Tag$ 
Horizontal??6S   ?? 5\   *   $ PageDown??61    ? ??$ ScrollBar.PageLeftCommand??6Z   ?? 5]   *   $ PageUp??61    ? ??$  ScrollBar.PageRightCommand??6X   5^   '   5`      5b      5c      5d      .??5g   
   ? .+?5h   
   ]? $??False??6   .+?5i      ?? -   5        $??Sorsolás indítása??5j      $??Bottom=?5k      $??50??6)   
???????
?????????5l      Z? ??5o      ?? 5p      " ??6   .?5q      ??  ? ??
 ?????68   ?? 5r       ? ??
 ?????67   ?? 5s       ? ??# [  6C   ?? 5t       ? ??$ 18(?6A   ?? 5u       ? ?? 5v      ?? 5w   "   " ??62   .R?5x   &   ?? $	 Border??5y   )   #??z??5z   )   #??z??5{   )   #??z??5|   )   ._?5}   *   ?? $??Center=?5~   -   $??Center=?5   -   #??z??5?   -   #??z??5?   -    ? Cursor# z 5?   -   #??z??5?   -   5?   '    5?   &   P? 5?   *    ?@J?IsMouseOver$
 True??6I   . ?5?   .   ?? $ Border??6]    ? ?? ?	#2F3434345?   +   5?   #   5?      5?      5?      5?      ?? 5?   
   -   5         ??Name$ 
MainCanvas??5?      $??0??5?   	   $??2??5?   	   $??0??5?   	   $??3??5?   	   .+?5?      A? -   5         A?Name$ 	close_img??5?      $??24??5?      $??24??5?      
???????
 ?? Top$ 16??5?       ?? Right$ 16??5?      ??5?      ?? 5?      $ /Images/cancel_button.png??6!   5?      ?? 5?      -   5         ??Name$ 	sound_img??5?      $??/Images/volume_up.png??5?      $??24??5?      $??24??5?      $ 16??5?      $ 50??5?      6#   ?? 5?      -   5         ??Name$ 
resztvevok??5?      $??Résztvevők??5?      $ 30??5?        ?? Left$  50??5?      #??[  5?      $??30(?5?      
???????5?      ?? 5?      -   5        ! ??Name$! usernames_panel??5?      $	 100??5?      $  50??5?      $	??300??5?      $	??540??5?      ??5?      ?? 5?      .R?5?      ?? " ??Name$" ScrollViewer??6+   #??z??6A   .??5?   "   ?? 5?      5?      5?      5?      5?      5?      
   M S B A M L   `   `   `  ????K  GTwitchSweepStake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TwitchSweepStakeTwitchSweepStake  5   	   #    TwitchSweepStake.WinnerWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5   	   *localclr-namespace:TwitchSweepStake  5   	   -   5          ? WindowStyle$
  None=?5   	   $	??720??5	      $
??1280??6'    ? 
ResizeMode$ NoResize=?64    ? Title$ WinnerWindow??5
   	    ? 	Resources 5       
  bender??%0   &	        *?5   
   /Fonts/#bender)?65   5      ??5      ?? 5   
    ?? ImageSource$ /Images/eft_bg4.jpg??6   .??5      ? .+?5   
   ?? -   5         ??Name$ 
cropCanvas??5      $??0??5   	   $??2??5   	   $??0??5   	   $??3??5   	   .+?5      A? -   5         A?Name$ crop1??5       ?? Left$	 251??5      
 ?? Top$ 86??6#   $	??255??63   $	??353??6@   ??5      ?? 5      $ /Images/crop1.png??6!   5!      A? 5$      -   5        $ crop2??5%      $	 937??5&      $	 455??6#   $	??255??64   $	??353??6A   ??5'      ?? 5(      $ /Images/crop2.png??6!   5*      A? 5,      -   5        $ crop3??5-      $ 91??5.      $	 455??6"   $	??255??63   $	??352??6@   ??5/      ?? 50      $ /Images/crop3.png??6!   52      53      ?? 56   
   -   5        $ OptionsCanvas??56      $??0??57   	   $??2??58   	   $??0??59   	   $??3??5:   	   .+?5<      A? -   5        $ 	close_img??5=      $??24??5>      $??24??5?      
???????$ 16??5A      	 ?? Right$	 16??5B      ??5C      ?? 5D      $ /Images/cancel_button.png??6!   5F      ?? 5H      -   5        
 ??Name$
 	sound_img??5I      $??/Images/volume_up.png??5J      $??24??5K      $??24??5L      $ 16??5M      $	 50??5N      6#   5P      ?? 5Q   
   -	   5        $ 
MainCanvas??5Q      $??0??5R   	   $??2??5S   	   $??0??5T   	   $??3??5U   	   .+?5V      ? ??6   ?? *ActualWidth+ ?? ElementName$ 
MainCanvas????5W      ?? *ActualHeight+$ 
MainCanvas??.+?5Z      ?? -
   5        $ CanvasMiddle??5[      $	??700??5\      $	??300??5]      $??Center=?5^      $??Center=?5`      ??5a      ?? 5b       ?? EndPoint$ 0.5,1&?6.    ?? 
StartPoint$ 0.5,0&?6?   .??5c      ?  ? Color$ Black??6+   ? 5d      $ 	#02F1AAAA??6+    ? Offset$ 1Q?6=   ? 5e      $ 	#AB503838??6+   $ 0.022Q?6=   5f      .+?5h      ? ??6   ?? *ActualWidth+$ CanvasMiddle????5i      ?? *ActualHeight+$ CanvasMiddle??.+?5j      ?? -   5        $??
gratulalok??5k      $??Gratulálok!??5l      $??Center=?5m   '   #??[  5o      $??80(?5p      $
??Bold"?5q      
???????$	 219??5r   4   ?? 5s      -   5         ??Name$ winner_name??5t      $??LeonardoGriffin??5u      $??Center=?5v      $??Center=?5w      #??[  5x      $??70(?5y      $
??Bold"?5z      
?????????5|      ?? 5}   "   $ 0.5,1&?66   $ 0.5,0&?6G   .??5~   &   ? $ 	#02000000??63   $ 0Q?6E   ? 5   &   $ White??63   $ 1Q?6A   ? 5?   &   $ 	#FF933232??63   $ 0.404Q?6E   ? 5?   &   $ 	#FF1A0808??63   $
 0.16Q?6E   ? 5?   &   $ 	#FF010000??63   $ 0.908Q?6E   5?   #   5?      5?      5?      5?      5?      5?      5?      
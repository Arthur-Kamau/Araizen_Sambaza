   M S B A M L   `   `   `  ����B  >Sambaza, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:SambazaSambaza  5   	   H DMahApps.Metro, Version=1.6.1.4, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	       Sambaza.Ui_MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Sambaza     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5          � Title$  Sambaza��5   	   $	��750��6   $	��900��6&   (  "MahApps.Metro.Controls.MetroWindow   RightWindowCommands 5      +  %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� -   5         ��Name$ login��5      .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $<��6./resources/images/ic_person_outline_black_24dp_1x.png��6   $��15��6\   $��15��6h   6v   5      5      �� 5      -   5        $ feedback��5      .��5      �� $ 
Horizontal=�6   .+�5      �� $��4 0 0 0q�6    $��Center=�5      $��Feedback��5      5      5      5       � 	Resources 5"       �� 
TargetType �� Property �� Value��%�   '��       �� 5#   
   " ��6   .�5$      ��  � �� �	#FFE6E6E66+   �� 5%       � ��$ 40��6&   �� 5&       � ��$ 50��6'   �� 5'       � �� �	#FFE6E6E66,   �� 5(       � ��$ 0q�60   5)      5+      .��5,      �� $ 
Horizontal=�6   .+�5.   
   �� $��0,0,0,1q�6   $
��Left=�6&   $	��105��6A   
�������.+�50      �� -   5        $��	0,20,0,15q�50   6   #��[" �6I   $��42��6�   .��51      �� $ 
Horizontal=�6   .+�52      �� $��25��6   $��25��6(   $$��./resources/images/ic_menu.png��63   6]   �� 53      $��	Dashboard��6   62   54      55      �� 59      -   5        $��	0,10,0,10q�59   F   #��[" �6Y   $��42��6�   .��5:      �� $ 
Horizontal=�6   .+�5;      �� $��25��6   $��25��6(   $1��+./resources/images/ic_wifi_tethering_2x.png��63   6j   �� 5<      $��	Hotspot  ��6   62   5=      5>      �� 5@      -   5        $
��Send��5@      $��	0,10,0,10q�64   #��[" �6G   $��42��6�   .��5A      �� $ 
Horizontal=�6   .+�5B      �� $��25��6   $��25��6(   $2��,./resources/images/ic_send_black_24dp_2x.png��63   6k   �� 5C      $��	Send     ��6   62   5D      5E      �� 5F      -   5        $��	0,10,0,10q�5F   1   #��[" �6D   $��42��6   .��5G      �� $ 
Horizontal=�6   .+�5H      �� $��25��6   $��25��6(   $;��5./resources/images/ic_folder_shared_black_24dp_2x.png��63   6t   �� 5I      $��	Public   ��6   62   5J      5K      �� 5P      -   5        $��	0,10,0,10q�5P   ;   #��[" �6O   $��42��6�   .��5Q      �� $ 
Horizontal=�6   .+�5R      �� $��25��6   $��25��6(   $*��$./resources/images/ic_history_3x.png��63   6c   �� 5S      $��
History   ��6   63   5T      5U      �� 5V      -	   5         J� Opacity$ 0Q�5V   3   $��	0,10,0,10q�6?   #��[" �6S   $��42��6�   .��5W      �� $ 
Horizontal=�6   .+�5X      �� $��25��6   $��25��6(   $5��/./resources/images/ic_supervisor_account_3x.png��63   6n   �� 5Y      $��Map    ��6   60   5Z      5[      �� 5]      -
   5        $��	0,205,0,0q�5]   3   #��[" �6H   $��42��6�   .��5^      �� $ 
Horizontal=�6   .+�5_      �� $��25��6   $��25��6(   $+��%./resources/images/ic_settings_2x.png��63   6d   �� 5`      $��Settings   ��6   64   5a      5b      5d       � 5f   
   -   5        	  �Name$	 content_container��5f      $��0,0,0,0q�6+   $	��785��6<   $	��720��6H   
�������
  � NavigationUIVisibility$
 Hidden=�6h   5h      5i      
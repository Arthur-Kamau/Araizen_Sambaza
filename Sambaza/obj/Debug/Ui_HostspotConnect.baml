   M S B A M L   `   `   `  ����B  >Sambaza, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:SambazaSambaza  5           Sambaza.Ui_HostspotConnect   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Sambaza     5        N� Title$  Connect��5	      .��5      ��  �� Orientation$ Vertical=�6   
�������.+�5   
   �� $ 
Horizontal=�6   $��Center=�6/   $��30��6L   $	��254��6X   .+�5      �� $��Connect to Hotspot��6   $��15(�61   $	��254��6?   6M   5      �� 5   
   $ 
Horizontal=�6   $��Center=�6.   $��
94,0,114,0q�6K   $	��412��6_   .+�5      �� -   5        $��	ErrorItem��5      $��
20,5,20,10q�6%   $��8(�6:   $��Center=�6G   $��Bottom=�6d   $�� ��6   $	��375��6�   $��24��6�   6�   5      �� 5   
   $��	0,20,0,20q�6   $ 
Horizontal=�6(   $
��Left=�6A   .+�5      �� -   5         ��Name$ hotspot_name_label��5   &   $��20,0,0,0q�6   $��Hotspot Name��6B   $	��132��6Y   $��25��6e   6s   �� 5      -   5         ��Name$ wifi_name_combobox��5   )   $��20,0,0,0q�6   $��30��6~   $��300.649��6�   �� 5      $��10,0,0,0q�6   .+�5      �� -   5        $��WifiStrength��5   1   $��Strength  :0 %��6   6G   5      5      �� 5   
   $ 
Horizontal=�6   .+�5      �� -   5        $ hotspot_password_label��5   '   $��20,0,0,0q�6   $��Password��6G   $	��132��6Z   $��25��6f   6u   G� 5      -   5         G�Name$ wifi_password_textbox��5   ,   $��20,0,0,0q�6   $��30��6K   $��200.649��6W   �� 5      -   5        $��
Protection��5   '   $��	110,0,0,0q�6   $��Protection : None ��69   6X   5      �� 5   
   .+�5      �� -   5         ��Name$ HotSpot_Connect��5   g   $��	10,40,0,0q�6   
������ $��0q�6B   $��submit��6V   $��Center=�6�   $	��100��6�   $��30��6�   6�   5       �� 5!   
   $��5q�6   $��0,5,5,0q�6(   6;   �� 5"   
   .+�5#      �� $��Details��6   6(   �� 5$      -	   5         ��Name$ Details��5$      $	��302��6'   $	��600��64   
�������{�.   �� TextWrapping$
 Wrap=�5&       �� AcceptsReturn . 	 �� 
AcceptsTab	 . 
 �� 	IsEnabled
 . $ �� HorizontalScrollBarVisibility$ Disabled=�5*      " �� VerticalScrollBarVisibility$
 Auto=�5+      5,      5-      5.      5/      
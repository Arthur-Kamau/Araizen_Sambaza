   M S B A M L   `   `   `  ����B  >Sambaza, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:SambazaSambaza  5          Sambaza.Ui_HostspotStart   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Sambaza     5        N� 
Background
  ����� N� Title$ Start��5
      .��5      �� 
������� �� Orientation$ Vertical=�6$   .+�5   
   �� $ 
Horizontal=�6   $��Center=�6/   $��30��6L   $	��254��6X   .+�5      �� $�� Hotspot details��6   $��15(�6/   $	��254��6=   6K   5      �� 5   
   $ 
Horizontal=�6   .+�5      �� -   5         ��Name$ hotspot_name_label��5   &   $��20,0,0,0q�6   $��Hotspot Name��6B   $��196.5��6Y   $��30��6g   6u   �� 5      -   5        $ hotspot_password_label��5   (   $��	103,0,0,0q�6   $��Password��6H   $��71��6[   $��30��6f   6u   �� 5      $��
0,10,20,10q�6   $��8(�6)   $��Right=�66   $��Bottom=�6R   $��More than 8 characters��6m   $��96��6�   $��19��6�   6�   5      �� 5   
   $��	0,20,0,20q�6   $ 
Horizontal=�6(   .+�5      �� -   5         ��Name$ hotspot_name_textbox��5   K   $��20,0,0,0q�6   $��30��6j   $��200.649��6v   �� 5      -   5        $!��hotspot_name_textbox_images��5   +   $��25��6   $��25��6    $��20,0,0,0q�6N   6b   G� 5      -   5         G�Name$ hotspot_password_textbox��5   T   $��	100,0,0,0q�6   $��30��6v   $��200.649��6�   �� 5      -   5        $%��hotspot_password_textbox_images��5   +   $��25��6   $��25��6    $��20,0,0,0q�6R   6f   5      �� 5   
   -   5         ��Name$ Hotspot_submit��5   b   $��0,0,0,0q�6   
������ $��0q�6=   $��submit��6Q   $��Center=�6�   $	��100��6�   $��30��6�   6�   �� 5   
   -   5         ��Name$ ShareOption��5   ;   $��Right=�6   $	��150��6/   6R   �� 5   
   $��	0,20,0,30q�6   6)   �� 5    
   .+�5!      �� $��Details��6   6(   �� 5"      -	   5        $ Details��5"      $	��302��6'   $	��600��64   
�������{�.   �� TextWrapping$
 Wrap=�5$      	 �� AcceptsReturn	 . 
 �� 
AcceptsTab
 .  �� 	IsEnabled . $ �� HorizontalScrollBarVisibility$ Disabled=�5(      " �� VerticalScrollBarVisibility$
 Auto=�5)      5*      5+      5,      5.      
   M S B A M L   `   `   `  ����F  BGSH Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PresentationPresentation  5   	       Presentation.HTC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Presentation     5   	   U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	     � Title$  Jagd den Kommandant��5	   	   $	��450��6%   $	��450��62    � Icon$ GSH.ico��6>    � 
ResizeMode$ CanMinimize=�6M   .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagrd_Players��5      $
��Left=�6,   $��	10,50,0,0q�6G   $	��Top=�6Z   $	��315��6r   $	��345��6      CanUserResizeColumns .     
IsReadOnly .  � ContextMenu 5      �� 5      .@�5      m�  m� Command$
 Copy��6   5      5      �� 5   
   -   5         ��Name$ lbl_Overview��5      $��Leaderboard��6&   $
��Left=�6<   $��166.652,12,0,0q�6W   $	��Top=�6o   &   System.Windows.Media.TextOptions	   TextHintingMode$	 Animated=�6�   
   TextFormattingMode$
 Display=�6�    � UseLayoutRounding .  $��16(�6�   $��
ExtraBlack"�6�   ���	#FF212BF16  !  MahApps.Metro.Controls.Tile  5   
   -   5          Name$ 
tile_Atras��5         Title$  ��6,      
TiltFactor$ 2��65   $��0��6D   $��45��6T   $��45��6_   $��387,364,10,10q�6k   $	 Animated=�6�   $��12(�6�   $��Microsoft Sans Serif)�6�      HorizontalTitleAlignment$ Center=�6�   ���	#CCFFFFFF.��5      �� $��45��6   $��45��6#   ��5      !� 5       !� Visual 5      � 5      .+�5   "   �� �� 5   "   $��Back.png��6(   �� 5   "   $��Center=�63   $��Center=�6P   5      5      5       5!        5"   
   -   5        $ tile_StartNewSeason��5"      $  ��65   $ 2��6>   $��0��6M   $��45��6]   $
��Auto��6h   $��387,50,10,324q�6v   $	 Animated=�6�   $��12(�6�   $��Microsoft Sans Serif)�6�   $ Center=�6�   ���	#CCFFFFFF � BindingGroup 5#      &   System.Windows.Data.BindingGroup  5$      .��5&      �� $��45��6   $��45��6#   ��5'      !� 5(       5)      � 5*      .+�5+   "   �� �� 5,   "   $��Stop.png��6(   �� 5-   "   $��Center=�63   $��Center=�6P   5.      50      52      53        54   
   -   5        $ tile_Editar��54      $  ��6-   $ 2��66   $��0��6E   $��45��6U   $��45��6`   $��387,195,10,179q�6l   $	 Animated=�6�   $��12(�6�   $��Microsoft Sans Serif)�6�   $ Center=�6�   ���	#CCFFFFFF.��55      �� $��45��6   $��45��6#   ��56      !� 57       58      � 59      .+�5:   "   �� �� 5;   "   $��Start_Session.png��6(   �� 5<   "   $��Center=�63   $��Center=�6P   5=      5?      5A      5B      �� 5C   
   -   5         ��Name$ btn_SelectAll��5C      $��
Select All��6(   $��184,382,183,0q�6=   $	��Top=�6T   6l   �� 5D   
   -   5        $ 
btn_Export��5D      $��Export��6%   $
��Left=�66   $��
10,382,0,0q�6Q   $	��Top=�6e   $��75��6}   6�   5F      5G      
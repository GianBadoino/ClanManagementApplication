   M S B A M L   `   `   `  ����F  BGSH Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PresentationPresentation  5   	        Presentation.ManagePlayers   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Presentation     5   	   U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	     � Title$  Players��5	   	   $	��650��6   $��754.201��6&    � Icon$ GSH.ico��66    � 
ResizeMode$ CanMinimize=�6E   .��5
      � .+�5   
   !  MahApps.Metro.Controls.Tile  -   5          Name$ 	tile_Back��5         Title$  ��6+      
TiltFactor$ 2��64   $��0��6C   $��45��6S   $��45��6^   $��688,547,13,27q�6j   &   System.Windows.Media.TextOptions   TextHintingMode$ Animated=�6�   $��12(�6�   $��Microsoft Sans Serif)�6�      HorizontalTitleAlignment$ Center=�6�   ���	#CCFFFFFF.��5      �� $��45��6   $��45��6#   ��5      !� 5       !� Visual 5      � 5      .+�5   "   �� �� 5   "   $��Back.png��6(   �� 5   "   $��Center=�63   $��Center=�6P   5      5      5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        	  Name$	 datagrd_Players��5      $
��Left=�6,   $��	10,27,0,0q�6G   $	��Top=�6Z   $	��653��6r   $	��517��6~   ��. 6�     5   
   -   5        $ tile_AddPlayer��5      $  ��60   $ 2��69   $��0��6H   $��35��6X   $��35��6c   $��698,175,13,409q�6o   $ Animated=�6�   $��12(�6�   $��Microsoft Sans Serif)�6�   $ Center=�6�   
�������.��5      �� $��35��6   $��34��6#   ��5      !� 5       5      � 5       .+�5!   "   �� �� 5"   "   $��Add.png��6(   �� 5#   "   $��Center=�63   $��Center=�6P   5$      5&      5(      5)        5*   
   -   5        $ tile_EditPlayer��5*      $  ��61   $ 2��6:   $��0��6I   $��35��6Y   $��35��6d   $��698,275,13,309q�6p   $ Animated=�6�   $��12(�6�   $��Microsoft Sans Serif)�6�   $ Center=�6�   
�������.��5+      �� $��35��6   $��34��6#   ��5,      !� 5-       5.      � 5/      .+�50   "   �� �� 51   "   $��Edit.png��6(   �� 52   "   $��Center=�63   $��Center=�6P   53      55      57      58        59   
   -   5        $ tile_DeletePlayer��59      $  ��63   $ 2��6<   $��0��6K   $��35��6[   $��35��6f   $��698,375,13,209q�6r   $ Animated=�6�   $��12(�6�   $��Microsoft Sans Serif)�6�   $ Center=�6�   
�������.��5:      �� $��35��6   $��34��6#   ��5;      !� 5<       5=      � 5>      .+�5?   "   �� �� 5@   "   $��
Delete.png��6(   �� 5A   "   $��Center=�63   $��Center=�6P   5B      5D      5F      5G        5H   
   -   5        $ tile_Refresh��5H      $  ��6.   $ 2��67   $��0��6F   $��35��6V   $��35��6a   $��698,27,13,557q�6m   $ Animated=�6�   $��12(�6�   $��Microsoft Sans Serif)�6�   $ Center=�6�   
�������.��5I      �� $��35��6   $��34��6#   ��5J      !� 5K       5L      � 5M      .+�5N   "   �� �� 5O   "   $��Refresh.png��6(   �� 5P   "   $��Center=�63   $��Center=�6P   5Q      5S      5U      5V      �� 5W   
   -   5        
 ��Name$ 
 btn_AddParticipationPoints��5W      $0��*                Add 
Participation Points��65   $
��Left=�6r   $��
10,549,0,0q�6�   $	��Top=�6�   $	��130��6�   $��45��6�   ���	#FFC5D8FF6�   �� 5X   
   -   5        $
 btn_Payments��5X      $��Payments��6'   $
��Left=�6:   $��186,549,0,0q�6U   $	��Top=�6j   $	��130��6�   $��43��6�   ���	#FFC5D8FF6�   5Z      5[      
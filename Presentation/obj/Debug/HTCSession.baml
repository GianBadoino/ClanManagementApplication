   M S B A M L   `   `   `  ����F  BGSH Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PresentationPresentation  5   	       Presentation.HTCSession   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Presentation     5   	   U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	     � Title$  HTC Session��5	   	   $	��500��6   $	��498��6*   ���	#FFC5D8FF � 
ResizeMode$ CanMinimize=�6M    � Icon$ GSH.ico��6f   .��5
      � $��0,0,2,0q�6   .+�5   
   �� -   5         ��Name$ combox_Players��5      $
��Left=�6+   $��
188,36,0,0q�6F   $	��Top=�6Z   $	��160��6r   !  MahApps.Metro.Controls.Tile  5   
   -   5          Name$ tile_AddPlayer��5         Title$  ��60      
TiltFactor$ 2��69   $��0��6H   $��35��6X   $��35��6c   $��355,33,100,403q�6o   &   System.Windows.Media.TextOptions   TextHintingMode$ Animated=�6�   $��12(�6�   $��Microsoft Sans Serif)�6�      HorizontalTitleAlignment$ Center=�6�   ���	#FFC5D8FF.��5      �� $��35��6   $��34��6#   ��5      !� 5      	 !� Visual	 5      � 5      .+�5   "   �� �� 5   "   $��Add.png��6(   �� 5   "   $��Center=�63   $��Center=�6P   5      5      5      5      �� 5   
   -   5        
 ��Name$
 lbl_SearchPlayer��5      $��Search Player:��6*   $
��Left=�6C   $��
100,36,0,0q�6^   $	��Top=�6r    J� RenderTransformOrigin$ 0.711,0.423&�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$" datagrd_ParticipatingPlayers��5      $
��Left=�69   $��
25,120,0,0q�6T   $	��274��6h   $	��290��6u   $	��Top=�6�   $ 0.5,0.5&�6�      CanUserSortColumns .     
IsReadOnly . z�5      V� 5      .~�5      �� �� 5        �� AngleX$ -0.129Q�6$   �� 5!      T� 5"       T� X$ -0.406Q�6)   5#      5%      �� 5&   
   -   5         ��Name$ txtbx_PointsEarned��5&      $
��Left=�6.   $��23��6I   $��
115,87,0,0q�6U    �� TextWrapping$
 Wrap=�6i   $�� ��6}   $	��Top=�6�   $��50��6�   6�   �� 5'   
   -   5        $
 lbl_PointsEarned��5'      $��Points Earned:��6*   $
��Left=�6C   $��	20,87,0,0q�6^   $	��Top=�6q   $
��Bold"�6�   �� 5(   
   -   5         ��Name$ btn_AddHTCPoints��5(      $��
Add Points��6+   $
��Left=�6@   $��
170,87,0,0q�6[   $	��Top=�6o   $��75��6�   6�     5)   
   -   5        $ datagrd_PointsEarned��5)      $
��Left=�61   $��314,120,0,0q�6L   $	��Top=�6a   $��60��6y   $	��274��6�    .     CanUserResizeColumns .   . 6C    5*   
   -	   5        $ datagrd_History��5*      $��375,120,0,0q�6,   $	��Top=�6A   $	��274��6Y    .  .   .  $
��Left=�6   $��90��6;  �� 5+   
   -
   5        $ btn_ProclaimWinner��5+      $��Proclaim Winner��6-   $
��Left=�6G   $��195,407,0,0q�6b   $	��Top=�6w   $	��110��6�   6�     5,   
   -   5        $ 
tile_Atras��5,      $  ��6,   $ 2��65   $��0��6D   $��45��6T   $��45��6_   $��420,416,25,10q�6k   $ Animated=�6�   $��12(�6�   $��Microsoft Sans Serif)�6�   $ Center=�6�   ���	#FFC5D8FF.��5-      �� $��45��6   $��45��6#   ��5.      !� 5/      	 50      � 51      .+�52   "   �� �� 53   "   $��CloseSession.png��6(   �� 54   "   $��Center=�63   $��Center=�6P   55      57      59      5:        5;   
   -   5        $ 	tile_Undo��5;      $  ��6+   $ 2��64   $��0��6C   $��30��6S   $
��Auto��6^   $��20,10,440,431q�6l   $ Animated=�6�   $��12(�6�   $��Microsoft Sans Serif)�6�   $ Center=�6�   ���	#FFC5D8FF.��5<      �� $��26��6   $��26��6#   ��5=      !� 5>      	 5?      � 5@      .+�5A   "   �� �� 5B   "   $��Undo.png��6(   �� 5C   "   $��Center=�63   $��Center=�6P   5D      5F      5H      5I        5J   
   -   5        $ 	tile_Redo��5J      $  ��6+   $ 2��64   $��0��6C   $��30��6S   $
��Auto��6^   $��55,10,405,431q�6l   $ Animated=�6�   $��12(�6�   $��Microsoft Sans Serif)�6�   $ Center=�6�   ���	#FFC5D8FF.��5K      �� $��26��6   $��26��6#   ��5L      !� 5M      	 5N      � 5O      .+�5P   "   �� �� 5Q   "   $��Redo.png��6(   �� 5R   "   $��Center=�63   $��Center=�6P   5S      5U      5W      5X      5Z      5[      
   M S B A M L   `   `   `  ����F  BGSH Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PresentationPresentation  5   	        Presentation.AddEditPlayer   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Presentation     5   	   U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	     � Title$   ��5	   	   $��370.543��6   $��264.341��6#    � Icon$ GSH.ico��63   ���	#FFC5D8FF � 
ResizeMode$ CanMinimize=�6Y   .��5
      � .+�5   
   �� -   5         ��Name$ lbl_Name��5      $��Name: ��6"   $
��Left=�63   $��	30,40,0,0q�6N   $	��Top=�6a   �� 5   
   -   5         ��Name$ 
txtbx_Name��5      $��23��6&   $��	72,40,0,0q�62    �� TextWrapping$
 Wrap=�6E   $�� ��6Y   $	��Top=�6a   $
��Left=�6y   $	��154��6�   �� 5   
   -   5        $ lbl_Rank��5      $��Rank: ��6"   $
��Left=�63   $��	30,72,0,0q�6N   $	��Top=�6a   �� 5   
   -   5         ��Name$ combox_Rank��5      $
��Left=�6(   $��	72,72,0,0q�6C   $	��Top=�6V   $	��154��6n   �� 5   
   -   5        $ txtbx_ParticipationPoints��5      $
��Left=�65   $��23��6P   $��147,103,0,0q�6\   $
 Wrap=�6q   $��0��6�   $	��Top=�6�   $��79��6�   6�   �� 5   
   -   5        $ lbl_ParticipationPoints��5      $��Participation Points: ��61   $
��Left=�6R   $��
30,103,0,0q�6m   $	��Top=�6�   �� 5   
   -   5        $ lbl_HTCPoints��5      $��HTC Points: ��6'   $
��Left=�6>   $��
30,134,0,0q�6Y   $	��Top=�6m   �� 5   
   -   5        $ txtbx_HTCPoints��5      $
��Left=�6+   $��23��6F   $��147,134,0,0q�6R   $
 Wrap=�6g   $��0��6{   $	��Top=�6�   $��79��6�   6�   �� 5   
   -	   5         ��Name$ btn_AddEdit��5      $�� ��6&   $��91,303,90,0q�61   $	��Top=�6F   6^   �� 5   
   -
   5         ��Name$ grpbox_JoinDate��5      $��	Join Date��6,   $
��Left=�6?   $��
30,183,0,0q�6Z   $	��Top=�6n   $	��196��6�   $��75��6�   .��5      � $
��Left=�6   $	��186��6.   $��	0,0,-2,-1q�6:   .+�5      �� -   5        $ lbl_YY��5      $��YY��6(   $
��Left=�65   $��0,5,0,0q�6P   $	��Top=�6a   $��10(�6y   �� 5      -   5        $ txtbx_YY��5      $
��Left=�6,   $��12��6G   $��23,5,0,0q�6S   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $��45��6�   	 �� 	MaxLength$	 4��6�   6�   �� 5      -   5        $ lbl_MM��5      $��MM��6(   $
��Left=�65   $��68,5,0,0q�6P   $	��Top=�6b   $��10(�6z   �� 5      -   5        $ lbl_DD��5      $��DD��6(   $
��Left=�65   $��	126,5,0,0q�6P   $	��Top=�6c   $��10(�6{   �� 5      -   5        $ txtbx_MM��5      $
��Left=�6,   $��23��6G   $��96,5,0,0q�6S   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $��30��6�   $	 2��6�   6�   �� 5      -   5        $ txtbx_DD��5      $
��Left=�6,   $��23��6G   $��	150,5,0,0q�6S   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $��30��6�   $	 2��6�   6�   5      5      5      5       
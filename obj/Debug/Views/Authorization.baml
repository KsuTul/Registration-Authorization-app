   M S B A M L   `   `   `  ����>  :App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:App.Views	App.Views  5   	       App.Views.Authorization   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:App.Views     5   	     � Title$  Authorization��5   	   $	��450��6   $	��800��6,   
���   �.��5	      �  � RowDefinitions 5
   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� -   5         ��Name$ 
EmailLabel��5      $��Email��6$   $��20(�64   $��Center=�6B   $��Center=�6_   
������6�   �� 5   
   -   5        $ PasswordLabel��5      $��2��6'   $��Password��64   $��20(�6G   $��Center=�6U   $��Center=�6r   
������6�   �� 5   
   -   5         ��Name$ Email��5      $��1��6!   $	��300��6.   $��30��6:   $��Center=�6F   $��Center=�6c   $��Center=�6~   $��Center=�6�   ��6�   �� *Email+ �� UpdateSourceTrigger$ 	LostFocus=�6�   �� 5   
   -   5        $ Password��5      $��3��6$   $	��300��61   $��30��6=   $��Center=�6I   $��Center=�6f   $��Center=�6�   $��Center=�6�   ��6�   �� *
Password+$ 	LostFocus=�6  �� 5   
   -   5         ��Name$ ErrorMessage��5      $��5��6*   $��20(�69   
���  ����6X   �� *	Message+6s   �� 5   
   -   5         ��Name$ ReadBut��5   P   $��4��6   $��0��6@   $��Sighn in��6a   $	��100��6t   $��50��6�   
������$��20(�6�   ��6   �� *ReadCommand+6�   5      5      
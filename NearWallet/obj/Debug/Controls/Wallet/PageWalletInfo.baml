   M S B A M L   `   `   `  ����E  ANearWallet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:NearWallet.ControlsNearWallet.Controls  5      /    )NearWallet.Controls.Wallet.PageWalletInfo   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:NearWallet.Controls     5      .��5	      � 
�������.+�5
   
   ��   �� Orientation$  Vertical=�6   .+�5      �� -   5         ��Name$ lb_balansUsd��5      $��Center=�6*   $	��Top=�6G   $��48(�6_   $
��Bold"�6m   $��0,50,0,0q�6   .��6�   $06�   �� 5      $��Center=�6   $	��Top=�61   $��0,0,0,0q�6I      	labelInfo#��[  6Z   .��6}   Available Balance6�   �� 5      $  
Horizontal=�6   $��Center=�62   $��Center=�6O   $��0,50,0,0q�6j   .+�5      �� -   5         ��Name$ btSend��5      $��60��6*   $��60��65     
homeButton#��[ 6A   $��Center=�6f   $��Center=�5      $��0,0,50,0q�64   .��5      ��   sendIcon J� OpacityMask# [ 6    
�������$��20��6V   $��20��6a   5      �� 5      $��60��6   $��60��6$   #��[ 60   $��Center=�6U   $��Center=�6r   .��5      ��   receiveIcon# [ 6    
�������$��20��6Y   $��20��6d   5      5      � 5      -   5         �Name$ inputs��5      $��0,50,0,0q�6#   5      5      � 5   
   $��Bottom=�6   .+�5      �� $��Right=�6   $��
0,0,30,110q�60   #��[  6D   .��6g   Token Balance6v   �� 5      $��
30,0,0,110q�6   #��[  6(   $
��Left=�6K   .��6f   Your Portfolio6v   � 5      $	��100��6   $��Bottom=�6    .+�5      �� $��3��6   $��0q�6)   $	��Top=�64   ��5       �� 5!       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5"      �  � Color$ 	#FFB4B4B4��6+    � Offset$ 0Q�6=   � 5#      $ White��6+   $ 1Q�69   5$      5&      �� 5'      $��40��6   $��40��6(   $
��Left=�64   $��30,0,0,0q�6O   $��Center=�6a   ��5(      !� 5)        
logoCircle	 !� Visual#	 [ 6&   5+      �� 5,        labelBalansCoin#��[ 6   $��Center=�6A   $
��Left=�6\   $��	80,0,0,25q�6w   .��6�   NEAR6�   �� 5-      -   5        $ lb_Price��5-      #��[  6*   $��Center=�6M   $
��Left=�6h   $��	80,25,0,0q�6�   .��6�   $06�   �� 5.      -   5        $ lb_balasNear��5.      #��[ 6.   $��Right=�6W   $��Center=�6s   $��	0,0,30,25q�6�   .��6�   0 NEAR6�   �� 5/      -   5        $ lb_smallBalansUsd��5/      #��[  63   $��Center=�6V   $��Right=�6q   $��	0,25,30,0q�6�   .��6�   
≈ $0 USD6�   50      51      52      53      
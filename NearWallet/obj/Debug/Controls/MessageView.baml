   M S B A M L   `   `   `  ����E  ANearWallet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:NearWallet.ControlsNearWallet.Controls  5      %    NearWallet.Controls.MessageView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:NearWallet.Controls     5      $	��380��5      $��70��5	      $��	0,0,15,15q�5
        J� Opacity$  1Q�5      $��Right=�5      $��Bottom=�5       � Triggers 5      :� 5   
    :� RoutedEvent$ UserControl.Loaded��6   [�5      �� 5      .��5      �� .��5      U�  �� TargetProperty$ Opacity�68   .\�5      ��  O� KeyTime$ 0:0:1��63    O� Value$ 1Q�6C   5      5      5      5      .��5      � 
������� J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6      
BlurRadius$ 10Q�6,   	   ShadowDepth$	 15Q�6<   .+�5!   
   �� $��1q�6   
�������._�5"      � .+�5#      �� -   5           buttonClose#��[  5$      5&      �� 5'      -   5        
 ��Name$
 	tb_header��5'        
labelColor#��[ 6/   $
��Bold"�6X   $��10,0,0,0q�6j   $��14(�6|   $
��Left=�6�   $	��Top=�6�   Заголовок6�   �� 5(      -   5        $
 tb_text��5(      $
��Wrap=�6.   $��14(�6B   $��10,25,10,10q�6P   ��Тут будут размещаться разные сообщения например сообщения об ошибаках или еще какие то уведомления.6�   5)      5*      5+      5,      
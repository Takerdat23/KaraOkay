   M S B A M L   `   `   `  ����G  CWpf_Karaokay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Wpf_KaraokayWpf_Karaokay  5   	       Wpf_Karaokay.RoomsWindows   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &localclr-namespace:Wpf_Karaokay  5   	     � Title$  RoomsWindows��5	   	    � WindowState$ 	Maximized=�6   $
��1080��66   $
��1920��6D      RoomsVM � DataContext# �   5
   	    � 	Resources 5       �� 
TargetType �� Triggers �� Binding �� Value �� Property	 �� Value��%  '��       �� 5   
   " ��6    5      �� 5       6   �� *
RMStatus+ 16;   .a�5      ��  � ��
	 � � �63   5      �� 5       6   �� *
RMStatus+ 06;   .a�5      ��  � ��
	 �����63   5      5      5      .��5      � $��	0,10,10,0q�6   
 � RowDefinitions
 5   
   �� 5      $	��26* �6   �� 5      $
��107* �6   .+�5   
   �� $��1��6   $��Disabled=�6$   $
��Auto=�6M   .��5      �� ��6   �� *Rooms+��5      �� 5       .R�5!      A�  A� Columns$ 3��6&   5"      ��5$      �� 5%      .R�5&      �� $	��132��6!   $	��132��6-   $��Gill Sans MT)�5'      $��25(�63   ��5&   :   �� *RmId+��5(      �� *DataContext.RoomButtonCommand+ �� RelativeSource ��  �� AncestorType" ���5)      �� 5*      5,      5-      �� 5.   
   $��Center=�6   $��0,81,0,0q�61   $
��Wrap=�6C   $	��Top=�6W   $��66��6o   $	��205��6{   $��Gill Sans MT)�6�   $��60(�6�   $��Black"�6�   �� 6�   $�Rooms��6�   �� 6�   �� 6�   6�   �� 50   
   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 30��6   
���   �$��2q�6S   ���	#FF2E228B
������� # MaterialDesignRaisedLightButton#��[ 54      $��Gill Sans MT)�55      $��12(�6(   $��	122,0,0,0q�66   $��71��6I   $��Center=�6U   $
��Left=�6p   $	��224��6�   y�51      �� *ButtonVisibility+��53      �� *DataContext.BackButtonCommand+ �� " �.��56      �� $	��Top=�6   $
��Back��60   $
��Left=�6=   $��Gill Sans MT)�6X   $��35(�6r   $��44��6�   $��91��6�    J� RenderTransformOrigin$ 0.618,0.644&�6�   6�   57      59      5:      
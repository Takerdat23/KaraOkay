   M S B A M L   `   `   `  ����G  CWpf_Karaokay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Wpf_KaraokayWpf_Karaokay  5   	       Wpf_Karaokay.EditRoom   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &localclr-namespace:Wpf_Karaokay  5   	   -   5        $��editRoom��5   	     � Title$  EditRoom��5	   	   $	��800��6   $	��500��6&   ���#FFF6F7 � WindowStartupLocation$ CenterScreen=�5   	      
EditRoomVM � DataContext# �   5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��104* �6   �� 5      $
��213* �6   �� 5      $	��83* �6   .+�5   
   �� $��	EDIT ROOM��6   
���   �$��24(�67   $��Black"�6E   $
��Left=�6X   $��113,33,0,347q�6s   $��1��6�   �� 5   
   -   5         ��Name$ 	insertBtn��5      
���   �$��2q�68   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 20��6L   $��INSERT��6z   ���#47a992
���   �$
��Left=�6�   $��
94,364,0,0q�6�   $	��Top=�6�   $��39��6�   $��96��6  $
��Bold"�6  $��15(�6$  ��62  �� *InsertCommand+�� 5   
   -   5        $ 	updateBtn��5      
���   �$��2q�68   $ 20��6L   $��UPDATE��6z   ���#FEBD25
���   �$
��Left=�6�   $��
54,364,0,0q�6�   $	��Top=�6�   $��39��6�   $��96��6  $
��Bold"�6  $��15(�6#  $��1��6S  ��61  �� *UpdateCommand+6S  �� 5   
   -   5        $ 	deleteBtn��5      
���   �$��2q�68   $ 20��6L   $��DELETE��6z   ���#FC4F41
���   �$
��Left=�6�   $��226,364,0,0q�6�   $	��Top=�6�   $��39��6�   $��96��6  $
��Bold"�6  $��15(�6$  $��1��6T  ��62  �� *DeleteCommand+6T  �� 5   
   -   5        $ clearBtn��5      
���   �$��2q�67   $ 20��6K   $��CLEAR��6y   
���   �$
��Left=�6�   $��386,364,0,0q�6�   $	��Top=�6�   $��39��6�   $��98��6�   $
��Bold"�6�   $��15(�6   J� RenderTransformOrigin$ 0.526,-0.625&�62  $��1��6W  $��2��6g  &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGrid��5      
�������   SelectionMode$ Extended=�6T   
���   �$��2q�6�      AutoGenerateColumns .  $��152,102,38,143q�6�   $��1��6�   $��2��6�   ��6#   �� *Rooms+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Room ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *RmId+  5      $
 	Room Type��6%    68   �� *RmType+  5      $
 Room Status��6%    6:   �� *
RMStatus+  5      $
 Price Per Hour��6%    6=   �� *PricePerHour+5"      �� 5#   
   -   5         ��Name$ 	txtRoomID��5#      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$  Enter Room ID��6%   
�������
���   �$��2q�6|   $
��Left=�6�   $��154,111,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��176��6  $��2��6  ��6�   �� *RoomID+6  �� 5$   
   -   5        $ txtRoomType��5$      $  Enter Room Type��6'   
�������
���   �$��2q�6�   $
��Left=�6�   $��154,167,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��176��6
  $��2��6  ��6�   �� *
RoomType+6  �� 5%   
   -	   5        $ txtRoomStatus��5%      $  Enter Room Status��6)   
�������
���   �$��2q�6�   $
��Left=�6�   $��154,221,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��176��6  $��2��6  ��6�   �� *
RoomStatus+6  �� 5&   
   -
   5        $ txtPricePerHour��5&      $  Enter Price Per Hour��6+   
�������
���   �$��2q�6�   $
��Left=�6�   $��154,282,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��176��6  $��2��6#  ��6�   �� *PricePerHour+6#  �� 5'   
   $��Room ID��6   
���   �$
��Bold"�65   $��13(�6G   $
��Left=�6V   $��
44,111,0,0q�6q   $	��Top=�6�   $ 0.528,0.119&�6�   �� 5(   
   $��	Room Type��6   
���   �$
��Bold"�67   $��13(�6I   $
��Left=�6W   $��
44,167,0,0q�6r   $	��Top=�6�   �� 5)   
   $��Room Status��6   
���   �$
��Bold"�69   $��13(�6K   $
��Left=�6Y   $��
44,221,0,0q�6t   $	��Top=�6�   �� 5*   
   $��Price Per Hour��6   
���   �$
��Bold"�6<   $��13(�6N   $
��Left=�6\   $��
44,283,0,0q�6w   $	��Top=�6�   �� 5+   
   $
��BACK��6   $��14(�6    $
��Bold"�6.   
���   �
���   �$��2q�6g   ���#FC4F41$ 20��5,      $��
26,33,87,0q�6?   $	��Top=�6S   $��41��6k   ��6w   �� *DataContext.BackCommand+ �� RelativeSource ��  �� AncestorType" ���5-      �� 53      54      
   M S B A M L   `   `   `  ����G  CWpf_Karaokay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Wpf_KaraokayWpf_Karaokay  5   	       Wpf_Karaokay.EditMenu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &localclr-namespace:Wpf_Karaokay  5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ EditMenu��5
   	   $	��800��6   $	��500��6&   ���#FFF6F7   
EditMenuVM � DataContext# [  5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��104* �6   �� 5      $
��213* �6   �� 5      $	��83* �6   .+�5   
   �� $��	EDIT MENU��6   
���   �$��24(�67   $��Black"�6E   $
��Left=�6X   $��113,33,0,397q�6s   $��1��6�   �� 5   
   -   5         ��Name$ 	insertBtn��5      
���   �$��2q�6Z   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 20��6n   $��INSERT��6�   ���#47a992
���   �$
��Left=�6�   $��
94,364,0,0q�6�   $	��Top=�6  $��39��6  $��96��6)  $
��Bold"�64  $��15(�6F  ��6$   �� *InsertCommand+6F  �� 5   
   -   5        $ 	updateBtn��5      
���   �$��2q�6Z   $ 20��6n   $��UPDATE��6�   ���#FEBD25
���   �$
��Left=�6�   $��
54,364,0,0q�6�   $	��Top=�6  $��39��6  $��96��6(  $
��Bold"�63  $��15(�6E  $��1��6S  ��6$   �� *UpdateCommand+6S  �� 5   
   -   5        $ 	deleteBtn��5      
���   �$��2q�6Z   $ 20��6n   $��DELETE��6�   ���#FC4F41
���   �$
��Left=�6�   $��226,364,0,0q�6�   $	��Top=�6  $��39��6  $��96��6)  $
��Bold"�64  $��15(�6F  $��1��6T  ��6$   �� *DeleteCommand+6T  �� 5   
   -   5        $ clearBtn��5      
���   �$��2q�67   $ 20��6K   $��CLEAR��6y   
���   �$
��Left=�6�   $��386,364,0,0q�6�   $	��Top=�6�   $��39��6�   $��98��6�   $
��Bold"�6�   $��15(�6   J� RenderTransformOrigin$ 0.526,-0.625&�62  $��1��6W  $��2��6g  &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGrid��5      
�������   SelectionMode$ Extended=�6T   
���   �$��2q�6�      AutoGenerateColumns .  $��86,105,27,140q�6�   $��1��6�   $��2��6�   ��6#   �� *Items+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Item ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *itemID+  5      $
 	Item Name��6%    68   �� *
itemName+  5      $
 	Item Type��6%    68   �� *
itemType+  5      $
 
Item Price��6%    69   �� *	itemPrice+5!      �� 5"   
   -   5         ��Name$ 	txtItemID��5"      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$  Enter Item ID��6%   
�������
���   �$��2q�6|   $
��Left=�6�   $��
94,117,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��176��6  $��2��6  ��6�   �� *ItemID+6  �� 5#   
   -   5        $ txtItemName��5#      $  Enter Item Name��6'   
�������
���   �$��2q�6�   $
��Left=�6�   $��
94,173,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��176��6	  $��2��6  ��6�   �� *
ItemName+6  �� 5$   
   -   5        $ txtItemType��5$      $  Enter Item Type��6'   
�������
���   �$��2q�6�   $
��Left=�6�   $��
94,227,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��176��6	  $��2��6  ��6�   �� *
ItemType+6  �� 5%   
   -	   5        $ txtItemPrice��5%      $  Enter Item Price��6(   
�������
���   �$��2q�6�   $
��Left=�6�   $��
94,288,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��176��6  $��2��6  ��6�   �� *	ItemPrice+6  �� 5&   
   $��Item ID��6   
���   �$
��Bold"�65   $��13(�6G   $
��Left=�6V   $��
17,117,0,0q�6q   $	��Top=�6�   $ 0.528,0.119&�6�   �� 5'   
   $��	Item Name��6   
���   �$
��Bold"�67   $��13(�6I   $
��Left=�6W   $��
17,173,0,0q�6r   $	��Top=�6�   �� 5(   
   $��	Item Type��6   
���   �$
��Bold"�67   $��13(�6I   $
��Left=�6W   $��
17,227,0,0q�6r   $	��Top=�6�   �� 5)   
   $��
Item Price��6   
���   �$
��Bold"�68   $��13(�6J   $
��Left=�6X   $��
17,289,0,0q�6s   $	��Top=�6�   �� 5*   
   $
��BACK��6   $��14(�6    $
��Bold"�6.   
���   �
���   �$��2q�6g   ���#FC4F41$ 20��5+      $��
17,22,96,0q�6?   $	��Top=�6S   $��38��6k   ��6w   �� *DataContext.BackCommand+ �� RelativeSource ��  �� AncestorType" ���5,      �� 5-      5.      
   M S B A M L   `   `   `  ����G  CWpf_Karaokay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Wpf_KaraokayWpf_Karaokay  5          Wpf_Karaokay.CashierPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      &localclr-namespace:Wpf_Karaokay  5        N� 
Background  �#FFF6F7 N� Title$ CashierPage��5         	CashierVM � DataContext# �   5      .��5      � ���	#FFF3EEEE � RowDefinitions 5   
   �� 5      $	��41* �6   �� 5      $
��157* �6   �� 5      $	��27* �6    � ColumnDefinitions 5   
   �� 5      $��7* �6   �� 5      $��3* �6   .+�5   
   �� -   5        +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 30��5      
���   �$��2q�6S    # MaterialDesignRaisedLightButton#��[ 5      ���	#FFFEBD25$��2��5   9   $��Gill Sans MT)�6F   $��12(�6`   $��144,0,145,0q�6n   $��70��6�   $��Center=�6�   $��1��6�   ��5      �� *DataContext.StopTimmerCommand+ �� RelativeSource ��  �� AncestorType" N���5      �� .��5       �� $��Center=�6   
���   �$��Center=�6H   $��Gill Sans MT)�6c   $��35(�6}   $��42��6�   $	��109��6�   �� 6�   $�Receipt��6�   �� 6�   �� 6�   $� ��6�   6�   5!      �� 5"   
    �� TextAlignment$ Center=�62   $��1��6I   $
��Wrap=�6Y   $��Gill Sans MT)�6m   $��15(�6�   $��10,196,10,11q�6�   $��2��6�   ��6   �� *receiptText+6�   �� 5#   
   $��image 2 copy.png��6   $��1��6*   $��	97,7,0,10q�6:   $
��Left=�6M   $	��416��6h   �� 5$   
   -   5        $ 30��5$      
���   �$��2q�6S   #��[ 5(      ���#47a992
���   �$��2��5)   J   $��Gill Sans MT)�6W   $��12(�6q   $��	743,0,0,0q�6   $��71��6�   $��Center=�6�   $
��Left=�6�   $	��246��6�   ��5&      �� *DataContext.TimerCommand+ �� " N���5'      �� .��5*      �� $��Center=�6   $
��Left=�63   $��Gill Sans MT)�6N   $��35(�6h   $��44��6v   $	��140��6�   	 J� RenderTransformOrigin$	 0.618,0.644&�6�   �� 6�   $�Start timer ��6�   �� 6�   �� 6�   �� 6�   �� 6�   $� ��6�   6�   5+      �� 50   
   $ 30��6   
���   �$��2q�6S   $
��Back��51      $��30(�6   $��	183,0,0,0q�6*   $	��246��6=   $��70��6I   
���   ����#FC4F41$��2��53   ^   $
��Left=�6k   $��Center=�6�   ��52      �� *DataContext.BackCommand+ �� " N���53      �� 6�   �� 54   
   $��	0,10,10,0q�6   $��2��6(   .@�55      �� $
��Food��6   $��99��6$   .��56      � ���	#FFE5E5E5.+�57      &   System.Windows.Controls.DataGrid  
   AutoGenerateColumns
 .  ��6   �� *	FoodItems+   Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *
itemName+  5:      $
 type��61    6?   �� *
itemType+  5;      $ Price��61    6@   �� *	itemPrice+4  .System.Windows.Controls.DataGridTemplateColumn  5<      $ Quantity��65      CellTemplate 5=   "   �� 5>   &   .R�5?   *   ��  �� Orientation$ 
Horizontal=�65   .+�5A   .   �  5B   2   �� 5C   6   $��* �6G   �� 5D   6   $
��Auto �6G   �� 5E   6   $
��Auto �6G   .+�5H   2   �� $��1��69   $��+��6I   ��6U   �� *%#DataContext.IncreaseQuantityCommand+ �� " N���5I      �� �� 5J   2   $��2��69   $��-��6I   ��6U   �� *%#DataContext.DecreaseQuantityCommand+ �� " N���5K      �� 5L   /   5M   +   5N   '   5P      5T      5U      5V      �� 5W      $��Beverage��6   $��91��6(   .��5X      � ���	#FFE5E5E5.+�5Y        
 .  ��6   �� *BeverageItems+ 5Z        5[      $
 Name��61    6?   �� *
itemName+  5\      $
 type��61    6?   �� *
itemType+  5]      $ Price��61    6@   �� *	itemPrice+  5^      $ Quantity��65    5_   "   �� 5`   &   .R�5a   *   �� $ 
Horizontal=�65   .+�5c   .   �  5d   2   �� 5e   6   $��* �6G   �� 5f   6   $
��Auto �6G   �� 5g   6   $
��Auto �6G   .+�5j   2   �� $��1��69   $��+��6I   ��6U   �� *%#DataContext.IncreaseQuantityCommand+ �� " N���5k      �� �� 5l   2   $��2��69   $��-��6I   ��6U   �� *%#DataContext.DecreaseQuantityCommand+ �� " N���5m      �� 5n   /   5o   +   5p   '   5r      5v      5w      5z      �� 5{      $��Others��6   $	��180��6&   .��5|      � ���	#FFE5E5E5.+�5}        
 .  ��6   �� *OthersItems+ 5~        5      $
 Name��61    6?   �� *
itemName+  5�      $
 type��61    6?   �� *
itemType+  5�      $ Price��61    6@   �� *	itemPrice+  5�      $ Quantity��65    5�   "   �� 5�   &   .R�5�   *   �� $ 
Horizontal=�65   .+�5�   .   �  5�   2   �� 5�   6   $��* �6G   �� 5�   6   $
��Auto �6G   �� 5�   6   $
��Auto �6G   .+�5�   2   �� $��1��69   $��+��6I   ��6U   �� *%#DataContext.IncreaseQuantityCommand+ �� " N���5�      �� �� 5�   2   $��2��69   $��-��6I   ��6U   �� *%#DataContext.DecreaseQuantityCommand+ �� " N���5�      �� 5�   /   5�   +   5�   '   5�      5�      5�      5�      5�      �� 5�   
   $��1��6   $��
80,10,80,0q�6$   $��1��68   $
��Wrap=�6E   $	��Top=�6}   $��62��6�   $��25(�6�   $ Center=�6�   $��Gill Sans MT)�6�   ��6Y   �� *ElapsedTimeForRoom+6�   5�      5�      
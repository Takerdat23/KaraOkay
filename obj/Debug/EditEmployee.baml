   M S B A M L   `   `   `  ����G  CWpf_Karaokay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Wpf_KaraokayWpf_Karaokay  5   	       Wpf_Karaokay.EditEmployee   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &localclr-namespace:Wpf_Karaokay  5   	   -   5        $��editEmployee��5   	   ���#FFF6F7  � WindowStartupLocation$  CenterScreen=�5
   	    � Title$ EditEmployee��5   	   $	��500��6   $	��800��6+      EditEmployeeVM � DataContext# [  5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��104* �6   �� 5      $
��213* �6   �� 5      $	��83* �6   .+�5   
   �� $��EDIT EMPLOYEE��6   
���   �$��24(�6;   $��Black"�6I   $
��Left=�6\   $��94,10,0,418q�6w   $��1��6�   �� 5   
   -   5         ��Name$ 	insertBtn��5      
���   �$��2q�6Z   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 20��6n   $��INSERT��6�   ���#47a992
���   �$
��Left=�6�   $��
98,398,0,0q�6�   $	��Top=�6  $��39��6  $��96��6)  $
��Bold"�64  $��15(�6F  ��6$   �� *InsertCommand+6F  �� 5   
   -   5        $ 	updateBtn��5      
���   �$��2q�6Z   $ 20��6n   $��UPDATE��6�   ���#FEBD25
���   �$
��Left=�6�   $��
58,398,0,0q�6�   $	��Top=�6  $��39��6  $��96��6(  $
��Bold"�63  $��15(�6E  $��1��6S  ��6$   �� *UpdateCommand+6S  �� 5   
   -   5        $ 	deleteBtn��5      
���   �$��2q�6Z   $ 20��6n   $��DELETE��6�   ���#FC4F41
���   �$
��Left=�6�   $��230,398,0,0q�6�   $	��Top=�6  $��39��6  $��96��6)  $
��Bold"�64  $��15(�6F  $��1��6T  ��6$   �� *DeleteCommand+6T  �� 5   
   -   5        $ clearBtn��5      
���   �$��2q�67   $ 20��6K   $��CLEAR��6y   
���   �$
��Left=�6�   $��390,398,0,0q�6�   $	��Top=�6�   $��39��6�   $��98��6�   $
��Bold"�6�   $��15(�6   J� RenderTransformOrigin$ 0.526,-0.625&�62  $��1��6W  $��2��6g  &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGrid��5      
�������   SelectionMode$ Extended=�6X   
���   �$��2q�6�      AutoGenerateColumns .  $��125,71,26,107q�6�   $��1��6�   $��2��6�   ��6#   �� *	Employees+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Employee ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *EmpId+  5      $

 Name��6%    63   �� *	EmpName+  5      $
 
Citizen ID��6%    69   �� *CCCD+  5      $
 Phone Number��6%    6;   �� *
EmpPhone+  5       $
 Date of Birth��6%    6<   �� *	BirthDate+  5!      $
 Place of Origin��6%    6>   �� *PlaceOfOrigin+5$      �� 5%   
   -   5         ��Name$ txtEmpID��5%      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$  Enter Employee ID��6$   
�������
���   �$��2q�6   $
��Left=�6�   $��
127,81,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��185��6  $��2��6  ��6�   �� *EmpID+6  �� 5&   
   -   5        $ 
txtEmpName��5&      $  Enter Name��6&   
�������
���   �$��2q�6z   $
��Left=�6�   $��127,121,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��185��6  $��2��6  ��6�   �� *	EmpName+6  �� 5'   
   -	   5        $ txtCitizenID��5'      $  Enter Citizen ID��6(   
�������
���   �$��2q�6�   $
��Left=�6�   $��127,161,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��185��6  $��2��6  ��6�   �� *	CitizenID+6  �� 5(   
   -
   5        $ txtEmpPhone��5(      $  Enter Phone Number��6'   
�������
���   �$��2q�6�   $
��Left=�6�   $��127,201,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��185��6  $��2��6  ��6�   �� *
EmpPhone+6  �� 5)   
   -   5        $ txtBirthDate��5)      $  Enter Birthdate��6(   
�������
���   �$��2q�6�   $
��Left=�6�   $��127,241,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��185��6  $��2��6  ��6�   �� *	BirthDate+6  �� 5*   
   -   5        $ txtPlaceOfOrigin��5*      $  Enter Place of Origin��6,   
�������
���   �$��2q�6�   $
��Left=�6�   $��127,281,0,0q�6�   $
 Wrap=�6�   $	��Top=�6  $	��185��6  $��2��6&  ��6�   �� *PlaceOfOrigin+6&  �� 5+   
   -   5        $ txtPassword��5+      $  Enter Password��6'   
�������
���   �$��2q�6   $
��Left=�6�   $��127,321,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��185��6	  $��2��6  ��6�   �� *
Password+6  �� 50   
   $��Employee ID��6   
���   �$
��Bold"�69   $��13(�6K   $
��Left=�6Z   $��	23,82,0,0q�6u   $	��Top=�6�   $ 0.528,0.119&�6�   �� 51   
   $
��Name��6   
���   �$
��Bold"�62   $��13(�6D   $
��Left=�6R   $��
23,122,0,0q�6m   $	��Top=�6�   $ 0.686,0.141&�6�   �� 52   
   $��
Citizen ID��6   
���   �$
��Bold"�68   $��13(�6J   $
��Left=�6X   $��
23,162,0,0q�6s   $	��Top=�6�   �� 53   
   $��Phone Number��6   
���   �$
��Bold"�6:   $��13(�6L   $
��Left=�6Z   $��
23,202,0,0q�6u   $	��Top=�6�   �� 54   
   $��Date of Birth��6   
���   �$
��Bold"�6;   $��13(�6M   $
��Left=�6[   $��
23,242,0,0q�6v   $	��Top=�6�   �� 55   
   $��Place of Origin��6   
���   �$
��Bold"�6=   $��13(�6O   $
��Left=�6]   $��
23,282,0,0q�6x   $	��Top=�6�   �� 56   
   $��Password��6   
���   �$
��Bold"�66   $��13(�6H   $
��Left=�6V   $��
23,322,0,0q�6q   $	��Top=�6�   �� 5;   
   $
��BACK��6   $��14(�6    $
��Bold"�6.   
���   �
���   �$��2q�6g   ���#FC4F41$ 20��5<      $��
26,13,87,0q�6?   $	��Top=�6S   $��43��6k   ��6w   �� *DataContext.BackCommand+ �� RelativeSource ��  �� AncestorType" ���5=      �� 5@      5A      
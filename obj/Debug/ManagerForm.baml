   M S B A M L   `   `   `  ����G  CWpf_Karaokay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Wpf_KaraokayWpf_Karaokay  5   	       Wpf_Karaokay.ManagerForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &localclr-namespace:Wpf_Karaokay  5   	   -   5        $��managerForm��5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ ManagerForm��5
   	   $	��500��6   $	��800��6*   ���#FFF6F7   
ManagerFVM � DataContext# �   5   	   .��5      �  � RowDefinitions 5   
   �� 5      $	��200 �6   $	��159��6)   �� 5      .+�5   
   �� $��ADMINextraline.png��6   $��357,10,109,273q�6,   $��2��6D   �� 5   
   $��35,59,617,0q�5   6   $	��132��6K   $	��Top=�6Y   ���	#FFFC4F41
���   �$��2q�6�   $��1��6�   ��5      �� *DataContext.CashierCmd+ �� RelativeSource ��  �� AncestorType" ���5      �� .��5      �� $��	Frame.png��6   $��80��6'   $��83��62   5      �� 5   
   
���   �$��2q�6%   $��419,59,232,0q�5!      $��1��6#   $	��132��60   $	��Top=�6=   ���#F5E9DB��5      �� *DataContext.RoomCmd+ �� " ���5      �� {�5       �� *DataContext.RoomCmd+ �� *FindAncestor+" �.��5"      �� $��Room.png��6   $��83��6&   $��80��62   5#      �� 5%   
   
���   �$��2q�6%   $��619,59,30,0q�5*      $	��132��6"   $	��Top=�6/   ���#243257$��1��6\   ��5&      �� *DataContext.MenuCmd+ �� " ���5'      �� {�5)      �� *DataContext.MenuCmd+ �� *FindAncestor+" �.��5+      �� $��Menu.png��6   $��72��6&   $	��106��62   5,      �� 5.   
   
���   �$��2q�6%   $��232,59,420,0q�53      $	��132��6#   $	��Top=�60   ���#243257$��1��6]   ��5/      �� *DataContext.EmployCmd+ �� " ���50      �� {�52      �� *DataContext.EmployCmd+ �� *FindAncestor+" �.��54      �� $��Employee.png��6   $��93��6*   $��66��65   55      �� 58   
   
���   �$��2q�6%   $��131,44,517,0q�5=      ���#F5E9DB J� RenderTransformOrigin$ 0.561,0.567&�68   $	��133��6\   $	��Top=�6i   ��59      �� *DataContext.ReportCmd+ �� " ���5:      �� {�5<      �� *DataContext.RoomCmd+ �� *FindAncestor+" �.��5>      �� $��
Report.png��6   $��80��6(   5?      �� 5A   
   $��Cashier��6   $
��Bold"�6"   $��20(�64   $
��Left=�6B   $��
69,191,0,0q�6]   $	��Top=�6q   $��1��6�   �� 5B   
   $��Rooms��6   $
��Bold"�6    $��20(�62   $
��Left=�6@   $��455,191,0,0q�6[   $��1��6p   $	��Top=�6}   �� 5C   
   $
��Menu��6   $
��Bold"�6   $��20(�61   $
��Left=�6?   $��660,191,0,0q�6Z   $	��Top=�6o   $��1��6�   �� 5D   
   $��	Employees��6   $
��Bold"�6$   $��20(�66   $
��Left=�6D   $��245,191,0,0q�6_   $��1��6t   $	��Top=�6�   �� 5E   
   $��Report��6   $
��Bold"�6!   $��20(�63   $
��Left=�6A   $��168,174,0,0q�6\   $	��Top=�6q   $��2��6�   �� 5G   
   $��LOG OUT��6   $��14(�6#   $
��Bold"�61   
���   �
���   �$��2q�6j   ���#FC4F41+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 20��5H      $��643,20,40,0q�6?   $	��Top=�6T   $��37��6l   ��6x   �� *LogOutCommand+5I      5K      
   M S B A M L   `   `   `  ����G  CWpf_Karaokay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WPF_KaraokayWPF_Karaokay  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	       WPF_Karaokay.ReportWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &localclr-namespace:WPF_Karaokay  5   	   >Wpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5   	     � Title$  ReportWindow��5
   	   $	��600��6   $	��950��6+   ���#FFF6F7   MaterialDesignBody#���   5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	     ReportVM � DataContext# �  5   	   .��5      �  � RowDefinitions 5   
   �� 5      $	��31* �6   �� 5      $	��42* �6   .+�5   
   �� $��Report Revenue��6   
���   �$��30(�6<   $
��Bold"�6J   $��Center=�6\   $��0,63,0,0q�6y   $	��Top=�6�   $��44��6�   $	��222��6�   �� 5   
   $��	From date��6   $��20(�6$   
���   �$
��Bold"�6E   $
��Left=�6W   $��
47,114,0,0q�6r   $	��Top=�6�   $��32��6�   $��99��6�   �� 5   
   $��To date��6   $��20(�6"   
���   �$
��Bold"�6C   $
��Left=�6U   $��
47,160,0,0q�6p   $	��Top=�6�   $��32��6�   $��74��6�   �� 5   
   ���#47a992 ! MaterialDesignFlatMidBgButton#��[ 6&   
���   �$��2q�6q   
���   �.  (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp0=�5       +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 20��5!      $��20(�6G   $��View Report��6U   $��740,130,49,0q�6k   $��46��6�   $	��Top=�6�   ��5"      �� *DataContext.ReportCmd+ �� RelativeSource ��  �� AncestorType" ���5#      �� (  "System.Windows.Controls.DatePicker  5$   
   $��20(�6   $��0,110,276,64q�6&   $��Stretch=�6_   $��Right=�6{   $	��498��6�   	   SelectedDate	 6<   �� *	StartDate+6�     5%   
   $��20(�6   $��0,160,276,22q�6%   $��Stretch=�6\   $��Right=�6x   $	��498��6�   	 6;   �� *	EndDate+6�   #  MaterialDesignThemes.Wpf.Card  5&   
   $
��Card��6   $
��Left=�6-   $��944,-176,0,0q�6H   $	��Top=�6^   $��14��6v   $��6��6�   #  LiveCharts.Wpf.CartesianChart  5(   
   $��0,10,0,0q�6A   $��Center=�6S   $	��890��6p   $��1��6|   &   LiveCharts.Wpf.Charts.Base.Chart
   Series
 6   �� *SeriesCollection+   AxisX 5*        LiveCharts.Wpf.Axis     Title$ 
Bill Dates��6      	FontStyle$ Oblique$�6.      Labels 6B   �� *
BillLabels+5-      �� 5/   
   $
��Back��6   $��0,0,806,184q�6    $ 15��65   
���   �$��2q�6w   
���   �$��16(�6�   $��Right=�51   6   $	��120��6R   $��42��6^   $��Bottom=�6j   ��50      �� *DataContext.BackCmd+ �� " ���51      �� 6j   58      5:      
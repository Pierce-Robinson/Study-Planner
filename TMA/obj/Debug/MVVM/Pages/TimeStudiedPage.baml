   M S B A M L   `   `   `  ����>  :TMA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TMA.MVVM.PagesTMA.MVVM.Pages  5      $    TMA.MVVM.Pages.TimeStudiedPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:TMA.MVVM.Pages     5        N� Title$  TimeStudiedPage��5	      .��5      �  � RowDefinitions 5   
   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��1��6   $��Center=�6%   .+�5      �� $��Module Code��6   
�������$��14(�5      $��0,15,0,0q�5      $��	helvetica)�5      $��Medium"�5      �� 5      -   5         ��Name$ 	cbModCode��5       �� SelectedIndex$ 0��5      ���#102F3F5       �� 5"      $��Hours of Self Study��6   
�������$��14(�5$      $��0,15,0,0q�5%      $��	helvetica)�5&      $��Medium"�5'      �� 5(      -   5         ��Name$ txtStudiedHours��5(      $��	Helvetica)�5)      $��Light"�5*      
�������$��20(�5,      
������ $
��left=�5.       J� Opacity$	 0.7Q�5/      $��25��50       �� 
CaretBrush
 �����$��0,0,0,3q�52      
�������53      �� 55      $��Date Studied On��6   
�������$��14(�57      $��0,15,0,0q�58      $��	helvetica)�59      $��Medium"�5:      (  "System.Windows.Controls.DatePicker  5;      -   5          Name$ dpStudydate��5;      
������ 
�������
�������5>      �� 5@      -   5        	 ��Name$	 	btnSaveTS��5@      $
��Save��5A      $	��100��5B      $��40��5C      $��0,30,0,0q�5D         LoginButtons#��[  5E      6;   5G      5J      5K      
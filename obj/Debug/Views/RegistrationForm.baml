   M S B A M L   `   `   `  ����M  IPsychTestsMilitary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:PsychTestsMilitary.ViewModelsPsychTestsMilitary.ViewModels  5   	   I)clr-namespace:PsychTestsMilitary.ServicesPsychTestsMilitary.Services  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	   	   4    .PsychTestsMilitary.ViewModels.RegistrationForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:PsychTestsMilitary.ViewModels     5   	   >services)clr-namespace:PsychTestsMilitary.Services     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   0sys&clr-namespace:System;assembly=mscorlib  5	   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Реєстрація��5   	   $	��600��6   $	��800��6)    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Styles/CustomStyles.xaml?�6%   %    5      .��5      �    CustomGridBackgroundStyle#��[  6   .+�5   
   ��   CustomBorderStyle#��[ 6   ._�5      �� .+�5      �  � ColumnDefinitions 5      �� 5      $��* �6+   �� 5      $��* �6+    � RowDefinitions 5      �� 5      $��* �6(   �� 5      $��* �6(   �� 5      $��* �6(   �� 5       $��* �6(   �� 5!      $��* �6(   �� 5"      $��* �6(   �� 5#      $��* �6(   .+�5&      �� $��Реєстрація��6   $��Center=�61   $��30(�6U   $
��Bold"�6c   $��0 0 0 15q�6u   $��0��6�   $��0��6�   $��2��6�   �� 5'      -   5        $��surname��5'      $��1��6-   $��0��6:   $��20(�6J   
�������$��
0 10 10 10q�6k   
 � Tag$% Введіть прізвище��6�   �� 5(      -   5        $
��name��5(      $��1��6*   $��1��67   $��20(�6G   
�������$��
10 10 0 10q�6h   $ Введіть ім'я��6�   �� 5)      -   5        $��fname��5)      $��2��6+   $��0��68   $��20(�6H   
�������$��
0 10 10 10q�6i   $ По батькові��6�   �� 5*      -   5        $��gender��5*      $��2��6-   $��1��6:   $��
10 10 0 10q�6J   $��20(�6^   
������� �� SelectedIndex$ 0��6�   .@�5+      �� {�.  $y�	Collapsed=�69   .��6P   Оберіть стать6_   �� 5,      .��6'   Чоловік60   �� 5-      .��6'   
Жінка6.   5.      �� 5/      -   5        $��login��5/      $��3��6+   $��0��68   $��20(�6H   
�������$��
0 10 10 10q�6i   $ 
Логін��6�   	 � ToolTip$�	 �Введіть логін, який повинен складатися з латинських літер, чисел та знаку _ 
Логін повинен починатися з літери��6�   (  "System.Windows.Controls.DatePicker  50      -   5        $��birthday��50   !   $��3��61   $��1��6>   $��20(�6N   
�������$��
10 10 0 10q�6o   
   IsTodayHighlighted
 .  �� Today   SelectedDate# Z 6�    J� Opacity$	 0.5Q�6�   6�   �� 51      -   5        $	��job��51      $��4��6)   $��2��66   $��20(�6J   
�������$��	0 10 0 10q�6k   $&  Посада, підрозділ��6�   �� 52      -   5        $
��spec��52      $��5��6*   $��0��67   $��20(�6G   
�������$��
0 10 10 10q�6h   $  Спеціальність��6�   �� 53      -	   5        $
��rank��53      $��5��6*   $��1��67   $��20(�6G   
�������$��
10 10 0 10q�6h   $% Військове звання��6�   �� 54      -
   5        $��registrationButton��54   �   $$��Зареєструватися��6   $��30(�67   $��Times New Roman)�6E   $��50��6b   $��6��6n   $��0��6{   $��Center=�6�   $��Center=�6�   6�   � 56      $��6��6   $��1��6(   $��Center=�68    57      �� 58      $��* �6/   �� 59      $��* �6/   �� 5:      $��* �6/    5<      �� 5=      $��* �6,   .+�5@      �� -   5        $��
backButton��5@   �   $��
Назад��6!   $��1��61   $��0��6A   $��20(�6N   $��Times New Roman)�6\   $��Center=�6y   $	��Top=�6�   6�   5A      5B      5E      5F      5H      5I      
   M S B A M L   `   `   `  ����F  BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:TaskManager.UserControlsTaskManager.UserControls  5      5    /TaskManager.UserControls.GantDiagramUserControl   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:TaskManager.UserControls     5      .��5	      �� $
��Auto=�6   $
��Auto=�68   .��5
   
   �   � RowDefinitions  5      �� 5      $
��auto �6    �� 5      .+�5      � ���#5488DE � ColumnDefinitions 5      �� 5      $
��auto �6'   �� 5      �� 5      $
��auto �6'   �� 5      $
��auto �6'   �� 5      $
��auto �6'   .+�5      �� $��Масштаб: ��6   �� 5      -   5         ��Name$ ScaleDatetimeSlider��5   >      
MainSlider#���   6    � Maximum$	 200Q�6[    � Minimum$ 10Q�6i    � Value$	 100Q�6v    �� TickFrequency$ 10Q�6�    �� TickPlacement$
 Both=�6�   $��1��6�   $��Center=�6�   �� 5      -   5         ��Name$ ScaleValueTextBlock��5      $��2��6�   ��69   �� *Value+	 �� ElementName$	 ScaleDatetimeSlider��
 �� StringFormat$
 {0:F0}��6�   �� 5      $��3��6   $	��100��6+    �� SelectedIndex$ 0��6:   .@�5      �� $��1 неделя��6#   �� 5      $��2 недели��6#   �� 5      $��1 месяц��6#   �� 5      $��1 год��6#   5      �� 5       -   5         ��Name$ ImportTasksButton��5    A     
MainButton#���  6   $-��'Импортировать задачи��6\   $��4��6{   5!      5"      5#      5$      
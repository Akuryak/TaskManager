   M S B A M L   `   `   `  ����F  BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TaskManager.PagesTaskManager.Pages  5      !    TaskManager.Pages.TasksPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:TaskManager.Pages     5      -   5          N� Title$  	TasksPage��5	      .��5      � ���#363759 � ColumnDefinitions 5   
   �� 5      -   5         ��Name$ TasksListColumn��5      �� 5      -   5        $ TasksEditColumn��5      $
��auto �68   .+�5   
   � -   5         �Name$ TasksListGrid��5   (   
������ $��0��6?    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      �� 5      $
��auto �6    .+�5      �� -   5         ��Name$ SearchProjectsTextBox��5   ?      MainTextBox#���   6   $��0��6^   6�   �� 5      -   5         ��Name$ SearchProjectsTextBlock��5      $��
Поиск��69   $��0��6F   
�������$��15,0,0,0q�6g   $
��Left=�6y   �� 5      -   5         ��Name$ ProjectTasksListBox��5      $��1��63   $��Stretch=�6@   6e   �� 5      -   5         ��Name$ CreateNewTaskButton��5   =     
MainButton#���  6   $,��&Создать новую задачу��6Z   $��2��6y   6�   5      � 5   
   -	   5        $ TaskEditGrid��5      
������ $��1��6>   $y�	Collapsed=�6N    5      �� 5      $
��auto �6#   �� 5       5       �� 5!      $
��auto �6    �� 5"      $
��auto �6    �� 5#      $
��auto �6    �� 5$      �� 5%      $
��auto �6    .+�5'      �� $ ��Наименование: ��6   �� 5(      -
   5        $ FullTitleTextBox��5(   ?   #���   6   $��1��6Y   �� 5*      $1��+Короткое наименование: ��6   $��1��67   �� 5+      -   5        $ ShortTitleTextBox��5+   ?   #���   6   	 �� 	MaxLength$	 5��6Z   $��1��6h   $��1��6x   �� 5-      $��Описание: ��6   $��2��6*   �� 5.      -   5        $ DescriptionTextBox��5.   ?   #���   6   $��2��6[   $��2��6k   
 �� MaxLines$
 3��6x   �� 50      $8��2Дата начала и конца задачи: ��6   $��3��6<   &   System.Windows.Controls.Calendar  51      -   5          Name$ DeadlineDatePicker��51      $��2��63   $��3��6C      SelectionMode$ SingleRange=�6P   � 53      
������ $��4��6,   $��2��69    54      �� 55      �� 56      �� 57      .+�59      �� -   5        $ SaveChangesButton��59   A   #���  6   $��Сохранить��6\   6p   �� 5:      -   5        $ CancelChangesButton��5:   A   #���  6   $��Отменить��6^   $��1��6q   6�   �� 5;      -   5        $ DeleteTaskButton��5;   A   #���  6   $��Удалить��6[   
���  ��$��1��6~   6�   5<      5=      5>      5?      
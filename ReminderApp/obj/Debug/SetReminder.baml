   M S B A M L   `   `   `  ����F  BReminderApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ReminderAppReminderApp  5   	       ReminderApp.SetReminder   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ReminderApp     5   	     � Title$  KoolReminders��5   	   $	��400��6   $	��320��6,    � Icon$ logo.png��5	   	   .��5
      �� .+�5   
   �� $��Center=�6   $��Center=�60   $��	0,20,0,20q�6M   .+�5      �� -   5         ��Name$ SetReminderText��5      $��Set A Reminder��61   $��Impact)�6G   $��18(�6[   $	��120��6i   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��10,0,0,0q�6.   .+�5      �� $��Event Date: ��6   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 
datePicker��5      $	��200��6,   $��20,0,0,0q�68      SelectedDateFormat$ Short=�6J   6e   5      �� 5   
   $ 
Horizontal=�6   $��	10,10,0,0q�6.   .+�5      �� $��Event Time: ��6   �� 5      -   5         ��Name$ 
TimePicker��5      $��20(�6+   $	��100��69   $��Center=�6E   $��Visible=�6b   $��31��6�    �� MaxDropDownHeight$	 200��6�   $��20,0,0,0q�6�   .@�5      �� $��12:00��6   �� 5      $��12:30��6   �� 5      $
��1:00��6   �� 5      $
��1:30��6   �� 5      $
��2:00��6   �� 5      $
��2:30��6   �� 5      $
��3:00��6   �� 5      $
��3:30��6   �� 5      $
��4:00��6   �� 5      $
��4:30��6   �� 5       $
��5:00��6   �� 5!      $
��5:30��6   �� 5"      $
��6:00��6   �� 5#      $
��6:30��6   �� 5$      $
��7:00��6   �� 5%      $
��7:30��6   �� 5&      $
��8:00��6   �� 5'      $
��8:30��6   �� 5(      $
��9:00��6   �� 5)      $
��9:30��6   �� 5*      $��10:00��6   �� 5+      $��10:30��6   �� 5,      $��11:00��6   �� 5-      $��11:30��6   5.      �� 5/      -   5        $ 
AmPmPicker��5/      $��20(�6+   $��70��69   $��Right=�6D   $��31��6`   $	 200��6l   $��15,0,0,0q�6�   .@�50      �� $��AM��6   �� 51      $��PM��6   52      53      �� 54   
   -   5        $ myTextblock��54      $�� ��6)   $��Center=�61   $��10,0,0,0q�6N   �� 55   
   $ 
Horizontal=�6   $��10,0,0,0q�6.   .+�56      �� $��Event Title: ��6   �� 57      -   5         ��Name$ 	EventText��57      $	��200��6*   $��23,0,0,0q�66   $��60��6H   58      �� 59   
   $ 
Horizontal=�6   $��	10,20,0,0q�6.   .+�5:      �� $��Email: ��6   �� 5;      -   5        $ 	EmailText��5;      $	��200��6*   $��50,0,0,0q�66   $��30��6H   $��Center=�6T   5<      �� 5=   
   $��	10,20,0,0q�6   .+�5>      �� -   5        	 ��Name$	 ThreeDay��5>      $��Three Day reminder��6)   $��12(�6F   {�.  6   �� 5?      -	   5        $	 OneDay��5?      $��One Day reminder��6'   $��12(�6B   {�.  6y   �� 5@      -
   5        $	 SameDay��5@      $��Same Day reminder��6(   $��12(�6D   {�.  6|   5A      �� 5C   
   -   5        
 ��Name$
 AddEventButton��5C      $��Set Reminder��6)   $��
190,10,0,0q�6@   $��80��6T   6~   5D      5E      
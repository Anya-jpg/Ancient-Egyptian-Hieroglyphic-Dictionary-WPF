   M S B A M L   `   `   `  ����M  IEgyptianDictionary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EgyptianDictionaryEgyptianDictionary  5   	   $    EgyptianDictionary.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:EgyptianDictionary     5   	     � Title$  Авторизация��5   	   $	��500��5	   	   $	��700��5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   $��Segoe UI Historic)�5   	   $��16(�5   	   ���#fff2b2.��5      �  � RowDefinitions 5   
   �� 5      $��24 �6   6*   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5    
   � ���#033f63$��2��5!      .+�5"      ��  �� Orientation$ 
Horizontal=�6   $��Right=�5#      .+�5$      �� -   5        $��20��5$      $��20��5%      $
��Bold"�5&      
������ $��0q�5(      
�������$��0,0,5,0q�5*      .��5+   1   —64   �� 5,      -   5        $��20��5,      $��20��5-      $
��Bold"�5.      
������ $��0q�50      
�������.��52   .   🞪62   53      54      � 55   
   $��0��6   $��1��6   $��7��6,   .+�56      �� $��Assets/img_login.jpg��6   $��Center=�57      $	��732��6/   $��0,-126,0.4,81.2q�6<   58      �� 59   
   $��24(�5:      $
��Bold"�5;      $��Center=�5<      $��Center=�5=      $��1��5>      $��1��5?      .��6   Авторизация5A      �� 5B   
   $��
Логин��6   $��Bottom=�5C      $��	25,10,0,0q�5D      $��2��5E      $��1��5F      �� 5G   
   -   5         ��Name$ TBLogin��5G      $��	25,5,25,0q�5H      $��25��5I      $��1��5J      $��3��5K      �� 5L   
   $��Пароль��6   $��Bottom=�5M      $��	25,10,0,0q�5N      $��4��5O      $��1��5P      G� 5Q   
   -   5        $��
PBPassword��5Q      $��	25,5,25,0q�5R      $��25��5S      $��1��5T      $��5��5U      5V      �� 5W   
   -   5        $��1��5W      $��6��5X      ���#28666e
�������
�������$��35��5\      $��
25,25,25,0q�5]      $��
Войти��5^      5_      �� 5`   
   -   5        $��1��5`      $��7��5a      
����������#28666e���#28666e$��35��5e      $��25,5,25,300q�5f      $*��$Зарегистрироваться��5g      5h      5i      5j      
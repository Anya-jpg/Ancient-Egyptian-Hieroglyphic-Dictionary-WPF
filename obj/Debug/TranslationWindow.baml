   M S B A M L   `   `   `  ����M  IEgyptianDictionary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EgyptianDictionaryEgyptianDictionary  5   	   *    $EgyptianDictionary.TranslationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:EgyptianDictionary     5   	     � Title$)  #Написание перевода��5   	   $	��450��6$   $	��450��61    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   $��Segoe UI Historic)�5   	   $��16(�5   	   ���#fff2b2.��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5        $��LClient��5      $��0��5      6   �� 5   
   $��Center=�6   $
��Bold"�6-   $��1��5      $��Bottom=�5      $��
25,10,25,0q�5      .��6$   %#Текст для перевода:6:   �� 5   
   -   5        $��
TBOriginal��5      $
��Wrap=�6&    �� TextAlignment$ Center=�5       $��	25,5,25,0q�5!      $��2��5"      6   �� 5#   
   $��Center=�6   $
��Bold"�6-   $��Bottom=�5$      $��
25,10,25,0q�5%      $��3��5&      .��6   Задание:6$   �� 5'   
   -   5        $��TBTask��5'      $
��Wrap=�6"   $ Center=�5(      $��	25,5,25,0q�5)      $��4��5*      6   �� 5+   
   $��Center=�6   $
��Bold"�6-   $��5��5,      $��Bottom=�5-      $��
25,10,25,0q�5.      .��6$   Перевод:6.   �� 5/   
   -   5        $��TBResult��5/       �� TextWrapping$
 Wrap=�6"    �� AcceptsReturn . $��	25,5,25,0q�50      $��6��51      $��1��6   6,   �� 52   
   -   5        $��BSend��52      ���#28666e
�������
�������$��35��56      $��	25,0,25,0q�57      $��8��58      .��62   #!Отправить перевод6E   59      5:      
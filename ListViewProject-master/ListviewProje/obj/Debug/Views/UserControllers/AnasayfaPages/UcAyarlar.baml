   M S B A M L   `   `   `  ����  ListviewProjeA    ;ListviewProje.Views.UserControllers.AnasayfaPages.UcAyarlar   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � Triggers  5      :� 5	   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5
      ��    Loading#��[  6   5      .��5      � -   5         �Name$
 grid��5      z�5   
   V� 5      .~�5      �� �� 5      �� 5      T� 5      5      .+�5   
   �� .+�5      �� $��Center=�6   $��48��66   .��5      �� $��Ayarlar��6    
 Header#��[ 6,   $��-5q�6L   5      �� 5      $��Center=�6   $
��Left=�66   .��5      �� $��Renkler��6   
���   �$��13,0,0,0q�6>   $��Titillium Web Light)�6P   $��24(�6q   5      �� 5        BorderStylePadding#��[ 6   ._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      A� -   5          	FireBrick#��[ 5        Ellipse#��[ 6@   $	��Top=�6a   6y   A� 5       -   5        
����� �#��[ 5    7   $	��Top=�6X   6p   A� 5!      -   5        
����d�#��[ 5!   4   $	��Top=�6U   6m   A� 5"      -   5        
����U��#��[ 5"   2   $	��Top=�6S   6k   A� 5#      -   5        
���P��#��[ 5#   +   $	��Top=�6L   6d   A� 5$      -   5        
��� ��#��[ 5$   0   $	��Top=�6Q   6i   A� 5%      -   5        
��� d �#��[ 5%   /   $	��Top=�6P   6h   A� 5&      -	   5        
���� K�#��[ 5&   ,   $	��Top=�6M   6e   A� 5'      -
   5        
����p��#��[ 5'   3   $	��Top=�6T   6l   A� 5(      -   5        
����� �#��[ 5(   *   $	��Top=�6K   6c   A� 5)      -   5        
���Gc��#��[ 5)   ,   $	��Top=�6M   6e   A� 5*      -   5        
�����@�#��[ 5*   /   $	��Top=�6P   6h   5+      5,      �� 5-      $��Center=�6   $
��Left=�66   .��5.      �� $��Bekleme Süreleri��6   
���   �$��13,0,0,0q�6G   $��Titillium Web Light)�6Y   $��24(�6z   5/      �� 50      #��[ 6   ._�51      �� $ 
Horizontal=�6   .+�52      ��   
StackPanel#��[ 6!   .+�53      �� $&�� Başlangıç Geri Sayım Süresi��6     � ToolTip$T NBaşlangıçta gerçekleşen geri sayımın kaç saniye olacağını belirtin.��6G    	 Label#��[ 6�   �� 54      -   5         ��Name$ BaslangicSure��54   #     ComboBox#��[ 6:   $
��Auto��6\   6i   55      �� 56      #��[ 6!   .+�57      �� $��Skor Gösterme Süresi��6    $\ VHer sorudan sonra skor listesinin kaç saniye süreyle ekranda duracağını belirtin.��6?   #��[ 6�   �� 58      -   5        $ SkorSure��58   #   #��[ 65   $
��Auto��6W   6d   59      5:      5;      5<      5=      5>      
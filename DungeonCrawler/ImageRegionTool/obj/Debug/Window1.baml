   M S B A M L   `   `   `  ����  ImageRegionTool    WpfTestProject.Window1   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6#   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6e   -   5          � Title$  WpfTestProject��5       � SizeToContent$ WidthAndHeight=�5      .��5      ]� |�.  .+�5	      o� -   5         o�Name$ menuMain��5	   	    o� 
IsMainMenu . $	��Top=�5      .@�5      m� -   5        $��_Open Image��5      5   "   m� 5      -   5        $��
O_pen JSON��5      5   &   m� 5      -   5        $��
_Save JSON��5      5   "   5      �� 5      $��Bottom=�6   
�������.@�5      �� .��5      �� -   5        $��lblStatusCoords��5      5      �� 5      5      �� 5       �� Orientation$ 
Horizontal=�5      
�������.+�5      �� $	��150��5       .+�5!      �� -   5        $��lstRects��5"      
�������$	��150��5%       �� DisplayMemberPath$
 Name��5'      -  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation$
 None=�5(      ��5&      �� *
NamedRects+5(      �� 5)      -   5        $��txtName��5*      ��5+      �� *
TestString+5,      �� 5-      -	   5        $��
btnAddRect��5.      .��5/      Add Rectangle6.   �� 50      -
   5        $��btnRemoveRect��51      .��52   "   Remove Rectangle64   �� 53      -   5        $��chkShadeRect��54       �� 	ClickMode$ Release=�57      ��.  .��58      Shade Rectangles6*   �� 59      -   5        $��
scrollZoom��5:      ��.  $	��150��5<      $	��150��5=      $��Hidden=�5>      $��Hidden=�5?      
����������	#FFFF00D4.��5B      �� -   5        $��canZoom��5C      $
��1024��5D      $
��1024��5E      .+�5F      �� -   5        $��imgZoom��5G      $
��None=�5I       �� BitmapScalingMode$ NearestNeighbor=�5J      	 J� SnapsToDevicePixels	 . ��5H      �� 
 �� ElementName$
 imgMain�� �� Path$ Source�5K      �� 5L      -   5        $��rectZoom��5M      
��� ��� J� Opacity$	 0.5Q�5O      �� 5P      -   5        $��lineMouseHor��5Q      
�������$	 0.5Q�5S      6   �� 5T      -   5        $��lineMouseVer��5U      
�������$	 0.5Q�5W      6   5X      5Y      5Z      �� 5[      -   5        $��canVas��5\      
�������$	��300��5^       � Cursor$ Cross��5_      |�. .+�5d      �� -   5        $��imgMain��5e      6   �� 5f      -   5        $��
rectCanvas��5g      
��� ������	#0FF2CF435i      5j      5k      5l      5m      
   M S B A M L   `   `   `  ����J  FMahApps.Metro, Version=1.6.0.184, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   B >Notepad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:NotepadNotepad 5   	      Notepad.MainWindow   5   	   HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Notepad     5   	     � Icon$  Resources/icon.ico��5
   	      AccentColorBrush(   "MahApps.Metro.Controls.MetroWindow   	GlowBrush# �   5   	   $��2q�5   	    � WindowStartupLocation$ CenterScreen=�5   	      SaveWindowPosition .  � WindowState$ 	Maximized=�5   	      	TitleCaps .   � 
ResizeMode$ CanResizeWithGrip=�5   	      TitlebarHeight$ 36��5   	    � Title$ iNotepad��5   	   $	��550��6   $	��620��6'   	 J� CommandBindings	 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        
   Command$

 Save��5      5       J� InputBindings 5      �� 5   
   
 �� Key$ S��6    �� 	Modifiers$
 Ctrlf�5       �� Command$
 Save��5         RightWindowCommands 5      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5       �� -   5        $��compileAndRun��5       .��6F   Compile And Run6W   5!         LeftWindowCommands 5$        5%   
   .@�5&      �� -   5        $��IncreaseFontSize��5&      .��6N   Increase Font Size6b   �� 5'      -   5        $��DecreaseFontSize��5'      .��6L   Decrease Font Size6`   5(      .��5-      �  � RowDefinitions 5.   
   �� 5/      $
��auto �6   �� 50      �� 51      $
��auto �6    � ColumnDefinitions 53   
   �� 54      .+�56   
   o� $��4q�6   $��0��57      $��0��58      $��2��59      
���   �$��1q�5;      .@�5=      m� $
��File��6   $��5 0 5 0q�5>      $��DemiBold"�5?      $��14(�5@      .@�5A      m� -   5        $
��Open��5A      $��Regular"�5B      5C      m� 5D      -   5        $
��Save��5D       m� Command$
 Save��5E       m� InputGestureText$  ��5F      $��Regular"�5H      m� 5I      -   5        $
��Exit��5I      $��Regular"�5J      5K      5L      m� 5M      $
��Edit��6   $��DemiBold"�5N      $��5 0 5 0q�5O      $��14(�5P      .@�5Q      m� -   5        $	��Cut��5Q      $��Regular"�5R      5S      m� 5T      -	   5        $
��Copy��5T      $��Regular"�5U      5V      m� 5W      -
   5        $��Paste��5W      $��Regular"�5X      5Y      m� 5Z      -   5        $��
ChangeFont��5[      $��Change Font Family��5Z      $��Regular"�5\      5]      5^      m� 5_      $��About��6   $��5 0 5 0q�5`      $��DemiBold"�5a      $��14(�5b      .@�5c      m� -   5        $��About iNotepad��5c      $��Regular"�5d      5e      5f      m� 5g      $��Syntax Highlighting��6   $��DemiBold"�5h      $��14(�5i      $��5 0 5 0q�5j      .@�5k      m� -   5        $��cSharp��5l      $��C Sharp��5k      5m      m� 5n      -   5        $	��php��5o      $	��Php��5n      5p      m� 5q      -   5        $	��cpp��5r      $	��C++��5q      5s      5t      5u      ] YICSharpCode.AvalonEdit, Version=5.0.3.0, Culture=neutral, PublicKeyToken=9cc39be672370310'  !ICSharpCode.AvalonEdit.TextEditor  5v   
   ?
avalonEdit.http://icsharpcode.net/sharpdevelop/avalonedit  5�      -   5        $��richtextbox��5�      $��1��5w      $��0��5x         SyntaxHighlightingM  GICSharpCode.AvalonEdit.Highlighting.HighlightingDefinitionTypeConverter$	 C++ 5y      $��3q�5z      $��16(�5{         WordWrap . $��Courier New)�5}         LineNumbersForeground
 ��� �   ShowLineNumbers .    Text. 5�   O   5�      �� 5�   
   $��2��6   $��5q�5�      $��0��5�      $��2��5�      
�������$��1q�5�      .@�5�      �� $
��Left=�6   .��5�      �� $ ��All Rights Reserved @ 2017��6   $��DemiBold"�5�      5�      �� 5�      $��Right=�6   .��5�      �� $ ��Programmed By Mujeeb Ishaq��6   $��DemiBold"�5�      5�      5�      5�      5�      
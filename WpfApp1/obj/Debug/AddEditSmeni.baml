   M S B A M L   `   `   `  ????B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5          WpfApp1.AddEditSmeni   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp1     5        N? Title$  AddEditSmeni??5	      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $??3* ?6   ?? 5      $??5* ?6    ? RowDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   .+?5   
   ?? $??Right=?6   $
??Wrap=?60   $(??"Время начала смены??6D   $??Center=?6^   $??18(?6y   $??Verdana)?6?   $??22??6?   $	??195??6?   $??0,0,20,0q?6?   ?? 5   
   $??Right=?6   $??1??60   $
??Wrap=?6=   $&?? Время конца смены??6Q   $??Center=?6j   $??0,0,20,0q?6?   $??Verdana)?6?   $??18(?6?   $??22??6?   ?? 5   
   $??Right=?6   $??2??60   $
??Wrap=?6=   $??Мастер??6Q   $??Center=?6_   $??0,0,20,0q?6z   $??Verdana)?6?   $??18(?6?   (  "System.Windows.Controls.DatePicker  5   
   -   5        $??DataPickerNach??5      $??1??6P   $??Stretch=?6`   $??Center=?6   $??Verdana)?6?      Text 6+   ?? *$"Время_начала_смены+6?     5   
   -   5        $??DataPickerKon??5      $??1??6M   $??Stretch=?6]   $??Center=?6{   $??1??6?   $??Verdana)?6?    6*   ?? *" Время_конца_смены+6?   ?? 5   
   -   5         ??Name$ ComboMaster??5       ?? DisplayMemberPath$ Фамилия??6U   $??1??6q   $??2??6?    ?? SelectedItem 6(   ?? *'%Мастер_производства+6?   ?? 5   
   -   5        $??1??5      $??Сохранить??6!   $
??Left=?6K   $??3??6f   $??Center=?6s   $??30,0,0,0q?6?   $??20(?6?   $	??200??6?   $??28??6?   5      5      
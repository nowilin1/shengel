using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Suppliner.xaml
    /// </summary>
    public partial class Suppliner : Page
    {
        public Suppliner()
        {
            InitializeComponent();

            var allTypes = bigbaseEntities.GetContext().Поставщик.ToList();
            allTypes.Insert(0, new Поставщик
            {
                Наименование = "Все типы"
            });

            //ComboType.ItemsSource = allTypes;
            //CheckActual.IsChecked = true;
            //ComboType.SelectedIndex = 0;
        }
        }
    }
   

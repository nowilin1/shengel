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
    /// Логика взаимодействия для Materials.xaml
    /// </summary>
    public partial class Materials : Page
    {
        public Materials()
        {
            InitializeComponent();
            var currentmat = bigbaseEntities.GetContext().Материалы.ToList();
            LViewTours.ItemsSource = currentmat;
            UpdateMaterials();

            ComboType.ItemsSource = new List<string> { "Все типы", "Гранулы", "Краски", "Нитки" };
            ComboType.SelectedIndex = 0;

            ComboSort.ItemsSource = new List<string> { "Все типы", "По названию", "Количеству на складе", "Минимальное количество в упаковке" };
            ComboSort.SelectedIndex = 0;
        }
        private void UpdateMaterials()
        {
            var currentmat = bigbaseEntities.GetContext().Материалы.ToList();

            if (ComboType.SelectedIndex > 0)
            {
                currentmat = currentmat.Where(p => p.Тип_материала.Contains(ComboType.SelectedItem.ToString())).ToList();
            }

            currentmat = currentmat.Where(p => p.Наименование_материала.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            if (ComboSort.SelectedIndex > 0)
            {

                if (ComboSort.SelectedItem.ToString() == "По названию")
                {
                    currentmat = currentmat.OrderBy(p => p.Наименование_материала).ToList();
                }
                else if (ComboSort.SelectedItem.ToString() == "Количеству на складе")
                {
                    currentmat = currentmat.OrderBy(p => p.Количество_на_складе).ToList();
                }
                else if (ComboSort.SelectedItem.ToString() == "Минимальное количество в упаковке")
                {
                    currentmat = currentmat.OrderBy(p => p.Минимальное_количество).ToList();
                }

            }

            LViewTours.ItemsSource = currentmat;
        }


        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateMaterials();
        }


        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {
            UpdateMaterials();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMaterials();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMaterials();
        }
    }
}

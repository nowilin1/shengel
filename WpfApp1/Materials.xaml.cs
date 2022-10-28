﻿using System;
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

            var currentTours = bigbaseEntities.GetContext().Материалы.ToList();
            LViewTours.ItemsSource = currentTours;
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

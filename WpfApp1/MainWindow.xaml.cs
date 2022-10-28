﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            var allTypes = bigbaseEntities.GetContext().Материалы.ToList();
            InitializeComponent();
            //MainFrame.Navigate(new Materials());
            Manager.MainFrame = MainFrame;  

        }
        public void ImportSupplier()
        {

            //var fileData = File.ReadAllLines(@"\\FSProfile1.biik.ad.biik.ru\Redirect\shengeliya\Desktop\Вариант 1\Сессия 1\supplier_k_import.txt");
            var images = Directory.GetFiles(@"C:\Users\shengeliya\Source\Repos\shengel\WpfApp1\
");
            ////foreach (var line in fileData)
            ////{
            ////    var data = line.Split('\t');
            var tempTour = new Материалы();
            ////    {
            ////        Name = data[0].Replace("\"", ""),
            ////        TicketsCount = int.Parse(data[2]),
            ////        Price = decimal.Parse(data[3]),
            ////        IsActual = (data[4] == "0") ? false : true
            ////    };
            tempTour.Изображение = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(tempTour.Наименование_материала)));
            //}
        }
            private void ButtonBack_Click(object sender, RoutedEventArgs e)
            {
                Manager.MainFrame.GoBack();
            }
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                ButtonBack.Visibility = Visibility.Visible;
            }
            else
            {
                ButtonBack.Visibility = Visibility.Hidden;
            }
        }

        private void ButtonMat_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Materials());
        }
    }
    }

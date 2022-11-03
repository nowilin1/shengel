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

            DGridSuppliner.ItemsSource = bigbaseEntities.GetContext().Поставщик.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Поставщик));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            var supplinerRemove = DGridSuppliner.SelectedItems.Cast<Поставщик>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {supplinerRemove.Count()} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    bigbaseEntities.GetContext().Поставщик.RemoveRange(supplinerRemove);
                    bigbaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные были успешно удалены!");
                    DGridSuppliner.ItemsSource = bigbaseEntities.GetContext().Поставщик.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
    }
   

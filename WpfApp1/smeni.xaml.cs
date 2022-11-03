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
    /// Логика взаимодействия для smeni.xaml
    /// </summary>
    public partial class smeni : Page
    {
        public smeni()
        {
            InitializeComponent();

            DGrid_smeni.ItemsSource = bigbaseEntities.GetContext().Смена.ToList();
        }

        private void BtnEdt_Ckick(object sender, RoutedEventArgs e)
        {

            Manager.MainFrame.Navigate(new AddEditSmeni((sender as Button).DataContext as Смена));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditSmeni(null));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var smeniRemove = DGrid_smeni.SelectedItems.Cast<Смена>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {smeniRemove.Count()} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    bigbaseEntities.GetContext().Смена.RemoveRange(smeniRemove);
                    bigbaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные были успешно удалены!");
                    DGrid_smeni.ItemsSource = bigbaseEntities.GetContext().Смена.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}

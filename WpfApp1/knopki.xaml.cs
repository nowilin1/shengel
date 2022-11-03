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
    /// Логика взаимодействия для knopki.xaml
    /// </summary>
    public partial class knopki : Page
    {
        public knopki()
        {
            InitializeComponent();
        }

        private void ButtonMat_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Materials());
        }

        private void ButtonSuppliner_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Suppliner());
        }

        private void Buttonsmeni_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new smeni());
        }
    }
}

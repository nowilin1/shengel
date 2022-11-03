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
    /// Логика взаимодействия для AddEditSmeni.xaml
    /// </summary>
    public partial class AddEditSmeni : Page
    {

        private Смена currentsmeni = new Смена();
        public AddEditSmeni(Смена selectedsmeni)
        {
            InitializeComponent();
            if (selectedsmeni != null)
            {
                currentsmeni = selectedsmeni;
            }

            DataContext = currentsmeni;
            ComboMaster.ItemsSource = bigbaseEntities.GetContext().Мастер_производства.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            {
                StringBuilder errors = new StringBuilder();

                if (DataPickerNach.SelectedDate == null)
                {
                    errors.AppendLine("Укажите время начала смены");
                }
                if (DataPickerKon.SelectedDate == null)
                {
                    errors.AppendLine("Укажите время конца смены");
                }
                if (currentsmeni.Мастер_производства == null)
                {
                    errors.AppendLine("Укажите мастера");
                }

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }

                if (currentsmeni.ID_Смены == 0)
                {
                    bigbaseEntities.GetContext().Смена.Add(currentsmeni);
                }
                try
                {

                    currentsmeni.Время_начала_смены = DataPickerNach.SelectedDate;
                    currentsmeni.Время_конца_смены = DataPickerKon.SelectedDate;
                    bigbaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                    Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}

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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Поставщик _currentsup = new Поставщик();
        public AddEditPage(Поставщик selectedSupplner)
        {
            InitializeComponent();
            if (selectedSupplner != null)
                _currentsup = selectedSupplner;
            DataContext = _currentsup;
            ComboCounties.ItemsSource = new List<string> { "ОАО", "ПАО", "МКК", "МФО", "ООО", "ЗАО" };
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentsup.Наименование))
                errors.AppendLine("Укажите Наименование");
            if (string.IsNullOrWhiteSpace(_currentsup.ИНН))
                errors.AppendLine("Введите ИНН");
            if (string.IsNullOrWhiteSpace(_currentsup.Рейтинг_качества))
                errors.AppendLine("Введите рейтинг качества");
            if (DatePickerSup.SelectedDate == null)
                errors.AppendLine("Выберите дату");
            if (ComboCounties.SelectedItem == null)
                errors.AppendLine("Выберите поставщика");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentsup.ID_Поставщика == 0)
                bigbaseEntities.GetContext().Поставщик.Add(_currentsup);
            try
            {
                _currentsup.Дата_начала_работы_с_поставщиком = DatePickerSup.SelectedDate;
                bigbaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

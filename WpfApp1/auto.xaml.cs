using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Security.Cryptography;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для auto.xaml
    /// </summary>
    public partial class auto : Page
    {
        public string Access;
        public auto()
        {
            InitializeComponent();
        }
        private string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(login_Box.Text))
            {
                errors.AppendLine("Укажите логин");
            }
            if (string.IsNullOrWhiteSpace(pass_Box.Text))
            {
                errors.AppendLine("Укажите пароль");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка входа!");
                return;
            }
            string login = login_Box.Text;
            string password = GetHash(pass_Box.Text);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string admin = "Admin";
            string agent = "Agent";
            string master = "Master";
            string querystring = $"SELECT Login, Password, Access FROM Users where Login ='{login}' and Password = '{password}'";
            SqlConnection SqlConnection = new SqlConnection(@"Data Source = dbs.mssql.app.biik.ru; Initial Catalog=bigbase; Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand(querystring, SqlConnection);
            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButton.OK);
                Access = table.Rows[0][2].ToString();
                if (Access == admin)
                {
                    Manager.MainFrame.Navigate(new knopki());
                    SqlConnection.Close();
                }

                else if (Access == master)
                {
                    Manager.MainFrame.Navigate(new smeni());
                    SqlConnection.Close();
                }
                else if (Access == agent)
                {
                    Manager.MainFrame.Navigate(new Suppliner());
                    SqlConnection.Close();
                }
            }
            else
                MessageBox.Show("Логин или пароль неверный. Если Вы забыли пароль - обратитесь к администрации", "Аккаунт не обнаружен!", MessageBoxButton.OK);

        
    }

        private void pass_Box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

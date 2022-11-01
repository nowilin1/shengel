using System;
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

            //var allTypes = bigbaseEntities.GetContext().Материалы.ToList();
            InitializeComponent();
            //MainFrame.Navigate(new Materials());
            Manager.MainFrame = MainFrame;
            ImportSuppliner();

        }
        public void ImportMaterials()
        {
            var fileData = File.ReadAllLines(@"\\FSProfile1.biik.ad.biik.ru\Redirect\shengeliya\Desktop\Вариант 1\Материалы.txt");
            var images = Directory.GetFiles(@"C:\Users\shengeliya\Source\Repos\shengel\WpfApp1\materials\");
            foreach (var line in fileData)
            {
                var data = line.Split('\t');
                var tempmat = new Материалы()
                {
                    Наименование_материала = data[0].Replace("\"", ""),
                    Тип_материала = data[1],
                    Цена = decimal.Parse(data[3]),
                    Количество_на_складе = int.Parse(data[4]),
                    Минимальное_количество = int.Parse(data[5]),
                    Количество_в_упаковке = int.Parse(data[6]),
                    Единица_измерения = data[7]
                };
                try
                {
                    tempmat.Изображение = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(data[2])));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                bigbaseEntities.GetContext().Материалы.Add(tempmat);
                bigbaseEntities.GetContext().SaveChanges();
            }
        }
        private void ImportSuppliner()
        {
            var filedata = File.ReadAllLines(@"\\FSProfile1.biik.ad.biik.ru\Redirect\shengeliya\Desktop\Вариант 1\supplier_k_import.txt");

            foreach(var line in filedata)
            {
                var data = line.Split(',');
                var tempsuppliner = new Поставщик()
                {

                    Наименование = data[0].Replace("\"", ""),
                    Тип_поставщика = data[1],
                    ИНН = data[2],
                    Рейтинг_качества =data[3],
                    Дата_начала_работы_с_поставщиком = DateTime.Parse(string.Format("{0:dd-mm-yyyy}", data[4]))
                };
                foreach (var toursuppliner in data[3].Replace(" в рейтинге", " ").Replace(" Рейтинг ="," ").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var currentType = bigbaseEntities.GetContext().Поставщик.ToList().FirstOrDefault(p => p.Наименование == toursuppliner);
                }
                bigbaseEntities.GetContext().Поставщик.Add(tempsuppliner);
                bigbaseEntities.GetContext().SaveChanges();
            }
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

        private void ButtonSuppliner_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Suppliner());
        }
    }
    }

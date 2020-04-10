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

namespace ArtStudio
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public bool start = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           clientDB cDB = new clientDB();
            //надо сделать проверку!!!!
            //cDB.ShowDialog();

            cDB.Show();
        }

        private void addOrder_Click(object sender, RoutedEventArgs e)
        {
            orderPage oP = new orderPage();
            oP.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Materials materials = new Materials();
            materials.Show();
        }
    }
}

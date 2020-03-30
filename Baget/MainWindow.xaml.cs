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
using System.Data;
using MySql.Data.MySqlClient;

namespace Baget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string rez;
            
        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "37.59.55.185";
            conn_string.UserID = "KqrFwmIx1f";
            conn_string.Password = "V2sbMriJY8";
            conn_string.Database = "KqrFwmIx1f";
            conn_string.CharacterSet = "utf8";
            MySqlConnection conn = new MySqlConnection(conn_string.ToString());
            conn.Open();
            string sql = "SELECT * FROM clientDB";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
// читаем результат
            while (reader.Read())//цикл выгружающий данные
            {
                rez += reader[0].ToString() +  " " +
                reader[1].ToString() + " "
                +reader[2].ToString() + " " +
               reader[3].ToString() + " " +
               reader[4].ToString() + " " +
               System.Environment.NewLine;//выгружаем все строки по столбцам
                tb1.Text = rez;
            }
            reader.Close(); // закрываем
            conn.Close();
        }
    }
}

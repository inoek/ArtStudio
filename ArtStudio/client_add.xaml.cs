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
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;

namespace ArtStudio
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            string name = Name_box.Text;
            string number = number_box.Text;
            string email = email_box.Text;
            int sale = int.Parse(sale_box.Text);
            string description = description_box.Text;
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "37.59.55.185";
            conn_string.UserID = "KqrFwmIx1f";
            conn_string.Password = "V2sbMriJY8";
            conn_string.Database = "KqrFwmIx1f";
            conn_string.CharacterSet = "utf8";
            MySqlConnection connection = new MySqlConnection(conn_string.ToString());
            connection.Open();
            string sql = "SELECT MAX(`id`) FROM `clientDB`";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, connection);
            // выполняем запрос и получаем ответ
            id = int.Parse(command.ExecuteScalar().ToString()) + 1;
            string query = "INSERT INTO clientDB (id, имя, Номер_телефона, Электронная_почта, Скидка, Описание) VALUES (";
            query += id.ToString() + ", '" + name + "', " + number + ", '" + email + "', " + sale.ToString() + ", '" + description + "')";
            command = new MySqlCommand(query, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();
            this.Close();
        }
    }
}

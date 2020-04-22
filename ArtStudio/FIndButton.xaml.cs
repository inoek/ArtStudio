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
using MySql.Data.MySqlClient;
using System.Data;

namespace ArtStudio
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            bool name_empty = false, number_empty = false, email_empty = false, sale_empty = false, description_empty = false;
            string name = Name_box.Text;
            string number = number_box.Text;
            string email = email_box.Text;
            int sale = 0;
            if (sale_box.Text != "")
                sale = int.Parse(sale_box.Text);
            string description = description_box.Text;
            if (name == "")
            {
                name_empty = true;
            }
            if (number == "")
            {
                number_empty = true;
            }
            if (email == "")
            {
                email_empty = true;
            }
            if (sale_box.Text == "")
            {
                sale_empty = true;
            }
            if (description == "")
            {
                description_empty = true;
            }

            if (name_empty && number_empty && email_empty && description_empty && sale_empty)
            {
                errortext.Text = "Вы ничего не ввели!";
            }
            else
            {
                errortext.Text = "";
                MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
                conn_string.Server = "37.59.55.185";
                conn_string.UserID = "KqrFwmIx1f";
                conn_string.Password = "V2sbMriJY8";
                conn_string.Database = "KqrFwmIx1f";
                conn_string.CharacterSet = "utf8";
                MySqlConnection connection = new MySqlConnection(conn_string.ToString());
                connection.Open();

                string sql = "SELECT * FROM clientDB WHERE ID != 0 ";
                if (!name_empty)
                    sql += "AND имя = '" + name + "'";
                if (!number_empty)
                    sql += "AND Номер_телефона = '" + number + "'";
                if (!email_empty)
                    sql += "AND Электронная_почта = '" + email + "'";
                if (!sale_empty)
                    sql += "AND Скидка = '" + sale_box.Text + "'";
                if (!description_empty)
                    sql += "AND Описание = '" + description + "'";
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                connection.Close();
                //this.Close();
            }
        }

        private void Closebutton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}

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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            bool name_empty = false, number_empty = false, email_empty = false, sale_empty = false, description_empty = false;
            bool new_name_empty = false, new_number_empty = false, new_email_empty = false, new_sale_empty = false, new_description_empty = false;
            string name = Name_box.Text, new_name = Name_box_New.Text;
            string number = number_box.Text, new_number = number_box_New.Text;
            string email = email_box.Text, new_email = email_box_New.Text;
            int sale = 0, new_sale = 0; 
            if (sale_box.Text != "")
                sale = int.Parse(sale_box.Text);
            if (sale_box_New.Text != "")
                new_sale = int.Parse(sale_box_New.Text);
            string description = description_box.Text, new_description = description_box_New.Text;
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
            if (new_name == "")
            {
                new_name_empty = true;
            }
            if (new_number == "")
            {
                new_number_empty = true;
            }
            if (new_email == "")
            {
                new_email_empty = true;
            }
            if (sale_box_New.Text == "")
            {
                new_sale_empty = true;
            }
            if (new_description == "")
            {
                new_description_empty = true;
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
                MySqlDataReader reader = command.ExecuteReader();
                // читаем результат
                List<string> iD = new List<string>(); 
               
                    while (reader.Read())
                    {
                    // элементы массива [] - это значения столбцов из запроса SELECT
                        iD.Add(reader[0].ToString()); 
                    
                    }
                    reader.Close();

                
                object result = command.ExecuteScalar();
                if (result == null)
                {
                    errortext.Text = "Таких данных в таблице нет, попробуйте еще раз";
                }
                else
                {
                    var res = MessageBox.Show("Вы уверены, что хотите обновить?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (res == MessageBoxResult.Yes)
                    {
                        MySqlDataAdapter da = new MySqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        foreach (object c in iD)
                        {
                            if (!new_name_empty)
                            {
                                sql = "UPDATE clientDB SET ";
                                sql += "имя = '" + new_name + "' ";
                                sql += " WHERE ID = " + c;
                                command = new MySqlCommand(sql, connection);
                                // command.ExecuteNonQuery();
                                da = new MySqlDataAdapter(command);
                                dt = new DataTable();
                                da.Fill(dt);
                            }

                            if (!new_number_empty)
                            {
                                sql = "UPDATE clientDB SET ";
                                sql += "Номер_телефона = '" + new_number + "' ";
                                sql += " WHERE ID = " + c;
                                command = new MySqlCommand(sql, connection);
                                da = new MySqlDataAdapter(command);
                                dt = new DataTable();
                                // command.ExecuteNonQuery();
                                da.Fill(dt);
                            }
                            if (!new_email_empty)
                            {
                                sql = "UPDATE clientDB SET ";
                                sql += "Электронная_почта = '" + new_email + "' ";
                                sql += " WHERE ID = " + c;
                                command = new MySqlCommand(sql, connection);
                                da = new MySqlDataAdapter(command);
                                dt = new DataTable();
                                // command.ExecuteNonQuery();
                                da.Fill(dt);
                            }
                            if (!new_sale_empty)
                            {
                                sql = "UPDATE clientDB SET ";
                                sql += "Скидка = '" + sale_box_New.Text + "' ";
                                sql += " WHERE ID = " + c;
                                command = new MySqlCommand(sql, connection);
                                // command.ExecuteNonQuery();
                                da = new MySqlDataAdapter(command);
                                dt = new DataTable();
                                da.Fill(dt);

                            }
                            if (!new_description_empty)
                            {
                                sql = "UPDATE clientDB SET ";
                                sql += "Описание = '" + new_description + "' ";
                                sql += " WHERE ID = " + c;
                                command = new MySqlCommand(sql, connection);
                                // command.ExecuteNonQuery();
                                da = new MySqlDataAdapter(command);
                                dt = new DataTable();
                                da.Fill(dt);
                            }
                        }
                    }
                    if (res == MessageBoxResult.No)
                    {


                    }


                }
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

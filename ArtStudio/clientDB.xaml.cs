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

namespace ArtStudio
{
    /// <summary>
    /// Логика взаимодействия для clientDB.xaml
    /// </summary>
    public partial class clientDB : Window
    {
        public clientDB()
        {
            InitializeComponent();
           
        }
        //string rez;
        
        

        private void showAll_Click(object sender, RoutedEventArgs e)
        {
            //var ID = 1;


            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "37.59.55.185";
            conn_string.UserID = "KqrFwmIx1f";
            conn_string.Password = "V2sbMriJY8";
            conn_string.Database = "KqrFwmIx1f";
            conn_string.CharacterSet = "utf8";
            MySqlConnection connection = new MySqlConnection(conn_string.ToString());
            connection.Open();
            string sqlRequest = "SELECT * FROM clientDB";
            // string sqlRequest = $"SELECT * FROM clientDB WHERE ID LIKE {ID} ";
            MySqlCommand command = new MySqlCommand(sqlRequest, connection);
            //MySqlDataReader reader = command.ExecuteReader();

            //List<string[]> data = new List<string[]>();

            
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                da.Fill(dt);
                grid.ItemsSource = dt.DefaultView;
                connection.Close();
            
        }
    }
}

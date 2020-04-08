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

namespace ArtStudio
{
    /// <summary>
    /// Логика взаимодействия для orderPage.xaml
    /// </summary>
    public partial class orderPage : Window
    {
        public orderPage()
        {
            InitializeComponent();
            //orderGrid.AutoGenerateColumns = false;
            orderGrid.ItemsSource = LoadCollectionData();
        }
        public class structForOrder
        {
            public int  ID { get; set; }
            public double widthOfRama { get; set; }
            public double heightOfRama { get; set; }
            public string paspartu { get; set; }//check type
            public double widthOfPaspartu { get; set; }
            public double heightOfPaspartu { get; set; }
            public double up { get; set; }
            public double down { get; set; }
            public double side { get; set; }
            public int glass { get; set; }
            public int carton { get; set; }
            public int podramnik { get; set; }
            public int sticker { get; set; }
            public int natyazhka { get; set; }
            public int penok { get; set; }
            public int furnitura { get; set; }
        }

        private List<structForOrder> LoadCollectionData()
        {
            List<structForOrder> sForO = new List<structForOrder>();
            sForO.Add(new structForOrder()
            {
                ID = 1,
                widthOfRama = 123.4,
                heightOfRama = 244.2,
                paspartu = "Yes",
                widthOfPaspartu = 2424.5,
                heightOfPaspartu = 4234.0,
                up = 12.0,
                down = 13.3,
                side = 14.2,
                glass = 3,
                carton = 1,
                podramnik = 2,
                sticker = 0,
                natyazhka = 0,
                penok = 1,
                furnitura = 0
            });

            sForO.Add(new structForOrder()
            {
                ID = 2,
                widthOfRama = 123.4,
                heightOfRama = 244.2,
                paspartu = "No",
                widthOfPaspartu = 2423334.5,
                heightOfPaspartu = 4234.0,
                up = 12.0,
                down = 13.3,
                side = 14.2,
                glass = 3,
                carton = 1,
                podramnik = 2,
                sticker = 0,
                natyazhka = 0,
                penok = 1,
                furnitura = 0
            });



            return sForO;
        }

        private void dateOfTheOrderText_TouchDown(object sender, TouchEventArgs e)
        {
            dateOfTheOrderText.Text = "";
        }
    }
}
                
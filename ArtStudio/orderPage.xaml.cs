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
            //orderGrid.ItemsSource = LoadCollectionData();
        }
        string emptyString = "";
        double emptyDouble = 0.0;
        int emptyInt = 0;

        public class structForOrder
        {
            public structForOrder(int number, string baget,
                double heightOfRama, double widthOfRama, 
                string паспарту, double heightOfPaspartu,
                double widthOfPaspartu, string up,
                string down, string side,
                string glass, string carton,
                string podramnik, string sticker,
                string natyazhka, string penok,
                string furnitura
                )
            {
                this.номер = number;
                this.багет = baget;
                this.высотаРамы = heightOfRama;
                this.ширинаРамы = widthOfRama;
                this.паспарту = паспарту;
                ширинаПаспарту = widthOfPaspartu;
                высотаПаспарту = heightOfPaspartu;
                высота = up;
                низ = down;
                бок = side;
                стекло = glass;
                картон = carton;
                подрамник = podramnik;
                наклейка = sticker;
                натяжка = natyazhka;
                пенок = penok;
                фурнитура = furnitura;
            }
            public int  номер { get; set; }
            public string багет { get; set; }
            public double ширинаРамы { get; set; }
            public double высотаРамы { get; set; }
            public string паспарту { get; set; }//check type
            public double ширинаПаспарту { get; set; }
            public double высотаПаспарту { get; set; }
            public string высота { get; set; }
            public string низ { get; set; }
            public string бок { get; set; }
            public string стекло { get; set; }
            public string картон { get; set; }
            public string подрамник { get; set; }
            public string наклейка { get; set; }
            public string натяжка { get; set; }
            public string пенок { get; set; }
            public string фурнитура { get; set; }
        }


        

        private void dateOfTheOrderText_TouchDown(object sender, TouchEventArgs e)
        {
            dateOfTheOrderText.Text = "";
        }

        private void orderGrid_Loaded(object sender, RoutedEventArgs e)
        {
            List<structForOrder> order = new List<structForOrder>();
            order.Add(new structForOrder(1, "Да", 20.0,
                12.0, "Нет", 45.0, 40.0,
                emptyString, emptyString, emptyString, "Да", "Нет",
                emptyString, emptyString, "Длинная", emptyString, "Нет"));
            order.Add(new structForOrder(emptyInt, emptyString, emptyDouble,
                emptyDouble, emptyString, emptyDouble, emptyDouble,
                emptyString, emptyString, emptyString, emptyString, emptyString,
                emptyString, emptyString, emptyString, emptyString, emptyString));
          
            orderGrid.ItemsSource = order;
        }
    }
}
                
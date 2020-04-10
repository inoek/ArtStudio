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
    /// Логика взаимодействия для Materials.xaml
    /// </summary>
    public partial class Materials : Window
    {
        public Materials()
        {
            InitializeComponent();
        }
        public class materialStruct
        {
            public materialStruct(int number, double height, double width, string status)
            {
                Номер = number;
                Высота = height;
                Ширина = width;
                Статус = status;
            }
            public int Номер { get; set; }
            public double Высота { get; set; }
            public double Ширина { get; set; }
            public string Статус { get; set; }
        }

        private void materialsGrid_Loaded(object sender, RoutedEventArgs e)
        {
            List<materialStruct> mS = new List<materialStruct>();
            mS.Add(new materialStruct(2312, 42, 21, "есть в наличии"));

            materialsGrid.ItemsSource = mS;
        }
    }
}

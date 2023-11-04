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

namespace E_commerce.Views
{
    /// <summary>
    /// Interaction logic for ProductVerwijderen.xaml
    /// </summary>
    public partial class ProductVerwijderen : Window
    {
        public ProductVerwijderen()
        {
            InitializeComponent();


            // Lijst van producten voor de ListBox
            List<string> producten = new List<string>
        {
            "Muis",
            "USB-drive",
            "HDMI-kabel",
            "Externe harde schijf",
            // Voeg hier meer producten toe
        };

            // Koppel de lijst van producten aan de ListBox
            lbProducten.ItemsSource = producten;
        
    }

        private void btVerwijderen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

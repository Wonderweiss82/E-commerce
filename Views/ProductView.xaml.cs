using E_commerce.Model;
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
    /// Logique d'interaction pour ProductView.xaml
    /// </summary>
    public partial class ProductView : Window
    {
        
        List<Categorie> categorie = null;
        Categorie selectedCategorie = null;
        List<Product> product = null;   
        MyDBContext context = new MyDBContext();
        public ProductView()
        {
            InitializeComponent();


            

            // Lijst van categorieën
            List<string> categorieen = new List<string>
        {
            "Toetsenborden",
            "Monitoren",
            "Printers",
            "Netwerkapparatuur",
            "Grafische kaarten",
            // Voeg hier meer categorieën toe
        };

            // Koppel de lijst van categorieën aan de ComboBox
            cmbCategorie.ItemsSource = categorieen;

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





        public void DeleteMessage(object sender, MouseEventArgs e)
        {
            ClearMessage();
        }

        private void ClearMessage()
        {
            // toon een foutboodschap

            tbBeschrijving.Visibility = Visibility.Hidden;
        }

        private void btToevoegen_Click(object sender, RoutedEventArgs e)
        {
            context.Product.Add(new Product
            {
                Naam = tbNaam.Text,
                Beschrijving = tbBeschrijving.Text,
                Categorie = selectedCategorie,
                voorraadNiveau =  int.Parse(tbVoorraadniveau.Text)

        }) ;
            context.SaveChanges();
            product = context.Product.Where(p => p.CategorieId == selectedCategorie.Id).ToList();
            lbProducten.ItemsSource = product;
        }

        private void btBijwerken_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            new ProductVerwijderen().Show();
        }

        private void lbProducten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

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
        Categorie selectedCategorie = new Categorie();
        List<Product> product = null;   
        MyDBContext context = new MyDBContext();
        public ProductView()
        {
            InitializeComponent();






            // Lijst van producten voor de ListBox
            using (MyDBContext context = new MyDBContext())
            {
                // Query de producten uit de database
                product = context.Product.ToList();

                // Koppel de lijst van producten aan de ListBox
                lbProducten.ItemsSource = product;
            }

            using (MyDBContext context = new MyDBContext())
            {
                // Query de producten uit de database
                categorie = context.Categorie.ToList();


                // Koppel de lijst van producten aan de ListBox
                cmbCategorie.ItemsSource = categorie;                              
            }

        }





        public void DeleteMessage(object sender, MouseEventArgs e)
        {
            ClearMessage();
        }

        private void ClearMessage()
        {
            // toon een foutboodschap

        }

        private void btToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(tbCategorieId.Text, out int categorieId))
                {
                    // Controleer of de opgegeven CategorieID overeenkomt met een bestaande categorie
                    var bestaandeCategorie = context.Categorie.FirstOrDefault(c => c.Id == categorieId);

                    if (bestaandeCategorie != null)
                    {
                        // De categorie bestaat, je kunt doorgaan met het toevoegen van het product
                        context.Product.Add(new Product
                        {
                            Naam = tbNaam.Text,
                            Beschrijving = tbBeschrijving.Text,
                            CategorieId = categorieId, // Vergelijk de Categorie.ID met categorieId
                            voorraadNiveau = int.Parse(tbVoorraadniveau.Text)
                        });

                        context.SaveChanges();

                        // Vernieuw de lijst van producten na toevoegen
                        product = context.Product.Where(p => p.CategorieId == categorieId).ToList();
                        lbProducten.ItemsSource = product;

                        ClearMessage();
                    }
                    else
                    {
                        // De categorie bestaat niet, geef een foutmelding of verwerk dit op de gewenste manier
                        MessageBox.Show("De opgegeven categorie bestaat niet.");
                    }
                }
                else
                {
                    MessageBox.Show("Ongeldige CategorieID. Voer een numerieke waarde in.");
                }
            }
            catch (Exception ex)
            {
                // Vang de uitzondering op en toon een foutmelding of verwerk deze op de gewenste manier.
                MessageBox.Show("Er is een fout opgetreden: " + ex.Message);
                if (ex.InnerException != null)
                {
                    MessageBox.Show("Inner Exception: " + ex.InnerException.Message);
                }
            }
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

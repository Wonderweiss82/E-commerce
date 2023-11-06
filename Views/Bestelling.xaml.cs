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
using E_commerce.Model;


namespace E_commerce.Views
{
    /// <summary>
    /// Interaction logic for Bestelling.xaml
    /// </summary>
    public partial class Bestelling : Window
    {

        MyDBContext context = new MyDBContext();
        List<Product> product = null;



        public Bestelling()
        {
            InitializeComponent();


              List<int> Hoeveelheid = new List<int>
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };

            cmbHoeveelheid.ItemsSource = Hoeveelheid;

      

         

            //cmbProducten.ItemsSource = productNames;
            using (MyDBContext context = new MyDBContext())
            {
                // Query de producten uit de database
                product = context.Product.ToList();

                // Koppel de lijst van producten aan de ListBox
                cmbProducten.ItemsSource = product;    
                
                cmbProducten.SelectionChanged += CalculateTotalPrice;
                cmbHoeveelheid.SelectionChanged += CalculateTotalPrice;

            }
        
            

        

        }

        private void CalculateTotalPrice(object sender, EventArgs e)
        {

            try
            {// Haal de geselecteerde productnaam en hoeveelheid op
                string? selectedProduct = cmbProducten.SelectedItem as string;

                if (selectedProduct != null)
                {
                    int selectedQuantity = (int)cmbHoeveelheid.SelectedItem;

                    // Zoek het geselecteerde product in de database
                    Product? selectedProductData = context.Product.FirstOrDefault(p => p.Naam == selectedProduct);

                    if (selectedProductData != null)
                    {
                        // Bereken de totaalprijs op basis van de prijs in de database en de geselecteerde hoeveelheid
                        decimal totalPrice = selectedProductData.Prijs * selectedQuantity;

                        // Toon de totaalprijs in een TextBlock met de naam txtTotaalPrijs (voeg deze toe aan je XAML)
                        txtTotaalPrijs.Text = $"Totaalprijs: {totalPrice:C}"; // De 'C' formatter toont het bedrag in valutaformaat
                    }
                    else
                    {
                        txtTotaalPrijs.Text = "Product niet gevonden"; // Of een andere foutmelding
                    }
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
    }
    
}

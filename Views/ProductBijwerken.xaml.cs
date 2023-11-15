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
    public partial class ProductBijwerken : Window
    {
        MyDBContext context = new MyDBContext();
        Product selectedProduct = null;

        public ProductBijwerken()
        {
            InitializeComponent();
            LoadProductList();
        }

        private void LoadProductList()
        {
            lbProducten.ItemsSource = context.Product.ToList();
            lbBeschrijving.ItemsSource = context.Product.ToList();
        }

        private void lbProducten_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Wanneer een product wordt geselecteerd, toon de huidige naam en beschrijving in TextBox-elementen.
            if (lbProducten.SelectedItem is Product product)
            {
                selectedProduct = product;
                tbNaam.Text = product.Naam;
                tbBeschrijving.Text = product.Beschrijving;
            }
        }

        private void btnBijwerken_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProduct != null)
            {
                // Update de naam en beschrijving van het geselecteerde product.
                selectedProduct.Naam = tbNaam.Text;
                selectedProduct.Beschrijving = tbBeschrijving.Text;

                // Sla de wijzigingen op in de database.
                context.SaveChanges();
                MessageBox.Show("Product bijgewerkt!");

                // Vernieuw de lijst met producten.
                LoadProductList();
            }
        }

        private void lbBeschrijving_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}


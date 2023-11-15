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
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Views
{
    /// <summary>
    /// Interaction logic for ProductVerwijderen.xaml
    /// </summary>
    public partial class ProductVerwijderen : Window
    {
        MyDBContext context = new MyDBContext();
        List<Product> product = null;

        public ProductVerwijderen()
        {
            InitializeComponent();
            LoadProductList();
        }

        private void LoadProductList()
        {
            product = context.Product.ToList();
            lbProducten.ItemsSource = product;
        }

        private void btVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (lbProducten.SelectedItem is Product selectedProduct)
            {
                try
                {
                    // Verwijder het geselecteerde product.
                    using (var dbContext = new MyDBContext())
                    {
                        dbContext.Product.Remove(selectedProduct);
                        dbContext.SaveChanges();

                        MessageBox.Show("Product succesvol verwijderd!");

                        // Refresh the product list
                        LoadProductList();
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is Product)
                        {
                            var databaseValues = entry.GetDatabaseValues();

                            // Refresh the entry with values from the database
                            entry.OriginalValues.SetValues(databaseValues);
                        }
                    }

                    // Display a message to the user indicating a concurrency conflict.
                    MessageBox.Show("Het product is ondertussen gewijzigd door een andere gebruiker. Vernieuw de productenlijst en probeer opnieuw.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Er is een fout opgetreden bij het verwijderen van het product: " + ex.Message);
                }
            }
        }
    }
}

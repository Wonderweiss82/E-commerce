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
using Microsoft.EntityFrameworkCore;


namespace E_commerce.Views
{
    public partial class BestellingView : Window
    {
        MyDBContext context = new MyDBContext();
        List<Product> product = null;

        public BestellingView()
        {
            InitializeComponent();

            using (MyDBContext context = new MyDBContext())
            {
                // Query de producten uit de database
                product = context.Product.ToList();

                // Koppel de lijst van producten aan de ListBox
                cmbProducten.ItemsSource = product;
            }
        }


        private void BtnBestellingToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbProducten.SelectedItem != null)
                {
                    if (cmbProducten.SelectedItem != null)
                    {
                        var selectedProduct = (Product)cmbProducten.SelectedItem;
                        Console.WriteLine($"Geselecteerd product: {selectedProduct.Id}, {selectedProduct.Naam}");
                        // Andere logica...
                    }

                    /*context.Bestellings.Add(new Bestelling
                    {
                        Datum = DatePickerDatum.SelectedDate ?? DateTime.Now,
                        KlantId = int.Parse(TxtKlantId.Text),
                        // ProductId ophalen uit de geselecteerde ComboBox-waarde (CmbProduct)
                        ProductId = ((Product)cmbProducten.SelectedItem).Id
                    });*/

                    context.SaveChanges(); // Bewaar de wijzigingen in de database

                    MessageBox.Show("Bestelling is succesvol toegevoegd aan de database.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Selecteer een product voordat je een bestelling toevoegt.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (DbUpdateException dbEx)
            {
                MessageBox.Show("Databasefout bij het toevoegen van de bestelling: " + dbEx.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij het toevoegen van de bestelling: " + ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}


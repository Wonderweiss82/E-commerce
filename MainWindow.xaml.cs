using E_commerce.Views;
using System.Windows;
using System;
using E_commerce.Model;

namespace E_commerce
{
    public partial class MainWindow : Window
    {

        Klant klant = new Klant();
        public MainWindow()
        {
            InitializeComponent();

            miUitloggen.Visibility = Visibility.Collapsed;
            miProduct.Visibility = Visibility.Collapsed;
            miBestellen.Visibility = Visibility.Collapsed;
            miCategorie.Visibility = Visibility.Collapsed;
            miBeheerder.Visibility = Visibility.Collapsed;

            btBestellen.Visibility = Visibility.Collapsed;
            btCategorie.Visibility = Visibility.Collapsed;
            btProduct.Visibility = Visibility.Collapsed;
            btUitloggen.Visibility = Visibility.Collapsed;

           



        }

        private void ShowProductsButton_Click(object sender, RoutedEventArgs e)
        {
            MededelingenTextBlock.Text = "Show Products geklikt!";

            // Open een nieuw venster (ProductListView) om bestaande producten weer te geven
            ProductListView productListView = new ProductListView();
            productListView.ShowDialog();
        }
        private void miProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Your existing code for handling the Product button click
                MededelingenTextBlock.Text = "Product Toevoegen geklikt!";
                new ProductView().Show();
            }
            catch (Exception ex)
            {
                // Handle and display the error
                MededelingenTextBlock.Text = $"Fout bij het openen van ProductView: {ex.Message}";
                MessageBox.Show($"Er is een fout opgetreden: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Repeat the above structure for other event handlers

        private void miCategorie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MededelingenTextBlock.Text = "Categorie Toevoegen geklikt!";
                new CategorieView().Show();
            }
            catch (Exception ex)
            {
                MededelingenTextBlock.Text = $"Fout bij het openen van CategorieView: {ex.Message}";
                MessageBox.Show($"Er is een fout opgetreden: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void miBestellen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MededelingenTextBlock.Text = "Bestellen geklikt!";
                new BestellingView().Show();
            }
            catch (Exception ex)
            {
                MededelingenTextBlock.Text = $"Fout bij het openen van BestellingView: {ex.Message}";
                MessageBox.Show($"Er is een fout opgetreden: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void miRegistreren_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MededelingenTextBlock.Text = "Registreren geklikt!";
                new RegistratieView().Show();

                if (UserSession.UserId != 0)
                {
                    // User is authenticated, update UI accordingly
                    UpdateUIBasedOnAuthentication();
                }
            }
            catch (Exception ex)
            {
                MededelingenTextBlock.Text = $"Fout bij het openen van Registratie: {ex.Message}";
                MessageBox.Show($"Er is een fout opgetreden: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void miLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MededelingenTextBlock.Text = "Inloggen geklikt!";

                // Show the login window
                Aanmelden loginWindow = new Aanmelden();
                loginWindow.ShowDialog();

                // Check if the user is authenticated after the login window is closed
                if (UserSession.UserId != 0)
                {
                    // User is authenticated, update UI accordingly
                    UpdateUIBasedOnAuthentication();
                }
            }
            catch (Exception ex)
            {
                MededelingenTextBlock.Text = $"Fout bij het openen van Login: {ex.Message}";
                MessageBox.Show($"Er is een fout opgetreden: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateUIBasedOnAuthentication()
        {
            // Update UI based on user authentication status


            if (UserSession.UserId != 0)
            {
                // User is authenticated, hide "Inloggen" and "Registreren" menu items
                miLogin.Visibility = Visibility.Collapsed;
                miRegistreren.Visibility = Visibility.Collapsed;
                btRegistreren.Visibility = Visibility.Collapsed;
                btLogin.Visibility = Visibility.Collapsed;

                // Show "Uitloggen" menu item
                miUitloggen.Visibility = Visibility.Visible;
                miProduct.Visibility = Visibility.Visible;
                miBestellen.Visibility = Visibility.Visible;
                miCategorie.Visibility = Visibility.Visible;
                miBeheerder.Visibility = Visibility.Visible;
                
                
            

                btBestellen.Visibility = Visibility.Visible;
                btCategorie.Visibility = Visibility.Visible;
                btProduct.Visibility = Visibility.Visible;
                btUitloggen.Visibility = Visibility.Visible;

                if (UserSession.IsAdmin)
                {
                    miBeheerder.Visibility = Visibility.Visible;
                }
                else
                {
                    miBeheerder.Visibility = Visibility.Collapsed;
                }


                // Show other menu items or perform additional actions as needed
            }
            else
            {
                // User is not authenticated, show "Inloggen" and "Registreren" menu items
                miLogin.Visibility = Visibility.Visible;
                miRegistreren.Visibility = Visibility.Visible;
                btRegistreren .Visibility = Visibility.Visible;
                btLogin .Visibility = Visibility.Visible;
                btUitloggen .Visibility = Visibility.Collapsed;

                // Hide "Uitloggen" menu item
                miUitloggen.Visibility = Visibility.Collapsed;
                miProduct.Visibility = Visibility.Collapsed;
                miBestellen.Visibility = Visibility.Collapsed;
                miCategorie.Visibility = Visibility.Collapsed;
                miBeheerder.Visibility = Visibility.Collapsed;

                btBestellen.Visibility = Visibility.Collapsed;
                btCategorie.Visibility = Visibility.Collapsed;
                btProduct.Visibility = Visibility.Collapsed;


                // Hide other menu items or perform additional actions as needed

            
            }

            
        }



        private void miBeheerder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MededelingenTextBlock.Text = "Beheerder geklikt!";
                new Beheerder().Show();
            }
            catch (Exception ex)
            {
                MededelingenTextBlock.Text = $"Fout bij het openen van Beheerder: {ex.Message}";
                MessageBox.Show($"Er is een fout opgetreden: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void miUitloggen_Click(object sender, RoutedEventArgs e)
        {

            MededelingenTextBlock.Text = "Uitloggen geklikt!";

            // Perform logout operations
            UserSession.UserId = 0;
            UserSession.UserName = string.Empty;

            // Show a message or perform any additional actions upon logout
            MessageBox.Show("U bent uitgelogd.", "Uitloggen", MessageBoxButton.OK, MessageBoxImage.Information);

            // Update UI based on the logout status
            UpdateUIBasedOnAuthentication();
        }
    }
}
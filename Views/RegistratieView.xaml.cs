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
    /// Interaction logic for RegistratieView.xaml
    /// </summary>
    public partial class RegistratieView : Window
    {
        public RegistratieView()
        {
            InitializeComponent();
        }

        private void RegistrerenButton_Click(object sender, RoutedEventArgs e)
        {
            // Get user input
            string naam = txtNaam.Text;
            string wachtwoord = txtWachtwoord.Password;
            string herhaalWachtwoord = txtHerhaalWachtwoord.Password;
            string email = txtEmail.Text;
            string adres = txtAdres.Text;

            // Validate user input (add your own validation logic here)

            // Check if passwords match
            if (wachtwoord != herhaalWachtwoord)
            {
                MessageBox.Show("Wachtwoord en herhaal wachtwoord komen niet overeen.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create a new user (Klant) object
            Klant nieuweGebruiker = new Klant
            {
                Naam = naam,
                Wachtwoord = wachtwoord,
                Email = email,
                Adres = adres
            };

            // Add the new user to the database
            AddGebruikerToDatabase(nieuweGebruiker);

            // Set the UserSession properties for automatic login
            UserSession.UserId = nieuweGebruiker.KlantID;
            UserSession.UserName = nieuweGebruiker.Naam;
            UserSession.IsAdmin = nieuweGebruiker.IsAdmin; // Kopieer de IsAdmin eigenschap


            // Show a success message
            MessageBox.Show("Registratie succesvol! U bent nu aangemeld.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);

            // Call UpdateUIBasedOnAuthentication() from MainWindow to update the UI
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.UpdateUIBasedOnAuthentication();
            }

            // Close the registration window
            this.Close();
        }


        private void AddGebruikerToDatabase(Klant gebruiker)
        {
            using (var dbContext = new MyDBContext())
            {
                // Add the new user to the database
                dbContext.Klant.Add(gebruiker);
                dbContext.SaveChanges();

                
            }
        }

    }
}

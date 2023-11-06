using System;
using System.Linq;
using System.Windows;
using E_commerce.Model;
using System.Windows.Navigation;

namespace E_commerce.Views
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            string ingevoerdeGebruikersnaam = tGebruiker.Text;
            string ingevoerdWachtwoord = pwWachtwoord.Password;

            try
            {
                using (var context = new MyDBContext()) // Vervang YourDbContext door de naam van je Entity Framework DbContext
                {
                    var klant = context.Klant.SingleOrDefault(k => k.Naam == ingevoerdeGebruikersnaam);

                    if (klant != null)
                    {
                        // Klant gevonden, vergelijk wachtwoord
                        if (ingevoerdWachtwoord == klant.Wachtwoord) // Vervang "Wachtwoord" door de juiste eigenschap
                        {
                            // Inloggen geslaagd
                            context.SaveChanges();
                            MessageBox.Show("Inloggen gelukt!");
                            this.Close();
                        }
                        else
                        {
                            // Onjuist wachtwoord
                            MessageBox.Show("Foutief wachtwoord!");
                        }
                    }
                    else
                    {
                        // Klant niet gevonden
                        MessageBox.Show("Gebruiker niet gevonden!");
                    }
                }
            }
            catch (Exception ex)
            {
                // Afhandelen van eventuele uitzonderingen (fouten)
                MessageBox.Show("Er is een fout opgetreden: " + ex.Message);
            }
        }
    }
}


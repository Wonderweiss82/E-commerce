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
    /// Interaction logic for Aanmelden.xaml
    /// </summary>
    public partial class Aanmelden : Window
    {
        public Aanmelden()
        {
            InitializeComponent();
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (AuthenticateUser())
            {
                // Set user session properties
                UserSession.UserId = GetUserId(txtUsername.Text);
                UserSession.UserName = txtUsername.Text;


                // Close the login window
                this.Close();

                // Show a success message in the main window
                MessageBox.Show($"Welkom, {UserSession.UserName}!", "Inloggen geslaagd", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                lblErrorMessage.Text = "Ongeldige inloggegevens. Probeer opnieuw.";
            }
        }

        private bool AuthenticateUser()
        {
            // Replace this with your actual authentication logic
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Password;

            using (var context = new MyDBContext())
            {
                // Example: Check if the user exists in your Klant database
                var user = context.Klant.FirstOrDefault(u => u.Naam == enteredUsername && u.Wachtwoord == enteredPassword);

                if (user != null)
                {
                    // Set IsAdmin property in UserSession
                    UserSession.IsAdmin = user.IsAdmin;

                    // Return true to indicate successful authentication
                    return true;
                }

                // Return true if the user is found; otherwise, return false
                return false;
            }
        }

        private int GetUserId(string username)
        {

            using (var context = new MyDBContext())
            {
                // Replace this with your actual logic to retrieve the user ID from the database
                var user = context.Klant.FirstOrDefault(u => u.Naam == username);
                return user != null ? user.KlantID : 0;
            }
        }

    }
}

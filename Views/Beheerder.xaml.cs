using E_commerce.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace E_commerce.Views
{
    public partial class Beheerder : Window
    {
        public Beheerder()
        {
            InitializeComponent();
            LoadUserList(); // Laad de lijst met gebruikers wanneer het Beheerder-venster wordt geopend.
        }

        private void LoadUserList()
        {
            using (var context = new MyDBContext())
            {
                var users = context.Klant.Where(klant => !klant.IsAdmin).ToList(); // Haal alle niet-beheerders op.

                UserList.ItemsSource = users;
            }
        }

        private void PromoteUser_Click(object sender, RoutedEventArgs e)
        {
            if (UserList.SelectedItem is Klant selectedUser)
            {
                try
                {
                    using (var context = new MyDBContext())
                    {
                        selectedUser.IsAdmin = true;
                        context.SaveChanges();
                        LoadUserList(); // Vernieuw de lijst met gebruikers.
                        MessageBox.Show("Gebruiker succesvol gepromoveerd!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fout bij het promoten van de gebruiker: " + ex.Message);
                }
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (UserList.SelectedItem is Klant selectedUser)
            {
                // Verwijder de geselecteerde gebruiker.
                using (var context = new MyDBContext())
                {
                    context.Klant.Remove(selectedUser);
                    context.SaveChanges();
                    MessageBox.Show("Gebruiker succesvol verwijderd!");
                    LoadUserList(); // Vernieuw de lijst met gebruikers.
                }
            }
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Hier kun je de details van de geselecteerde gebruiker weergeven.
            if (UserList.SelectedItem is Klant selectedUser)
            {
                // Toon de gegevens van de geselecteerde gebruiker in je UI.
            }
        }
    }
}
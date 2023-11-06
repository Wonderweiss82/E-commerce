using System;
using System.Windows;
using E_commerce.Model;
using Microsoft.EntityFrameworkCore;
 
namespace E_commerce.Views
{
    public partial class CategorieView : Window
    {
        MyDBContext context = new MyDBContext();

        public CategorieView()
        {
            InitializeComponent();
        }

        private void btToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validatie van de invoer
                if (string.IsNullOrWhiteSpace(tbNaam.Text))
                {
                    throw new Exception("Naam van de categorie is vereist.");
                }

                // Voeg de nieuwe categorie toe aan de database
                context.Categorie.Add(new Categorie
                {
                    Naam = tbNaam.Text,
                    Beschrijving = tbBeschrijving.Text
                });

                context.SaveChanges();

                // Leeg de tekstvakken na succesvol toevoegen
                tbNaam.Text = "";
                tbBeschrijving.Text = "";

                // Toon een succesboodschap
                tbErrorMessage.Text = ""; // Wissen van foutmelding als die er was
                tbSuccessMessage.Text = "Categorie toegevoegd";
            }
            catch (Exception ex)
            {
                // Vang eventuele uitzonderingen op en toon een foutmelding
                tbSuccessMessage.Text = ""; // Wissen van succesmelding als die er was
                tbErrorMessage.Text = ex.Message;
            }
        }
    }
}
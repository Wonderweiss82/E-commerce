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
using System.Windows.Navigation;

namespace E_commerce.Views
{
    /// <summary>
    /// Interaction logic for Registratie.xaml
    /// </summary>
    public partial class Registratie : Window
    {

        MyDBContext context = new MyDBContext();

        public Registratie()
        {
            InitializeComponent();
        }

        private void btRegistreren_Click(object sender, RoutedEventArgs e)
        {
           

            try
            {
                

                    context.Klant.Add(new Klant()


                    {
                        Naam = tbNaam.Text,
                        Email = tbGebruiker.Text,
                        Wachtwoord = pwWachtwoord.Password,
                        Adres = tbAdres.Text
                    });
                    
                context.SaveChanges();
                MessageBox.Show("Registratie succesvol");
                this.Close();
                    
                
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

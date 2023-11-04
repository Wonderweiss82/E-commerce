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
    /// Interaction logic for Registratie.xaml
    /// </summary>
    public partial class Registratie : Window
    {
        public Registratie()
        {
            InitializeComponent();
        }

        private void btRegistreren_Click(object sender, RoutedEventArgs e)
        {

            if (pwWachtwoord.Password == "" || tbNaam.Text == "" || tbGebruiker.Text == "")
            {
                tbMededelen.Text = "Alle velden";
                tbMededelen.Visibility = Visibility.Visible;
            }
            if (pwWachtwoord.Password != pwHerhaling.Password)
            {
                tbMededelen.Text = "Geef dezelfde wachtwoord";
                tbMededelen.Visibility = Visibility.Visible;
            }
            else
            {
                Klant? gebruiker = null;
                try
                {
                    gebruiker = App.context.Klant.First(gebruiker => gebruiker.Naam == tbGebruiker.Text);
                }
                catch
                {


                    gebruiker = new Klant()
                    {
                        Naam = tbNaam.Text,
                        Email = tbGebruiker.Text,
                        Wachtwoord = pwWachtwoord.Password


                    };

                    App.context.Add(gebruiker);
                    App.context.SaveChanges();
                    this.Close();

                }

                tbMededelen.Text = "Bestaat al";

            }

        }
    }
}

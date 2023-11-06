using E_commerce.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace E_commerce
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void miProduct_Click(object sender, RoutedEventArgs e)
        {
            new ProductView().Show();
        }

        private void miRegistreren_Click(object sender, RoutedEventArgs e)
        {
            new Registratie().Show();
        }

        private void miLogin_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
        }

        private void miBestellen_Click(object sender, RoutedEventArgs e)
        {
            new BestellingView().Show();
        }

        private void miCategorie_Click(object sender, RoutedEventArgs e)
        {
            new CategorieView().Show();
        }
    }
}

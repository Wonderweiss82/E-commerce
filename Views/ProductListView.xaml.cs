using E_commerce.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace E_commerce.Views
{
    public partial class ProductListView : Window
    {
        private MyDBContext context = new MyDBContext();
        private List<Product> productList = null;

        public ProductListView()
        {
            InitializeComponent();

            // Query de producten uit de database
            productList = context.Product.ToList();

            // Koppel de lijst van producten aan de ListBox
            lbProductList.ItemsSource = productList;
        }
    }
}
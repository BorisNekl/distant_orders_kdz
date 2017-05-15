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

namespace distant_orders_kdz
{
    /// <summary>
    /// Interaction logic for WindowProducts.xaml
    /// </summary>
    public partial class WindowProducts : Window
    {
        List<Product> products = new List<Product>();
        public WindowProducts()
        {
            products = Product.Read();
            InitializeComponent();
            listBoxProducts.ItemsSource = products;
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

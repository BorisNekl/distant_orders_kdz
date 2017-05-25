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
using System.IO;
using System.Xml.Serialization;

namespace distant_orders_kdz
{
    /// <summary>
    /// Interaction logic for PageProduct.xaml
    /// </summary>
    public partial class PageProduct : Page
    {
        static List<User> users = new List<User>();
        static List<Product> products = new List<Product>();
        static List<Product> temp_cart = new List<Product>();
        static string[] fileArray = null;
        public static void ShowProduct()
        {
            products.Clear();
            if (File.Exists("catalog.txt"))
            {
                fileArray = File.ReadAllLines("catalog.txt");
                foreach (string str in fileArray)
                {
                    string t = str.Split(' ')[0];
                    int p = int.Parse(str.Split(' ')[1]);
                    Product pr = new Product(t, p);
                    products.Add(pr);
                }
            }
        }

        public PageProduct()
        {
            InitializeComponent();
            DeserializeUser();
            ShowProduct();
            listBoxProducts.ItemsSource = null;
            listBoxProducts.ItemsSource = products;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            button_Add.IsEnabled = (listBoxProducts.SelectedIndex != -1);
        }
        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("temp.txt"))
            {
                File.AppendAllText("temp.txt", "," + products[listBoxProducts.SelectedIndex].showInfo);
            }
            else
            {
                File.AppendAllText("temp.txt",products[listBoxProducts.SelectedIndex].showInfo);
            }
        }

        private void button_Cart_Click(object sender, RoutedEventArgs e)
        {
            foreach (User u in users.ToArray())
            {
                users.Remove(u);
            }
            DeserializeUser();
            if (User.Search(users))
            {
                Pages.PageCart.Refresh();
                Pages.PageCart.RefreshListBox();
                NavigationService.Navigate(Pages.PageCart);
            }
            else
            {
                MessageBox.Show("You should sign in or sign up to order","ERROR");
            }     
           
        }

        private void button_signup_Click(object sender, RoutedEventArgs e)
        {
            WindowSignUp a = new WindowSignUp();
            if (a.ShowDialog().Value)
            {
                users.Add(a.newuser);
                SerializeUser();
            }
        }
        private void SerializeUser()
        {
            using (FileStream fs = new FileStream("users.xml", FileMode.Create))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<User>));
                ser.Serialize(fs, users);
            }
        }
        private void DeserializeUser()
        {
            if (File.Exists("users.xml"))
            {
                using (FileStream fs = new FileStream("users.xml", FileMode.Open))
                {
                    XmlSerializer deser = new XmlSerializer(typeof(List<User>));
                    users = (List<User>)deser.Deserialize(fs);
                }
            }
        }
        private void button_signin_Click(object sender, RoutedEventArgs e)
        {
            WindowSignIn a = new WindowSignIn();
            a.ShowDialog();
        }

        private void button_orders_Click(object sender, RoutedEventArgs e)
        {
            foreach(User u in users.ToArray())
            {
                users.Remove(u);
            }
            DeserializeUser();
            if (User.Search(users))
            {
                Pages.PageUserOrders.RefreshDataGrid();
                NavigationService.Navigate(Pages.PageUserOrders);
            }
            else
            {
                MessageBox.Show("You should sign in or sign up to see your orders", "ERROR");
            }
        }
    }
}

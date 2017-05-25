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
    /// Interaction logic for PageUserOrders.xaml
    /// </summary>
    public partial class PageUserOrders : Page
    {
        List<Order> orders = new List<Order>();
        static List<UserOrder> userorders = new List<UserOrder>();
        private User logged = new User();
        static List<User> users = new List<User>();
        public PageUserOrders()
        {
            InitializeComponent();
            DeserializeOrder();
            Show_Data();
            dataGrid_order.ItemsSource = userorders;
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
        private void Show_Data()
        {
            DeserializeUser();
            DeserializeOrder();
            foreach (User u in users)
            {
                if (u.Check)
                {
                    foreach (Order o in orders)
                    {
                        string name = "";
                        int price = 0;
                        if(u.Mail == o.Mail)
                        {
                            List<Product> products = o.Products;
                            foreach (Product pr in products)
                            {
                                name += pr.Title + " ";
                                price += pr.Price;
                            }
                            UserOrder uo = new UserOrder(name, price, o.Address, o.Zip_code, o.Phone, o.Mail, o.Date);
                            userorders.Add(uo);
                            name = "";
                        }
                    }
                }
            }
        }
        private void DeserializeOrder()
        {
            if (File.Exists("orders.xml"))
            {
                using (FileStream fs = new FileStream("orders.xml", FileMode.Open))
                {
                    XmlSerializer deser = new XmlSerializer(typeof(List<Order>));
                    orders = (List<Order>)deser.Deserialize(fs);
                }
            }
        }
        private void SerializeOrder()
        {
            using (FileStream fs = new FileStream("orders.xml", FileMode.Create))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Order>));
                ser.Serialize(fs, orders);
            }
        }
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            button_delete.IsEnabled = (dataGrid_order.SelectedIndex != -1);
            button_change.IsEnabled = (dataGrid_order.SelectedIndex != -1);
        }
        private void button_delete_Click(object sender, RoutedEventArgs e)
        {
            UserOrder pressed = userorders[dataGrid_order.SelectedIndex];
            foreach (Order o in orders)
            {
                if(pressed.Date == o.Date && pressed.Mail == o.Mail)
                {
                    userorders.RemoveAt(dataGrid_order.SelectedIndex);
                    dataGrid_order.ItemsSource = null;
                    dataGrid_order.ItemsSource = userorders;
                    orders.Remove(o);
                    SerializeOrder();
                    break;
                }
            }
        }
        public void RefreshDataGrid()
        {
            foreach (UserOrder uo in userorders.ToArray())
               userorders.Remove(uo);
            Show_Data();
            dataGrid_order.ItemsSource = null;
            dataGrid_order.ItemsSource = userorders;
        }
        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.PageProduct);
        }

        private void button_change_Click(object sender, RoutedEventArgs e)
        {
            UserOrder us = userorders[dataGrid_order.SelectedIndex];
            WindowChange a = new WindowChange();
            if (a.ShowDialog().Value)
            {
                foreach (Order o in orders)
                {
                    if (us.Date == o.Date && us.Mail == o.Mail)
                    {
                        if (a.Address != "")
                        {
                            us.Address = a.Address;
                            o.Address = a.Address;
                        }
                        if (a.Phone != "")
                        {
                            us.Phone = a.Phone;
                            o.Phone = a.Phone;
                        }
                        if (a.Zip_code != "")
                        {
                            us.Zip_code = a.Zip_code;
                            o.Zip_code = a.Zip_code;
                        }
                    }
                    SerializeOrder();
                    dataGrid_order.ItemsSource = null;
                    dataGrid_order.ItemsSource = userorders;
                }
            }
        }

        private void button_search_Click(object sender, RoutedEventArgs e)
        {
            WindowSearch a = new WindowSearch();
            List<UserOrder> selected = new List<UserOrder>();
            if (a.ShowDialog().Value)
            {
                foreach (UserOrder uo in userorders)
                {
                    string[] namearray = uo.Name.Split(' ');
                    for (int i = 0; i < namearray.Count() ; i ++)
                    {
                        string n = namearray[i];
                        if (n == a.Name)
                        {
                            selected.Add(uo);
                            break;
                        }
                    }
                }
                dataGrid_order.ItemsSource = null;
                dataGrid_order.ItemsSource = selected;
            }
        }
        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.PageProduct);
        }

        private void button_show_Click(object sender, RoutedEventArgs e)
        {
            dataGrid_order.ItemsSource = null;
            dataGrid_order.ItemsSource = userorders;
        }
    }
}

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

namespace distant_orders_kdz
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

        private void button_start_Click(object sender, RoutedEventArgs e)
        {
            WindowProducts a = new WindowProducts();
            MainWindow m = new MainWindow();
            m.Close();
            a.Show();
        }

        private void button_signup_Click(object sender, RoutedEventArgs e)
        {
            WindowSignUp a = new WindowSignUp();
            MainWindow m = new MainWindow();
            m.Hide();
            a.ShowDialog();
        }

        private void button_signin_Click(object sender, RoutedEventArgs e)
        {
            WindowSignIn a = new WindowSignIn();
            a.ShowDialog();
        }
    }
}

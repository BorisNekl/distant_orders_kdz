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
    /// Interaction logic for WindowSignUp.xaml
    /// </summary>
    public partial class WindowSignUp : Window
    {
        private User _newuser = new User();

        public User newuser
        {
            get { return _newuser; }
        }

        public WindowSignUp()
        {
            InitializeComponent();
        }

        private void button_adduser_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_name.Text))
            {
                MessageBox.Show("Введите имя", "ОШИБКА");
                textBox_name.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_surname.Text))
            {
                MessageBox.Show("Введите фамилию", "ОШИБКА");
                textBox_surname.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_mail.Text))
            {
                MessageBox.Show("Введите почту", "ОШИБКА");
                textBox_mail.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_password.Text))
            {
                MessageBox.Show("Введите пароль", "ОШИБКА");
                textBox_password.Focus();
                return;
            }
            _newuser = new User(textBox_name.Text, textBox_surname.Text, textBox_mail.Text, textBox_password.Text);
            DialogResult = true;
        }
    }
}

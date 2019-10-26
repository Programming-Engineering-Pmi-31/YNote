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

namespace YNoreWPF.AdditionalWindow {
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window {

        string Email,Password;

        public LoginWindow() {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            if (LoginTextBox.Text == "admin" && PasswordTextBox.Text == "admin") {
                MainWindow mw = new MainWindow();
                //mw.UserProperty = new User(LoginTextBox.Text, PasswordTextBox.Text);
                mw.Show();
                this.Close();
            }
            else {
                LoginTextBox.BorderBrush = Brushes.Red;
                PasswordTextBox.BorderBrush = Brushes.Red;
                RegisterButton.Visibility = Visibility.Visible;
            }

        }
    }
}

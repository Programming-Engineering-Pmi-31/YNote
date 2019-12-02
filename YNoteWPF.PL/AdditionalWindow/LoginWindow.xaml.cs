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
using YNoteWPF.BLL;

namespace YNoteWPF.PL.AdditionalWindow
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        string Email;
        string Password;
        UserData data = new UserData();

        public LoginWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();
        }

        private void Close_Event(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // maybe time to delete such admin
            if (LoginTextBox.Text == "admin" && PasswordTextBox.Password == "admin")
            {
                MainWindow mw = new MainWindow();
                //mw.UserProperty = new User(LoginTextBox.Text, PasswordTextBox.Text);
                mw.Show();
                this.Close();
            }
            else if (data.Verification(LoginTextBox.Text, PasswordTextBox.Password))
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
            else
            {
                LoginTextBox.BorderBrush = Brushes.Red;
                PasswordTextBox.BorderBrush = Brushes.Red;
                RegisterButton.Visibility = Visibility.Visible;
                ConfirmPasswordPanel.Visibility = Visibility.Visible;
            }

        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            MainLabel.Content = "Register";
            NameStackPanel.Visibility = Visibility.Visible;
            SurnameStackPanel.Visibility = Visibility.Visible;
            NicknameStackPanel.Visibility = Visibility.Visible;
            ConfirmPasswordPanel.Visibility = Visibility.Visible;

            List<string> parameters = new List<string>() { NameTextBox.Text, SurnameTextBox.Text, NicknameTextBox.Text,
                    LoginTextBox.Text, PasswordTextBox.Password, PasswordTextBoxConfirm.Password};
            data.RegisterWithoutAllNecessaryTests(parameters, RegisterButton);
        }
    }
}

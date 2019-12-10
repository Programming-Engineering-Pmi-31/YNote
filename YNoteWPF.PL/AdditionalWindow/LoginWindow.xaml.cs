﻿using System;
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
using YNoteWPF.BLL.Data.Models;

namespace YNoteWPF.PL.AdditionalWindow
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        UserData data = new UserData();

        public LoginWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();
        }

        private void Close_Event(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // maybe time to delete such admin
            if (this.LoginTextBox.Text == "admin" && this.PasswordTextBox.Password == "admin")
            {
                MainWindow mw = new MainWindow();
                //mw.UserProperty = new User(LoginTextBox.Text, PasswordTextBox.Text);
                mw.Show();
                this.Close();
            }
            else if (this.data.Verification(this.LoginTextBox.Text, this.PasswordTextBox.Password))
            {
                MainWindow mw = new MainWindow(data.GetUser());
                //mw.User = data.GetUser();
                mw.Show();
                this.Close();
            }
            else
            {
                this.LoginTextBox.BorderBrush = Brushes.Red;
                this.PasswordTextBox.BorderBrush = Brushes.Red;
            }

        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            this.MainLabel.Content = "Register";
            this.NameStackPanel.Visibility = Visibility.Visible;
            this.SurnameStackPanel.Visibility = Visibility.Visible;
            this.NicknameStackPanel.Visibility = Visibility.Visible;
            this.ConfirmPasswordPanel.Visibility = Visibility.Visible;

            List<string> parameters = new List<string>() { NameTextBox.Text, SurnameTextBox.Text, NicknameTextBox.Text,
                    LoginTextBox.Text, PasswordTextBox.Password, PasswordTextBoxConfirm.Password};
            data.Register(parameters, RegisterButton);
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Return) {
                if (data.Verification(this.LoginTextBox.Text, this.PasswordTextBox.Password))
                {
                    MainWindow mw = new MainWindow(data.GetUser());
                    mw.Show();
                    this.Close();
                }
            }
        }
    }
}

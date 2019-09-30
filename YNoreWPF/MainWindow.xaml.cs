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

namespace YNoreWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();

            for (int countSpace = 0; countSpace < 2; ++countSpace) {
                SpacesListView.Items.Add(new Label() { Content = $"{countSpace+1}",
                                                       FontSize = 25});
            }

            SpacesListView.Items.Add(new Label() {
                Content = "+",
                FontSize = 25
            });
        }

        private void Add_New_Note(object sender, RoutedEventArgs e) {
            NotesStackPanel.Children.Add(new CustomControls.Note() { Height = 100,
                                                                     Width = 100,
                                                                     HorizontalAlignment = HorizontalAlignment.Left,
                                                                     Margin = new Thickness(10)                                                                     
                                                                     });
        }

        private void Login_Click(object sender, RoutedEventArgs e) {
            YNoreWPF.AdditionalWindow.LoginWindow loginWindow = new AdditionalWindow.LoginWindow();
            loginWindow.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
        private void MouseLeftButtonUp_Event(object sender, MouseButtonEventArgs e) {

        }
        private void MouseMove_Event(object sender, MouseEventArgs e) {

        }

        private void SelectionChange_Event(object sender, SelectionChangedEventArgs e) {
            int index = SpacesListView.SelectedIndex;

            NotesStackPanel.Children.Clear();

            if (index == SpacesListView.Items.Count - 1) { 
                SpacesListView.Items.RemoveAt(SpacesListView.Items.Count - 1);
                SpacesListView.Items.Add(new Label() {
                    Content = $"{ SpacesListView.Items.Count + 1}",
                    FontSize = 25
                });
                SpacesListView.Items.Add(new Label() {
                    Content = $"+",
                    FontSize = 25
                });
            }

        }
    }
}

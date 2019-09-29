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

        double FirstXPos, FirstYPos, FirstArrowXPos, FirstArrowYPos;
        object MovingObject;
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
            NotesStackPanel.Children.Add(new CustomControls.Note() { Height = Double.NaN,
                                                                     Width = 100,
                                                                     MinHeight = 100,
                                                                     //MinWidth = 100,
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

        private void MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            //In this event, we get current mouse position on the control to use it in the MouseMove event.
            FirstXPos = e.GetPosition(sender as Control).X;
            FirstYPos = e.GetPosition(sender as Control).Y;
            FirstArrowXPos = e.GetPosition((sender as Control).Parent as Control).X - FirstXPos;
            FirstArrowYPos = e.GetPosition((sender as Control).Parent as Control).Y - FirstYPos;
            MovingObject = sender;
        }
        void MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            MovingObject = null;
        }
        private void MouseMove(object sender, MouseEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) {
                (MovingObject as FrameworkElement).SetValue(Canvas.LeftProperty,
                     e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).X - FirstXPos);

                (MovingObject as FrameworkElement).SetValue(Canvas.TopProperty,
                     e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).Y - FirstYPos);
            }
        }
    }
}

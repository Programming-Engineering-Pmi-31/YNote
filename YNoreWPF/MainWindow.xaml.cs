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
        // Drop and drag
        double FirstXPos, FirstYPos;
        object MovingObject;

        public MainWindow() {
            InitializeComponent();

            foreach (Control control in NotesCanvas.Children) {
                control.PreviewMouseLeftButtonDown += this.MouseLeftButtonDown_Event;
                control.PreviewMouseLeftButtonUp += this.PreviewMouseLeftButtonUp_Event;
                control.Cursor = Cursors.Hand;
            }
            NotesCanvas.PreviewMouseMove += this.MouseMove_Event;

            for (int countSpace = 0; countSpace < 2; ++countSpace) {
                SpacesListView.Items.Add(new Label() { Content = $"{countSpace+1}",
                                                       FontSize = 25});
            }
            SpacesListView.Items.Add(new Label() {
                Content = "+",
                FontSize = 25
            });
        }

        private void CanMove_Checked(object sender, RoutedEventArgs e) {
            foreach (Control control in NotesCanvas.Children) {
                control.PreviewMouseLeftButtonDown -= this.MouseLeftButtonDown_Event;
                control.PreviewMouseLeftButtonUp -= this.PreviewMouseLeftButtonUp_Event;
                control.Cursor = null;
            }
            NotesCanvas.PreviewMouseMove -= this.MouseMove_Event;
        }

        private void Movable_Unchecked(object sender, RoutedEventArgs e) {
            foreach (Control control in NotesCanvas.Children) {
                control.PreviewMouseLeftButtonDown += this.MouseLeftButtonDown_Event;
                control.PreviewMouseLeftButtonUp += this.PreviewMouseLeftButtonUp_Event;
                control.Cursor = Cursors.Hand;
            }
            NotesCanvas.PreviewMouseMove += this.MouseMove_Event;
        }

        private void Add_New_Note(object sender, RoutedEventArgs e) {
            NotesCanvas.Children.Add(new CustomControls.Note("Test text", new List<Addition.UserTask>{ new Addition.UserTask(true,"todo"),new Addition.UserTask(false,"do") }) { Height = 150,
                                                                     Width = 150,
                                                                     HorizontalAlignment = HorizontalAlignment.Right,
                                                                     VerticalAlignment = VerticalAlignment.Top,
                                                                     Margin = new Thickness(10)});
            foreach (Control control in NotesCanvas.Children) {
                control.PreviewMouseLeftButtonDown += this.MouseLeftButtonDown_Event;
                control.PreviewMouseLeftButtonUp += this.PreviewMouseLeftButtonUp_Event;
                control.Cursor = Cursors.Hand;
            }
            NotesCanvas.PreviewMouseMove += this.MouseMove_Event;
        }

        private void Login_Click(object sender, RoutedEventArgs e) {
            YNoreWPF.AdditionalWindow.LoginWindow loginWindow = new AdditionalWindow.LoginWindow();
            loginWindow.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void MouseLeftButtonDown_Event(object sender, MouseButtonEventArgs e) {
            FirstXPos = e.GetPosition(sender as Control).X;
            FirstYPos = e.GetPosition(sender as Control).Y;
            MovingObject = sender;
        }
        void PreviewMouseLeftButtonUp_Event(object sender, MouseButtonEventArgs e) {
            MovingObject = null;
        }
        private void MouseMove_Event(object sender, MouseEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed && Keyboard.IsKeyDown(Key.LeftCtrl)) {
                (MovingObject as FrameworkElement).SetValue(Canvas.LeftProperty,
                     e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).X - FirstXPos);

                (MovingObject as FrameworkElement).SetValue(Canvas.TopProperty,
                     e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).Y - FirstYPos);
            }
        }

        private void FullScreen_Click(object sender, RoutedEventArgs e) {
            if ((string)((Button)sender).Content == "FullScreen") {
                this.WindowState = WindowState.Maximized;
                ((Button)sender).Content = "Minimizate";
            }
            if ((string)((Button)sender).Content == "Minimizate") {
                this.WindowState = WindowState.Normal;
                ((Button)sender).Content = "FullScreen";
            }
        }

        private void SelectionChange_Event(object sender, SelectionChangedEventArgs e) {
            int index = SpacesListView.SelectedIndex;

            NotesCanvas.Children.Clear();

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

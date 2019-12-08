using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes;
using System.IO;
using YNoteWPF.BLL.Data.Models;

namespace YNoteWPF.PL {

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window {
        // Drop and drag
        private double firstXPos;
        private double firstYPos;
        private object movingObject;

        public UserDTO User { get; set; }

        public MainWindow() {

            InitializeComponent();

            foreach (Control control in this.NotesCanvas.Children) {
                control.PreviewMouseLeftButtonDown += this.MouseLeftButtonDown_Event;
                control.PreviewMouseLeftButtonUp += this.PreviewMouseLeftButtonUp_Event;
                control.Cursor = Cursors.Hand;
            }

            this.NotesCanvas.PreviewMouseMove += this.MouseMove_Event;
        }

        public MainWindow(UserDTO user) : this() {
            this.User = user;

            this.UserNameTextBlock.Text = user.Nickname;

            this.NameLabel.Text = user.Name;
            this.SurnameLabel.Text = user.Surname;

            this.ChangeName.Text = user.Name;
            this.ChangeSurname.Text = user.Surname;

            this.ChangeEmail.Text = user.Email;
        }

        #region AddToDashboard
        private void Add_New_Note(object sender, RoutedEventArgs e) {
            this.NotesCanvas.Children.Add(new CustomControls.Note()
            {
                Height = 150,
                Width = 150,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(30 * this.NotesCanvas.Children.Count),
            });

            foreach (Control control in this.NotesCanvas.Children) {
                control.PreviewMouseLeftButtonDown += this.MouseLeftButtonDown_Event;
                control.PreviewMouseLeftButtonUp += this.PreviewMouseLeftButtonUp_Event;
                control.Cursor = Cursors.Hand;
            }

            this.NotesCanvas.PreviewMouseMove += this.MouseMove_Event;
        }

        private void Add_Group(object sender, RoutedEventArgs e) {
            if (this.GroupStackPanel.Children.Count < 4)
            {
                this.GroupStackPanel.Children.Add(new CustomControls.Group()
                {
                    Margin = new Thickness(10),
                    Height = 550,
                    MinWidth = 160
                });
            }
        }
        #endregion

        #region InfoBar
        private void Login_Click(object sender, RoutedEventArgs e) {
            YNoteWPF.PL.AdditionalWindow.LoginWindow loginWindow = new AdditionalWindow.LoginWindow();
            loginWindow.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void FullScreen_Click(object sender, RoutedEventArgs e) {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void Minimized_Click(object sender, RoutedEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }
        #endregion

        #region MakeNoteMovable_Events
        private void MouseLeftButtonDown_Event(object sender, MouseButtonEventArgs e) {
            firstXPos = e.GetPosition(sender as Control).X;
            firstYPos = e.GetPosition(sender as Control).Y;
            movingObject = sender;
        }

        void PreviewMouseLeftButtonUp_Event(object sender, MouseButtonEventArgs e) {
            movingObject = null;
        }
        private void MouseMove_Event(object sender, MouseEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed && Keyboard.IsKeyDown(Key.LeftCtrl)) {
                (movingObject as FrameworkElement).SetValue(
                    Canvas.LeftProperty,
                    e.GetPosition((movingObject as FrameworkElement).Parent as FrameworkElement).X - firstXPos);

                (movingObject as FrameworkElement).SetValue(Canvas.TopProperty,
                     e.GetPosition((movingObject as FrameworkElement).Parent as FrameworkElement).Y - firstYPos);
            }
        }
        #endregion

        #region PopUp_Menu
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e) {
            this.ButtonOpenMenu.Visibility = Visibility.Visible;
            this.ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e) {
            this.ButtonOpenMenu.Visibility = Visibility.Collapsed;
            this.ButtonCloseMenu.Visibility = Visibility.Visible;
        }
        #endregion

        #region SpaceInfoGrid
        private void ButtonOpenInfoGrid_Click(object sender, RoutedEventArgs e) {
            this.ButtonOpenInfoGrid.Visibility = Visibility.Collapsed;
            this.ButtonCloseInfoGrid.Visibility = Visibility.Visible;
        }
        private void ButtonCloseInfoGridu_Click(object sender, RoutedEventArgs e) {
            this.ButtonOpenInfoGrid.Visibility = Visibility.Visible;
            this.ButtonCloseInfoGrid.Visibility = Visibility.Collapsed;
        }
        #endregion

        private void SelectionChange_Event(object sender, SelectionChangedEventArgs e) {
            int index = SpacesListView.SelectedIndex;

            NotesCanvas.Children.Clear();




            if (index == SpacesListView.Items.Count - 1) { 
                SpacesListView.Items.RemoveAt(SpacesListView.Items.Count - 1);

                StackPanel dynamicStackPanel = new StackPanel() {Orientation = Orientation.Horizontal };

                dynamicStackPanel.Children.Add(new MaterialDesignThemes.Wpf.PackIcon {
                    Kind = MaterialDesignThemes.Wpf.PackIconKind.FileDocument,
                    Height = 25,
                    Width = 25,
                    Margin = new Thickness(0, 0, 10, 0),
                    Foreground = (Brush)new BrushConverter().ConvertFrom("#002d53")
                });
                dynamicStackPanel.Children.Add(new TextBlock() {
                    Text = $"Space {SpacesListView.Items.Count + 1}",
                    Height = 25,
                    FontSize = 17,
                    Foreground = (Brush)new BrushConverter().ConvertFrom("#002d53")
                });

                SpacesListView.Items.Add(dynamicStackPanel);

                StackPanel dynamicStackPanelAddNew = new StackPanel() { Orientation = Orientation.Horizontal};

                dynamicStackPanelAddNew.Children.Add(new MaterialDesignThemes.Wpf.PackIcon {
                    Kind = MaterialDesignThemes.Wpf.PackIconKind.FileDocument,
                    Height = 25,
                    Width = 25,
                    Margin = new Thickness(0, 0, 10, 0),
                    Foreground = (Brush)new BrushConverter().ConvertFrom("#002d53")
                });
                dynamicStackPanelAddNew.Children.Add(new TextBlock() {
                    Text = $"Add Space",
                    Height = 25,
                    FontSize = 17,
                    Foreground = (Brush)new BrushConverter().ConvertFrom("#002d53")
                });

                SpacesListView.Items.Add(dynamicStackPanelAddNew);
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            //SaveExternalXaml();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            //NotesCanvas.Children.Clear();
            //LoadExternalXaml();
        }
        public void LoadExternalXaml() {
            if (File.Exists("savepoint.xaml")) {
                using (FileStream savepoint = new FileStream("savepoint.xaml", FileMode.Open, FileAccess.Read)) {
                    //this.Content = XamlReader.Load(savepoint);
                    //foreach (var elem in (UIElementCollection)XamlReader.Load(savepoint)) {
                    //NotesCanvas.Children.Add((UIElement)elem);
                    //}
                    //NotesCanvas.Children.Add(XamlReader.Load(savepoint) as Canvas);
                    //((Panel)this.Parent).Children.Remove(this);

                    //var notes = XamlReader.Load(savepoint) as Canvas;

                    //foreach (CustomControls.Note elem in notes.Children) {
                    //    //((Panel)elem.Parent).Children.Remove(elem);
                    //    Models.RemovePaernt.RemoveElementFromItsParent(elem);
                    //    //var temp = elem;
                    //    //((Panel)temp.Parent).Children.Remove(temp);
                    //    NotesCanvas.Children.Add(elem);
                    //}

                    //while (notes.Children.Count != 0) {
                    //    var elem  = notes.Children.cop
                    //    Models.RemovePaernt.RemoveElementFromItsParent()
                    //}

                    var notes = XamlReader.Load(savepoint) as Canvas;

                    UIElement[] noteArray = new UIElement[notes.Children.Count];
                    notes.Children.CopyTo(noteArray, 0);

                    for (int i = 0; i < noteArray.Length; ++i) {
                        Models.RemoveParent.RemoveElementFromItsParent((FrameworkElement)noteArray[i]);
                        NotesCanvas.Children.Add(noteArray[i]);
                    }
                }
                File.Delete("savepoint.xaml");
            }
        }

        public void SaveExternalXaml() {
            using (FileStream savepoint = new FileStream("savepoint.xaml", FileMode.Create)) {
                XamlWriter.Save(this.NotesCanvas, savepoint);
            }
        }



        private void CloseUserInfo_Click(object sender, RoutedEventArgs e) {
            this.UserInfoGrid.Visibility = Visibility.Hidden;
        }

        private void PackIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            if (this.SpaceGrid.Width > 50)
            {
                this.UserInfoGrid.Visibility = Visibility.Visible;
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e) {
            this.ChangesGrid.Visibility = Visibility.Visible;
        }

        private void DeleteAccountButton_Click(object sender, RoutedEventArgs e) {
            YNoteWPF.PL.AdditionalWindow.ConfirmDelete confirmdeleteWindow = new AdditionalWindow.ConfirmDelete();
            confirmdeleteWindow.Show();
            this.ChangesGrid.Visibility = Visibility.Hidden;
        }

        private void SavaChangeButton_Click(object sender, RoutedEventArgs e) {
            this.ChangesGrid.Visibility = Visibility.Hidden;
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e) {
            AdditionalWindow.LoginWindow loginWindow = new AdditionalWindow.LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}

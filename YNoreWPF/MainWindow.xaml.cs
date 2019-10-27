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

namespace YNoreWPF {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        // Drop and drag
        double FirstXPos, FirstYPos;
        object MovingObject;

        

        public MainWindow() {

            //AdditionalWindow.LoginWindow loginWindow = new AdditionalWindow.LoginWindow();
            //loginWindow.Show();


            InitializeComponent();

            foreach (Control control in NotesCanvas.Children) {
                control.PreviewMouseLeftButtonDown += this.MouseLeftButtonDown_Event;
                control.PreviewMouseLeftButtonUp += this.PreviewMouseLeftButtonUp_Event;
                control.Cursor = Cursors.Hand;
            }
            NotesCanvas.PreviewMouseMove += this.MouseMove_Event;

            //UserNameTextBlock.Text = UserProperty.Email;


            //for (int countSpace = 0; countSpace < 2; ++countSpace) {
            //    SpacesListView.Items.Add(new Label() { Content = $"{countSpace+1}",
            //                                           FontSize = 25});
            //}
            //SpacesListView.Items.Add(new Label() {
            //    Content = "+",
            //    FontSize = 25
            //});

            //Notes.Children.Add(new CustomControls.Group(new List<Addition.Note> { new Addition.Note("1",new List<Addition.UserTask> { }),
            //                                                                      new Addition.Note("2",new List<Addition.UserTask> { }),
            //                                                                      new Addition.Note("3",new List<Addition.UserTask> { }),
            //                                                                      new Addition.Note("4",new List<Addition.UserTask> { })}) { Height = 200, Width = 200 });
                
        }

        private void Add_New_Note(object sender, RoutedEventArgs e) {
            NotesCanvas.Children.Add(new CustomControls.Note() {
                Height = 150,
                Width = 150,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(10)
            });
            foreach (Control control in NotesCanvas.Children) {
                control.PreviewMouseLeftButtonDown += this.MouseLeftButtonDown_Event;
                control.PreviewMouseLeftButtonUp += this.PreviewMouseLeftButtonUp_Event;
                control.Cursor = Cursors.Hand;
            }
            NotesCanvas.PreviewMouseMove += this.MouseMove_Event;
        }

        #region InfoBar
        private void Login_Click(object sender, RoutedEventArgs e) {
            YNoreWPF.AdditionalWindow.LoginWindow loginWindow = new AdditionalWindow.LoginWindow();
            loginWindow.Show();
        }
        private void Exit_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
        private void FullScreen_Click(object sender, RoutedEventArgs e) {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }
        private void Minimized_Click(object sender, RoutedEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }
        #endregion

        #region MakeNoteMovable_Events
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
        #endregion

        #region PopUp_Menu
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e) {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e) {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }
        #endregion

        #region SpaceInfoGrid
        private void ButtonOpenInfoGrid_Click(object sender, RoutedEventArgs e) {
            ButtonOpenInfoGrid.Visibility = Visibility.Collapsed;
            ButtonCloseInfoGrid.Visibility = Visibility.Visible;
        }
        private void ButtonCloseInfoGridu_Click(object sender, RoutedEventArgs e) {
            ButtonOpenInfoGrid.Visibility = Visibility.Visible;
            ButtonCloseInfoGrid.Visibility = Visibility.Collapsed;
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
            if (File.Exists("savepoint.xaml"))
                using (FileStream savepoint = new FileStream("savepoint.xaml",FileMode.Open, FileAccess.Read)) {
                    //this.Content = XamlReader.Load(savepoint);
                    //foreach (var elem in (UIElementCollection)XamlReader.Load(savepoint)) {
                    //NotesCanvas.Children.Add((UIElement)elem);
                    //}
                    //NotesCanvas.Children.Add(XamlReader.Load(savepoint) as Canvas);
                    //((Panel)this.Parent).Children.Remove(this);

                    //var notes = XamlReader.Load(savepoint) as UIElementCollection;

                    foreach (CustomControls.Note elem in (XamlReader.Load(savepoint) as Canvas).Children) {
                        //((Panel)elem.Parent).Children.Remove(elem);
                        var temp = elem;
                        ((Panel)temp.Parent).Children.Remove(temp);
                        NotesCanvas.Children.Add(temp);
                    }

                }
        }
        public void SaveExternalXaml() {
            using (FileStream savepoint = new FileStream("savepoint.xaml", FileMode.Create)) {
                XamlWriter.Save(NotesCanvas,savepoint);
            }
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e) {
            AdditionalWindow.LoginWindow loginWindow = new AdditionalWindow.LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}

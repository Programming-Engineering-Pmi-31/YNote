using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

namespace YNoreWPF.CustomControls {
    /// <summary>
    /// Interaction logic for Note.xaml
    /// </summary>
    public partial class Note : UserControl {

        
        public Note() {
            InitializeComponent();
        }

        public Note(string text, List<Addition.UserTask> tasks) : this() {
            TextBoxElem.Text = text;
            foreach (Addition.UserTask userTask in tasks)
                Context.Children.Add(new CustomControls.CheckWithTextBox(userTask.Status, userTask.Text));
        }

        private void Add_CheckBox_On_Click(object sender, RoutedEventArgs e) {
            //Context.Children.Add(new CheckBox() { HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
            //                                      Margin = new System.Windows.Thickness(0,0,0,0),
            //                                      Content = "ToDo"});
            Context.Children.Add(new YNoreWPF.CustomControls.CheckWithTextBox(true,"todo") { HorizontalAlignment = System.Windows.HorizontalAlignment.Left });
        }
        private void Delete_Note_On_Click(object sender, RoutedEventArgs e) {
            ((Panel)this.Parent).Children.Remove(this);
        }

        private void ChangeColorToWhite_click(object sender, RoutedEventArgs e) {
            NoteGrid.Background = Brushes.White;
        }
        private void ChangeColorToYellow_click(object sender, RoutedEventArgs e) {
            NoteGrid.Background = Brushes.Yellow;
        }
        private void ChangeColorToBlue_click(object sender, RoutedEventArgs e) {
            NoteGrid.Background = Brushes.Aqua;
        }

        private void MoveToDesktop_Click(object sender, RoutedEventArgs e) {
            ((Panel)this.Parent).Children.Remove(this);
            AdditionalWindow.NoteDesktop noteWindow = new AdditionalWindow.NoteDesktop(this);
            noteWindow.Show();
        }

        private void DontMovable_Event(object sender, RoutedEventArgs e) {

        }
    }
}

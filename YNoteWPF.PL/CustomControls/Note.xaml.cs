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
using YNoteWPF.PL.Models;
using YNoteWPF.BLL;

namespace YNoteWPF.PL.CustomControls
{
    /// <summary>
    /// Interaction logic for Note.xaml
    /// </summary>
    public partial class Note : UserControl
    {
        UserData data;

        private double normalHeight;

        public string Text { get; set; }

        public List<UserTask> Task { get; set; }


        public Note()
        {
            InitializeComponent();
            this.CreationAt.Content = $"{DateTime.Now.ToLongTimeString()}";
        }

        public Note(string text, List<UserTask> tasks) : this()
        {
            this.Text = text;
            this.Task = tasks;

            this.TextBoxElem.Document.Blocks.Add(new Paragraph(new Run(text)));
            foreach (UserTask userTask in tasks)
            {
                this.Context.Children.Add(new CheckWithTextBox(userTask.Status, userTask.Text));
            }
        }

        public void DeleteParent()
        {
            ((Panel)this.Parent).Children.Remove(this);
        }

        private void Add_CheckBox_On_Click(object sender, RoutedEventArgs e)
        {
            this.Context.Children.Add(new CheckWithTextBox(true, "todo") { HorizontalAlignment = System.Windows.HorizontalAlignment.Left });
        }

        private void Delete_Note_On_Click(object sender, RoutedEventArgs e)
        {
            ((Panel)this.Parent).Children.Remove(this);
        }

        private void ChangeColorToWhite_click(object sender, RoutedEventArgs e)
        {
            this.NoteGrid.Background = Brushes.White;
        }

        private void ChangeColorToYellow_click(object sender, RoutedEventArgs e)
        {
            this.NoteGrid.Background = Brushes.Yellow;
        }

        private void ChangeColorToBlue_click(object sender, RoutedEventArgs e)
        {
            this.NoteGrid.Background = Brushes.Aqua;
        }

        private void MoveToDesktop_Click(object sender, RoutedEventArgs e)
        {
            ((Panel)this.Parent).Children.Remove(this);
            AdditionalWindow.NoteDesktop noteWindow = new AdditionalWindow.NoteDesktop(this);
            noteWindow.Show();
        }

        #region MouseInsideOutsideEvent
        private void MouseEnter_Event(object sender, MouseEventArgs e)
        {
            this.ToolPanel.Visibility = Visibility.Visible;
        }

        private void MouseLeave_Event(object sender, MouseEventArgs e)
        {
            this.ToolPanel.Visibility = Visibility.Hidden;
        }
        #endregion

        private void Minimaze_click(object sender, RoutedEventArgs e)
        {
            this.normalHeight = this.Height;
            this.Height = this.TextBoxElem.Height + 20;
        }

        private void Maximaze_click(object sender, RoutedEventArgs e)
        {
            this.Height = this.normalHeight;
        }
    }
}

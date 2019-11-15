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

namespace YNoteWPF.PL.CustomControls
{
    /// <summary>
    /// Interaction logic for Note.xaml
    /// </summary>
    public partial class Note : UserControl
    {

        double normalHeight;

        public string Text { get; set; }
        public List<UserTask> Task { get; set; }


        public Note()
        {
            InitializeComponent();
        }

        public Note(string text, List<UserTask> tasks) : this()
        {
            Text = text;
            Task = tasks;

            TextBoxElem.Document.Blocks.Add(new Paragraph(new Run(text)));
            foreach (UserTask userTask in tasks)
                Context.Children.Add(new CheckWithTextBox(userTask.Status, userTask.Text));
        }

        private void Add_CheckBox_On_Click(object sender, RoutedEventArgs e)
        {
            Context.Children.Add(new CheckWithTextBox(true, "todo") { HorizontalAlignment = System.Windows.HorizontalAlignment.Left });
        }
        private void Delete_Note_On_Click(object sender, RoutedEventArgs e)
        {
            ((Panel)this.Parent).Children.Remove(this);
        }

        private void ChangeColorToWhite_click(object sender, RoutedEventArgs e)
        {
            NoteGrid.Background = Brushes.White;
        }
        private void ChangeColorToYellow_click(object sender, RoutedEventArgs e)
        {
            NoteGrid.Background = Brushes.Yellow;
        }
        private void ChangeColorToBlue_click(object sender, RoutedEventArgs e)
        {
            NoteGrid.Background = Brushes.Aqua;
        }

        private void MoveToDesktop_Click(object sender, RoutedEventArgs e)
        {
            ((Panel)this.Parent).Children.Remove(this);
            AdditionalWindow.NoteDesktop noteWindow = new AdditionalWindow.NoteDesktop(this);
            noteWindow.Show();
        }

        private void IncrementSelectedText_Click(object sender, RoutedEventArgs e)
        {
            TextSelection text = TextBoxElem.Selection;
            if (!text.IsEmpty)
            {
                //text.ApplyPropertyValue(RichTextBox.FontSizeProperty, FontSize + Convert.ToInt32(EnterSize.Text));
                //EnterSize.Text = "";
            }
        }
        private void DecrementSelectedText_Click(object sender, RoutedEventArgs e)
        {
            TextSelection text = TextBoxElem.Selection;
            if (!text.IsEmpty)
            {
                //text.ApplyPropertyValue(RichTextBox.FontSizeProperty, FontSize - Convert.ToInt32(EnterSize.Text));
                //EnterSize.Text = "";
            }
        }

        public void DeleteParent()
        {
            ((Panel)this.Parent).Children.Remove(this);
        }

        #region MouseInsideOutsideEvent
        private void MouseEnter_Event(object sender, MouseEventArgs e)
        {
            ToolPanel.Visibility = Visibility.Visible;
        }

        private void MouseLeave_Event(object sender, MouseEventArgs e)
        {
            ToolPanel.Visibility = Visibility.Hidden;
        }
        #endregion

        private void Minimaze_click(object sender, RoutedEventArgs e)
        {
            normalHeight = this.Height;
            this.Height = TextBoxElem.Height + 20;
        }

        private void Maximaze_click(object sender, RoutedEventArgs e)
        {
            this.Height = normalHeight;
        }
    }
}

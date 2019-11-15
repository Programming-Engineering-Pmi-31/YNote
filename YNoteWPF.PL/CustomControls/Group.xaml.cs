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
using YNoteWPF.PL.Models;

namespace YNoteWPF.PL.CustomControls {
    /// <summary>
    /// Interaction logic for Group.xaml
    /// </summary>
    public partial class Group : UserControl {
        List<Note> notes = new List<Note>();

        public Group() {
            InitializeComponent();
        }
        public Group(List<Models.Note> _notes):this() {
            //foreach(Addition.Note noteElem in _notes)
            //    StackPanelElem.Children.Add(new CustomControls.Note(noteElem.Text,noteElem.Tasks));
            foreach (Models.Note noteElem in _notes) {
                for (int i = 0; i < 2; ++i)
                    for (int j = 0; j < 2; ++j) {
                        var note = new Note(noteElem.Text, noteElem.Tasks);
                        MainGrid.Children.Add(note);
                        Grid.SetColumn(note,i);
                        Grid.SetRow(note,j);
                    }
            }
        }

        private void Add_New_Note(object sender, RoutedEventArgs e) {
            if (NotePanel.Children.Count < 5) 
                NotePanel.Children.Add(new CustomControls.Note() {
                    Margin = new Thickness(5),
                    Width = 150
                });
        }

        private void Delete_Note_On_Click(object sender, RoutedEventArgs e) {
            ((Panel)this.Parent).Children.Remove(this);
        }
    }
}

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
using YNoteWPF_BL.Entities;

namespace YNoreWPF.CustomControls {
    /// <summary>
    /// Interaction logic for Group.xaml
    /// </summary>
    public partial class Group : UserControl {
        List<Note> notes = new List<Note>();

        public Group() {
            InitializeComponent();
        }
        public Group(List<YNoteWPF_BL.Entities.Note> _notes):this() {
            //foreach(Addition.Note noteElem in _notes)
            //    StackPanelElem.Children.Add(new CustomControls.Note(noteElem.Text,noteElem.Tasks));
            foreach (YNoteWPF_BL.Entities.Note noteElem in _notes) {
                for (int i = 0; i < 2; ++i)
                    for (int j = 0; j < 2; ++j) {
                        var note = new CustomControls.Note(noteElem.Text, noteElem.Tasks);
                        MainGrid.Children.Add(note);
                        Grid.SetColumn(note,i);
                        Grid.SetRow(note,j);
                    }
            }
        }
        public void add_note() {

        }
    }
}

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
using System.Windows.Shapes;

namespace YNoteWPF.PL.AdditionalWindow {
    /// <summary>
    /// Interaction logic for NoteDesktop.xaml
    /// </summary>
    public partial class NoteDesktop : Window {
        private CustomControls.Note Note;

        public NoteDesktop() {
            InitializeComponent();
        }
        public NoteDesktop(CustomControls.Note note):this() {
            this.Note = note;
            MainWindow.Height = note.Height + 20;
            MainWindow.Width = note.Width + 20;
            this.MainGrid.Children.Add(this.Note);

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e) {
            MainGrid.Width = e.NewSize.Width;
            MainGrid.Height = e.NewSize.Height;
            double xChange = 1;
            double yChange = 1;

            if (e.PreviousSize.Width != 0)
                xChange = (e.NewSize.Width / e.PreviousSize.Width);

            if (e.PreviousSize.Height != 0)
                yChange = (e.NewSize.Height / e.PreviousSize.Height);

            foreach (FrameworkElement fe in MainGrid.Children) {
                if (fe is Grid == false) {
                    fe.Height = fe.ActualHeight * yChange;
                    fe.Width = fe.ActualWidth * xChange;
                }
            }
            // save changes
        }
    }
}

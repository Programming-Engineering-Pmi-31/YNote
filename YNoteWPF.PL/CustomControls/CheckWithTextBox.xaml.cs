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

namespace YNoteWPF.PL.CustomControls {
    /// <summary>
    /// Interaction logic for CheckWithTextBox.xaml
    /// </summary>
    public partial class CheckWithTextBox : UserControl {

        public bool Status { get { return (bool)this.CheckBoxElem.IsChecked; } }
        public string Text { get { return this.TextBoxElem.Text; } }

        public CheckWithTextBox()
        {
            InitializeComponent();
        }

        public CheckWithTextBox(bool status, string text) : this()
        {
            this.CheckBoxElem.IsChecked = status;
            this.TextBoxElem.Text = text;
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            this.DescriptionPopUp.IsOpen = true;
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!this.DescriptionPopUp.IsMouseOver)
            {
                this.DescriptionPopUp.IsOpen = false;
            }
            else { }
        }

        private void CheckBoxElem_Checked(object sender, RoutedEventArgs e)
        {
            this.TextBoxElem.TextDecorations = TextDecorations.Strikethrough;
        }

        private void CheckBoxElem_Unchecked(object sender, RoutedEventArgs e)
        {
            this.TextBoxElem.TextDecorations = TextDecorations.Baseline;
        }
    }
}

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

namespace YNoreWPF.CustomControls {
    /// <summary>
    /// Interaction logic for Note.xaml
    /// </summary>
    public partial class Note : UserControl {

        public Note() {
            InitializeComponent();
        }

        private void Add_CheckBox_On_Click(object sender, RoutedEventArgs e) {
            //Context.Children.Add(new CheckBox() { HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
            //                                      Margin = new System.Windows.Thickness(0,0,0,0),
            //                                      Content = "ToDo"});
            Context.Children.Add(new YNoreWPF.CustomControls.CheckWithTextBox() { HorizontalAlignment = System.Windows.HorizontalAlignment.Left });
        }
        private void Delete_Note_On_Click(object sender, RoutedEventArgs e) {
            ((Panel)this.Parent).Children.Remove(this);
        }
    }
}

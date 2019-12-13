using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace YNoteWPF.PL.AdditionalWindow {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ConfirmDelete : Window {
        public ConfirmDelete() {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void cancelDelete_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void deleteAcount_Click(object sender, RoutedEventArgs e) {
            LoginWindow lg = new LoginWindow();
            lg.Show();

            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            foreach (Window w in Application.Current.Windows)
            {
                if (w.GetType().Assembly == currentAssembly)
                {
                    w.Close();
                    break;
                }
            }

            this.Close();
        }
    }
}

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
using YNoteWPF.BLL.UserOperations;

namespace YNoteWPF.PL.AdditionalWindow
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ConfirmDelete : Window
    {
        UserEditor userEditor = new UserEditor();
        public ConfirmDelete()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }
        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            userEditor.DeleteUser();
            this.Close();
        }
        private void cancelDelete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

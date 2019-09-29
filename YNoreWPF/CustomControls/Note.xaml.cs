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
        // Data

        // For move elements
        double FirstXPos, FirstYPos, FirstArrowXPos, FirstArrowYPos;
        object MovingObject;

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

        //private void MouseLeftButtonDown_Event(object sender, MouseButtonEventArgs e) {
        //    //In this event, we get current mouse position on the control to use it in the MouseMove event.
        //    FirstXPos = e.GetPosition(sender as Control).X;
        //    FirstYPos = e.GetPosition(sender as Control).Y;
        //    FirstArrowXPos = e.GetPosition((sender as Control).Parent as Control).X - FirstXPos;
        //    FirstArrowYPos = e.GetPosition((sender as Control).Parent as Control).Y - FirstYPos;
        //    MovingObject = sender;
        //}
        //void MouseLeftButtonUp_Event(object sender, MouseButtonEventArgs e) {
        //    MovingObject = null;
        //}
        //private void MouseMove_Event(object sender, MouseEventArgs e) {
        //    if (e.LeftButton == MouseButtonState.Pressed) {
        //        (MovingObject as FrameworkElement).SetValue(Canvas.LeftProperty,
        //             e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).X - FirstXPos);

        //        (MovingObject as FrameworkElement).SetValue(Canvas.TopProperty,
        //             e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).Y - FirstYPos);
        //    }
        //}
    }
}

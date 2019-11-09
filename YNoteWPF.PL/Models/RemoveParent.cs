using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace YNoteWPF.PL.Models {
    public class RemoveParent {

        public static void RemoveElementFromItsParent(FrameworkElement el) {
            if (el.Parent == null)
                return;

            var panel = el.Parent as Panel;
            if (panel != null) {
                panel.Children.Remove(el);
                return;
            }

            var decorator = el.Parent as Decorator;
            if (decorator != null) {
                decorator.Child = null;
                return;
            }

            var contentPresenter = el.Parent as ContentPresenter;
            if (contentPresenter != null) {
                contentPresenter.Content = null;
                return;
            }

            var contentControl = el.Parent as ContentControl;
            if (contentControl != null)
                contentControl.Content = null;
        }

    }
}

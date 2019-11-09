using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YNoteWPF.PL.Addition {
    interface IMovable {
        FrameworkElement Parent { get; set; }
        double X { get; set; }
        double Y { get; set; }
    }
}

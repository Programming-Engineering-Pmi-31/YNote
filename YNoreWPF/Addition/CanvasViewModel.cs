using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace YNoreWPF.Addition {
    class CanvasViewModel: INotifyPropertyChanged {

        ObservableCollection<CustomControls.Note> _AllItems;
        public ObservableCollection<CustomControls.Note> AllItems {
            get {
                return _AllItems;
            }
            set {
                if (_AllItems != value) {
                    _AllItems = value;
                    RaisePropertyChanged("AllItems");
                }
            }
        }

        public CanvasViewModel() {
            AllItems = new ObservableCollection<CustomControls.Note>();
        }


        void RaisePropertyChanged(string prop) {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

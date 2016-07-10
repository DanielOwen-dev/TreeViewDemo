using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TreeViewDemo
{
    public class Segment : INotifyPropertyChanged
    {
        public Segment(int aNumber, ObservableCollection<Segment> p)
        {
            Number = aNumber;
            parent = p;
        }

        public int Number { get { return _Number; } set { if (_Number == value) return; _Number = value; OnPropertyChanged(nameof(Number)); } }
        private int _Number;

        public ObservableCollection<Segment> parent;

        public ObservableCollection<Condition> Conditions { get; } = new ObservableCollection<Condition>();

        private void OnPropertyChanged(string aPropertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName)); }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

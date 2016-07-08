using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TreeViewDemo
{
    public class Gesture : INotifyPropertyChanged
    {
        public Gesture( string aName, int aID )
        {
            Name = aName;
            ID = aID;
        }

        public int NumberOfSegments()
        {
            int i = 0;
            foreach(var s in Segments)
            {
                i += s.Number;
            }
            return i;
        }

        public string Name { get { return _Name; } set { if (_Name == value) return; _Name = value; OnPropertyChanged(nameof(Name)); } }
        private string _Name;

        public int ID { get { return _ID; } set { if (_ID == value) return; _ID = value; OnPropertyChanged(nameof(ID)); } }
        private int _ID;

        public ObservableCollection<Segment> Segments { get; } = new ObservableCollection<Segment>();

        private void OnPropertyChanged(string aPropertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName)); }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

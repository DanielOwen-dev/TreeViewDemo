using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TreeViewDemo
{
    public class Condition : INotifyPropertyChanged
    {
        public Condition(int aType, int aJoint0, int aJoint1, float aNumber, ObservableCollection<Condition> p)
        {
            Type = aType;
            Joint0 = aJoint0;
            Joint1 = aJoint1;
            Number = aNumber;
            parent = p;
        }

        public ObservableCollection<Condition> parent;

        public int Type { get { return _Type; } set { if (_Type == value) return; _Type = value; OnPropertyChanged(nameof(Type)); } }
        private int _Type;

        public int Joint0 { get { return _Joint0; } set { if (_Joint0 == value) return; _Joint0 = value; OnPropertyChanged(nameof(Joint0)); } }
        private int _Joint0;

        public int Joint1 { get { return _Joint1; } set { if (_Joint1 == value) return; _Joint1 = value; OnPropertyChanged(nameof(Joint1)); } }
        private int _Joint1;

        public float Number { get { return _Number; } set { if (_Number == value) return; _Number = value; OnPropertyChanged(nameof(Number)); } }
        private float _Number;

        private void OnPropertyChanged(string aPropertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName)); }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

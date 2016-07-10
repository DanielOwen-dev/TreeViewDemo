using System.Windows;
using MahApps.Metro.Controls;

namespace TreeViewDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            _Model = new DemoModel();
            this.DataContext = _Model;
        }
        private DemoModel _Model;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _Model.save();
        }

        private void tvwDatas_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int ID = _Model.Gestures.Count;
            _Model.Gestures.Add(new Gesture("New Gesture", ID, _Model.Gestures));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (tvwDatas.SelectedItem == null) { MessageBox.Show("未选择对象"); return; }

            Gesture g = tvwDatas.SelectedItem as Gesture;
            if (g != null) { g.parent.Remove(g); }

            Segment s = tvwDatas.SelectedItem as Segment;
            if (s != null) { s.parent.Remove(s); }

            Condition c = tvwDatas.SelectedItem as Condition;
            if (c != null) { c.parent.Remove(c); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (tvwDatas.SelectedItem == null) { MessageBox.Show("未选择对象"); return; }
            Gesture g = tvwDatas.SelectedItem as Gesture;
            if(g!=null)
            {
                g.Segments.Add(new Segment(0,g.Segments));
            }
            Segment s = tvwDatas.SelectedItem as Segment;
            if (s != null)
            {
                s.Conditions.Add(new Condition(0,0,0,0,s.Conditions));
            }
        }
    }
}

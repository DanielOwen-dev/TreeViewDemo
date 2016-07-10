using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

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
            try
            {
                _Model.save();
            }
            catch { this.ShowMessageAsync("错误", "保存失败"); return; }
            this.ShowMessageAsync("保存成功", ""); return;
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
            if (tvwDatas.SelectedItem == null) { this.ShowMessageAsync("错误", "未选择对象"); return; }

            Gesture g = tvwDatas.SelectedItem as Gesture;
            if (g != null) { g.parent.Remove(g); return; }

            Segment s = tvwDatas.SelectedItem as Segment;
            if (s != null) { s.parent.Remove(s); return; }

            Condition c = tvwDatas.SelectedItem as Condition;
            if (c != null) { c.parent.Remove(c); return; }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (tvwDatas.SelectedItem == null) { this.ShowMessageAsync("错误", "未选择对象"); return; }
            Gesture g = tvwDatas.SelectedItem as Gesture;
            if(g!=null)
            {
                g.Segments.Add(new Segment(0,g.Segments));
                return;
            }
            Segment s = tvwDatas.SelectedItem as Segment;
            if (s != null)
            {
                s.Conditions.Add(new Condition(0,0,0,0,s.Conditions));
                return;
            }
            this.ShowMessageAsync("错误","Condition没有添加操作");
        }
    }
}

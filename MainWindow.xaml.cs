using System.Windows;

namespace TreeViewDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
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
    }
}

using Restaurant.Common;
using Restaurant.Main;
using System.Windows;

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = ServiceProvider.Instance.GetService(typeof(IMainViewModel));
        }
    }
}

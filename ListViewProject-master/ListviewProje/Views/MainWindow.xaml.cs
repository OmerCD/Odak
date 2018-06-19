using ListviewProje.Views.UserControllers;
using System.Windows;

namespace ListviewProje.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            AnasayfaIcerik.Content = new Anasayfa();
        }
    }
}

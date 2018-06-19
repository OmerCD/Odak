using System.Windows;
using System.Windows.Controls;
using ListviewProje.Models;

namespace ListviewProje.Views.UserControllers.AnasayfaPages.BaslangicPages
{
    /// <summary>
    /// Interaction logic for adim1.xaml
    /// </summary>
    public partial class StudentView : UserControl
    {
        public StudentView()
        {
            InitializeComponent();
            StudentDAO studentDAO = new StudentDAO();
                        
        }

        private void OdayiOlustur(object sender, RoutedEventArgs e)
        {

        }
        private void KullaniciGoster(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        

        }
    }
}

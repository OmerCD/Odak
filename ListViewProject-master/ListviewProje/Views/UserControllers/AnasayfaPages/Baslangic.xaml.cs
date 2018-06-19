using System.Windows;
using System.Windows.Controls;
using ListviewProje.Classes;
using ListviewProje.Views.UserControllers.AnasayfaPages;
using ListviewProje.Views.UserControllers.AnasayfaPages.BaslangicPages;

namespace ListviewProje.Views.UserControllers.AnasayfaPages
{
    /// <summary>
    /// ucBaslangic.xaml etkileşim mantığı
    /// </summary>
    public partial class Baslangic : UserControl
    {
        PermanentTrigger permanent = new PermanentTrigger();

        public Baslangic() 
        {
            InitializeComponent();
        }


        private void StudentView(object sender, RoutedEventArgs e)
        {
            permanent.Change(dockPanel, (Button)sender);
            Icerik.Content =new StudentView();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PermanentTrigger permanent = new PermanentTrigger();
            permanent.Change(dockPanel, StudentViewButton);
            Icerik.Content = new StudentView();
        }
    }
}

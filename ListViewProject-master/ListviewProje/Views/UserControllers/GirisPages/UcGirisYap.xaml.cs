using ListviewProje.Classes;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ListviewProje.Views.UserControllers.GirisPages
{
    /// <summary>
    /// Interaction logic for UcGirisYap.xaml
    /// </summary>
    public partial class UcGirisYap : UserControl
    {
        public UcGirisYap()
        {
            InitializeComponent();
        }

        private void GirisYap_Click(object sender, RoutedEventArgs e)
        {
            //// Kullanıcı Datasını Çek ve Kontrol Et
            //var serverKullanici = new ServerKullanici
            //{
            //    KullaniciAdi = KullaniciAdi.Text,
            //    Sifre = Sifre.Password
            //};

            //var serverKullaniciData = FServerKullanici.Select(serverKullanici);

            //if (serverKullaniciData!=null)
            //{
            //    Global.AktifKullanici(serverKullaniciData);
            //    Anasayfa.Yonlendir(new UcAnasayfa());
            //}
            //else
            //{
            //    UcGiris.GirisInfo("Böyle Bir Kullanıcı Yok",false);
            //}
        }

        private void YeniUyelik_Click(object sender, RoutedEventArgs e)
        {
            Giris.Navigate(new UcYeniUyelik());
        }

        private void SifremiUnuttum_Click(object sender, RoutedEventArgs e)
        {
            Giris.Navigate(new UcYeniSifre());
        }
    }
}

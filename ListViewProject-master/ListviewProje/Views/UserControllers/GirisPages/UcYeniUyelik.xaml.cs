using ListviewProje.Classes;
using System.Windows;
using System.Windows.Controls;

namespace ListviewProje.Views.UserControllers.GirisPages
{
    /// <summary>
    /// Interaction logic for UcYeniUyelik.xaml
    /// </summary>
    public partial class UcYeniUyelik : UserControl
    {
        public UcYeniUyelik()
        {
            InitializeComponent();
        }

        private void YeniUyelik_Click(object sender, RoutedEventArgs e)
        {
            //var serverKullanici = new ServerKullanici
            //{
            //    KullaniciAdi = KullaniciAdi.Text,
            //    Sifre=Sifre.Password,
            //    Mail=MailAdresi.Text
            //};

            //var result = FServerKullanici.Insert(serverKullanici);
            //if (result>0)
            //{
            //    UcGiris.GirisInfo("Kayıt Oluşturuldu",true);
            //}
            //else
            //{
            //    UcGiris.GirisInfo("Kayıt Başarısız",true);
            //}
        }

        private void MailValidate_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool result = Validator.IsValidEmailAddress(MailAdresi.Text);
            if (!result)
            {
                Giris.GirisInfo("Lütfen doğru mail adresini formatı giriniz.",false);
            }
            else
            {
                Giris.GirisInfo("",false);
            }
        }
    }
}

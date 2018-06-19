using ListviewProje.Classes;
using System.Windows.Controls;

namespace ListviewProje.Views.UserControllers.GirisPages
{
    /// <summary>
    /// Interaction logic for UcYeniSifre.xaml
    /// </summary>
    public partial class UcYeniSifre : UserControl
    {
        public UcYeniSifre()
        {
            InitializeComponent();
        }

        private void MailText_Changed(object sender, TextChangedEventArgs e)
        {
            bool result = Validator.IsValidEmailAddress(MailTextBox.Text);
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

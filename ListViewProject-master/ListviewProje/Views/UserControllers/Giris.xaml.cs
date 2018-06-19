using ListviewProje.Views.UserControllers.GirisPages;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace ListviewProje.Views.UserControllers
{
    /// <summary>
    /// Interaction logic for Giris.xaml
    /// </summary>
    public partial class Giris : UserControl
    {
        DispatcherTimer timer;
        static Giris ucGiris;
        public Giris()
        {
            InitializeComponent();
            ucGiris = this;
            UcGirisIcerik.Content = new UcGirisYap();
        }

        public static void Navigate(UserControl userControl)
        {

            ucGiris.UcGirisIcerik.Content = userControl;
            if (userControl.GetType() == typeof(UcGirisYap))
            {
                ucGiris.NavigateButton.Visibility = Visibility.Hidden;
            }
            else
            {
                ucGiris.NavigateButton.Visibility = Visibility.Visible;
            }
        }

        private void Navigate_Click(object sender, RoutedEventArgs e)
        {
            Navigate(new UcGirisYap());
        }

        public static void GirisInfo(string text, bool result)
        {

            if (result)
            {
                ucGiris.WarningText.Foreground = (SolidColorBrush)Application.Current.FindResource("SuccessColor");
            }
            else
            {
                ucGiris.WarningText.Foreground = (SolidColorBrush)Application.Current.FindResource("WarningColor");
            }

            ucGiris.WarningText.Content = text;

            TimeSpan time = TimeSpan.FromSeconds(5);
            ucGiris.timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                if (time.Seconds <= 0)
                {
                    ucGiris.WarningText.Content = "";
                    ucGiris.timer.Stop();
                }
                time = time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
            ucGiris.timer.Start();
        }
    }
}

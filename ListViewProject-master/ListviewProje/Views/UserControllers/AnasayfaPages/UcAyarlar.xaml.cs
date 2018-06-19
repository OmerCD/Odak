using ListviewProje.Classes;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ListviewProje.Views.UserControllers.AnasayfaPages
{
    /// <summary>
    /// Interaction logic for UcAyarlar.xaml
    /// </summary>
    public partial class UcAyarlar : UserControl
    {
        public UcAyarlar()
        {
            InitializeComponent();

        }

        private new void MouseUp(object sender, MouseButtonEventArgs e)
        {
            var ellipse = (Ellipse)e.Source;
            var solidColor = (SolidColorBrush)ellipse.Fill;
            Global.ChangeColour(solidColor);
        }

        private void SkorSure_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BaslangicSure_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StaticGesturesDemos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Ellipse_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var ellipse = (sender as Ellipse);
            var color = ((SolidColorBrush)ellipse.Fill).Color;
            color.R = (byte)(255 - color.R);
            color.G = (byte)(255 - color.G);
            color.B = (byte)(255 - color.B);
            ((SolidColorBrush)ellipse.Fill).Color = color;
        }

        private void Ellipse_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var ellipse = (sender as Ellipse);
            ellipse.Width *= 2;
            ellipse.Height *= 2;
            e.Handled = true;
        }

        private void Ellipse_Holding(object sender, HoldingRoutedEventArgs e)
        {
            var ellipse = (sender as Ellipse);
            ellipse.Height = 100;
            ellipse.Width = 100;
        }
    }
}

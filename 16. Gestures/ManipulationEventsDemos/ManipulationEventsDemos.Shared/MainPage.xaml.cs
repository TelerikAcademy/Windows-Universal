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

namespace ManipulationEventsDemos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void Ellipse_ManipulationDelta(object sender,
            ManipulationDeltaRoutedEventArgs e)
        {
            var elli = sender as Ellipse;
            var delta = e.Delta;
            this.ScaleEllipse(elli, delta);
            this.RotateEllipse(elli, delta);
            this.TranslateEllipse(elli, delta);
        }

        private void TranslateEllipse(Ellipse elli, Windows.UI.Input.ManipulationDelta delta)
        {
            var translation = delta.Translation;
            var left = Canvas.GetLeft(elli) + translation.X;
            var top = Canvas.GetTop(elli) + translation.Y;

            var maxLeft = (elli.Parent as FrameworkElement).ActualWidth - elli.Width;
            var maxTop = (elli.Parent as FrameworkElement).ActualHeight - elli.Height;
            left = (left < maxLeft) ? left : maxLeft;
            left = (0 < left) ? left : 0;
            top = (top < maxTop) ? top : maxTop;
            top = (0 < top) ? top : 0;

            Canvas.SetLeft(elli, left);
            Canvas.SetTop(elli, top);

        }

        private void RotateEllipse(Ellipse elli, Windows.UI.Input.ManipulationDelta delta)
        {
            //check if rotate transform
            var oldTransform = (elli.RenderTransform as RotateTransform);
            if (oldTransform == null)
            {
                oldTransform = new RotateTransform();
            }
            var angle = oldTransform.Angle;
            angle += delta.Rotation;
            var rotateTransform = new RotateTransform();
            rotateTransform.Angle = angle;
            rotateTransform.CenterX = 150;
            rotateTransform.CenterY = 150;
            elli.RenderTransform = rotateTransform;
        }

        private void ScaleEllipse(Ellipse elli, Windows.UI.Input.ManipulationDelta delta)
        {
            var scale = delta.Scale;
            elli.Width *= scale;
            elli.Height *= scale;
        }

        private void Ellipse_ManipulationStarting(object sender, ManipulationStartingRoutedEventArgs e)
        {
            var elli = (sender as Ellipse);

            var parent = elli.Parent as Panel;
            (parent.Background as SolidColorBrush).Opacity = 0.5;
            foreach (var child in parent.Children)
            {
                if (child != elli)
                {
                    child.Opacity = 0.5;
                }
            }
        }

        private void Ellipse_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            var elli = (sender as Ellipse);

            var parent = elli.Parent as Panel;
            (parent.Background as SolidColorBrush).Opacity = 1.0;
            foreach (var child in parent.Children)
            {
                if (child != elli)
                {
                    child.Opacity = 1.0;
                }
            }
        }

        private void Ellipse_ManipulationInertiaStarting(object sender, ManipulationInertiaStartingRoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void Canvas_ManipulationStarted(object sender,
            ManipulationStartedRoutedEventArgs e)
        {
            var rect = new Rectangle();
            rect.Width = 0;
            rect.Height = 0;
            rect.Stroke = new SolidColorBrush(Colors.White);
            rect.StrokeThickness = 1.0;
            Canvas.SetLeft(rect, e.Position.X);
            Canvas.SetTop(rect, e.Position.Y);

            (sender as Canvas).Children.Add(rect);
        }

        private void Canvas_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var rect = (Shape)(sender as Canvas).Children.Last();
            rect.Width += e.Delta.Translation.X;
            rect.Height += e.Delta.Translation.Y;
        }

        private void Canvas_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            var rect = (Shape)(sender as Canvas).Children.Last();
            rect.Stroke = new SolidColorBrush(Colors.Transparent);
            rect.Fill = new SolidColorBrush(Colors.YellowGreen);
        }
    }
}

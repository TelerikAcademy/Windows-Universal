using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace AttachedBehaviorDemo.AttachedProperties
{
    public static class CanvasExtensions
    {
        public static double GetBottom(DependencyObject obj)
        {
            return (double)obj.GetValue(BottomProperty);
        }

        public static void SetBottom(DependencyObject obj, double value)
        {
            obj.SetValue(BottomProperty, value);
        }

        // Using a DependencyProperty as the backing store for Bottom.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BottomProperty =
            DependencyProperty.RegisterAttached("Bottom", 
            typeof(double), 
            typeof(object), 
            new PropertyMetadata(1.0,OnBottomChanged));

        private static void OnBottomChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Shape shape = d as Shape;
            if (shape == null)
            {
                return;
            }

            var timer = new DispatcherTimer();
            timer.Tick += (obj, args) =>
            {
                var parent = shape.Parent as Canvas;
                timer.Stop();
                var top = parent.ActualHeight - 
                    double.Parse(e.NewValue.ToString()) - 
                    shape.Height;
                Canvas.SetTop(shape, top);
            };
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Start();
        }

    }
}

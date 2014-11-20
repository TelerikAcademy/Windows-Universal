using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace AttachedProperties.AttachedProperties
{
    public class AttachedProperties
    {
        public static double GetScale(DependencyObject obj)
        {
            return (double)obj.GetValue(ScaleProperty);
        }

        public static void SetScale(DependencyObject obj, double value)
        {
            obj.SetValue(ScaleProperty, value);
        }

        // Using a DependencyProperty as the backing store for Scale.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScaleProperty =
            DependencyProperty.RegisterAttached("Scale", typeof(double), typeof(Rectangle), new PropertyMetadata(1, OnScalePropertyChanged));

        private static void OnScalePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var rect = d as Rectangle;

            if (rect == null)
            {
                return;
            }
            var scale = double.Parse(e.NewValue.ToString());
            var oldScale = double.Parse(e.OldValue.ToString());
            rect.Width = scale * rect.Width / oldScale;
            rect.Height = scale * rect.Height / oldScale;
        }
    }
}

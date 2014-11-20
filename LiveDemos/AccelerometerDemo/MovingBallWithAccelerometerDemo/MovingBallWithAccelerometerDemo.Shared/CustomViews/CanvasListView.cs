using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace MovingBallWithAccelerometerDemo.CustomViews
{
    public class CanvasListView: ListView
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            FrameworkElement contentItem = element as FrameworkElement;
            Binding leftBinding = new Binding() { Path = new PropertyPath("Position.Y") };
            Binding topBinding = new Binding() { Path = new PropertyPath("Position.X") };
            contentItem.SetBinding(Canvas.LeftProperty, leftBinding);
            contentItem.SetBinding(Canvas.TopProperty, topBinding);

            base.PrepareContainerForItemOverride(element, item);
        }
    }
}

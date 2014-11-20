using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MvvmDemos.Views
{
    public sealed partial class NewPhoneView : UserControl
    {
        public NewPhoneView()
        {
            this.InitializeComponent();
        }



        public static ICommand GetMyProperty(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(MyPropertyProperty);
        }

        public static void SetMyProperty(DependencyObject obj, ICommand value)
        {
            obj.SetValue(MyPropertyProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.RegisterAttached("MyProperty", typeof(ICommand), typeof(ownerclass), new PropertyMetadata(0));

        

        public void OnSaveButtonClick(object snd, RoutedEventArgs args)
        {
            if (this.Save == null)
            {
                return;
            }
            this.Save.Execute(null);
        }
    }
}

using ManualNavigation.Common;
using ManualNavigation.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace ManualNavigation.Views
{
    public sealed partial class MainPageContent : UserControl
    {
        public MainPageContent()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var page = this.FindPage(sender as FrameworkElement);
            if (page == null)
            {
                return;
            }
            page.Frame.Navigate(typeof(OtherPage));
        }

        private Page FindPage(FrameworkElement element)
        {
            var el = element;
            while ((el != null) && !(el is Page))
            {
                el = VisualTreeHelper.GetParent(el) as FrameworkElement;
            }
            return el as Page;
        }
    }
}

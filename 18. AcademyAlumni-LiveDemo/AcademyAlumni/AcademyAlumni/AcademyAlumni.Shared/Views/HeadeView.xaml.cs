using Parse;
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

namespace AcademyAlumni.Views
{
    public sealed partial class HeadeView : UserControl
    {
        public event EventHandler SignOut;

        public HeadeView()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        public string Username
        {
            get
            {
                return ParseUser.CurrentUser.Username;
            }
        }

        public String TitleText
        {
            get { return (String)GetValue(TitleTextProperty); }
            set { SetValue(TitleTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TitleText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleTextProperty =
            DependencyProperty.Register("TitleText", typeof(String), typeof(HeadeView), new PropertyMetadata(null));

        private void OnSignOutButtonClick(object sender, RoutedEventArgs e)
        {
            ParseUser.LogOut();
            if (this.SignOut != null)
            {
                this.SignOut(this, null);
            }
        }



    }
}

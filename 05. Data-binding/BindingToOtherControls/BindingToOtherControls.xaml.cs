using DataContext.ViewModels;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BindingToOtherControls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Person person = new Person("Dedo Kolio", 200);

        public MainPage()
        {
            this.InitializeComponent();
            this.MainGrid.DataContext = this.person;
        }

        void BirthdayButton_Click(object sender, RoutedEventArgs e)
        {
            ++person.Age;
            this.TextBlock.Text = string.Format(
                "Happy Birthday, {0}, age {1}!",
                person.Name, person.Age);

            this.TextBoxAge.Foreground = new SolidColorBrush() { Color = Colors.Red };
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AsyncProgramming
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
            this.GetData();

            //continues
            var b = 5;
        }


        //int GetData() -> async Task<int> GetDataAsync()
        //void DoStuff() -> async Task DoStuffAsyc()
        //IEnumerable<Phone> GetPhones -> async Task<IEnumerable<Phone>> GetPhonesAsync()
        private async Task GetData()
        {
            //var number = await this.GetNumberAsync();
            //return number;
            //return this.GetNumberAsync().Result;
           //return this.GetNumberAsync().ContinueWith(task =>
           // {
           //     var number = task.Result;
           //     return number;
           // }).Result;
        }

        private async Task<int> GetNumberAsync()
        {
            int count = 75000;
            for (var i = 0; i < count; i++)
            {
                for (var j = 0; j < count; j++)
                {
                    bool isTrue = false;
                }
            }
            return 5;
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

        private void OnClickButtonClick(object sender, RoutedEventArgs e)
        {
            this.DoStuffForButton();
        }

        private async Task DoStuffForButton()
        {

        }
    }
}

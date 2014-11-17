using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FutureAccessListDemo
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

#if WINDOWS_PHONE_APP
        internal async void WinPhonePickedFile(FileOpenPickerContinuationEventArgs arguments)
        {
            var file = arguments.Files.FirstOrDefault();
            if (file == null)
            {
                return;
            }

            StorageApplicationPermissions.FutureAccessList.Add(file);
            await ListPermissions();
        }
#endif

        private async void AddFileClick(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker()
            {
                FileTypeFilter = { "*" },
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };

#if WINDOWS_APP
            var file = await picker.PickSingleFileAsync();
            StorageApplicationPermissions.FutureAccessList.Add(file);
            await ListPermissions();
#elif WINDOWS_PHONE_APP
            picker.PickSingleFileAndContinue();
#endif
        }

        private async void PageLoaded(object sender, RoutedEventArgs e)
        {
            await ListPermissions();
        }

        private async Task ListPermissions()
        {
            var accessListEntries = StorageApplicationPermissions
                .FutureAccessList.Entries;

            var permissionsBuilder = new StringBuilder();

            foreach (var entry in accessListEntries)
            {
                var file = await StorageApplicationPermissions
                    .FutureAccessList.GetFileAsync(entry.Token);

                permissionsBuilder.AppendLine(entry.Token + " - " + file.Name);
            }

            PermissionsList.Text = permissionsBuilder.ToString();
        }
    }
}

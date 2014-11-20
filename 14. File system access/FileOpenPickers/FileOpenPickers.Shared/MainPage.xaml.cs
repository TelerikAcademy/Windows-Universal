using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FileOpenPickers
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

        private async void LoadFileButtonClick(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                CommitButtonText = "All done",
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                FileTypeFilter = { ".jpg", ".jpeg", ".png", ".bmp" }
            };

#if WINDOWS_PHONE_APP
            picker.PickSingleFileAndContinue();            
#elif WINDOWS_APP
            StorageFile file = await picker.PickSingleFileAsync();
            DisplayFileName(file);
#endif
        }

        private async void LoadMultipleFilesButtonClick(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.Desktop,
                FileTypeFilter = { "*" }
            };

#if WINDOWS_PHONE_APP
            picker.PickMultipleFilesAndContinue();            
#elif WINDOWS_APP
            IReadOnlyList<StorageFile> files = await picker.PickMultipleFilesAsync();
            foreach (var file in files)
            {
                DisplayFileName(file);
            }
#endif
        }
        
#if WINDOWS_PHONE_APP
        internal void WinPhonePickedFile(FileOpenPickerContinuationEventArgs arguments)
        {
            var files = arguments.Files;
            foreach (var file in files)
            {
                DisplayFileName(file);
            }
        }
#endif

        private void DisplayFileName(StorageFile file)
        {
            if (file == null)
            {
                return;
            }

            this.TextBlockList.Text += file.Name + Environment.NewLine;
        }
    }
}

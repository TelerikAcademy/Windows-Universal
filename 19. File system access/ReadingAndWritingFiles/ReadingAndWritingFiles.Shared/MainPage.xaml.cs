using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ReadingAndWritingFiles
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private StorageFile fileToUse = null;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private async void PickFileForDemoClick(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker()
            {
                FileTypeFilter = { ".txt" },
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };

#if WINDOWS_PHONE_APP
            picker.PickSingleFileAndContinue();
#elif WINDOWS_APP
            fileToUse = await picker.PickSingleFileAsync();
#endif
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
        internal async void WinPhonePickedFile(FileOpenPickerContinuationEventArgs args)
        {
            fileToUse = args.Files.FirstOrDefault();
        }
#endif

        private async void WriteToFileClick(object sender, RoutedEventArgs e)
        {
            var text = TextInput.Text;

            if (fileToUse != null)
            {
                try
                {
                    if (OverwriteCheckBox.IsChecked == true)
                    {
                        await FileIO.WriteTextAsync(fileToUse, text);
                    }
                    else
                    {
                        await FileIO.AppendTextAsync(fileToUse, text);
                    }

                    await new Windows.UI.Popups.MessageDialog("Text successfully written to file").ShowAsync();
                }
                catch (Exception)
                {
                    new Windows.UI.Popups.MessageDialog("Something went wrong").ShowAsync();
                    throw;
                }
            }
        }

        private async void ReadFromFileClick(object sender, RoutedEventArgs e)
        {
            if (fileToUse != null)
            {
                try
                {
                    var text = await FileIO.ReadTextAsync(fileToUse);
                    FileContents.Text = text;
                }
                catch (Exception)
                {
                    new Windows.UI.Popups.MessageDialog("Something went wrong").ShowAsync();
                }
            }
        }
    }
}

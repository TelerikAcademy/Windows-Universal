using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace FileSavePickers
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

        private async void SaveToFileButton(object sender, RoutedEventArgs e)
        {
            FileSavePicker savePicker = new FileSavePicker()
            {
                SuggestedFileName = string.Format("TextDocument-{0}", DateTime.Now.ToString("dd-MMM-yyyy")),
                FileTypeChoices =
                {
                    { "Plain text", new List<string>{ ".txt" }},
                    { "Web Page", new List<string>{ ".html", ".htm" }}
                },
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                CommitButtonText = "Save my text document"
            };

#if WINDOWS_APP
            StorageFile saveFile = await savePicker.PickSaveFileAsync();
            await SaveTextFile(saveFile);
#elif WINDOWS_PHONE_APP
            savePicker.PickSaveFileAndContinue();
#endif
        }

#if WINDOWS_PHONE_APP
        internal async void WinPhonePickedFile(FileSavePickerContinuationEventArgs arguments)
        {
            var file = arguments.File;
            if (file == null)
            {
                return;
            }

            await SaveTextFile(file);
        }
#endif

        private async Task SaveTextFile(StorageFile saveFile)
        {
            if (saveFile == null)
            {
                return;
            }

            string result = TextBoxInput.Text;
            if (saveFile.DisplayType == "Web Page")
            // ( saveFile.FileType == ".html" || saveFile.FileType == ".htm")
            {
                result = string.Format("<html><head><title>Saved By FileSavePicker</title></head><body><p>{0}</p></body>", result);
            }

            await Windows.Storage.FileIO.WriteTextAsync(saveFile, result);
            await new Windows.UI.Popups.MessageDialog("File Saved!").ShowAsync();
        }
    }
}

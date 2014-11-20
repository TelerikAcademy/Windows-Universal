using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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

namespace FolderPickers
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

        private async void OpenFolderClick(object sender, RoutedEventArgs e)
        {
            var picker = new FolderPicker()
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                FileTypeFilter = { "*" },
            };

#if WINDOWS_APP
            var folder = await picker.PickSingleFolderAsync();
            DisplayFolderInfo(folder);
#elif WINDOWS_PHONE_APP
            picker.PickFolderAndContinue();
#endif
        }

#if WINDOWS_PHONE_APP
        internal void WinPhonePickedFolder(FolderPickerContinuationEventArgs args)
        {
            var folder = args.Folder;
            DisplayFolderInfo(folder);
        }
#endif

        private async void DisplayFolderInfo(StorageFolder folder)
        {
            if (folder == null)
            {
                return;
            }

            var folderInfo = new StringBuilder();
            folderInfo.AppendLine(string.Format("Folder name: {0}", folder.Name));

            folderInfo.AppendLine(string.Format("Files:"));
            var files = await folder.GetFilesAsync();
            foreach (var file in files)
            {
                folderInfo.AppendLine(file.Name);
            }

            this.TextBlockFolderInfo.Text = folderInfo.ToString();
        }
    }
}

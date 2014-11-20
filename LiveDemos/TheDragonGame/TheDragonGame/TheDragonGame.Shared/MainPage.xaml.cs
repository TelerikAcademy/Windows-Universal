using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TheDragonGame.ViewModels;
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

namespace TheDragonGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private MainPageViewModel viewModel;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.ViewModel = new MainPageViewModel(0, 0);
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

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            this.ViewModel.Width = this.ActualWidth;
            this.ViewModel.Height = this.ActualHeight;
            this.ViewModel.StartGame();

            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Tick += (snd, args) =>
            //{
            //    (this.DataContext as MainPageViewModel).StartGame();
            //};

            //timer.Interval = TimeSpan.FromSeconds(2);
            //timer.Start();
        }

        private void OnPageManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var delta = e.Delta;
            var translationDelta = delta.Translation;

            this.ViewModel.MovePlayer(translationDelta.Y);
        }

        public MainPageViewModel ViewModel
        {
            get
            {
                return this.viewModel;
            }
            set
            {
                this.viewModel = value;
                this.DataContext = this.viewModel;
            }
        }

        private void OnPageTapped(object sender, TappedRoutedEventArgs e)
        {
            this.ViewModel.PlayeAttack();
        }

        private void OnPageHolding(object sender, HoldingRoutedEventArgs e)
        {
            this.ViewModel.PlayerUltraAttack();
        }

        private void Page_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (this.ContiniusFireTimer == null)
            {
                this.ContiniusFireTimer = new DispatcherTimer();
                this.ContiniusFireTimer.Interval = TimeSpan.FromMilliseconds(500);
                this.ContiniusFireTimer.Tick += (snd, args) =>
                {
                    this.ViewModel.PlayeAttack();
                };
            }
            if (this.ContiniusFireTimer.IsEnabled)
            {
                this.ContiniusFireTimer.Stop();
            }

            this.ContiniusFireTimer.Start();
        }

        private void Page_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (this.ContiniusFireTimer == null)
            {
                return;
            }
            this.ContiniusFireTimer.Stop();
        }

        public DispatcherTimer ContiniusFireTimer { get; set; }
    }
}

using MovingBallWithAccelerometerDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Sensors;
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

namespace MovingBallWithAccelerometerDemo
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

            var appVM = new AppViewModel();
            this.DataContext = appVM;

            this.Accelerometer = Accelerometer.GetDefault();

            this.Accelerometer.ReportInterval = 10;

            this.Accelerometer.ReadingChanged += (snd, args) =>
            {
                var dx = args.Reading.AccelerationX;
                var dy = args.Reading.AccelerationY;
                var dz = args.Reading.AccelerationZ;

                this.Dispatcher.RunAsync((Windows.UI.Core.CoreDispatcherPriority.Normal), () =>
                {
                    appVM.MoveBallsWithDelta(dz, dx);
                });
            };

            this.Accelerometer.Shaken += (snd, args) =>
            {
                var b = 65;
            };

            //Window.Current.SizeChanged += (snd, args) =>
            //{
            //    appVM.Width = args.Size.Height;
            //    appVM.Height = args.Size.Width;
            //};

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

        public Accelerometer Accelerometer { get; set; }

        private void rootPanel_Loaded(object sender, RoutedEventArgs e)
        {
            var panel = sender as Panel;

            (this.DataContext as AppViewModel).Width = panel.ActualWidth;
            (this.DataContext as AppViewModel).Height = panel.ActualHeight;
        }

        //private void rootPanel_Loaded(object sender, RoutedEventArgs e)
        //{
        //    //var panel = sender as Panel;
        //    //var width = panel.ActualWidth;
        //    //var height = panel.ActualHeight;
        //    var appVM = new AppViewModel(height, width);
        //    this.DataContext = appVM;

        //    this.Accelerometer = Accelerometer.GetDefault();

        //    this.Accelerometer.ReportInterval = 10;

        //    this.Accelerometer.ReadingChanged += (snd, args) =>
        //    {
        //        var dx = args.Reading.AccelerationX;
        //        var dy = args.Reading.AccelerationY;
        //        var dz = args.Reading.AccelerationZ;

        //        this.Dispatcher.RunAsync((Windows.UI.Core.CoreDispatcherPriority.Normal), () =>
        //        {
        //            appVM.MoveBallsWithDelta(dz, dx);
        //        });
        //    };
        //}

        public OrientationSensor OrientSensor { get; set; }
    }
}

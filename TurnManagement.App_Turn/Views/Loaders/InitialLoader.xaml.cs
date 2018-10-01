using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace TurnManagement.App_Turn.Views.Loaders
{
    /// <summary>
    /// Interaction logic for InitialLoader.xaml
    /// </summary>
    public partial class InitialLoader : Window
    {
        public InitialLoader()
        {
            InitializeComponent();

            //// Create a thread
            //Thread newWindowThread = new Thread(new ThreadStart(() =>
            //{
            //    LogWindow mainWindow = new LogWindow();

            //    mainWindow.Loaded += (sender, args) =>
            //    {
            //        Application.Current.Dispatcher.Invoke(new Action(() =>
            //        {
            //            this.Close();
            //        }));
            //    };

            //    // When the window closes, shut down the dispatcher
            //    mainWindow.Closed += (s, e) =>
            //       Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Inactive);

            //    mainWindow.Show();
            //    // Start the Dispatcher Processing
            //    Dispatcher.Run();
            //}));

            //newWindowThread.SetApartmentState(ApartmentState.STA);
            //// Make the thread a background thread
            //newWindowThread.IsBackground = false;
            //// Start the thread
            //newWindowThread.Start();
        }
    }
}

using System;
using System.Threading;
using System.Windows;

namespace TurnManagement.App_Turn.Controls
{
    public class BaseLogControl : Window
    {
        private Views.Loaders.InitialLoader initialLoader { get; set; } = new Views.Loaders.InitialLoader();

        private Thread initialLoaderThread { get; set; } = null;

        [STAThread]
        protected Thread ShowInitialLoader()
        {
            try
            {
                initialLoaderThread = new Thread(delegate ()
                {
                    initialLoader = new Views.Loaders.InitialLoader();
                    initialLoader.Show();

                    //viewer.Closed += (sender2, e2) => viewer.Dispatcher.InvokeShutdown();

                    System.Windows.Threading.Dispatcher.Run();
                });

                initialLoaderThread.SetApartmentState(ApartmentState.STA); // needs to be STA or throws exception
                initialLoaderThread.Start();

                System.Threading.Tasks.Task.Delay(3000);

                return initialLoaderThread;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                //abortado de Thread
            }

            return initialLoaderThread;
        }

        [STAThread]
        protected void CloseLoader()
        {
            try
            {
                initialLoaderThread.Abort();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                //Abort Exception from Thread Loader
            }
        }
    }
}

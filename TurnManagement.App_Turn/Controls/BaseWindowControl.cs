using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TurnManagement.App_Turn.ViewModel.Base;
using TurnManagement.App_Turn.Views;

namespace TurnManagement.App_Turn.Controls
{
    public class BaseWindowControl : Window
    {
        #region Private Members

        /// <summary>
        /// The window we will be contained within
        /// </summary>
        private MainWindow mainWindow;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseWindowControl()
        {
            // Create a new page window
            mainWindow = new MainWindow();
        }

        #region Public Dialog Show Methods

        /// <summary>
        /// Displays a Page
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <typeparam name="T">The view model type for this control</typeparam>
        /// <returns></returns>
        public void ShowMainWindowPage<T>(T viewModel)
            where T : BaseViewModel
        {
            // Run on UI thread
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    // Setup this controls data context binding to the view model
                    mainWindow.DataContext = viewModel;

                    // Show in the center of the parent
                    mainWindow.Owner = Application.Current.MainWindow;
                    mainWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                    // Show Page
                    mainWindow.Show();
                }
                finally
                {
                    // Close the previous windows
                    var logWindow = Application.Current.Windows.OfType<LogWindow>().FirstOrDefault();
                    logWindow.Hide();
                }
            });
        }

        #endregion
    }
}

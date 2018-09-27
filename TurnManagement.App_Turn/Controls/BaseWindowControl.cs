using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TurnManagement.App_Turn.ViewModel.Base;
using TurnManagement.App_Turn.Views;
using TurnManagement.App_Turn.Views.Dialogs;
using TurnManagement.App_Turn.Views.Manager;
using TurnManagement.App_Turn.Views.Turns;
using TurnManagement.CrossCutting.Enumerations;

namespace TurnManagement.App_Turn.Controls
{
    public class BaseWindowControl : Window
    {
        #region Private Windows Members

        /// <summary>
        /// The window we will be contained within
        /// </summary>
        private MainWindow mainWindow;

        /// <summary>
        /// The window for New Turns
        /// </summary>
        private TurnView turnWindow;

        /// <summary>
        /// The window for Patients Manager
        /// </summary>
        private PatientsManagerView patientsWindow;

        /// <summary>
        /// The window for Patients Manager
        /// </summary>
        private ProfessionalsManagerView professionalsWindow;

        /// <summary>
        /// The window for Patients Manager
        /// </summary>
        private SpecialitiesManagerView specialitiesWindow;

        /// <summary>
        /// The Input Dialog Box
        /// </summary>
        private InputDialogBox inputDialogBox;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseWindowControl()
        {
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

        /// <summary>
        /// Displays a Modal Windo Page
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <typeparam name="T">The view model type for this control</typeparam>
        /// <returns></returns>
        public async Task<bool> ShowModalWindowPage<T>(ApplicationPage pageToOpen, T viewModel)
            where T : BaseViewModel
        {
            // Create a task to await the dialog closing
            var tcs = new TaskCompletionSource<bool>();

            // Run on UI thread
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    switch (pageToOpen)
                    {
                        case ApplicationPage.Turns:
                            //Instancio mi nueva ventana
                            turnWindow = new TurnView();
                            turnWindow.DataContext = viewModel;
                            turnWindow.Owner = Application.Current.MainWindow;
                            // Show dialog
                            turnWindow.ShowDialog();
                            break;
                        case ApplicationPage.Patients:
                            patientsWindow = new PatientsManagerView();
                            patientsWindow.DataContext = viewModel;
                            patientsWindow.Owner = Application.Current.MainWindow;
                            // Show dialog
                            patientsWindow.ShowDialog();
                            break;
                        case ApplicationPage.Professionals:
                            professionalsWindow = new ProfessionalsManagerView();
                            professionalsWindow.DataContext = viewModel;
                            professionalsWindow.Owner = Application.Current.MainWindow;
                            // Show dialog
                            professionalsWindow.ShowDialog();
                            break;
                        case ApplicationPage.Specialitys:
                            specialitiesWindow = new SpecialitiesManagerView();
                            specialitiesWindow.DataContext = viewModel;
                            specialitiesWindow.Owner = Application.Current.MainWindow;
                            // Show dialog
                            specialitiesWindow.ShowDialog();
                            break;
                        case ApplicationPage.inputDialogBox:
                            inputDialogBox = new InputDialogBox();
                            inputDialogBox.DataContext = viewModel;
                            inputDialogBox.Owner = Application.Current.MainWindow;

                            inputDialogBox.ShowDialog();
                            break;
                        default:
                            break;
                    }
                }
                catch (System.Exception)
                {
                    
                }
                finally
                {
                    // Let caller know we finished
                    tcs.TrySetResult(true);
                }

                return true;
            });

            return await tcs.Task;
        }

        #endregion
    }
}

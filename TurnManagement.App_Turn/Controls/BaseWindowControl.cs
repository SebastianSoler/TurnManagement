using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TurnManagement.App_Turn.ViewModel.Base;
using TurnManagement.App_Turn.Views;
using TurnManagement.App_Turn.Views.Dialogs;
using TurnManagement.App_Turn.Views.Loaders;
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
        private TurnManagerView turnWindow;

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

        /// <summary>
        /// The Mesage Dialog Box
        /// </summary>
        private MessageDialogBox messageDialogBox;

        /// <summary>
        /// The Edit Patient Dialog Box
        /// </summary>
        private EditPatientDialogBox editPatientDialogBox;

        /// <summary>
        /// The Edit Professional Dialog Box
        /// </summary>
        private EditProfessionalDialogBox editProfessionalDialogBox;

        /// <summary>
        /// The Waiting Loader Box
        /// </summary>
        private WaitingLoader waitingLoader;

        private Thread waitingLoaderThread { get; set; } = null;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseWindowControl()
        {
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

            mainWindow = new MainWindow();

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
                            //New window Instance
                            turnWindow = new TurnManagerView();
                            turnWindow.DataContext = viewModel;
                            turnWindow.Owner = Application.Current.MainWindow;
                            // Show dialog
                            turnWindow.ShowDialog();
                            break;
                        case ApplicationPage.Patients:
                            patientsWindow = new PatientsManagerView();
                            patientsWindow.DataContext = viewModel;
                            patientsWindow.Owner = Application.Current.MainWindow;
                            patientsWindow.ShowDialog();
                            break;
                        case ApplicationPage.Professionals:
                            professionalsWindow = new ProfessionalsManagerView();
                            professionalsWindow.DataContext = viewModel;
                            professionalsWindow.Owner = Application.Current.MainWindow;
                            professionalsWindow.ShowDialog();
                            break;
                        case ApplicationPage.Specialitys:
                            specialitiesWindow = new SpecialitiesManagerView();
                            specialitiesWindow.DataContext = viewModel;
                            specialitiesWindow.Owner = Application.Current.MainWindow;
                            specialitiesWindow.ShowDialog();
                            break;
                        case ApplicationPage.InputDialogBox:
                            inputDialogBox = new InputDialogBox();
                            inputDialogBox.DataContext = viewModel;
                            inputDialogBox.Owner = Application.Current.MainWindow;
                            inputDialogBox.ShowDialog();
                            break;
                        case ApplicationPage.MessageDialogBox:
                            messageDialogBox = new MessageDialogBox();
                            messageDialogBox.DataContext = viewModel;
                            messageDialogBox.Owner = Application.Current.MainWindow;
                            messageDialogBox.ShowDialog();
                            break;
                        case ApplicationPage.EditPatientDialogBox:
                            editPatientDialogBox = new EditPatientDialogBox();
                            editPatientDialogBox.DataContext = viewModel;
                            editPatientDialogBox.Owner = Application.Current.MainWindow;
                            editPatientDialogBox.ShowDialog();
                            break;
                        case ApplicationPage.EditProfessionalDialogBox:
                            editProfessionalDialogBox = new EditProfessionalDialogBox();
                            editProfessionalDialogBox.DataContext = viewModel;
                            editProfessionalDialogBox.Owner = Application.Current.MainWindow;
                            editProfessionalDialogBox.ShowDialog();
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

        [STAThread]
        public Thread ShowWaitingLoader()
        {
            try
            {
                waitingLoaderThread = new Thread(new ThreadStart(delegate ()
                {
                    waitingLoader = new WaitingLoader();
                    waitingLoader.Show();

                    waitingLoader.Closed += (sender2, e2) => waitingLoader.Dispatcher.InvokeShutdown();

                    System.Windows.Threading.Dispatcher.Run();
                }));

                waitingLoaderThread.SetApartmentState(ApartmentState.STA); // needs to be STA or throws exception
                waitingLoaderThread.IsBackground = true;
                waitingLoaderThread.Start();

                Task.Delay(3000);

                return waitingLoaderThread;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                //abortado de Thread
            }

            return waitingLoaderThread;
        }

        [STAThread]
        public void CloseWaitingLoader()
        {
            try
            {
                waitingLoaderThread.Abort();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                //Abort Exception from Thread Loader
            }
        }

        #endregion
    }
}

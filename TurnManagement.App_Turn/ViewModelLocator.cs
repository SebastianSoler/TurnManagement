using CommonServiceLocator;
using TurnManagement.App_Turn.App_Start;
using TurnManagement.App_Turn.ViewModel;
using TurnManagement.App_Turn.ViewModel.Dialogs;
using Unity.ServiceLocation;

namespace TurnManagement.App_Turn
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            var unityContainer = UnityConfig.GetConfiguredContainer();

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unityContainer));
        }

        #region GetInstances ViewModels 

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        public LoginViewModel LoginViewModel => ServiceLocator.Current.GetInstance<LoginViewModel>();

        //public MessageBoxDialogViewModel MessageBoxDialogViewModel => ServiceLocator.Current.GetInstance<MessageBoxDialogViewModel>();

        public MessageDialogBoxViewModel MessageDialogBoxViewModel => ServiceLocator.Current.GetInstance<MessageDialogBoxViewModel>();

        public InputDialogBoxViewModel InputDialogBoxViewModel => ServiceLocator.Current.GetInstance<InputDialogBoxViewModel>();

        #endregion

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
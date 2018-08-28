using System;
using System.Threading.Tasks;
using TurnManagement.App_Turn.ViewModel.Base;
using TurnManagement.CrossCutting.Enumerations;

namespace TurnManagement.App_Turn.ViewModel.Application
{
    /// <summary>
    /// The application state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        /// <summary>
        /// The view model to use for the current page when the CurrentPage changes
        /// NOTE: This is not a live up-to-date view model of the current page
        ///       it is simply used to set the view model of the current page 
        ///       at the time it changes
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; }

        #endregion
        
        /// <summary>
        /// Handles what happens when we have successfully logged in
        /// </summary>
        public void HandleSuccessfulLogin()
        {
            // Go to Main page
            DI.DI.ViewModelApplication.SetCurrentPage(ApplicationPage.Main);
        }

        /// <summary>
        /// Navigates to the Main page
        /// </summary>
        /// <param name="page">The page to go to</param>
        /// <param name="viewModel">The view model, if any, to set explicitly to the new page</param>
        public async Task ShowModalPage(ApplicationPage page, BaseViewModel baseViewModel)
        {                    
            // Set the view model
            CurrentPageViewModel = baseViewModel;
            // Set the current page
            CurrentPage = page;

            //Lanzo la apertura del nuevo Modal
            await DI.DI.UI.ShowModalPage(page, baseViewModel);
        }

        /// <summary>
        /// Navigates to the Main page
        /// </summary>
        /// <param name="page">The page to go to</param>
        /// <param name="viewModel">The view model, if any, to set explicitly to the new page</param>
        private void SetCurrentPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            // Set the view model
            CurrentPageViewModel = viewModel;

            // Set the current page
            CurrentPage = page;

            //Enviar a Pagina que viene por parametro.[viewModel]
            var mainVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<MainViewModel>();

            DI.DI.UI.ShowPage(mainVM);

        }
    }
}
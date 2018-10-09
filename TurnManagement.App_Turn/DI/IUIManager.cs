using System.Threading;
using System.Threading.Tasks;
using TurnManagement.App_Turn.ViewModel.Base;
using TurnManagement.CrossCutting.Enumerations;

namespace TurnManagement.App_Turn.DI
{
    /// <summary>
    /// The UI manager that handles any UI interaction in the application
    /// </summary>
    public interface IUIManager
    {
        /// <summary>
        /// Displays a Main Page
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        void ShowPage(BaseViewModel mainViewModel);

        /// <summary>
        /// Displays a Modal Page
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        Task<bool> ShowModalPage(ApplicationPage page, BaseViewModel mainViewModel);

        //Display a Waiting Loeader
        Thread ShowWaitingLoader();

        void CloseWaitingLoader();
    }
}

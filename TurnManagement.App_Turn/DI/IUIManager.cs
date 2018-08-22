using System.Threading.Tasks;
using TurnManagement.App_Turn.ViewModel.Base;
using TurnManagement.App_Turn.ViewModel.Dialogs;

namespace TurnManagement.App_Turn.DI
{
    /// <summary>
    /// The UI manager that handles any UI interaction in the application
    /// </summary>
    public interface IUIManager
    {
        /// <summary>
        /// Displays a single message box to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        Task ShowMessage(MessageBoxDialogViewModel viewModel);

        /// <summary>
        /// Displays a Main Page
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        void ShowPage(BaseViewModel mainViewModel);
    }
}

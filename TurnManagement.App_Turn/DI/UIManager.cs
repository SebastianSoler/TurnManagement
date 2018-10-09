using System.Threading.Tasks;
using TurnManagement.App_Turn.Controls;
using TurnManagement.App_Turn.ViewModel.Base;
using TurnManagement.CrossCutting.Enumerations;

namespace TurnManagement.App_Turn.DI
{
    // <summary>
    /// The applications implementation of the <see cref="IUIManager"/>
    /// </summary>
    public class UIManager : IUIManager
    {
        private static BaseWindowControl baseWindowLoaderControl;

        //private 

        /// <summary>
        /// Displays some Modal Page
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        public Task<bool> ShowModalPage(ApplicationPage page, BaseViewModel viewModel)
        {
            return new BaseWindowControl().ShowModalWindowPage(page, viewModel);
        }

        /// <summary>
        /// Displays a Main Page
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        public void ShowPage(BaseViewModel mainViewModel)
        {
            new BaseWindowControl().ShowMainWindowPage(mainViewModel);
        }

        /// <summary>
        /// Displays a Waiting Loader Box
        /// </summary>
        public System.Threading.Thread ShowWaitingLoader()
        {
            baseWindowLoaderControl = new BaseWindowControl();

            return baseWindowLoaderControl.ShowWaitingLoader();
        }

        /// <summary>
        /// Close a Waiting Loader Box
        /// </summary>
        public void CloseWaitingLoader()
        {
            baseWindowLoaderControl.CloseWaitingLoader();
        }
    }
}

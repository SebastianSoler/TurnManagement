﻿using System.Threading.Tasks;
using TurnManagement.App_Turn.ViewModel.Dialogs;
using TurnManagement.App_Turn.Views.Dialogs;

namespace TurnManagement.App_Turn.DI
{
    // <summary>
    /// The applications implementation of the <see cref="IUIManager"/>
    /// </summary>
    public class UIManager : IUIManager
    {
        /// <summary>
        /// Displays a single message box to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            return new DialogMessageBox().ShowDialog(viewModel);
        }
    }
}
using System.Threading.Tasks;
using TurnManagement.App_Turn.ViewModel.Dialogs;

namespace TurnManagement.App_Turn.Controls.Checks
{
    public static class CheckDisplayMessage
    {
        /// <summary>
        /// Checks the message result for any errors, displaying them if there are any
        /// </summary>
        /// <param name="message">The response to check</param>
        /// <param name="title">The title of the error dialog if there is an error</param>
        /// <returns>Returns true if there was an error, or false if all was OK</returns>
        public static async Task<bool> DisplayMessageBox(string title, string message)
        {
            // Display error
            await DI.DI.UI.ShowMessage(new MessageBoxDialogViewModel(message)
            {
                // TODO: Localize strings
                Title = title
            });

            // Return that we had an error
            return true;
        }
    }
}

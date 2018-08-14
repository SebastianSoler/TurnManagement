namespace TurnManagement.App_Turn.ViewModel.Base
{
    /// <summary>
    /// A base view model for any dialogs
    /// </summary>
    public class BaseDialogViewModel : BaseViewModel
    {
        /// <summary>
        /// The title of the dialog
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The message of the dialog
        /// </summary>
        public string Message { get; set; }
    }
}

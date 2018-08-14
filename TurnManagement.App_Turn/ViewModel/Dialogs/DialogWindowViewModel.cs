using System.Windows;
using System.Windows.Controls;

namespace TurnManagement.App_Turn.ViewModel.Dialogs
{
    /// <summary>
    /// The View Model for the custom flat window
    /// </summary>
    public class DialogWindowViewModel
    {
        #region Public Properties

        /// <summary>
        /// The title of this dialog window
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The Message of this dialog window
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The content to host inside the dialog
        /// </summary>
        public Control Content { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DialogWindowViewModel(Window window)
        {
        }

        #endregion
    }
}

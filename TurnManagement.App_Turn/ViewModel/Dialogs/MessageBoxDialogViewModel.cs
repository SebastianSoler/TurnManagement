using System.Windows.Controls;
using TurnManagement.App_Turn.ViewModel.Base;

namespace TurnManagement.App_Turn.ViewModel.Dialogs
{
    public class MessageBoxDialogViewModel : BaseDialogViewModel
    {
        public Control Content { get; set; }

        public MessageBoxDialogViewModel(string message)
        {
            Message = message;
        }
    }
}

using TurnManagement.App_Turn.ViewModel.Base;

namespace TurnManagement.App_Turn.ViewModel.Dialogs
{
    public class MessageDialogBoxViewModel : BaseDialogViewModel
    {
        public MessageDialogBoxViewModel(string title, string message)
        {
            Message = message;
            Title = title;
        }
    }
}

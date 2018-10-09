using TurnManagement.App_Turn.ViewModel.Base;

namespace TurnManagement.App_Turn.ViewModel.Dialogs
{
    public class InputDialogBoxViewModel: BaseDialogViewModel
    {
        public string OldName { get; private set; }

        public string NewName { get; set; } = string.Empty;

        public InputDialogBoxViewModel(string oldName)
        {
            OldName = oldName;
            NewName = string.Empty;
            //Title = GeneralMessages.SpecialitiesManagerTittle;
        }
    }
}

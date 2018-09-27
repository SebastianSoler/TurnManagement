using TurnManagement.App_Turn.ViewModel.Base;
using TurnManagement.CrossCutting.Strings;

namespace TurnManagement.App_Turn.ViewModel.Dialogs
{
    public class InputDialogBoxViewModel: BaseDialogViewModel
    {
        public string OldSpecialityName { get; private set; }

        public string NewSpecialityName { get; set; } = string.Empty;

        public InputDialogBoxViewModel(string oldName)
        {
            OldSpecialityName = oldName;
            NewSpecialityName = string.Empty;
            Title = GeneralMessages.SpecialitiesManagerTittle;
        }
    }
}

using System.ComponentModel;

namespace TurnManagement.CrossCutting.Enumerations
{
    public enum Status
    {
        [Description("Acordado")]
        Agreed = 1,

        [Description("Cancelado")]
        Canceled = 2,

        [Description("Suspendido")]
        Suspended = 3,

        [Description("A Confirmar")]
        ToConfirm = 4
    }
}

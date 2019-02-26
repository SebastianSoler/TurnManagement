using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Scheduling;

namespace TurnManagement.App_Turn.Styles
{
    public class NewAppointmentInitConverter : EventArgsConverterBase<AppointmentItemEventArgs>
    {
        protected override object Convert(object sender, AppointmentItemEventArgs args)
        {
            args.Appointment.LabelId = 1;
            args.Appointment.Reminders.Clear();
            return args;
        }
    }
}

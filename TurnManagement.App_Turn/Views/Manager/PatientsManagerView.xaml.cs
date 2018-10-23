using DevExpress.Xpf.Ribbon;

namespace TurnManagement.App_Turn.Views.Manager
{
    public partial class PatientsManagerView : DXRibbonWindow
    {
        public PatientsManagerView()
        {
            InitializeComponent();
        }

        private void btnAgregar_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            txtPatientName.Text = string.Empty;
            txtPatientSurName.Text = string.Empty;
            txtPatientDni.Text = string.Empty;
            txtPatientGenre.Text = string.Empty;
            txtPatientAddress.Text = string.Empty;
            cldrPatientDateOfB.Text = string.Empty;
            txtPatientHInsurance.Text = string.Empty;
            txtPatientPlan.Text = string.Empty;
            txtPatientEmail.Text = string.Empty;
            txtPatientCellPhone.Text = string.Empty;
            txtPatientNote.Text = string.Empty;
            listViewPatients.Focus();
        }
    }
}

using DevExpress.Xpf.Ribbon;

namespace TurnManagement.App_Turn.Views.Manager
{
    public partial class ProfessionalsManagerView : DXRibbonWindow
    {
        public ProfessionalsManagerView()
        {
            InitializeComponent();
        }

        private void SaveAndCloseProfessionals(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnAgregar_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            txtProfessionalName.Text = string.Empty;
            txtProfessionalSurnName.Text = string.Empty;
            txtProfessionalDni.Text = string.Empty;
            txtProfessionalGenre.Text = string.Empty;
            txtProfessionalAddress.Text = string.Empty;
            cldrProfessionalDateOfB.Text = string.Empty;
            txtProfessionalEmail.Text = string.Empty;
            txtProfessionalCellPhone.Text = string.Empty;
            txtProfessionalNote.Text = string.Empty;

            listViewProfessionals.Focus();
        }
    }
}

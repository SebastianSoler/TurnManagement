using DevExpress.Xpf.Ribbon;

namespace TurnManagement.App_Turn.Views.Manager
{
    public partial class SpecialitiesManagerView : DXRibbonWindow
    {
        public SpecialitiesManagerView()
        {
            InitializeComponent();
        }

        private void PostAddSpeciality_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            txtSpecialityName.Text = string.Empty;
            listViewSpecialities.Focus();
        }

        private void txtSpecialityName_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            txtSpecialityName.SelectAll();
        }

        private void SaveAndCloseSpecialities(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}

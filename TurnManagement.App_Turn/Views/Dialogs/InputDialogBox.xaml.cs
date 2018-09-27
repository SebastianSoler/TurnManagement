using System.Windows;

namespace TurnManagement.App_Turn.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for InputDialogBox.xaml
    /// </summary>
    public partial class InputDialogBox : Window
    {
        public InputDialogBox()
        {
            InitializeComponent();
        }

        private void ShotDownPage(object sender, RoutedEventArgs e)
        {
            Close();
            //Application.Current.MainWindow.DialogResult
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtNewSpecialityName.Focus();
        }

        private void ConfirmModified(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewSpecialityName.Text))
            {
                Close();
            }
            else
            {
                MessageBox.Show("El campo no puede ser Vacio", "Validacion de Campos", MessageBoxButton.OK, MessageBoxImage.Information);
                txtNewSpecialityName.Focus();
            }
        }
    }
}

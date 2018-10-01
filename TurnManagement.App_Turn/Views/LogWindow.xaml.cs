using System.Windows;
using TurnManagement.App_Turn.Controls;

namespace TurnManagement.App_Turn.Views
{
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : BaseLogControl
    {
        public LogWindow()
        {
            ShowInitialLoader();

            InitializeComponent();

            CloseLoader();
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ShutDown(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void UserLoginPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModel.LoginViewModel loginViewModel)
            {
                loginViewModel.PasswordPlainText = txtPassword.Password;
            }
        }

        private void LostFocusButton(object sender, RoutedEventArgs e)
        {
            txtUser.Text = string.Empty;
            txtPassword.Clear();
            txtUser.Focus();
        }

        private void Log_Initialized(object sender, System.EventArgs e)
        {
            txtUser.Focus();
        }
    }
}

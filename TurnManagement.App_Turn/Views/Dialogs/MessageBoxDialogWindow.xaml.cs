using System.Windows;
using System.Windows.Input;

namespace TurnManagement.App_Turn.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for MessageBoxDialogWindow.xaml
    /// </summary>
    public partial class MessageBoxDialogWindow : Window
    {
        public MessageBoxDialogWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ShutDown(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

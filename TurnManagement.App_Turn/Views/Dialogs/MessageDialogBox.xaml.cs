using System.Windows;
using System.Windows.Input;

namespace TurnManagement.App_Turn.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for MessageBoxDialogWindow.xaml
    /// </summary>
    public partial class MessageDialogBox : Window
    {
        public MessageDialogBox()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ShutDown(object sender, RoutedEventArgs e)
        {
            Close();
            //Application.Current.Shutdown();
        }
    }
}

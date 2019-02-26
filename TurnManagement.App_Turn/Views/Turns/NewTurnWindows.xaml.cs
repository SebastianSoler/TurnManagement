using System.Windows;

namespace TurnManagement.App_Turn.Views.Turns
{
    /// <summary>
    /// Interaction logic for NewTurnWindows.xaml
    /// </summary>
    public partial class NewTurnWindows : Window
    {
        public NewTurnWindows()
        {
            InitializeComponent();
        }

        private void ShotDownPage(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboxNewTurnPatient.Focus();
        }
    }
}

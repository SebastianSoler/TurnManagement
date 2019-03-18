using System.Windows;
using DevExpress.Xpf.Ribbon;

namespace TurnManagement.App_Turn.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXRibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //Style style = (Style)FindResource("DateHeaderStyle");
            //TurnCalendar.ActiveView.DateHeaderStyle = style;
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ShutDown(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DXRibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DI.DI.ViewModelApplication.CloseWaitingLoader();
        }

        private void DXRibbonWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

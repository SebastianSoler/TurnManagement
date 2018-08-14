using System.Windows;
using Dna;
using TurnManagement.App_Turn.DI.Utils;

namespace TurnManagement.App_Turn
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Setup the main application 
            ApplicationSetup();
        }

        private void ApplicationSetup()
        {
            // Setup the Dna Framework
            Framework.Construct<DefaultFrameworkConstruction>()
                .AddViewModels()
                .AddClientServices()
                .Build();
        }
    }
}

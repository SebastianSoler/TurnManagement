using System.Globalization;
using System.Threading;
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

            SetCultureInfo();

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

        private void SetCultureInfo()
        {
            // Create a new object, representing the German culture.  
            CultureInfo culture = CultureInfo.CreateSpecificCulture("es-AR");

            // The following line provides localization for the application's user interface.  
            Thread.CurrentThread.CurrentUICulture = culture;

            // The following line provides localization for data formats.  
            Thread.CurrentThread.CurrentCulture = culture;

            // Set this culture as the default culture for all threads in this application.  
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}

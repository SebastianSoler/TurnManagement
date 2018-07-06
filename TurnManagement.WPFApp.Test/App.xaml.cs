using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.Business.Services;
using TurnManagement.DataAccess.Interfaces.Persistence.Repositories;
using TurnManagement.DataAccess.Persistence.Repositories;
using TurnManagement.WPFApp.Test.App_Start;
using TurnManagement.WPFApp.Test.ViewModel;
using Unity;

namespace TurnManagement.WPFApp.Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //public App()
        //{
        //    Resources = new ResourceDictionary();
        //    Resources.Add("Locator", new ViewModelLocator());

        //    Test test = new Test();

        //    //base.OnStartup();
        //}

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            UnityActivator.Start();

            //Test test = new Test();
            //test.Show();
        }
    }
}

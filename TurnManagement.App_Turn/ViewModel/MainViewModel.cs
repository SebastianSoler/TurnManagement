using GalaSoft.MvvmLight;
using TurnManagement.App_Turn.ViewModel.Application;
using TurnManagement.App_Turn.ViewModel.Base;
using TurnManagement.Business.Interfaces.Services;

namespace TurnManagement.App_Turn.ViewModel
{

    public class MainViewModel : BaseViewModel
    {
        private readonly IApplicationUserService applicationUserService;

        private ApplicationViewModel applicationViewModel;

        public MainViewModel(IApplicationUserService applicationUserService)
        {
            this.applicationUserService = applicationUserService;

            applicationViewModel = new ApplicationViewModel();
        }
    }
}
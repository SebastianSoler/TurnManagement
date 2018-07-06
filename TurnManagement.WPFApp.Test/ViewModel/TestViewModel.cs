using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.Domain.Entities;
using TurnManagement.WPFApp.Test.EntitiesVM;

namespace TurnManagement.WPFApp.Test.ViewModel
{
    public class TestViewModel : ViewModelBase
    {
        private readonly IApplicationUserService baseService;
        
        #region Model Property : ApplicationUserVM
        /// <summary>
        /// The <see cref="ApplicationUserVM" /> property's name.
        /// </summary>
        public const string ApplicationUserVMPropertyName = "ApplicationUserVM";

        private ApplicationUserVM applicationUserVM = new ApplicationUserVM();

        /// <summary>
        /// Sets and gets the ApplicationUserVM property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ApplicationUserVM ApplicationUserVM
        {
            get
            {
                return applicationUserVM;
            }
            set
            {
                Set(() => ApplicationUserVM, ref applicationUserVM, value);
            }
        }


        #endregion

        public RelayCommand _addApplicationUser { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public TestViewModel(IApplicationUserService applicationUserService)
        {
            baseService = applicationUserService;

            _addApplicationUser = new RelayCommand(AddApplicationUser);

        }

        public void AddApplicationUser()
        {
            //ApplicationUserVM userPerson = new ApplicationUserVM();

            ApplicationUser newUser= new ApplicationUser()
            {
                UserName = ApplicationUserVM.UserName,
                Password = ApplicationUserVM.Password
            };

            //var newId = baseService.Add(newUser);
        }
    }
}
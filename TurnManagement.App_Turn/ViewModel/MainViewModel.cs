using System;
using System.Collections.Generic;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using TurnManagement.App_Turn.ViewModel.Application;
using TurnManagement.App_Turn.ViewModel.Base;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.CrossCutting.Enumerations;
using TurnManagement.CrossCutting.Strings;
using TurnManagement.Domain.Entities;

namespace TurnManagement.App_Turn.ViewModel
{

    public class MainViewModel : BaseViewModel
    {
        #region Private Properties

        private readonly IApplicationUserService applicationUserService;

        private readonly IProfessionalService professionalService;

        private readonly IPatientService patientService;

        private ApplicationViewModel applicationViewModel;

        #endregion

        #region Public Properties

        public IEnumerable<Patient> PatientList { get; private set; } = new List<Patient>();

        public IEnumerable<Professional> ProfessionalList { get; private set; } = new List<Professional>();

        #endregion

        #region COMMANDS

        public RelayCommand NewTurnCommand;

        #endregion

        public MainViewModel(IApplicationUserService applicationUserService, IProfessionalService professionalService, IPatientService patientService)
        {
            this.applicationUserService = applicationUserService;
            this.professionalService = professionalService;
            this.patientService = patientService;

            applicationViewModel = DI.DI.ViewModelApplication;

            RegisterRelayCommands();
            InitializerDataList();
        }

        private void RegisterRelayCommands()
        {
            NewTurnCommand = new RelayCommand(execute: () => AddNewTurn());
        }

        private void InitializerDataList()
        {
            ProfessionalList = professionalService.GetAll();
        }

        #region Command Implementations

        private void AddNewTurn()
        {
            try
            {
                var resp =  applicationViewModel.ShowModalPage(ApplicationPage.Turns, this);
            }
            catch (Exception)
            {
                //TODO: Mensaje de error al Abrir Dialog de nuevo Turno
                MessageBox.Show(GeneralMessages.ShowWindowsError, GeneralMessages.NewTurnTitle, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        #endregion
    }
}
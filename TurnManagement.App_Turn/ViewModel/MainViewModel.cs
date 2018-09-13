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
        private ApplicationViewModel applicationViewModel;

        #region Private Properties SERVICES

        private readonly IApplicationUserService applicationUserService;

        private readonly IProfessionalService professionalService;

        private readonly IPatientService patientService;

        private readonly ISpecialityService specialityService;

        #endregion

        #region Public Properties COLLECTIONS

        public IEnumerable<Patient> PatientList { get; private set; } = new List<Patient>();

        public IEnumerable<Professional> ProfessionalList { get; private set; } = new List<Professional>();

        public IEnumerable<Speciality> SpecialityList { get; private set; } = new List<Speciality>();

        public IEnumerable<string> HealtInsuranceList { get; private set; } = new List<string>() { "IOMA", "OSDE", "ART" };

        #endregion

        #region Public Properties 

        private Professional professional { get; set; }

        public string ProfessionalFilter { get; set; }

        public string NewSpecialityName { get; set; } = string.Empty;

        #endregion


        #region COMMANDS

        #region COMMANDS To Open Windows

        public RelayCommand NewTurnCommand { get; set; }

        public RelayCommand Patients { get; set; }

        public RelayCommand Professionals { get; set; }

        public RelayCommand Specialitys { get; set; }

        #endregion

        public RelayCommand Filter { get; set; }

        public RelayCommand AddNewSpecialityRC { get; set; }

        #endregion

        public MainViewModel(
            IApplicationUserService applicationUserService, 
            IProfessionalService professionalService, 
            IPatientService patientService,
            ISpecialityService specialityService)
        {
            this.applicationUserService = applicationUserService;
            this.professionalService = professionalService;
            this.patientService = patientService;
            this.specialityService = specialityService;

            applicationViewModel = DI.DI.ViewModelApplication;

            RegisterRelayCommands();
            InitializerDataList();
        }

        private void RegisterRelayCommands()
        {
            // Commands to Open Windows
            NewTurnCommand = new RelayCommand(execute: () => AddNewTurn());
            Patients = new RelayCommand(execute: () => AdminPatients());
            Professionals = new RelayCommand(execute: () => AdminProfessional());
            Specialitys = new RelayCommand(execute: () => AdminSpecialitys());
            Filter = new RelayCommand(execute: () => ApplyFilter(ProfessionalFilter));

            //Actions Commands
            AddNewSpecialityRC = new RelayCommand(execute: () => AddNewSpeciality(NewSpecialityName));
        }

        private void InitializerDataList()
        {
            ProfessionalList = professionalService.GetAll();
            PatientList = patientService.GetAll();
            SpecialityList = specialityService.GetAll();
        }

        #region Command Implementations

        private void AddNewTurn()
        {
            try
            {
                var resp = applicationViewModel.ShowModalPage(ApplicationPage.Turns, this);
            }
            catch (Exception)
            {
                //TODO: Mensaje de error al Abrir Dialog de nuevo Turno
                MessageBox.Show(GeneralMessages.ShowWindowsError, GeneralMessages.NewTurnTitle, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void AdminPatients()
        {
            try
            {
                var resp = applicationViewModel.ShowModalPage(ApplicationPage.Patients, this);
            }
            catch (Exception)
            {
                MessageBox.Show(GeneralMessages.ShowWindowsError, GeneralMessages.PatientsManagerTittle, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void AdminProfessional()
        {
            try
            {
                var resp = applicationViewModel.ShowModalPage(ApplicationPage.Professionals, this);
            }
            catch (Exception)
            {
                MessageBox.Show(GeneralMessages.ShowWindowsError, GeneralMessages.ProfessionalsManagerTittle, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void AdminSpecialitys()
        {
            try
            {
                var resp = applicationViewModel.ShowModalPage(ApplicationPage.Specialitys, this);
            }
            catch (Exception)
            {
                MessageBox.Show(GeneralMessages.ShowWindowsError, GeneralMessages.SpecialitiesManagerTittle, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void ApplyFilter(string value)
        {
            string test = ProfessionalFilter;

            Console.WriteLine(test);
        }

        #endregion

        #region ACTION COMMANDS

        private void AddNewSpeciality(string newSpecialityName)
        {
            if(newSpecialityName != null && !string.IsNullOrWhiteSpace(newSpecialityName))
            {
                var newSpeciality = new Speciality() { Name = newSpecialityName };

                specialityService.Add(newSpeciality);
            }
            else
            {
                //Message Error con campo invalido
            }

            
        }

        #endregion
    }
}
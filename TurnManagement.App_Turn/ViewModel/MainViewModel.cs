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

        private static string ValueDateEnd = DateTime.Now.ToShortDateString().ToString();
        private static string ValueDateStart = new DateTime(1900, 01, 01).ToShortDateString().ToString();

        #region Private Properties SERVICES

        private readonly IApplicationUserService applicationUserService;

        private readonly IProfessionalService professionalService;

        private readonly IPatientService patientService;

        private readonly ISpecialityService specialityService;

        //Private Collections
        private IEnumerable<Speciality> _specialityList;
        private IEnumerable<Patient> _patientList;
        private IEnumerable<Professional> _professionalList;

        #endregion

        #region Public Properties COLLECTIONS

        public IEnumerable<Patient> PatientList
        {
            get { return _patientList; }
            private set
            {
                _patientList = value;
                base.RaisePropertyChanged("PatientList");
            }
        }

        public IEnumerable<Professional> ProfessionalList 
        {
            get { return _professionalList; }
            private set
            {
                _professionalList = value;
                base.RaisePropertyChanged("ProfessionalList");
            }
        }

        public IEnumerable<Speciality> SpecialityList 
        {
            get { return _specialityList; }
            private set
            {
                _specialityList = value;
                base.RaisePropertyChanged("SpecialityList");
            }
        }

        public IEnumerable<string> HealtInsuranceList { get; private set; } = new List<string>() { "IOMA", "OSDE", "ART" };
        public IEnumerable<string> PlanList { get; private set; } = new List<string>() { "210", "310", "410", "510" };
        public IEnumerable<string> GenreList { get; private set; } = new List<string>() { "Femenino", "Masculino", "No aclarado"};

        #endregion

        #region Public Properties 

        #region Patient Properties

        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientDni { get; set; }
        public string PatientGenre { get; set; }
        public string PatientDateOfBirth { get; set; }
        public string PatientAddress { get; set; } = "";
        public string PatientInsurance { get; set; }
        public string PatientPlan { get; set; }
        public string PatientEmail { get; set; }
        public string PatientCellPhone { get; set; }
        public string PatientNote { get; set; } = "";

        #endregion

        private Professional professional { get; set; }

        public string ProfessionalFilter { get; set; }

        public string NewSpecialityName { get;set; }

        public string txtSpecialitySearch { get; set; }

        public Speciality SelectedSpecialityItem { get; set; } = null;

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

        public RelayCommand AddNewPatientRC { get; set; }

        public RelayCommand DeleteSpecialityRC { get; set; }

        public RelayCommand ModifySpecialityRC { get; set; }

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

            applicationViewModel.ShowWaitingLoader();

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
            AddNewPatientRC = new RelayCommand(execute: () => AddNewPatient());
            AddNewSpecialityRC = new RelayCommand(execute: () => AddNewSpeciality());
            DeleteSpecialityRC = new RelayCommand(execute: () => DeleteSpeciality());
            ModifySpecialityRC = new RelayCommand(execute: () => ModifySpecialityAsync());
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

        private void AddNewSpeciality()
        {
            try
            {
                var newSpeciality = new Speciality() { Name = NewSpecialityName };

                specialityService.Add(newSpeciality);

                SpecialityList = specialityService.GetAll();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, GeneralMessages.SpecialitiesManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void DeleteSpeciality()
        {
            try
            {
                if (SelectedSpecialityItem != null)
                {
                    var specialityId = SelectedSpecialityItem.Id;
                    
                    var bodyMessage = string.Format(ValidationMessages.ConfirmDeleteSpeciality, SelectedSpecialityItem.Name);

                    var result = MessageBox.Show(bodyMessage, GeneralMessages.SpecialitiesManagerTittle, MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK);

                    if (result == MessageBoxResult.OK)
                    {
                        specialityService.Delete(specialityId);

                        SpecialityList = specialityService.GetAll();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, GeneralMessages.SpecialitiesManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private async void ModifySpecialityAsync()
        {
            try
            {
                if(SelectedSpecialityItem != null)
                {
                    var oldName = SelectedSpecialityItem.Name;

                    var inputBoxViewModel = new Dialogs.InputDialogBoxViewModel(oldName);

                    await DI.DI.ViewModelApplication.ShowModalPage(ApplicationPage.InputDialogBox, inputBoxViewModel);

                    if (!string.IsNullOrWhiteSpace(inputBoxViewModel.NewName))
                    {
                        SelectedSpecialityItem.Name = inputBoxViewModel.NewName;

                        specialityService.Update(SelectedSpecialityItem);

                        SpecialityList = specialityService.GetAll();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, GeneralMessages.SpecialitiesManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void AddNewPatient()
        {
            try
            {
                var newPatient = new Patient()
                {
                    Name = PatientFirstName,
                    SurnName = PatientLastName,
                    Dni = PatientDni,
                    Genre = PatientGenre,
                    DateOfBirth = DateTime.Parse(PatientDateOfBirth),
                    Address = PatientAddress,
                    HealthInsurance = PatientInsurance,
                    Plan = PatientPlan,
                    Email = PatientEmail,
                    CellPhone = PatientCellPhone,
                    Note = PatientNote
                };

                patientService.Add(newPatient);

                PatientList = patientService.GetAll();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, GeneralMessages.SpecialitiesManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        #endregion
    }
}
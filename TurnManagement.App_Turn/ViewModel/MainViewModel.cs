using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using Propago.Net.CrossCutting.CustomException;
using TurnManagement.App_Turn.ViewModel.Application;
using TurnManagement.App_Turn.ViewModel.Base;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.CrossCutting.Enumerations;
using TurnManagement.CrossCutting.Strings;
using TurnManagement.CrossCutting.Utils;
using TurnManagement.Domain.Entities;

namespace TurnManagement.App_Turn.ViewModel
{

    public class MainViewModel : BaseViewModel
    {
        private ApplicationViewModel applicationViewModel;

        private static readonly string ValueDateEnd = DateTime.Now.ToShortDateString().ToString();
        private static readonly string ValueDateStart = new DateTime(1900, 01, 01).ToShortDateString().ToString();

        #region Private Properties SERVICES

        private readonly IApplicationUserService applicationUserService;

        private readonly IProfessionalService professionalService;

        private readonly IPatientService patientService;

        private readonly ISpecialityService specialityService;

        private readonly ITurnService turnService;

        //Private Collections
        private IEnumerable<Speciality> _specialityList;
        private IEnumerable<Patient> _patientList;
        private IEnumerable<Professional> _professionalList;

        public System.ComponentModel.BindingList<Turn> turnBindingList { get; set; }

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
        public IEnumerable<string> StatusList { get; } = EnumUtils.ToDictionary<Status>().Select(x => x.Value.ToString()).ToList();

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
        public Patient SelectedPatientItem { get; set; } = null;
        public Patient EditPatient { get; set; } = null;
        public string FindPatientTxt { get; set; }


        #endregion

        #region Professional Properties

        public string ProfessionalFirstName { get; set; }
        public string ProfessionalLastName { get; set; }
        public string ProfessionalDni { get; set; }
        public string ProfessionalGenre { get; set; }
        public string ProfessionalDateOfBirth { get; set; }
        public string ProfessionalAddress { get; set; } = "";
        public string ProfessionalEmail { get; set; }
        public string ProfessionalCellPhone { get; set; }
        public string ProfessionalNote { get; set; } = "";
        public Professional EditProfessional { get; set; } = null;
        
        public string ProfessionalFilter { get; set; }
        public string FindProfessionalTxt { get; set; }
        public Professional SelectedProfessionalItem { get; set; } = null;

        #endregion

        #region Speciality Properties
        public string NewSpecialityName { get;set; }
        public string FindSpecialityTxt { get; set; } = "";
        public Speciality SelectedSpecialityItem { get; set; } = null;

        #endregion

        #region Turn Properties

        public Turn NewTurn { get; set; } = new Turn();
        public string StartHour { get; set; }
        public string EndHour { get; set; }

        #endregion

        #endregion

        #region COMMANDS

        #region COMMANDS To Open Windows

        public RelayCommand NewTurnCommand { get; set; }

        public RelayCommand Patients { get; set; }

        public RelayCommand Professionals { get; set; }

        public RelayCommand Specialitys { get; set; }

        #endregion

        #region COMMANDS for Actions

        public RelayCommand Filter { get; set; }
        //Patients
        public RelayCommand AddNewPatientRC { get; set; }
        public RelayCommand DeletePatientRC { get; set; }
        public RelayCommand ModifyPatientRC { get; set; }
        public RelayCommand ConfirmEditPatientRC { get; set; }
        public RelayCommand FindPatientRC { get; set; }
        //Specality
        public RelayCommand AddNewSpecialityRC { get; set; }
        public RelayCommand DeleteSpecialityRC { get; set; }
        public RelayCommand ModifySpecialityRC { get; set; }
        public RelayCommand FindSpecialityRC { get; set; }
        //Professional
        public RelayCommand AddNewProfessionalRC { get; set; }
        public RelayCommand DeleteProfessionalRC { get; set; }
        public RelayCommand ModifyProfessionalRC { get; set; }
        public RelayCommand ConfirmEditProfessionalRC { get; set; }
        public RelayCommand FindProfessionalRC { get; set; }
        //Turn
        public RelayCommand AddNewTurnRC { get; set; }
        public RelayCommand ConfirmNewTurnRC { get; set; }

        #endregion

        #endregion

        public MainViewModel(
            IApplicationUserService applicationUserService, 
            IProfessionalService professionalService, 
            IPatientService patientService,
            ISpecialityService specialityService,
            ITurnService turnService)
        {
            this.applicationUserService = applicationUserService;
            this.professionalService = professionalService;
            this.patientService = patientService;
            this.specialityService = specialityService;
            this.turnService = turnService;

            applicationViewModel = DI.DI.ViewModelApplication;

            applicationViewModel.ShowWaitingLoader();

            RegisterRelayCommands();
            InitializerDataList();

            turnBindingList = GetTurnEvents();
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
            ModifyPatientRC = new RelayCommand(execute: () => ModifyPatient());
            ConfirmEditPatientRC = new RelayCommand(execute: () => ConfirmEditedPatient());
            DeletePatientRC = new RelayCommand(execute: () => DeletePatient());

            AddNewSpecialityRC = new RelayCommand(execute: () => AddNewSpeciality());
            DeleteSpecialityRC = new RelayCommand(execute: () => DeleteSpeciality());
            ModifySpecialityRC = new RelayCommand(execute: () => ModifySpecialityAsync());
            FindSpecialityRC = new RelayCommand(execute: () => FindSpeciality());

            AddNewProfessionalRC = new RelayCommand(execute: () => AddNewProfessional());
            DeleteProfessionalRC = new RelayCommand(execute: () => DeleteProfessional());
            ModifyProfessionalRC = new RelayCommand(execute: () => ModifyProfessional());
            ConfirmEditProfessionalRC = new RelayCommand(execute: () => ConfirmEditProfessional());
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
            string test = ProfessionalFilter ?? value;

            Console.WriteLine(test);
        }

        #endregion

        #region ACTION COMMANDS

        //SPECIALITIES
        private void AddNewSpeciality()
        {
            try
            {
                var newSpeciality = new Speciality() { Name = NewSpecialityName };

                specialityService.Add(newSpeciality);

                SpecialityList = specialityService.GetAll();
            }
            catch(BusinessException be)
            {
                MessageBox.Show(be.Message, GeneralMessages.SpecialitiesManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show(GeneralMessages.ContactAdminMessage, GeneralMessages.SpecialitiesManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
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
            catch (BusinessException be)
            {
                MessageBox.Show(be.Message, GeneralMessages.SpecialitiesManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show(GeneralMessages.ContactAdminMessage, GeneralMessages.SpecialitiesManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
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

        private void FindSpeciality()
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(FindSpecialityTxt))
                {
                    SpecialityList = specialityService.GetSpecialities(FindSpecialityTxt);
                }
            }
            catch (Exception)
            {
            }
        }

        //PATIENTS
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
                    DateOfBirth = !string.IsNullOrWhiteSpace(PatientDateOfBirth) ? DateTime.Parse(PatientDateOfBirth) : DateTime.Parse(ValueDateEnd),
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
            catch (BusinessException be)
            {
                MessageBox.Show(be.Message, GeneralMessages.PatientsManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show(GeneralMessages.ContactAdminMessage, GeneralMessages.PatientsManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private async void ModifyPatient()
        {
            try
            {
                if (SelectedPatientItem != null)
                {
                    EditPatient = SelectedPatientItem;

                    await DI.DI.ViewModelApplication.ShowModalPage(ApplicationPage.EditPatientDialogBox, this);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, GeneralMessages.PatientsManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void ConfirmEditedPatient()
        {
            try
            {
                patientService.Update(EditPatient);

                PatientList = patientService.GetAll();
            }
            catch(BusinessException be)
            {
                MessageBox.Show(be.Message, GeneralMessages.PatientsManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch(Exception)
            {
                MessageBox.Show(GeneralMessages.ContactAdminMessage, GeneralMessages.PatientsManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void DeletePatient()
        {
            try
            {
                if (SelectedPatientItem != null)
                {
                    var patientId = SelectedPatientItem.Id;

                    var bodyMessage = string.Format(ValidationMessages.ConfirmDeletePatient, SelectedPatientItem.Name);

                    var result = MessageBox.Show(bodyMessage, GeneralMessages.PatientsManagerTittle, MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK);

                    if (result == MessageBoxResult.OK)
                    {
                        patientService.Delete(patientId);

                        PatientList = patientService.GetAll();
                    }
                }
            }
            catch (BusinessException be)
            {
                MessageBox.Show(be.Message, GeneralMessages.PatientsManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show(GeneralMessages.ContactAdminMessage, GeneralMessages.PatientsManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void FindPatient()
        {
            try
            {
                //if (!string.IsNullOrWhiteSpace(FindSpecialityTxt))
                //{
                //    SpecialityList = specialityService.GetSpecialities(FindSpecialityTxt);
                //}
            }
            catch (Exception)
            {
            }
        }

        //PROFESSIONALS
        private void AddNewProfessional()
        {
            try
            {
                var newProfessional = new Professional()
                {
                    Name = PatientFirstName,
                    SurnName = PatientLastName,
                    Dni = PatientDni,
                    Genre = PatientGenre,
                    DateOfBirth = !string.IsNullOrWhiteSpace(PatientDateOfBirth) ? DateTime.Parse(PatientDateOfBirth) : DateTime.Parse(ValueDateEnd),
                    Address = PatientAddress,
                    Email = PatientEmail,
                    CellPhone = PatientCellPhone,
                    Note = PatientNote
                };

                professionalService.Add(newProfessional);

                ProfessionalList = professionalService.GetAll();
            }
            catch (BusinessException be)
            {
                MessageBox.Show(be.Message, GeneralMessages.ProfessionalsManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show(GeneralMessages.ContactAdminMessage, GeneralMessages.ProfessionalsManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void DeleteProfessional()
        {
            try
            {
                if (SelectedProfessionalItem != null)
                {
                    var professionalId = SelectedProfessionalItem.Id;

                    var bodyMessage = string.Format(ValidationMessages.ConfirmDeleteProfessional, string.Concat(SelectedProfessionalItem.Name, " ", SelectedProfessionalItem.SurnName));

                    var result = MessageBox.Show(bodyMessage, GeneralMessages.ProfessionalsManagerTittle, MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK);

                    if (result == MessageBoxResult.OK) 
                    {
                        professionalService.Delete(SelectedProfessionalItem.Id);

                        ProfessionalList= professionalService.GetAll();
                    }
                }
            }
            catch (BusinessException be)
            {
                MessageBox.Show(be.Message, GeneralMessages.SpecialitiesManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show(GeneralMessages.ContactAdminMessage, GeneralMessages.SpecialitiesManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private async void ModifyProfessional()
        {
            try
            {
                if (SelectedProfessionalItem != null)
                {
                    EditProfessional = SelectedProfessionalItem;

                    await DI.DI.ViewModelApplication.ShowModalPage(ApplicationPage.EditProfessionalDialogBox, this);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, GeneralMessages.ProfessionalEditTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void ConfirmEditProfessional()
        {
            try
            {
               professionalService.Update(EditProfessional);

                ProfessionalList = professionalService.GetAll();
            }
            catch (BusinessException be)
            {
                MessageBox.Show(be.Message, GeneralMessages.ProfessionalEditTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show(GeneralMessages.ContactAdminMessage, GeneralMessages.ProfessionalsManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void FindProfessional()
        {
            try
            {
                //if (!string.IsNullOrWhiteSpace(FindSpecialityTxt))
                //{
                //    SpecialityList = specialityService.GetSpecialities(FindSpecialityTxt);
                //}
            }
            catch (Exception)
            {
            }
        }

        #endregion


        //TEST TURN COLLECTION

        public static System.ComponentModel.BindingList<Turn> GetTurnEvents()
        {
            System.ComponentModel.BindingList<Turn> result = new System.ComponentModel.BindingList<Turn>();

            result.Add(CreateTurn("sebastian" + " meeting", 1, 5));
            result.Add(CreateTurn("Juan" + " travel", 1, 6));
            result.Add(CreateTurn("Cosme" + " phone call", 1, 10));
            result.Add(CreateTurn("Fulanito" + " sarasa", 1, 1));
            result.Add(CreateTurn("Pablo" + " Sarrasqueta", 1, 4));
            result.Add(CreateTurn("Roberto" + " Olmedo", 1, 7));

            return result;
        }

        static Turn CreateTurn(string subject, int status, int label)
        {
            Random Rnd = new Random(DateTime.Now.Millisecond);
            DateTime currentTime = DateTime.Now;

            Turn apt = new Turn();
            apt.Comment = subject;
            var initTime = Rnd.Next(8, 18);

            apt.StartDateTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, initTime, initTime % 2 == 0 ? 00 : 30, 0, DateTimeKind.Unspecified);
            apt.EndDateTime = apt.StartDateTime.AddHours(2);

            apt.Status = (Status)status;
            apt.SpecialityId = label;
            System.Threading.Thread.Sleep(10);

            return apt;
        }
    }
}
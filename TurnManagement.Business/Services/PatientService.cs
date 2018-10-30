using System;
using System.Linq;
using Propago.Net.CrossCutting.CustomException;
using TurnManagement.Business.Core;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.CrossCutting.Strings;
using TurnManagement.DataAccess.Interfaces.Persistence.Repositories;
using TurnManagement.Domain.Entities;

namespace TurnManagement.Business.Services
{
    public class PatientService : BaseService<Patient>, IPatientService
    {
        public PatientService(IPatientRepository baseRepository) : base(baseRepository)
        {
        }

        protected override void BusinessValidations(Patient item)
        {
            base.BusinessValidations(item);

            var baseQuery = baseRepository.GetAll();

            AddBusinessExceptionValidation(!string.IsNullOrWhiteSpace(item.Name), ValidationMessages.EmptyName);
            AddBusinessExceptionValidation(!string.IsNullOrWhiteSpace(item.SurnName), ValidationMessages.EmptySurnName);
            AddBusinessExceptionValidation(!string.IsNullOrWhiteSpace(item.Dni) && (item.Dni.Length == 8), ValidationMessages.EmptyDni);
            AddBusinessExceptionValidation(!string.IsNullOrWhiteSpace(item.Genre), ValidationMessages.EmptyGenre);
            AddBusinessExceptionValidation(!string.IsNullOrWhiteSpace(item.CellPhone), ValidationMessages.EmptyCellPhone);

            AddBusinessExceptionValidation(!baseQuery.Any(x => x.Dni == item.Dni), ValidationMessages.DuplicatedDni);

            if (item.DateOfBirth != null)
            {
                AddBusinessExceptionValidation(IsValidDateOfBirth(item.DateOfBirth), ValidationMessages.InvalidDateOfBirth);
            }

            if (!string.IsNullOrWhiteSpace(item.Email))
            {
                AddBusinessExceptionValidation(IsValidEmail(item.Email), ValidationMessages.InvalidOrEmptyEmail);
            }
        }

        public override void Update(Patient item)
        {
            var duplicatedDniPatient = baseRepository.GetAll().Any(x => x.Dni == item.Dni && x.Id != item.Id);

            if (duplicatedDniPatient)
            {
                throw new BusinessException(ValidationMessages.DuplicatedDni);
            }

            base.Update(item);
        }

        public override void Delete(int id)
        {
            // Consultar y Verificar si tiene turnos asignados y Eliminarlos tambien
            base.Delete(id);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidDateOfBirth(DateTime dateOfBirth)
        {
            if(dateOfBirth <= DateTime.Now.Date)
            {
                return true;
            }

            return false;
        }
    }
}

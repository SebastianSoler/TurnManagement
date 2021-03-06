﻿using System;
using System.Collections.Generic;
using System.Linq;
using Propago.Net.CrossCutting.CustomException;
using TurnManagement.Business.Core;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.CrossCutting.Strings;
using TurnManagement.DataAccess.Interfaces.Persistence.Repositories;
using TurnManagement.Domain.Entities;

namespace TurnManagement.Business.Services
{
    public class ProfessionalService : BaseService<Professional>, IProfessionalService
    {
        public ProfessionalService(IProfessionalRepository baseRepository) : base(baseRepository)
        {
        }

        protected override void BusinessValidations(Professional item)
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

            if (!string.IsNullOrWhiteSpace(item.RegistrationNumber))
            {
                AddBusinessExceptionValidation(!baseQuery.Any(x => x.RegistrationNumber == item.RegistrationNumber), ValidationMessages.DuplicatedRegisterNumber);
            }
        }

        public override void Update(Professional item)
        {
            var duplicatedDni = baseRepository.GetAll().Any(x => x.Dni == item.Dni && x.Id != item.Id);

            if (duplicatedDni)
            {
                throw new BusinessException(ValidationMessages.DuplicatedDni);
            }

            base.Update(item);
        }

        public override void Delete(int id)
        {
            //TODO: Buscar si tiene turnos Proximos asignados antes de Eliminar!!

            base.Delete(id);
        }

        public IEnumerable<Professional> GetProfessionals(string professionalSearch)
        {
            return baseRepository.GetAll().Where(x => x.Name.Contains(professionalSearch) 
                                                   || x.SurnName.Contains(professionalSearch) 
                                                   || x.Dni.Contains(professionalSearch));
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
            if (dateOfBirth <= DateTime.Now.Date)
            {
                return true;
            }

            return false;
        }
    }
}

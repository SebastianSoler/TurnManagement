using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Propago.Net.CrossCutting.CustomException;
using TurnManagement.Business.Core;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.CrossCutting.Strings;
using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.DataAccess.Interfaces.Persistence.Repositories;
using TurnManagement.Domain.Entities;

namespace TurnManagement.Business.Services
{
    public class ApplicationUserService : IApplicationUserService//:  BaseService<ApplicationUser>, IApplicationUserService
    {
        private readonly IApplicationUserRepository baseRepository;

        protected IList<string> entityValidationsMessages = new List<string>();

        public ApplicationUserService(IApplicationUserRepository baseRepository) //: base(baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public ApplicationUser Get(int id)
        {
            var item = baseRepository.Get(id);

            if (item == null)
            {
                throw new BusinessException(GeneralMessages.InvalidItem);
            }

            return item;
        }

        public virtual IEnumerable<ApplicationUser> GetAll()
        {
            return baseRepository.GetAll().ToList();
        }

        public virtual IEnumerable<ApplicationUser> GetByIds(IEnumerable<int> Ids)
        {
            return baseRepository.GetByIds(Ids);
        }

        public virtual int Add(ApplicationUser item)
        {
            if (item.Id != 0)
            {
                throw new BusinessException(ValidationMessages.AddItemNullIdValidation);
            }

            PreAddEntityHandler(item);

            return baseRepository.Add(item);
        }

        public virtual void Update(ApplicationUser item)
        {
            if (item.Id == 0)
            {
                throw new BusinessException(ValidationMessages.UpdateItemIdValidation);
            }

            baseRepository.Update(item);
        }

        public virtual void Delete(int id)
        {
            throw new NotImplementedException();
        }

        // Se implementa en cada servicio para hacer las valicadiones correspondientes.
        protected virtual void BusinessValidations(ApplicationUser item)
        {
        }

        // Se implementa en cada servicio para hacer las valicadiones correspondientes.
        protected virtual void PreAddEntityHandler(ApplicationUser item)
        {
        }

        protected void AddBusinessExceptionValidation(bool validationResult, string exceptionMessage)
        {
            if (!validationResult)
            {
                entityValidationsMessages.Add(exceptionMessage.Trim());
            }
        }

        private static string MessageFormater(IEnumerable<string> messages)
        {
            var spliter = "||";

            StringBuilder message = new StringBuilder();

            foreach (var m in messages)
            {
                message.AppendFormat("{0}{1}", m, spliter);
            }

            message.Remove(message.Length - 2, 2);

            return message.ToString();
        }
    }
}

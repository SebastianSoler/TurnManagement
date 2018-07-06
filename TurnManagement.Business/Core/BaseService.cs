using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Propago.Net.CrossCutting.CustomException;
using TurnManagement.Business.Interfaces.Core;
using TurnManagement.CrossCutting.Strings;
using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.Domain.Entities;

namespace TurnManagement.Business.Core
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {        
        protected readonly IBaseCrudRepository<TEntity> baseRepository;
                
        protected IList<string> entityValidationsMessages = new List<string>();

        public BaseService(IBaseCrudRepository<TEntity> baseRepository)
        {
            this.baseRepository = baseRepository;
        }       
        
        public virtual TEntity Get(int id)
        {
            var item = baseRepository.Get(id);

            if (item == null)
            {
                throw new BusinessException(GeneralMessages.InvalidItem);
            }
            
            return item;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return baseRepository.GetAll().ToList();
        }

        public virtual IEnumerable<TEntity> GetByIds(IEnumerable<int> Ids)
        {
            return baseRepository.GetByIds(Ids);
        }

        public virtual int Add(TEntity item)
        {
            if (item.Id != 0)
            {
                throw new BusinessException(ValidationMessages.AddItemNullIdValidation);
            }

            PreAddEntityHandler(item);

            ExecuteValidationsChecker(item);

            return baseRepository.Add(item);
        }

        public virtual void Update(TEntity item)
        {
            if (item.Id == 0)
            {
                throw new BusinessException(ValidationMessages.UpdateItemIdValidation);
            }

            ExecuteValidationsChecker(item);

            baseRepository.Update(item);
        }

        public virtual void Delete(int id)
        {
            throw new NotImplementedException();
        }

        // Se implementa en cada servicio para hacer las valicadiones correspondientes.
        protected virtual void BusinessValidations(TEntity item)
        {
        }

        // Se implementa en cada servicio para hacer las valicadiones correspondientes.
        protected virtual void PreAddEntityHandler(TEntity item)
        {
        }

        protected void AddBusinessExceptionValidation(bool validationResult, string exceptionMessage)
        {
            if (!validationResult)
            {
                entityValidationsMessages.Add(exceptionMessage.Trim());
            }
        }

        protected void ExecuteValidationsChecker(TEntity item)
        {
            BusinessValidations(item);

            if (entityValidationsMessages.Any())
            {
                var message = MessageFormater(entityValidationsMessages);

                throw new BusinessException(message);
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
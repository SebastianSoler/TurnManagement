using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using TurnManagement.Domain.Entities;

namespace TurnManagement.ViewModels.Interfaces
{
    public interface IBaseCommandViewModel//<TEntity> where  TEntity : BaseEntity
    {
        void AddCommand();

        void GetCommand();

        void GetAllCommand();

        void DeleteCommand();

        void UpdateCommand();
    }
}

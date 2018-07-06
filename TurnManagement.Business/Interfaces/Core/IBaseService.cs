using System.Collections.Generic;

namespace TurnManagement.Business.Interfaces.Core
{
    public interface IBaseService<T>
    {       
        IEnumerable<T> GetAll();

        IEnumerable<T> GetByIds(IEnumerable<int> Ids);

        T Get(int id);

        int Add(T item);

        void Update(T item);

        void Delete(int id);
    }
}

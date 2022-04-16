using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timesheets.DAL.Repository.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> Get(int id);

        Task<IEnumerable<T>> GetAll();

        Task Add(T item);

        Task Update(T item);

        Task Delete(T item);
    }
}
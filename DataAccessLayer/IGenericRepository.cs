using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<PagedResult<T>> GetPaged(int pageNumber, int pageSize);
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}

using CRM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T: BaseEntity 
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> AddAsync(T entity);
        Task<T> Update(T entity);
    }
}

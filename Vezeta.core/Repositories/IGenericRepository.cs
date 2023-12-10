using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Vezeta.core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T Item);
        IEnumerable<T> FindAll(Expression<Func<T,bool>>match,int take,int skip,string[] includes=null);
        void Update(T Item);
        void Delete(T Item);
        Task<int> GetCountAsync();
    }
}

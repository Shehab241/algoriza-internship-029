using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Repository.Data;
using Vezeta.core.Repositories;

namespace Vezeta.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext _dbcontext;

        public GenericRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task AddAsync(T Item)
        => await _dbcontext.Set<T>().AddAsync(Item);

        public async Task<int> GetCountAsync()
        {
            var count = await _dbcontext.Set<T>().CountAsync();
            return count;
        }

        public void Delete(T Item)
         => _dbcontext.Set<T>().Remove(Item);

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int take, int skip, string[] includes = null)
        {
            IQueryable<T> query = _dbcontext.Set<T>();

            if(includes != null) 
                foreach(var include in includes)
                    query = query.Include(include);
            return query.Where(match).Skip(skip).Take(take).ToList();

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        =>  await _dbcontext.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id)
        =>  await _dbcontext.Set<T>().FindAsync(id);

        public void Update(T Item)
        => _dbcontext.Set<T>().Update(Item);
    }
}

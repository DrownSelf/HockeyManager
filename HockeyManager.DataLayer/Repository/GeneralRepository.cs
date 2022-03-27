using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.DataLayer.Repository
{
    public class GeneralRepository<T> : IRepository<T> 
        where T : class 
    {
        private readonly GeneralContext _generalContext;

        public GeneralRepository(GeneralContext generalContext)
        {
            _generalContext = generalContext;
        }

        public IEnumerable<T> Entities 
        { 
            get { return _generalContext.Set<T>().ToList(); } 
        }

        public async Task CreateAsync(T entity)
        {
            await _generalContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _generalContext.Set<T>().Remove(entity);
        }

        public async Task<T?> FindByIdAsync(string id)
        {
            return await _generalContext.Set<T>().FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await _generalContext.SaveChangesAsync();
        }
    }
}

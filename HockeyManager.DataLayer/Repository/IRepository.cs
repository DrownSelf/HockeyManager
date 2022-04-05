using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.DataLayer.Repository
{
    public interface IRepository<T>
        where T : class
    {
        public IEnumerable<T> Entities { get; }

        public bool Delete(T entity);

        public bool CreateAsync(T entity);

        public Task SaveAsync();

        public Task<T?> FindByIdAsync(string id);
    }
}
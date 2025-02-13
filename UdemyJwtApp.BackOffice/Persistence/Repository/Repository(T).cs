using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UdemyJwtApp.BackOffice.Core.Application.Interfaces;
using UdemyJwtApp.BackOffice.Persistence.Context;

namespace UdemyJwtApp.BackOffice.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly UdemyJwtContext udemyJwtContext;

        public Repository(UdemyJwtContext udemyJwtContext)
        {
            this.udemyJwtContext = udemyJwtContext;
        }

        public async Task CreateAsync(T entity)
        {
            await this.udemyJwtContext.Set<T>().AddAsync(entity);
            await this.udemyJwtContext.SaveChangesAsync();

        }
        public async Task<List<T>>? GetAllAsync()
        {
            return await this.udemyJwtContext.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await this.udemyJwtContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }
        public async Task<T?> GetByIdAsync(object id)
        {
            return await this.udemyJwtContext.Set<T>().FindAsync(id);
        }
        public async Task UpdateAsync(T entity)
        {
            this.udemyJwtContext.Set<T>().Update(entity);
            await this.udemyJwtContext.SaveChangesAsync();
        }
        public async Task RemoveAsync(T entity)
        {
            this.udemyJwtContext.Set<T>().Remove(entity);
            await this.udemyJwtContext.SaveChangesAsync();

        }





    }
}

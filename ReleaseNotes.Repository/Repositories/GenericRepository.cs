using Microsoft.EntityFrameworkCore;
using ReleaseNotes.Repository.Context;
using ReleaseNotes.Repository.Interfaces.Generic;

namespace ReleaseNotes.Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly NpgSqlContext _context;
        public GenericRepository(NpgSqlContext context)
        {
            _context = context; 
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _context.Set<TEntity>().Remove(entity);
            await Save();
        }

        public async Task<IEnumerable<TEntity>> GetAll() => await _context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetById(long id) => await _context.Set<TEntity>().FindAsync(id);

        public async Task<TEntity> Insert(TEntity entity)
        {
            await _context.AddAsync(entity);
            await Save();
            return entity;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
            _context.Dispose();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var update = _context.Set<TEntity>().Update(entity);
            update.State = EntityState.Modified;
            await Save();
            return entity;
        }
    }
}

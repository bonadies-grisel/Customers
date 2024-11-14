#region Usings
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using knowledge.common.entities.Types;
using knowledge.common.interfaces;
using knowledge.common.mysql;
#endregion

namespace knowledge.common.repositories
{
    public abstract class GenericRepository<T, TId> : IGenericRepository<T, TId>
        where T : EntityBase<TId>
        where TId : IEquatable<TId>
    {
        private readonly DataContext _context;
        protected DbSet<T> Entities => _context.Set<T>();        

        protected GenericRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
            => Entities;

        public async Task<T?> GetById(TId id)
            => await Entities.FirstOrDefaultAsync(x => x.Id.Equals(id));        

        public async Task<T> Insert(T value)
        {
            EntityEntry<T> result = await Entities.AddAsync(value);

            return result.Entity;
        }
       
        public void Update(T value)
            => Entities.Update(value);   
    }
}

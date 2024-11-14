#region Usings
using knowledge.common.entities.Types;
#endregion

namespace knowledge.common.interfaces
{
    public interface IGenericRepository<T, TId>
    {
        #region Asynchronous Methods
        

        /// <summary>
        /// Finds an entity by id.
        /// </summary>
        /// <param name="id">Entity unique identifier.</param>
        /// <returns></returns>
        Task<T> Insert(T value);
        Task<T?> GetById(TId id);
        IQueryable<T> GetAll();
        void Update(T value);        
        #endregion
    }
}

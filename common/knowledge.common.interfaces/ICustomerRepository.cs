#region Usings
using knowledge.common.entities.Types        ; 
#endregion

namespace knowledge.common.interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer, int>
    {
        IQueryable<Customer> Search(string searchValue);
    }
}

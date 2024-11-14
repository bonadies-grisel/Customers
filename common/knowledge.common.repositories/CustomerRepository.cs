#region Usings
using knowledge.common.entities.Types;
using knowledge.common.interfaces;
using knowledge.common.mysql;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace knowledge.common.repositories
{
    public class CustomerRepository : GenericRepository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context)
        {            
        }

        public IQueryable<Customer> Search(string searchValue)
            => Entities.Where(x => x.Names.Contains(searchValue));
    }
}

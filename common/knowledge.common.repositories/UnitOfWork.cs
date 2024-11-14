#region Usings
using knowledge.common.interfaces;
using knowledge.common.mysql;
#endregion

namespace knowledge.common.repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;        
        public ITracerRepository TracerRepository { get; }
        public ICustomerRepository CustomerRepository { get; }        

        public UnitOfWork(DataContext context, ITracerRepository tracerRepository, ICustomerRepository customerRepository)
        {
            _context = context;            
            TracerRepository = tracerRepository;
            CustomerRepository = customerRepository;            
        }

        public int SaveChanges()
            => _context.SaveChanges();

        public void Dispose()
            => _context.Dispose();
    }
}

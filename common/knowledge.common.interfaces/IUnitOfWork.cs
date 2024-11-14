#region Usings

#endregion
namespace knowledge.common.interfaces
{
    public interface IUnitOfWork : IDisposable
    {        
        public ITracerRepository TracerRepository { get; }
        public ICustomerRepository CustomerRepository { get; }     

        public int SaveChanges();
    }
}

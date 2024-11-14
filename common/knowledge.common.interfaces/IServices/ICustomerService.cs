#region Usings
using knowledge.common.entities.DTOs;
using knowledge.common.entities.Types; 
#endregion

namespace knowledge.common.interfaces.IServices
{
    public interface ICustomerService
    {
        Task<CustomerDTO?> GetById(int id);
        Task<List<CustomerDTO>> GetAll();
        Task<List<CustomerDTO>> Search(string searchValue);
        Task<CustomerDTO> Create(CreateCustomerDTO newCustomer);
        Task<CustomerDTO> Update(UpdateCustomerDTO newCustomer);       
    }
}

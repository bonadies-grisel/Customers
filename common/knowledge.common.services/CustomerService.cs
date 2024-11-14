#region Usings
using Microsoft.EntityFrameworkCore;
using knowledge.common.entities.DTOs;
using knowledge.common.entities.Types;
using knowledge.common.interfaces;
using knowledge.common.interfaces.IServices;
using knowledge.common.mapper;
using knowledge.common.helpers;
#endregion

namespace knowledge.common.services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
                _unitOfWork = unitOfWork;
        }

        public async Task<List<CustomerDTO>> GetAll()
            => (await Task.WhenAll(
                    _unitOfWork.CustomerRepository.GetAll()
                    .Select(x => EntityMapper.FromCustomerToCustomerDTO(x)))
                )
                .ToList();
          
        

        public async Task<CustomerDTO> GetById(int id)
            => await EntityMapper.FromCustomerToCustomerDTO(await _unitOfWork.CustomerRepository.GetById(id));

        public async Task<List<CustomerDTO>> Search(string searchValue)
            => (await Task.WhenAll(
                    _unitOfWork.CustomerRepository.Search(searchValue)
                    .Select(x => EntityMapper.FromCustomerToCustomerDTO(x)))
                    ).ToList();

        public async Task<CustomerDTO?> Create(CreateCustomerDTO newCustomerDTO)
        {
            Customer newCustomer = await _unitOfWork.CustomerRepository.Insert(
                await EntityMapper.FromCreateCustomerDTOToCustomer(newCustomerDTO)
            );

            int saved = _unitOfWork.SaveChanges();

            CustomerDTO customerDTO = await EntityMapper.FromCustomerToCustomerDTO(newCustomer);

            return customerDTO;
        }

        public async Task<CustomerDTO?> Update(UpdateCustomerDTO updateCustomerDTO) {

            Customer? customerForUpdate = await _unitOfWork.CustomerRepository.GetById(updateCustomerDTO.Id);

            if (customerForUpdate == null) return null;

            Customer updatedCustomer = await EntityMapper.FromUpdateCustomerDTOToCustomer(updateCustomerDTO, customerForUpdate);

            _unitOfWork.CustomerRepository.Update(updatedCustomer);
            
            _unitOfWork.SaveChanges();

            CustomerDTO customer = await EntityMapper.FromCustomerToCustomerDTO(updatedCustomer);

            return customer;
        }
    }
}

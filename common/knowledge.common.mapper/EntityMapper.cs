#region Usings
using knowledge.common.entities;
using knowledge.common.entities.DTOs;
using knowledge.common.entities.Types;
using knowledge.common.helpers;
using System.Formats.Asn1;
#endregion

namespace knowledge.common.mapper
{
    public class EntityMapper
    {
        #region Customer Mappings
        public static async Task<CustomerDTO> FromCustomerToCustomerDTO(Customer customer)
        {
            if (customer == null) return null;

            CustomerDTO customerDTO = new CustomerDTO();

            customerDTO.Id = customer.Id;
            customerDTO.Names = customer.Names;
            customerDTO.Surnames = customer.Surnames;
            customerDTO.BirthDate = customer.BirthDate;
            customerDTO.CUIT = customer.CUIT;
            customerDTO.Address = customer.Address;
            customerDTO.CellphoneNumber = customer.CellphoneNumber;
            customerDTO.Email = customer.Email;

            return customerDTO;
        }

        public static async Task<Customer> FromCustomerDTOToCustomer(CustomerDTO customerDTO)
        {
            Customer customer = new Customer();
            
            customer.Id = customerDTO.Id;
            customer.Names = customerDTO.Names;
            customer.Surnames = customerDTO.Surnames;
            customer.BirthDate = customerDTO.BirthDate;
            customer.Address = customerDTO.Address;
            customer.CellphoneNumber = customerDTO.CellphoneNumber;
            customer.Email = customerDTO.Email;

            return customer;
        }

        public static async Task<Customer> FromCreateCustomerDTOToCustomer(CreateCustomerDTO customerDTO)
        {
            Customer newCustomer = new Customer();

            newCustomer.Names = customerDTO.Names;
            newCustomer.Surnames = customerDTO.Surnames;
            newCustomer.BirthDate = DateTimeHelper.DateTimeToDateOnly(customerDTO.BirthDate);
            newCustomer.CUIT = customerDTO.CUIT;
            newCustomer.Address = customerDTO.Address;
            newCustomer.CellphoneNumber = customerDTO.CellphoneNumber;
            newCustomer.Email = customerDTO.Email;
            newCustomer.Active = true;

            return newCustomer;
        }

        public static async Task<CreateCustomerDTO> FromCustomerToCreateCustomerDTO(Customer customer)
        {
            CreateCustomerDTO createCustomerDTO = new CreateCustomerDTO();

            createCustomerDTO.Names = customer.Names;
            createCustomerDTO.Surnames = customer.Surnames;
            createCustomerDTO.BirthDate = DateTimeHelper.DateOnlyToDateTime(customer.BirthDate);
            createCustomerDTO.CUIT = customer.CUIT;
            createCustomerDTO.Address = customer.Address;
            createCustomerDTO.CellphoneNumber = customer.CellphoneNumber;
            createCustomerDTO.Email = customer.Email;            

            return createCustomerDTO;
        }

        public static async Task<Customer> FromUpdateCustomerDTOToCustomer(UpdateCustomerDTO updateCustomerDTO, Customer customerForUpdate)
        {
            customerForUpdate.Id = updateCustomerDTO.Id;
            customerForUpdate.Names = updateCustomerDTO.Names ?? customerForUpdate.Names;
            customerForUpdate.Surnames = updateCustomerDTO.Surnames ?? customerForUpdate.Surnames;
            customerForUpdate.BirthDate = updateCustomerDTO.BirthDate.HasValue ? 
                    DateTimeHelper.DateTimeToDateOnly(updateCustomerDTO.BirthDate.Value) : 
                    customerForUpdate.BirthDate;
            customerForUpdate.CUIT = updateCustomerDTO.CUIT ?? customerForUpdate.CUIT;
            customerForUpdate.Address = updateCustomerDTO.Address ?? customerForUpdate.Address;
            customerForUpdate.CellphoneNumber = updateCustomerDTO.CellphoneNumber ?? customerForUpdate.CellphoneNumber;
            customerForUpdate.Email = updateCustomerDTO.Email ?? customerForUpdate.Email;
            customerForUpdate.Active = true;

            return customerForUpdate;
        }

        public static async Task<UpdateCustomerDTO> FromCustomerToUpdateCustomerDTO(Customer customer, UpdateCustomerDTO updateCustomerDTO)
        {
            updateCustomerDTO.Id = customer.Id;
            updateCustomerDTO.Names = customer.Names;
            updateCustomerDTO.Surnames = customer.Surnames;
            updateCustomerDTO.BirthDate = DateTimeHelper.DateOnlyToDateTime(customer.BirthDate);
            updateCustomerDTO.CUIT = customer.CUIT;
            updateCustomerDTO.Address = customer.Address;
            updateCustomerDTO.CellphoneNumber = customer.CellphoneNumber;
            updateCustomerDTO.Email = customer.Email;

            return updateCustomerDTO;
        }
        #endregion        
    }
}
#region Usings
using Microsoft.AspNetCore.Mvc;
using knowledge.common.entities.DTOs;
using knowledge.common.entities.Types;
using knowledge.common.interfaces.IServices;
#endregion

namespace knowledge.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService) : base()
        {
            _customerService = customerService;
        }

        public IActionResult Index()
            => View();

        /// <summary>
        /// Gets customer by ID.
        /// </summary>
        [HttpGet("/customer/get/{id}")]
        public async Task<CustomerDTO?> GetById(int id)
        {
            CustomerDTO? customer = await _customerService.GetById(id);

            if (customer == null) NoContent();

            return customer;
        }

        /// <summary>
        /// Gets all customers.
        /// </summary>
        [HttpGet("/customer/get-all")]
        public async Task<ActionResult<List<CustomerDTO>>> GetAll()
        {
            List<CustomerDTO> customers = await _customerService.GetAll();

            if (customers.Count == 0) return NoContent();

            return customers;
        }

        /// <summary>
        /// Gets customers matching a string value by name.
        /// </summary>
        [HttpGet("/customer/search/{searchValue}")]
        public async Task<ActionResult<List<CustomerDTO>>> Search(string searchValue)
        {
            List<CustomerDTO> customers = await _customerService.Search(searchValue);

            if (customers.Count == 0) return NoContent();

            return customers;
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="createCustomerDTO">New customer data to create.</param>
        /// <remarks>
        /// Request example:
        /// 
        ///     POST /customer/create
        ///     {
        ///         "Names": "John",
        ///         "Surnames": "Doe",
        ///         "BirthDate": "1990-01-01",
        ///         "CUIT": "12-34567890-1",
        ///         "Address": "123 Main St",
        ///         "CellphoneNumber": "123456789",
        ///         "Email": "john.doe@example.com"
        ///     }
        /// </remarks>      
        [HttpPost]
        [Route("/customer/create")]
        public async Task<ActionResult<CustomerDTO>> Create([FromBody]CreateCustomerDTO createCustomerDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            CustomerDTO createdCustomer = await _customerService.Create(createCustomerDTO);

            if (createdCustomer == null) return NoContent();

            return createdCustomer;
        }

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        /// <param name="updateCustomerDTO">Customer data to update.</param>
        /// <remarks>
        /// Ejemplo de solicitud:
        /// 
        ///     PUT /customer/update
        ///     {
        ///         "Id": 1,
        ///         "Names": "UpdatedName",
        ///         "Surnames": "UpdatedSurname",
        ///         "BirthDate": "1990-01-01",
        ///         "CUIT": "12-34567890-1",
        ///         "Address": "UpdatedAddress",
        ///         "CellphoneNumber": "123456789",
        ///         "Email": "updated.email@example.com"
        ///     }
        /// </remarks>
        [HttpPut]
        [Route("/customer/update")]
        public async Task<ActionResult<CustomerDTO>> Update([FromBody]UpdateCustomerDTO updateCustomerDTO)
        {
            ModelState.Clear();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            CustomerDTO updatedCustomer = await _customerService.Update(updateCustomerDTO);

            if (updatedCustomer == null) return NoContent();

            return updatedCustomer;
        }

        /// <summary>
        /// Endpoint to generate a handled exception in order to test exception middleware.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/error")]
        public int Error(int num1, int num2)
            => num1 / num2;
    }
}

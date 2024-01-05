using CustomerApi.Data;
using CustomerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerRepo;
        public CustomerController(ICustomer customerRepo)
        {
            _customerRepo = customerRepo;
        }
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerRepo.GetCustomers().ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 1)
                return BadRequest();
            var customer = _customerRepo.GetCustomerById(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);

        }

        [HttpPost]
        [Route("addUpdateCustomer")]
        public IActionResult Post([FromBody] Customer customer)
        {
            bool response = false;
            if (customer.Id == 0)
                response = _customerRepo.AddCustomer(customer);
            else response = _customerRepo.UpdateCustomer(customer);
            return Ok(response);
        }
        [HttpGet]
        [Route("deleteCustomer/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            bool response = false;
            if (id < 1)
                return BadRequest();
            response = _customerRepo.DeleteCustomer(id);
            return Ok(response);

        }
    }
}

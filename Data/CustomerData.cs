
using CustomerApi.Models;

namespace CustomerApi.Data
{
    public class CustomerData : ICustomer
    {
        private readonly CustomerDbContext _context;
        public CustomerData(CustomerDbContext dbContext)
        {
            _context = dbContext;
        }
        public bool AddCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                var customer =  _context.Customers.Find(id);
                if (customer == null)
                    return false;

                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.AsEnumerable();
        }

        public Customer GetCustomerById(int id) => _context.Customers.FirstOrDefault(c => c.Id == id);

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                var dbCustomer = _context.Customers.Find(customer.Id);
                if (dbCustomer == null)
                    return false;

                dbCustomer.FirstName = customer.FirstName;
                dbCustomer.LastName = customer.LastName;
                dbCustomer.PhoneNumber =  customer.PhoneNumber;
                dbCustomer.EmailAddress = customer.EmailAddress;
                dbCustomer.MiddleName =    customer.MiddleName;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

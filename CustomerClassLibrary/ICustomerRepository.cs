using System.Collections.Generic;

namespace CustomerClassLibrary
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int customerId);
        Customer GetCustomer(int customerId);
        List<Customer> GetAllCustomers();
    }
}
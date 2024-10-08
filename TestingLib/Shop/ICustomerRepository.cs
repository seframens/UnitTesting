namespace TestingLib.Shop
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        void AddCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Customer GetCustomerById(int id);
    }
}

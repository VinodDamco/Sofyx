using System.Collections.Generic;
using System.Threading.Tasks;
using SofyxWeb.ApplicationCore.Entities;

namespace SofyxWeb.ApplicationCore.Interfaces
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Customer GetCustomer(int id);
        void DeleteCustomer(Customer customer);

    }
}

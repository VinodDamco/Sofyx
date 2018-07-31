using SofyxWeb.ApplicationCore.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using SofyxWeb.ApplicationCore.Specifications;
using SofyxWeb.ApplicationCore.Entities;
using System.Linq;
using Ardalis.GuardClauses;

namespace SofyxWeb.ApplicationCore.Services
{

    public class CustomerService : ICustomerService
    {

        private readonly IAppLogger<CustomerService> _logger;
        private readonly IRepository<Customer> _itemRepository;

        public CustomerService(
            IRepository<Customer> itemRepository,
            IAppLogger<CustomerService> logger)
        {
            this._logger = logger;
            _itemRepository = itemRepository;
        }

        public void AddCustomer(Customer customer)
        {
           
            _itemRepository.Add(customer);
           
        }
        public void UpdateCustomer(Customer customer)
        {

            _itemRepository.Update(customer);

        }

        public Customer GetCustomer(int id)
        {
            var customer= _itemRepository.GetById(id);
            return customer;
        }

        public void DeleteCustomer(Customer customer)
        {
            _itemRepository.Delete(customer);
        }
    }
}

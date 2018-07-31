using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SofyxWeb.Web.ViewModels;
using SofyxWeb.ApplicationCore.Entities;
using Microsoft.Extensions.Logging;
using SofyxWeb.Web.Interfaces;
using System;
using SofyxWeb.ApplicationCore.Specifications;
using SofyxWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.Web.Services
{
    public class CustomerViewModelService : ICustomerViewModelService
    {

        private readonly ILogger<CustomerViewModelService> _logger;
        private readonly IRepository<Customer> _itemRepository;

        public CustomerViewModelService(
           ILoggerFactory loggerFactory,
           IRepository<Customer> itemRepository)
        {
            _logger = loggerFactory.CreateLogger<CustomerViewModelService>();
            _itemRepository = itemRepository;
        }

        public IEnumerable<CustomerViewModel> GetCustomer()
        {
            _logger.LogInformation("Get Customer called.");
            var root = _itemRepository.ListAll();
            
            IEnumerable<CustomerViewModel> model = root.ToList().Select(s => new CustomerViewModel
            {
                Id = s.Id,
                Name = $"{s.FirstName} {s.LastName}",
                MobileNo = s.MobileNo,
                Email = s.Email
            });

            return model;
        }
    }
}

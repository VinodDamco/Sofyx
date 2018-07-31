using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SofyxWeb.Web.ViewModels;
using SofyxWeb.ApplicationCore.Entities;
using SofyxWeb.Infrastructure;
using Microsoft.AspNetCore.Http;
using SofyxWeb.Infrastructure.Data;
using SofyxWeb.Web.Services;
using SofyxWeb.Web.Interfaces;
using SofyxWeb.ApplicationCore.Interfaces;

namespace SofyxWeb.Web.Controllers
{
    
    public class CustomerController : Controller
    {
        private SofyxTestContext context;

        private readonly ICustomerViewModelService _customerviewService;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerViewModelService customerviewService, SofyxTestContext scontext, ICustomerService customerService)
        {
            _customerviewService = customerviewService;
            _customerService = customerService;
            context = scontext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var customerModel = _customerviewService.GetCustomer();
            return View("Index", customerModel);
        }

        [HttpGet]
        public IActionResult AddEditCustomer(int? id)
        {
            CustomerViewModel model = new CustomerViewModel();
            if (id.HasValue)
            {
                Customer customer = _customerService.GetCustomer(Convert.ToInt32(id));
                if (customer != null)
                {
                    model.Id = customer.Id;
                    model.FirstName = customer.FirstName;
                    model.LastName = customer.LastName;
                    model.MobileNo = customer.MobileNo;
                    model.Email = customer.Email;
                }
            }
            return PartialView("~/Views/Customer/_AddEditCustomer.cshtml", model);
        }

        [HttpPost]
        public ActionResult AddEditCustomer(int? id, CustomerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Customer customer = isNew ? new Customer
                    {
                        AddedDate = DateTime.UtcNow
                    } : _customerService.GetCustomer(Convert.ToInt32(id));
                    customer.FirstName = model.FirstName;
                    customer.LastName = model.LastName;
                    customer.MobileNo = model.MobileNo;
                    customer.Email = model.Email;
                    customer.Ipaddress = "";
                    customer.ModifiedDate = DateTime.UtcNow;
                    if (isNew)
                    {
                        _customerService.AddCustomer(customer);
                    }
                    else
                        _customerService.UpdateCustomer(customer);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteCustomer(int id)
        {
            Customer customer = _customerService.GetCustomer(id);
            CustomerViewModel model = new CustomerViewModel
            {
                Name = $"{customer.FirstName} {customer.LastName}"
            };
            return PartialView("~/Views/Customer/_DeleteCustomer.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteCustomer(int id, IFormCollection form)
        {
            Customer customer = _customerService.GetCustomer(id);
            _customerService.DeleteCustomer(customer);
            return RedirectToAction("Index");
        }
    }
}

using SofyxWeb.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SofyxWeb.Web.Interfaces
{
   public interface ICustomerViewModelService
    {
        IEnumerable<CustomerViewModel> GetCustomer();
    }
}

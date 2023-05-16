using DevelopSoft.Models.Customer;

namespace DevelopSoft.Services.Customers
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerViewModel>> SearchAsync(IFormCollection requestForm);
    }
}

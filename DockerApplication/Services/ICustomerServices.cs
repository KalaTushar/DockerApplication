using DockerApplication.ViewModels;

namespace DockerApplication.Services
{
    public interface ICustomerServices
    {
        Task<IEnumerable<CustomerViewModel>> GetCustomerAsync();
        Task<CustomerViewModel> GetCustomerByIdAsync(int id);
        Task<CustomerViewModel> CreateAsync(CustomerCreateViewModel customer);
        Task<string> DeleteAsync(int id);
    }
}

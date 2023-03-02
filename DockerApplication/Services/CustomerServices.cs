using Microsoft.EntityFrameworkCore;
using DockerApplication.ViewModels;
using DockerApplication.DAL;
using DockerApplication.Model;

namespace DockerApplication.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly CustomerService _context;

        public CustomerServices(CustomerService context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CustomerViewModel>> GetCustomerAsync()
        {
            return await _context.Customers
                .Select(p => new CustomerViewModel
                {
                    CustomerId = p.CustomerEntityId,
                    CustomerAddress = p.CustomerAddress,
                    CustomerName = p.CustomerName,
                    CustomerPhone = p.CustomerPhone,
                }).ToListAsync();
        }
        public async Task<CustomerViewModel> GetCustomerByIdAsync(int id)
        {
            if (!await _context.Customers
                .AnyAsync(x => x.CustomerEntityId == id))
            {
                throw new Exception("Not Found");
            }
            var t = await _context.Customers
                .FirstAsync(x => x.CustomerEntityId == id);
            var ans = new CustomerViewModel
            {
                CustomerId = t.CustomerEntityId,
                CustomerAddress = t.CustomerAddress,
                CustomerName = t.CustomerName,
                CustomerPhone = t.CustomerPhone,
            };

            return ans;
        }
        public async Task<string> DeleteAsync(int id)
        {
            if (!await _context.Customers
                .AnyAsync(x => x.CustomerEntityId == id))
            {
                throw new Exception("");
            }
            var t = await _context.Customers
                .FirstAsync(x => x.CustomerEntityId == id);
            _context.Customers.Remove(t);
            await _context.SaveChangesAsync();
            return "The Content is Deleted";
        }
        public async Task<CustomerViewModel> CreateAsync(CustomerCreateViewModel customer)
        {
            var p = ToEntity(customer);

            await _context.AddAsync(p);
            await _context.SaveChangesAsync();
            return ToViewModel(p);
        }
        private CustomerViewModel ToViewModel(CustomerEntity p)
        {
            return new CustomerViewModel
            {
                CustomerId = p.CustomerEntityId,
                CustomerAddress = p.CustomerAddress,
                CustomerName = p.CustomerName,
                CustomerPhone = p.CustomerPhone,

            };
        }
        private CustomerEntity ToEntity(CustomerCreateViewModel customer)
        {
            return new CustomerEntity
            {
                CustomerAddress = customer.CustomerAddress,
                CustomerName = customer.CustomerName,
                CustomerPhone = customer.CustomerPhone,
            };
        }
    }
}

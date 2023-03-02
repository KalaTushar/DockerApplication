using Microsoft.AspNetCore.Mvc;
using DockerApplication.ViewModels;
using DockerApplication.Services;

namespace DockerApplication.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _service;

        public CustomerController(ICustomerServices service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerViewModel>>> GetAsync()
        {
            return Ok(await _service.GetCustomerAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CustomerViewModel>> GetByIdAsync(int id)
        {
            return Ok(await _service.GetCustomerByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerViewModel>> CreateAsync(CustomerCreateViewModel customer)
        {
            return Ok(await _service.CreateAsync(customer));
        }
        [HttpDelete]
        public async Task<ActionResult<string>> DeleteAsync(int id)
        {
            return Ok(await _service.DeleteAsync(id));
        }
    }
}

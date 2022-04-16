using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Timesheets.Controllers.Models;
using Timesheets.Services;

namespace Timesheets.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IService<CustomerDto> _service;

        public CustomersController(IService<CustomerDto> service)
        {
            _service = service;
        }

        // получить список всех клиентов
        [HttpGet("get")]
        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok(await _service.GetAll());
        }

        // получить информацию о клиенте по ID
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int id)
        {
            return Ok(await _service.Get(id));
        }

        // регистрация нового клиента
        [HttpPost("register")]
        public async Task<IActionResult> RegisterCustomer([FromBody] CustomerDto customer)
        {
            await _service.Create(customer);
            return Ok();
        }

        // изменение данных о клиенте
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDto customer)
        {
            await _service.Update(customer);
            return Ok();
        }

        // удаление клиента по ID
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
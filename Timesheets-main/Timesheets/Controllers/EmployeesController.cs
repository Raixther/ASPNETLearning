using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Timesheets.Controllers.Models;
using Timesheets.Services;

namespace Timesheets.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IService<EmployeeDto> _service;

        public EmployeesController(IService<EmployeeDto> service)
        {
            _service = service;
        }

        // получить список всех работников
        [HttpGet("get")]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _service.GetAll());
        }

        // получить информацию о работнике по ID
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            return Ok(await _service.Get(id));
        }

        // регистрация нового работника
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] EmployeeDto employeeInfo)
        {
            await _service.Create(employeeInfo);
            return Ok();
        }

        // изменение данных о работнике
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] EmployeeDto employeeInfo)
        {
            await _service.Update(employeeInfo);
            return Ok();
        }

        // удаление работника по ID
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Timesheets.Controllers.Models;
using Timesheets.Services;

namespace Timesheets.Controllers
{
    [Route("api/contracts")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly IService<ContractDto> _service;

        public ContractsController(IService<ContractDto> service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllContracts()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetContractById([FromRoute] int id)
        {
            return Ok(await _service.Get(id));
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterContract([FromBody] ContractDto contract)
        {
            await _service.Create(contract);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateContract([FromBody] ContractDto contract)
        {
            await _service.Update(contract);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteContract([FromRoute] int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
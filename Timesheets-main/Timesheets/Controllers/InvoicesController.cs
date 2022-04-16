using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Timesheets.Controllers.Models;
using Timesheets.Services;

namespace Timesheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {

        private readonly IService<InvoiceDto> _service;

        public InvoicesController(IService<InvoiceDto> service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllInvoices([FromBody] ContractDto contractDto)
        {
            return Ok(await _service.Get(contractDto.Id));
        }


        [HttpPut("update")]
        public async Task<IActionResult> UpdateInvoice([FromBody] InvoiceDto invoiceDto)
        {
            await _service.Update(invoiceDto);
            return Ok();
        }
    }
}
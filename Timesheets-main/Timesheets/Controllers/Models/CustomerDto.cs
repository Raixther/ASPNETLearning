using System.Collections.Generic;

namespace Timesheets.Controllers.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ContractDto> Contracts { get; set; }
    }
}
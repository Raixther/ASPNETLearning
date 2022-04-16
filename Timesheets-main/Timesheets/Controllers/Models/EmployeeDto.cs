using System.Collections.Generic;

namespace Timesheets.Controllers.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TaskDto> Tasks { get; set; }
    }
}
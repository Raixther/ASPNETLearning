using System.Collections.Generic;

namespace Timesheets.DAL.Entities
{
    public class EmployeeEntity : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<TaskEntity> Tasks { get; set; }
    }
}
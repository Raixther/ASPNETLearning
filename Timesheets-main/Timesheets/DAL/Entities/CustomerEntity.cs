using System.Collections.Generic;

namespace Timesheets.DAL.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<ContractEntity> Contracts { get; set; }
    }
}
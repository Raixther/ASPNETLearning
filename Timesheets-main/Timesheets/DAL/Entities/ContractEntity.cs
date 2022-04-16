using System;

namespace Timesheets.DAL.Entities
{
    //[Table("Contract", Schema = "contract")]
    public class ContractEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate => DateTime.Now;
        public InvoiceEntity Invoice { get; init; }
    }
}
using System;
using System.Collections.Generic;

namespace Timesheets.DAL.Entities
{
    public class InvoiceEntity : BaseEntity
    {
        public InvoiceEntity(string name)
        {
            Name = name;
        }
        private decimal _sum;

        public decimal Sum
        {
            get
            {
                _sum = 0;
                if (Tasks == null)
                    return _sum;
                foreach (var task in Tasks)
                {
                    _sum += task.Price;
                }
                return _sum;
            }
        }
        public string Name { get; }
        public bool IsPayed { get; set; }
        public DateTime PayTime { get; set; }
        public List<TaskEntity> Tasks { get; set; }

        public void Pay()
        {
            if (IsPayed)
                return;
            IsPayed = true;
            PayTime = DateTime.Now;
        }
    }
}
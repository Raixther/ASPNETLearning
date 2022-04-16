using System;

namespace Timesheets.DAL.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; private set; }
        public DateTime DeleteDate { get; private set; }

        public void Delete()
        {
            if (IsDeleted)
                return;
            IsDeleted = true;
            DeleteDate = DateTime.Now;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Timesheets.DAL.Entities;

namespace Timesheets.DAL.Repository.DataBase
{
    public sealed class Context : DbContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<ContractEntity> Contracts { get; set; }
        public DbSet<InvoiceEntity> Invoices { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
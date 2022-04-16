using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Entities;
using Timesheets.DAL.Repository.DataBase;
using Timesheets.DAL.Repository.Interfaces;

namespace Timesheets.DAL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
        }

        public async Task Add(CustomerEntity item)
        {
            await _context.Customers.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(CustomerEntity item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<CustomerEntity> Get(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                throw new ArgumentException("Клиент не найден!");
            }
            return customer;
        }

        public async Task<IEnumerable<CustomerEntity>> GetAll()
        {
            return await _context
                .Customers
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
        }

        public async Task Update(CustomerEntity item)
        {
            _context.Customers.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
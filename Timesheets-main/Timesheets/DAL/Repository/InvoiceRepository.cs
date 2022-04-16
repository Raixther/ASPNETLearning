using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.DAL.Entities;
using Timesheets.DAL.Repository.DataBase;
using Timesheets.DAL.Repository.Interfaces;

namespace Timesheets.DAL.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly Context _context;

        public InvoiceRepository(Context context)
        {
            _context = context;
        }

        public async Task Add(InvoiceEntity item)
        {
            await _context.Invoices.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(InvoiceEntity item)
        {
            await Update(item);
        }

        public async Task<InvoiceEntity> Get(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                throw new ArgumentException("Счет не найден!");
            }
            return invoice;
        }

        public async Task<IEnumerable<InvoiceEntity>> GetAll()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task Update(InvoiceEntity item)
        {
            _context.Invoices.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
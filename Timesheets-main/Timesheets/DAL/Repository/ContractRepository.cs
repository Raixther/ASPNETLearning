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
    public class ContractRepository : IContractRepository
    {
        private readonly Context _context;

        public ContractRepository(Context context)
        {
            _context = context;
        }

        public async Task Add(ContractEntity item)
        {
            await _context.Contracts.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ContractEntity item)
        {
            Task task = new (()=>_context.Remove(item));          
            await _context.SaveChangesAsync();
        }

        public Task<ContractEntity> Get(int id)
        {
            Task<ContractEntity> task = new(() => _context.Find<ContractEntity>(id));

            task.Wait();

            return task;
        
        }

        public Task<IEnumerable<ContractEntity>> GetAll()
        {
            Task<IEnumerable<ContractEntity>> task = new(() => _context.Contracts.AsEnumerable());

            task.Wait();

            return task;

        }

		public Task Update(ContractEntity item)
        {
            Task task = new(() => _context.Update(item));

            task.Wait();

            return task;
        }      
    }
}
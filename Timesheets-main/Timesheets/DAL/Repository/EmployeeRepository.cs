using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.DAL.Entities;
using Timesheets.DAL.Repository.DataBase;
using Timesheets.DAL.Repository.Interfaces;

namespace Timesheets.DAL.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async Task Add(EmployeeEntity item)
        {
            await _context.Employees.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(EmployeeEntity item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<EmployeeEntity> Get(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new ArgumentException("Сотрудник не найден!");
            }
            return employee;
        }

        public async Task<IEnumerable<EmployeeEntity>> GetAll()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }

        public async Task Update(EmployeeEntity item)
        {
            var employee = await _context.Employees.FindAsync(item.Id);
            if (employee == null)
            {
                throw new ArgumentException("Сотрудник не найден!");
            }
            employee.Name = item.Name;
            await _context.SaveChangesAsync();
        }
    }
}
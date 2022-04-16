using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.DAL.Entities;
using Timesheets.DAL.Repository.DataBase;
using Timesheets.DAL.Repository.Interfaces;

namespace Timesheets.DAL.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly Context _context;

        public TaskRepository(Context context)
        {
            _context = context;
        }

        public async Task Add(TaskEntity item)
        {
            await _context.Tasks.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TaskEntity item)
        {
            var task = await _context.Tasks.FindAsync(item.Id);
            if (task == null)
            {
                throw new ArgumentException("Задача не найдена!");
            }
            task.Delete();
            await _context.SaveChangesAsync();
        }

        public async Task<TaskEntity> Get(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                throw new ArgumentException("Задача не найдена!");
            }
            return task;
        }

        public async Task<IEnumerable<TaskEntity>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task Update(TaskEntity item)
        {
            _context.Tasks.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
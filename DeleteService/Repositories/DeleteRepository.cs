using Microsoft.EntityFrameworkCore;
using SSICMS.Core.Data.Context;
using SSICMS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSICMS.Microservises.DeleteService.Repositories
{
    public class DeleteRepository : IDeleteRepository
    {
        private readonly ApplicationDbContext _context;

        public DeleteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool status = false;
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Entry(student).State = EntityState.Deleted;
                _context.SaveChanges();
                status = true;
                return status;
            }
            else
                return status;
            
        }
    }
}

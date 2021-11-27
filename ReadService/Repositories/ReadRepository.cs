using Microsoft.EntityFrameworkCore;
using SSICMS.Core.Data.Context;
using SSICMS.Core.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSICMS.Microservises.ReadService.Repositories
{
    public class ReadRepository : IReadRepository
    {
        private readonly ApplicationDbContext _context;

        public ReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<StudentDto>> GetAllAsync()
        {
            return await _context.Students.Select(s => new StudentDto
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                PhoneNumber = s.PhoneNumber,
                Email = s.Email,
                Address = s.Address,
                Country = s.Country,
                State = s.State
            }).ToListAsync();
        }

        public async Task<StudentDto> GetAsync(int id)
        {
            return await _context.Students.Where(s => s.Id == id).Select(s => new StudentDto
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                PhoneNumber = s.PhoneNumber,
                Email = s.Email,
                Address = s.Address,
                Country = s.Country,
                State = s.State
            }).SingleOrDefaultAsync();
        }
    }
}

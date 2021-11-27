using Microsoft.EntityFrameworkCore;
using SSICMS.Core.Data.Context;
using SSICMS.Core.Domain.Dtos;
using SSICMS.Core.Domain.Entities;
using SSICMS.Microservises.UpdateService.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSICMS.Microservises.UpdateService.Repositories
{
    public class UpdateRepository : IUpdateRepository
    {
        private readonly ApplicationDbContext _context;

        public UpdateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Student> UpdateAsync(int id, StudentDto model)
        {
            var student = _context.Students.Find(id);
            if(student != null)
            {
                student.FirstName = model.FirstName;
                student.LastName = model.LastName;
                student.PhoneNumber = model.PhoneNumber;
                student.Email = model.Email;
                student.Address = model.Address;
                student.Country = model.Country;
                student.State = model.State;

                _context.Entry(student).State = EntityState.Modified;
                _context.SaveChanges();
                return Task.FromResult(student);
            }
            else
                throw new NotFoundException($"Studnet not found.");
        }
    }
}

using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SSICMS.Core.Data.Context;
using SSICMS.Core.Domain.Dtos;
using SSICMS.Core.Domain.Entities;
using SSICMS.Microservises.CreateService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SSICMS.Microservises.CreateService.Implementations
{
    public class CreateRepository : ICreateRepository
    {
        private readonly ApplicationDbContext _context;

        public CreateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StudentResponseModel> AddAsync(StudentRequestModel model)
        {
            if(_context.Students.Any(s => s.Email == model.Email))
            {
                return new StudentResponseModel
                {
                    Message = "Student with email already exist.",
                    Status = false,
                    StudentDto = null
                };
            }
            else
            {
              
                var student = new Student
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Address = model.Address,
                    Country = model.Country,
                    State = model.State

                };

                await _context.Students.AddAsync(student);
                _context.SaveChanges();

                return new StudentResponseModel
                {
                    Message = "Student Registration Created Successfully.",
                    Status = true,
                    StudentDto = new StudentDto
                    {
                        Id = student.Id,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        PhoneNumber = student.PhoneNumber,
                        Email = student.Email,
                        Address = student.Address,
                        Country = student.Country,
                        State = student.State
                    }
                };
            }
        }

       
    }
}

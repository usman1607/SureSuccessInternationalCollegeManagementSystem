using SSICMS.Core.Domain.Dtos;
using SSICMS.Core.Domain.Entities;
using SSICMS.Microservises.UpdateService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSICMS.Microservises.UpdateService.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly IUpdateRepository _updateRepository;

        public UpdateService(IUpdateRepository updateRepository)
        {
            _updateRepository = updateRepository;
        }
        public async Task<StudentDto> UpdateAsync(int id, StudentDto model)
        {
            var student = await _updateRepository.UpdateAsync(id, model);

            return new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                PhoneNumber = student.PhoneNumber,
                Email = student.Email,
                Address = student.Address,
                Country = student.Country,
                State = student.State
        };
        }
    }
}

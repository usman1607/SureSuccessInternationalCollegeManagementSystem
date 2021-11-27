using SSICMS.Core.Domain.Dtos;
using SSICMS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSICMS.Microservises.UpdateService.Repositories
{
    public interface IUpdateRepository
    {
        Task<Student> UpdateAsync(int id, StudentDto model);
    }
}

using SSICMS.Core.Domain.Dtos;
using SSICMS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSICMS.Microservises.UpdateService.Services
{
    public interface IUpdateService
    {
        Task<StudentDto> UpdateAsync(int id, StudentDto model);
    }
}

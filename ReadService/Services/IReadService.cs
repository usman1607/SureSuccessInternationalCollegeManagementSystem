using SSICMS.Core.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSICMS.Microservises.ReadService.Services
{
    public interface IReadService
    {
        Task<StudentDto> GetAsync(int id);
        Task<IList<StudentDto>> GetAllAsync();
    }
}

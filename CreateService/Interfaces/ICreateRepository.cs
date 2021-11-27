using SSICMS.Core.Domain.Dtos;
using SSICMS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSICMS.Microservises.CreateService.Interfaces
{
    public interface ICreateRepository
    {
        Task<StudentResponseModel> AddAsync(StudentRequestModel model);
    }
}

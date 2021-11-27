using SSICMS.Core.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSICMS.Microservises.CreateService.Interfaces
{
    public interface ICreateService
    {
        Task<StudentResponseModel> Create(StudentRequestModel model);
    }
}

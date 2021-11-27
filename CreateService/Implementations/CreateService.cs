using SSICMS.Core.Data.Context;
using SSICMS.Core.Domain.Dtos;
using SSICMS.Core.Domain.Entities;
using SSICMS.Microservises.CreateService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSICMS.Microservises.CreateService.Implementations
{
    public class CreateService : ICreateService
    {
        private readonly ICreateRepository _createRepository;

        public CreateService(ICreateRepository createRepository)
        {
            _createRepository = createRepository;
        }

        public async Task<StudentResponseModel> Create(StudentRequestModel model)
        {
            return await _createRepository.AddAsync(model);
        }
    }
}

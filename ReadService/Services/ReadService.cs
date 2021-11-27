using SSICMS.Core.Domain.Dtos;
using SSICMS.Microservises.ReadService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSICMS.Microservises.ReadService.Services
{
    public class ReadService : IReadService
    {
        private readonly IReadRepository _readReapository;

        public ReadService(IReadRepository readReapository)
        {
            _readReapository = readReapository;
        }
        public async Task<IList<StudentDto>> GetAllAsync()
        {
            return await _readReapository.GetAllAsync();
        }

        public async Task<StudentDto> GetAsync(int id)
        {
            return await _readReapository.GetAsync(id);
        }
    }
}

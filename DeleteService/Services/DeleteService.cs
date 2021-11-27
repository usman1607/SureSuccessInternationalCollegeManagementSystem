using SSICMS.Microservises.DeleteService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSICMS.Microservises.DeleteService.Services
{
    public class DeleteService : IDeleteService
    {
        private readonly IDeleteRepository _deleteRepository;

        public DeleteService(IDeleteRepository deleteRepository)
        {
            _deleteRepository = deleteRepository;
        }
        public async Task<bool> DeleteAsync(int id)
        {
           return await _deleteRepository.DeleteAsync(id);
        }
    }
}

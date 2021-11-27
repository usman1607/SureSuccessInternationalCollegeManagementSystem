using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSICMS.Microservises.DeleteService.Repositories
{
    public interface IDeleteRepository
    {
        Task<bool> DeleteAsync(int id);
    }
}

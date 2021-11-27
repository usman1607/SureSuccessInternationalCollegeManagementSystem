using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSICMS.Microservises.DeleteService.Services
{
    public interface IDeleteService
    {
        Task<bool> DeleteAsync(int id);
    }
}

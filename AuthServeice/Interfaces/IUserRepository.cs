using SSICMS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServeice.Interfaces
{
    interface IUserRepository
    {

        Task<User> AddUser(User user);

        Task<User> GetUser(string email);
    }
}

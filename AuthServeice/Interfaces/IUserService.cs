using Domain.Dtos;
using SSICMS.Core.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServeice.Interfaces
{
    public interface IUserService
    {

        Task<StudentResponseModel> Register(StudentRequestModel model);

        Task<string> Login(LoginRequestModel model);
    }
}

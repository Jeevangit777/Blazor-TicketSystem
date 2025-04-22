using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO.Response;
using Domain.DTO.Request;
namespace Domain.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<string>> VerifyUser(string email, string password);
        Task<BaseResponse> RegisterUser(RegisterUserRequest request);
    }
}

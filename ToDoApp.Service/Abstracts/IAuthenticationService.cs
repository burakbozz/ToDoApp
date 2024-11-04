using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models.Dtos.Tokens.Responses;
using ToDoApp.Models.Dtos.Users.Requests;

namespace ToDoApp.Service.Abstracts
{
    public interface IAuthenticationService
    {
        Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginRequestDto dto);
        Task<ReturnModel<TokenResponseDto>> RegisterAsync(RegisterRequestDto dto);
    }
}

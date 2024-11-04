using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models.Dtos.Tokens.Responses;
using ToDoApp.Models.Entities;

namespace ToDoApp.Service.Abstracts;

public interface IJwtService
{
    Task<TokenResponseDto> CreateJwtTokenAsync(User user);
}

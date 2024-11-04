using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models.Dtos.Tokens.Responses;

public sealed class TokenResponseDto
{
    public string AccessToken { get; set; }
    public DateTime AccessTokenExpiration { get; set; }
}

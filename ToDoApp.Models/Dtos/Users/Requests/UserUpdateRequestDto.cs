using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models.Dtos.Users.Requests;

public sealed record UserUpdateRequestDto(
string FirstName,
string LastName,
string City,
string Username
);

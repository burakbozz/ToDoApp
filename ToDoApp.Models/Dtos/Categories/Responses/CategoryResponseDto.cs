using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models.Entities;

namespace ToDoApp.Models.Dtos.Categories.Responses
{
    public sealed record CategoryResponseDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        
    }
}

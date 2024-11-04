using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models.Entities;

namespace ToDoApp.Models.Dtos.ToDos.Responses;

public sealed record ToDoResponseDto
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public Priority Priority { get; set; }    
    public bool Completed { get; set; }
    public string UserName { get; init; }
    public string Category { get; set; }
}

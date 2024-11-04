

using Core.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ToDoApp.Models.Entities;

public class Category : Entity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ToDo> ToDos { get; set; }
}

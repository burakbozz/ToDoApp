using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models.Entities;

namespace ToDoApp.DataAccess.Abstracts;

public interface ICategoryRepository : IRepository<Category, int>
{

}

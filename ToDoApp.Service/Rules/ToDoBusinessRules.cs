using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models.Entities;

namespace ToDoApp.Service.Rules;

public class ToDoBusinessRules
{
    public virtual void ToDoIsNullCheck(ToDo toDo)
    {
        if (toDo is null)
        {
            throw new NotFoundException("İlgili post bulunamadı.");
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models.Dtos.ToDos.Requests;

namespace ToDoApp.Service.Validations.ToDos;

public class CreateToDoRequestValidator : AbstractValidator<CreateToDoRequest>
{
    public CreateToDoRequestValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("ToDo Başlığı boş olamaz.")
    .Length(2, 50).WithMessage("ToDo Başlığı Minimum 2 max 50 karakterli olmalıdır.");


        RuleFor(x => x.Description).NotEmpty().WithMessage("ToDo açıklama İçeriği boş olamaz.");
    }
}

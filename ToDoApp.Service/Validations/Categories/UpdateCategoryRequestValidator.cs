﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models.Dtos.Categories.Requests;

namespace ToDoApp.Service.Validations.Categories
{
    public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id alanı boş olamaz.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Adı Boş olamaz.");
        }
    }
}

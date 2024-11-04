using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models.Dtos.Categories.Requests;
using ToDoApp.Models.Dtos.Categories.Responses;
using ToDoApp.Models.Dtos.ToDos.Requests;
using ToDoApp.Models.Dtos.ToDos.Responses;
using ToDoApp.Models.Entities;

namespace ToDoApp.Service.Profiles;

public class MappingProfiles : Profile
{

    public MappingProfiles()
    {
        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<Category, CategoryResponseDto>();
        CreateMap<CreateToDoRequest, ToDo>();
        CreateMap<UpdateToDoRequest, ToDo>();
        CreateMap<ToDo, ToDoResponseDto>()
            .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name))
            .ForMember(x => x.UserName, opt => opt.MapFrom(X => X.User.FirstName));
    }
}

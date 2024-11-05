using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Service.Abstracts;
using ToDoApp.Service.Concretes;
using ToDoApp.Service.Profiles;
using ToDoApp.Service.Rules;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace ToDoApp.Service
{
    public static class ServiceDependencies
    {

        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddScoped<ToDoBusinessRules>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IToDoService, ToDoService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<RoleService>();
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}

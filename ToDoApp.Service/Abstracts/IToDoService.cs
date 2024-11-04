

using Core.Responses;
using ToDoApp.Models.Dtos.ToDos.Requests;
using ToDoApp.Models.Dtos.ToDos.Responses;

namespace ToDoApp.Service.Abstracts;

public interface IToDoService
{
    ReturnModel<List<ToDoResponseDto>> GetAll();
    ReturnModel<ToDoResponseDto?> GetById(Guid id);
    ReturnModel<ToDoResponseDto> Add(CreateToDoRequest create, string userId);

    ReturnModel<ToDoResponseDto> Update(UpdateToDoRequest updateToDo);

    ReturnModel<ToDoResponseDto> Remove(Guid id);

    ReturnModel<List<ToDoResponseDto>> GetAllByCategoryId(int id);

    ReturnModel<List<ToDoResponseDto>> GetAllByUserId(string id);
}

using AutoMapper;
using Core.Responses;

using ToDoApp.DataAccess.Abstracts;
using ToDoApp.Models.Dtos.ToDos.Requests;
using ToDoApp.Models.Dtos.ToDos.Responses;
using ToDoApp.Models.Entities;
using ToDoApp.Service.Abstracts;
using ToDoApp.Service.Rules;

namespace ToDoApp.Service.Concretes;

public sealed class ToDoService : IToDoService
{
    private readonly IToDoRepository _toDoRepository;
    private readonly IMapper _mapper;
    private readonly ToDoBusinessRules _businessRules;
    public ToDoService(IToDoRepository toDoRepository,IMapper mapper,ToDoBusinessRules rules)
    {
        _toDoRepository = toDoRepository;
        _mapper = mapper;
        _businessRules = rules;
        
    }
    public ReturnModel<ToDoResponseDto> Add(CreateToDoRequest create, string userId)
    {
        ToDo createdToDo = _mapper.Map<ToDo>(create);
        createdToDo.Id = Guid.NewGuid();
        createdToDo.UserId = userId;


        // iş kuralı
        _toDoRepository.Add(createdToDo);

        ToDoResponseDto response = _mapper.Map<ToDoResponseDto>(createdToDo);

        return new ReturnModel<ToDoResponseDto>
        {
            Data = response,
            Message = "Post Eklendi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<ToDoResponseDto>> GetAll()
    {
        List<ToDo> toDos = _toDoRepository.GetAll();
        List<ToDoResponseDto> responses = _mapper.Map<List<ToDoResponseDto>>(toDos);


        return new ReturnModel<List<ToDoResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<ToDoResponseDto>> GetAllByUserId(string id)
    {
        var posts = _toDoRepository.GetAll(x => x.UserId == id, false);
        var responses = _mapper.Map<List<ToDoResponseDto>>(posts);

        return new ReturnModel<List<ToDoResponseDto>>
        {
            Data = responses,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<ToDoResponseDto>> GetAllByCategoryId(int id)
    {
        var toDos = _toDoRepository.GetAll(x => x.CategoryId == id, false);
        var responses = _mapper.Map<List<ToDoResponseDto>>(toDos);

        return new ReturnModel<List<ToDoResponseDto>>
        {
            Data = responses,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<ToDoResponseDto?> GetById(Guid id)
    {
        var toDo = _toDoRepository.GetById(id);
        _businessRules.ToDoIsNullCheck(toDo);

        var response = _mapper.Map<ToDoResponseDto>(toDo);

        return new ReturnModel<ToDoResponseDto?>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<ToDoResponseDto> Remove(Guid id)
    {
        ToDo toDo = _toDoRepository.GetById(id);


        ToDo deletedToDo = _toDoRepository.Remove(toDo);

        ToDoResponseDto response = _mapper.Map<ToDoResponseDto>(deletedToDo);

        return new ReturnModel<ToDoResponseDto>
        {
            Data = response,
            Message = "Post Silindi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<ToDoResponseDto> Update(UpdateToDoRequest updateToDo)
    {
        ToDo toDo = _toDoRepository.GetById(updateToDo.Id);


        toDo.Priority = updateToDo.Priority;
        toDo.Title = updateToDo.Title;
        toDo.Description = updateToDo.Description;
        toDo.CategoryId = updateToDo.CategoryId;
        toDo.StartDate = updateToDo.StartDate;
        toDo.EndDate = updateToDo.EndDate;
        toDo.Completed = updateToDo.Completed;
        toDo.UpdatedDate = DateTime.Now;


        ToDo updatedToDo = _toDoRepository.Update(toDo);


        ToDoResponseDto dto = _mapper.Map<ToDoResponseDto>(updatedToDo);

        return new ReturnModel<ToDoResponseDto>
        {
            Data = dto,
            Message = "Post güncellendi",
            StatusCode = 200,
            Success = true
        };
    }
}

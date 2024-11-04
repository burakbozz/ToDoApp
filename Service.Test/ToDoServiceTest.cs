using AutoMapper;
using Moq;

using ToDoApp.DataAccess.Abstracts;
using ToDoApp.Models.Dtos.ToDos.Requests;
using ToDoApp.Models.Dtos.ToDos.Responses;
using ToDoApp.Models.Entities;
using ToDoApp.Service.Concretes;
using ToDoApp.Service.Rules;



namespace Service.Tests;

public class ToDoServiceTest
{
    private ToDoService _toDoService;
    private Mock<IMapper> _mockMapper;
    private Mock<IToDoRepository> _repositoryMock;
    private Mock<ToDoBusinessRules> _rulesMock;


    [SetUp]
    public void SetUp()
    {
        _repositoryMock = new Mock<IToDoRepository>();
        _mockMapper = new Mock<IMapper>();
        _rulesMock = new Mock<ToDoBusinessRules>();
        _toDoService = new ToDoService(_repositoryMock.Object, _mockMapper.Object, _rulesMock.Object);
    }


    [Test]
    public void GetAll_ReturnsSuccess()
    {
        // Arange
        List<ToDo> toDos = new List<ToDo>();
        List<ToDoResponseDto> responses = new();
        _repositoryMock.Setup(x => x.GetAll(null, true)).Returns(toDos);
        _mockMapper.Setup(x => x.Map<List<ToDoResponseDto>>(toDos)).Returns(responses);

        // Act 

        var result = _toDoService.GetAll();

        // Assert
        Assert.IsTrue(result.Success);
        Assert.AreEqual(responses, result.Data);
        Assert.AreEqual(200, result.StatusCode);
        Assert.AreEqual(string.Empty, result.Message);
    }
    

    [Test]
    public void GetAllByUserId_ReturnsSuccess()
    {
        // Arrange
        string userId = "user123";
        var toDos = new List<ToDo>();
        var responses = new List<ToDoResponseDto>();

        _repositoryMock.Setup(x => x.GetAll(x => x.UserId == userId, false)).Returns(toDos);
        _mockMapper.Setup(x => x.Map<List<ToDoResponseDto>>(toDos)).Returns(responses);

        // Act
        var result = _toDoService.GetAllByUserId(userId);

        // Assert
        Assert.IsTrue(result.Success);
        Assert.AreEqual(200, result.StatusCode);
        Assert.AreEqual(responses, result.Data);
    }

    [Test]
    public void GetById_ValidId_ReturnsSuccess()
    {
        // Arrange
        var toDoId = Guid.NewGuid();
        var toDo = new ToDo { Id = toDoId };
        var responseDto = new ToDoResponseDto();

        _repositoryMock.Setup(x => x.GetById(toDoId)).Returns(toDo);
        _rulesMock.Setup(x => x.ToDoIsNullCheck(toDo));
        _mockMapper.Setup(x => x.Map<ToDoResponseDto>(toDo)).Returns(responseDto);

        // Act
        var result = _toDoService.GetById(toDoId);

        // Assert
        Assert.IsTrue(result.Success);
        Assert.AreEqual(200, result.StatusCode);
        Assert.AreEqual(responseDto, result.Data);
    }

    [Test]
    public void Remove_ValidId_ReturnsSuccess()
    {
        // Arrange
        var toDoId = Guid.NewGuid();
        var toDo = new ToDo { Id = toDoId };
        var responseDto = new ToDoResponseDto();

        _repositoryMock.Setup(x => x.GetById(toDoId)).Returns(toDo);
        _repositoryMock.Setup(x => x.Remove(toDo)).Returns(toDo);
        _mockMapper.Setup(x => x.Map<ToDoResponseDto>(toDo)).Returns(responseDto);

        // Act
        var result = _toDoService.Remove(toDoId);

        // Assert
        Assert.IsTrue(result.Success);
        Assert.AreEqual(200, result.StatusCode);
        Assert.AreEqual(responseDto, result.Data);
        Assert.AreEqual("Post Silindi.", result.Message);
    }

}
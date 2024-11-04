using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using ToDoApp.Models.Dtos.ToDos.Requests;
using ToDoApp.Models.Dtos.ToDos.Responses;
using ToDoApp.Models.Entities;
using ToDoApp.Service.Concretes;
using ToDoApp.Service.Rules;
using Core.Exceptions;

namespace Service.Tests
{
    public class ToDoServiceTest
    {
        private ToDoService _toDoService;
        private Mock<IToDoRepository> _repositoryMock;
        private Mock<IMapper> _mockMapper;
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
        public void Add_WhenToDoAdded_ReturnsSuccess()
        {
            // Arrange
            var createRequest = new CreateToDoRequest
            {
                Title = "Test ToDo",
                Description = "Description",
                CategoryId = 1,
                Priority = 1
            };

            var toDo = new ToDo
            {
                Id = Guid.NewGuid(),
                Title = "Test ToDo",
                Description = "Description",
                CategoryId = 1,
                UserId = "user-id",
                CreatedDate = DateTime.Now
            };

            var responseDto = new ToDoResponseDto
            {
                Id = toDo.Id,
                Title = toDo.Title,
                Description = toDo.Description,
                CategoryId = toDo.CategoryId
            };

            _mockMapper.Setup(m => m.Map<ToDo>(createRequest)).Returns(toDo);
            _repositoryMock.Setup(r => r.Add(toDo)).Returns(toDo);
            _mockMapper.Setup(m => m.Map<ToDoResponseDto>(toDo)).Returns(responseDto);

            // Act
            var result = _toDoService.Add(createRequest, "user-id");

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(responseDto, result.Data);
            Assert.AreEqual("Post Eklendi.", result.Message);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void GetAll_ReturnsSuccess()
        {
            // Arrange
            var toDos = new List<ToDo>
            {
                new ToDo { Id = Guid.NewGuid(), Title = "ToDo 1" },
                new ToDo { Id = Guid.NewGuid(), Title = "ToDo 2" }
            };

            var responseDtos = new List<ToDoResponseDto>
            {
                new ToDoResponseDto { Id = toDos[0].Id, Title = "ToDo 1" },
                new ToDoResponseDto { Id = toDos[1].Id, Title = "ToDo 2" }
            };

            _repositoryMock.Setup(r => r.GetAll()).Returns(toDos);
            _mockMapper.Setup(m => m.Map<List<ToDoResponseDto>>(toDos)).Returns(responseDtos);

            // Act
            var result = _toDoService.GetAll();

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(responseDtos, result.Data);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(string.Empty, result.Message);
        }

        [Test]
        public void GetById_WhenToDoExists_ReturnsSuccess()
        {
            // Arrange
            var toDoId = Guid.NewGuid();
            var toDo = new ToDo { Id = toDoId, Title = "Test ToDo" };
            var responseDto = new ToDoResponseDto { Id = toDoId, Title = "Test ToDo" };

            _repositoryMock.Setup(r => r.GetById(toDoId)).Returns(toDo);
            _rulesMock.Setup(r => r.ToDoIsNullCheck(toDo));
            _mockMapper.Setup(m => m.Map<ToDoResponseDto>(toDo)).Returns(responseDto);

            // Act
            var result = _toDoService.GetById(toDoId);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(responseDto, result.Data);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void GetById_WhenToDoDoesNotExist_ThrowsNotFoundException()
        {
            // Arrange
            var toDoId = Guid.NewGuid();
            ToDo toDo = null;

            _repositoryMock.Setup(r => r.GetById(toDoId)).Returns(toDo);
            _rulesMock.Setup(r => r.ToDoIsNullCheck(toDo)).Throws(new NotFoundException("İlgili ToDo bulunamadı."));

            // Act & Assert
            var ex = Assert.Throws<NotFoundException>(() => _toDoService.GetById(toDoId));
            Assert.AreEqual("İlgili ToDo bulunamadı.", ex.Message);
        }

        [Test]
        public void Remove_WhenToDoExists_ReturnsSuccess()
        {
            // Arrange
            var toDoId = Guid.NewGuid();
            var toDo = new ToDo { Id = toDoId, Title = "Test ToDo" };
            var responseDto = new ToDoResponseDto { Id = toDoId, Title = "Test ToDo" };

            _repositoryMock.Setup(r => r.GetById(toDoId)).Returns(toDo);
            _repositoryMock.Setup(r => r.Remove(toDo)).Returns(toDo);
            _mockMapper.Setup(m => m.Map<ToDoResponseDto>(toDo)).Returns(responseDto);

            // Act
            var result = _toDoService.Remove(toDoId);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(responseDto, result.Data);
            Assert.AreEqual("Post Silindi.", result.Message);
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}



using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoApp.Models.Dtos.ToDos.Requests;
using ToDoApp.Service.Abstracts;

namespace ToDoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController(IToDoService _toDoService) : ControllerBase
    {
        [HttpGet("getall")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            var result = _toDoService.GetAll();
            return Ok(result);
        }
        
        [HttpPost("add")]
        [Authorize]
        public IActionResult Add([FromBody] CreateToDoRequest dto)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var result = _toDoService.Add(dto, userId);
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        [Authorize]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var result = _toDoService.GetById(id);
            return Ok(result);
        }

        [HttpDelete("delete")]
        [Authorize]
        public IActionResult Delete([FromQuery] Guid id)
        {

            var result = _toDoService.Remove(id);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateToDoRequest dto)
        {
            var result = _toDoService.Update(dto);
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllByUserId([FromQuery] string userId)
        {
            var result = _toDoService.GetAllByUserId(userId);
            return Ok(result);
        }
        [HttpGet("category/{categoryId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllByCategoryId([FromQuery] int categoryId)
        {
            var result = _toDoService.GetAllByCategoryId(categoryId);
            return Ok(result);
        }
    }
}

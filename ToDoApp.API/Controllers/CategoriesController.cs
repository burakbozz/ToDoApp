using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models.Dtos.Categories.Requests;
using ToDoApp.Service.Abstracts;
using ToDoApp.Service.Concretes;

namespace ToDoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService _categoryService) : ControllerBase
    {
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            return Ok(result);
        }
        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public IActionResult Add([FromBody] CreateCategoryRequest dto)
        {
            var result = _categoryService.Add(dto);
            return Ok(result);
        }
        [HttpGet("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _categoryService.GetById(id);
            return Ok(result);
        }

        [HttpDelete("delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromQuery] int id)
        {
            var result = _categoryService.Remove(id);
            return Ok(result);
        }

        [HttpPut("update")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromBody] UpdateCategoryRequest dto)
        {
            var result = _categoryService.Update(dto);
            return Ok(result);
        }
    }
}

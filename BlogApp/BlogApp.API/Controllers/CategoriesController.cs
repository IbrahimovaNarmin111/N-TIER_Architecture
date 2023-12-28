using BlogApp.Business.Services.Interfaces;
using BlogApp.Business.DTOs;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Business.DTOs.CategoryDTO;

namespace BlogApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var categories=await _service.GetAllAsync();
           return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var result=await _service.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryDto categoryDto)
        {
            if(await _service.CreateAsync(categoryDto))
            {
                return Ok();
            }
            return BadRequest();            
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateCategoryDto categoryDto)
        {

            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.Update(id, categoryDto);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id<=0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}

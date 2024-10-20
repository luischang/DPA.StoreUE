using DPA.Store.DOMAIN.Core.DTO;
using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        //private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;

        //public CategoryController(ICategoryRepository categoryRepository)
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id, [FromQuery] bool includeProducts)
        {
            if (includeProducts)
                return Ok(await _categoryService.GetCategoryProductsById(id));

            return Ok(await _categoryService.GetCategoryById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDescriptionDTO categoryDTO)
        {
            int id = await _categoryService.Insert(categoryDTO);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] CategoryListDTO categoryListDTO)
        {
            if(id != categoryListDTO.Id) return BadRequest();

            var result = await _categoryService.Update(categoryListDTO);
            if(!result) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _categoryService.Delete(id);
            if(!result) return BadRequest();
            return Ok(result);
        }


    }
}

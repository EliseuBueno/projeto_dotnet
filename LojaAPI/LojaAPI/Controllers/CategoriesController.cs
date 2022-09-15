using LojaAPI.Models;
using LojaAPI.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryRepository.Get();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Category>> GetCategories(int Id)
        {
            return await _categoryRepository.Get(Id);
        }
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategories([FromBody] Category category)
        {
            var newCategory = await _categoryRepository.Create(category);
            return CreatedAtAction(nameof(GetCategories), new { Id = newCategory.Id }, newCategory);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var categoryToDelete = await _categoryRepository.Get(Id);

            if (categoryToDelete == null)
                return NotFound();

            await _categoryRepository.Delete(categoryToDelete.Id);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult> PutCategory(int Id, [FromBody] Category category)
        {
            if(Id != category.Id)
                return BadRequest();

                await _categoryRepository.Update(category);

            return NoContent();
        }

    }
}

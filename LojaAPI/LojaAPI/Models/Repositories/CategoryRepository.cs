using Microsoft.EntityFrameworkCore;

namespace LojaAPI.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly CategoryContext _context;
        public CategoryRepository(CategoryContext context)
        {
            _context = context;
        }
        public async Task<Category> Create(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task Delete(int Id)
        {
            var categoryToDelete = await _context.Categories.FindAsync(Id);
            _context.Categories.Remove(categoryToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await _context.Categories.ToArrayAsync();
        }

        public async Task<Category> Get(int Id)
        {
            return await _context.Categories.FindAsync(Id);
        }

        public async Task Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

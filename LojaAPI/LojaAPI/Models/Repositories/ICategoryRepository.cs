namespace LojaAPI.Models.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> Get();

        Task<Category> Get(int Id);

        Task<Category> Create(Category category);

        Task Update(Category category);

        Task Delete(int Id);
    }
}

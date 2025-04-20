using Eventick.Services.EventtCatalog.Entities;

namespace Eventick.Services.EventtCatalog.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category> GetCategoryById(string categoryId);
}
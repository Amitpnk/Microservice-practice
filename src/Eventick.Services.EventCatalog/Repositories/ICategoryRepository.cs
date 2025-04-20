using Eventick.Services.EventCatalog.Entities;

namespace Eventick.Services.EventCatalog.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category> GetCategoryById(string categoryId);
}
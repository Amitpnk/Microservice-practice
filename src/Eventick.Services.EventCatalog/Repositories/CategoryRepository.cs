using Eventick.Services.EventCatalog.DbContexts;
using Eventick.Services.EventCatalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eventick.Services.EventCatalog.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly EventCatalogDbContext _eventCatalogDbContext;

    public CategoryRepository(EventCatalogDbContext eventCatalogDbContext)
    {
        _eventCatalogDbContext = eventCatalogDbContext;
    }


    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        return await _eventCatalogDbContext.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryById(string categoryId)
    {
        return await _eventCatalogDbContext.Categories.Where(x => x.CategoryId.ToString() == categoryId)
            .FirstOrDefaultAsync();
    }
}
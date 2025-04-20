using Eventick.Services.EventtCatalog.DbContexts;
using Eventick.Services.EventtCatalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eventick.Services.EventtCatalog.Repositories;

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
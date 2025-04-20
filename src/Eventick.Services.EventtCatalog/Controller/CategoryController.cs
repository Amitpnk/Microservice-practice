using AutoMapper;
using Eventick.Services.EventtCatalog.Models;
using Eventick.Services.EventtCatalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Eventick.Services.EventtCatalog.Controllers;

public class CategoryController : ControllerBase
{
    private ICategoryRepository _categoryRepository;
    private IMapper _mapper;

    public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
    {
        var result = await _categoryRepository.GetAllCategories();
        return Ok(_mapper.Map<List<CategoryDto>>(result));
    }
}
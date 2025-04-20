using AutoMapper;
using Eventick.Services.EventtCatalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Eventick.Services.EventtCatalog.Controller;

public class EventController : ControllerBase
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public EventController(IEventRepository eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.EventDto>>> Get(
        [FromQuery] Guid categoryId)
    {
        var result = await _eventRepository.GetEvents(categoryId);
        return Ok(_mapper.Map<List<Models.EventDto>>(result));
    }

    [HttpGet("{eventId}")]
    public async Task<ActionResult<Models.EventDto>> GetById(Guid eventId)
    {
        var result = await _eventRepository.GetEventById(eventId);
        return Ok(_mapper.Map<Models.EventDto>(result));
    }
}
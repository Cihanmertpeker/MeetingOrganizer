using AutoMapper;
using MeetingOrganizer.BusinessLayer.Abstract;
using MeetingOrganizer.DtoLayer.MeetingDtos;
using MeetingOrganizer.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingOrganizerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly IGenericService<Meeting> _meetingService;
        private readonly IMapper _mapper;

        public MeetingsController(IGenericService<Meeting> meetingService, IMapper mapper)
        {
            _meetingService = meetingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var values = _meetingService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _meetingService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _meetingService.TDelete(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMeetingDto createMeetingDto)
        {
            var newValue = _mapper.Map<Meeting>(createMeetingDto);
            _meetingService.TCreate(newValue);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(UpdateMeetingDto updateMeetingDto)
        {
            var value = _mapper.Map<Meeting>(updateMeetingDto);
            _meetingService.TUpdate(value);
            return Ok();

        }


    }
}

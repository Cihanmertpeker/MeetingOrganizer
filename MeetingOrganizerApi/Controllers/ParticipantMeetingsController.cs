using AutoMapper;
using MeetingOrganizer.BusinessLayer.Abstract;
using MeetingOrganizer.DtoLayer.MeetingDtos;
using MeetingOrganizer.DtoLayer.ParticipantMeetingDtos;
using MeetingOrganizer.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingOrganizerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantMeetingsController : ControllerBase
    {
        private readonly IGenericService<ParticipantMeeting> _participantMeetingService;
        private readonly IMapper _mapper;

        public ParticipantMeetingsController(IGenericService<ParticipantMeeting> participantMeetingService, IMapper mapper)
        {
            _participantMeetingService = participantMeetingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var values = _participantMeetingService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _participantMeetingService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _participantMeetingService.TDelete(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateParticipantMeetingDto createParticipantMeetingDto)
        {
            var newValue = _mapper.Map<ParticipantMeeting>(createParticipantMeetingDto);
            _participantMeetingService.TCreate(newValue);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(UpdateParticipantMeetingDto updateParticipantMeetingDto)
        {
            var value = _mapper.Map<ParticipantMeeting>(updateParticipantMeetingDto);
            _participantMeetingService.TUpdate(value);
            return Ok();

        }
    }
}

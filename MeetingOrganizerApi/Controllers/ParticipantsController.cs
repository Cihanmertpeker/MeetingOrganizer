using AutoMapper;
using MeetingOrganizer.BusinessLayer.Abstract;
using MeetingOrganizer.DtoLayer.MeetingDtos;
using MeetingOrganizer.DtoLayer.ParticipantDtos;
using MeetingOrganizer.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingOrganizerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IGenericService<Participant> _participantsService;
        private readonly IMapper _mapper;

        public ParticipantsController(IGenericService<Participant> participantsService, IMapper mapper)
        {
            _participantsService = participantsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var values = _participantsService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _participantsService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _participantsService.TDelete(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateParticipantDto createParticipantDto)
        {
            var newValue = _mapper.Map<Participant>(createParticipantDto);
            _participantsService.TCreate(newValue);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(UpdateParticipantDto updateParticipantDto)
        {
            var value = _mapper.Map<Participant>(updateParticipantDto);
            _participantsService.TUpdate(value);
            return Ok();

        }
    }
}

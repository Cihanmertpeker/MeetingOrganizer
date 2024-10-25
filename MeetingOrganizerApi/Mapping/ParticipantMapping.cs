using AutoMapper;
using MeetingOrganizer.DtoLayer.MeetingDtos;
using MeetingOrganizer.DtoLayer.ParticipantDtos;
using MeetingOrganizer.EntityLayer.Entities;

namespace MeetingOrganizerApi.Mapping
{
	public class ParticipantMapping:Profile
	{
        public ParticipantMapping()
        {
			CreateMap<Participant, ResultParticipantDto>().ReverseMap();
			CreateMap<Participant, CreateParticipantDto>().ReverseMap();
			CreateMap<Participant, UpdateParticipantDto>().ReverseMap();

		}
	}
}

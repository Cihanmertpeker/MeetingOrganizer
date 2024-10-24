using AutoMapper;
using MeetingOrganizer.DtoLayer.MeetingDtos;
using MeetingOrganizer.DtoLayer.ParticipantDtos;
using MeetingOrganizer.EntityLayer.Entities;

namespace MeetingOrganizerApi.Mapping
{
	public class ParticipantMeeting:Profile
	{
        public ParticipantMeeting()
        {
			CreateMap<Participant, ResultParticipantDto>().ReverseMap();

		}
	}
}

using AutoMapper;
using MeetingOrganizer.DtoLayer.ParticipantMeetingDtos;
using MeetingOrganizer.EntityLayer.Entities;

namespace MeetingOrganizerApi.Mapping
{
    public class ParticipantMeetingMapping : Profile
    {
        public ParticipantMeetingMapping()
        {
            CreateMap<ParticipantMeeting, ResultParticipantMeetingDto>().ReverseMap();
            CreateMap<ParticipantMeeting, CreateParticipantMeetingDto>().ReverseMap();
            CreateMap<ParticipantMeeting, UpdateParticipantMeetingDto>().ReverseMap();
        }
    }
}

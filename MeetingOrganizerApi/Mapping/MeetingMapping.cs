using AutoMapper;
using MeetingOrganizer.DtoLayer.MeetingDtos;
using MeetingOrganizer.EntityLayer.Entities;

namespace MeetingOrganizerApi.Mapping
{
    public class MeetingMapping : Profile
    {
        public MeetingMapping()
        {
            CreateMap<Meeting, ResultMeetingDto>().ReverseMap();
            CreateMap<Meeting, CreateMeetingDto>().ReverseMap();
            CreateMap<Meeting, UpdateMeetingDto>().ReverseMap();
        }
    }
}

using MeetingOrganizer.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingOrganizer.DtoLayer.ParticipantMeetingDtos
{
    public class CreateParticipantMeetingDto
    {

        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }

        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}

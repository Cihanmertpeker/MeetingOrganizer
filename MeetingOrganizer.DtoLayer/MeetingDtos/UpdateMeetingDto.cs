using MeetingOrganizer.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingOrganizer.DtoLayer.MeetingDtos
{
    public class UpdateMeetingDto
    {
        public int MeetingId { get; set; }
        public string MeetingSubject { get; set; }
        public DateTime MeetingDate { get; set; }
        public DateTime MeetStartTime { get; set; }
        public DateTime MeetEndTime { get; set; }

        public List<int> ParticipantIds { get; set; }


    }
}

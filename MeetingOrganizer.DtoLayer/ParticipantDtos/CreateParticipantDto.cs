using MeetingOrganizer.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingOrganizer.DtoLayer.ParticipantDtos
{
    public class CreateParticipantDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}

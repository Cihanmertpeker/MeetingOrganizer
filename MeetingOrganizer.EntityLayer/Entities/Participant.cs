using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingOrganizer.EntityLayer.Entities
{
    public class Participant
    {
        public int ParticipantId { get; set; }  
        public string Name { get; set; }
        public string Surname { get; set; }        
        public string Company { get; set; }

    }
}

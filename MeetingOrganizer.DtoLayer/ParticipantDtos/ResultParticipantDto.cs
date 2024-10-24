using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingOrganizer.DtoLayer.ParticipantDtos
{
	public class ResultParticipantDto
	{
		public int ParticipantId { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Company { get; set; }
	}
}

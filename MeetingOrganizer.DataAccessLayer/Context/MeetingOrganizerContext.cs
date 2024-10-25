using MeetingOrganizer.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingOrganizer.DataAccessLayer.Concrete
{
    public class MeetingOrganizerContext : DbContext
    {
        public MeetingOrganizerContext(DbContextOptions options) :base(options)
        {
        }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingOrganizer.EntityLayer.Entities
{
    public class Meeting
    {
        public int MeetingId { get; set; }  
        public string MeetingSubject { get; set; }
        public DateTime MeetingDate { get; set; }
        public DateTime MeetStartTime { get; set; }
        public DateTime MeetEndTime { get; set; }

    }
}
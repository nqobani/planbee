using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMNS.Entities
{
    public class MeetingEntity
    {
        public int id { get; set; }
        public int projectId { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public DateTime createdAt { get; set; }
        public string decisions { get; set; }
    }
}
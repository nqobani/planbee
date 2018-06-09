using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMNS.Entities
{
    public class ProjectEntity
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
        public DateTime createdAt { get; set; }
    }
}
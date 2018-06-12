using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DMNS.Models
{
    public class Meeting
    {
        [Key]
        public int id { get; set; }
        public int projectId { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public string image { get; set; }
        public DateTime createdAt { get; set; }
        public string decisions { get; set; }
    }
}
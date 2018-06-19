using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMNS.Models
{
    public class SharedProjects
    {
        [Key]
        public int id { get; set; }
        public int sharedBy { get; set; }
        public int sharedTo { get; set; }
        public int projectId { get; set; }
    }
}
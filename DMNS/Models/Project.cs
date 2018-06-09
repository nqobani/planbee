using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMNS.Models
{
    public class Project
    {
        [Key]
        public int id { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
        public DateTime createdAt { get; set; }
    }
}
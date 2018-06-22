using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DMNS.Models
{
    public class User
    {        
        [Key]
        public int id { get; set; }//the must be changed to a type Guid and be auto generated
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string username { get; set; }
        public string password { get; set; }//this must be hashed
        public string email { get; set; }
    }
}
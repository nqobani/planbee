using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMNS.Entities
{
    public class UserEntity
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}
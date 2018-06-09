using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DMNS.Models
{
    public class PlanBeeDataContext : DbContext
    {
        public DbSet<User> userTable { set; get; }
        public DbSet<Meeting> meetingTable { set; get; }
        public DbSet<Project> projectTable { set; get; }
    }
}
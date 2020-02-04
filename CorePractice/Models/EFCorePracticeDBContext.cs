using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace CorePractice.Models
{
    public class EFCorePracticeDBContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Group> groups { get; set; }
    }
}
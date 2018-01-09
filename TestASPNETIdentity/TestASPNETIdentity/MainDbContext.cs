using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using TestASPNETIdentity.Models;

namespace TestASPNETIdentity
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<Users> Users { get; set; }
    }
}
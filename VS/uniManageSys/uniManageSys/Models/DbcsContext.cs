using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace uniManageSys.Models
{
    public class DbcsContext:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
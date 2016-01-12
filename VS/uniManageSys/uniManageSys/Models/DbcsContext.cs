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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Risk.Models
{
    public class MyDbContext :DbContext
    {
        public MyDbContext() : base("name=dbContext")
        {

        }

        public DbSet<ProjectDescription> projectDescription { get; set; }

    }
}

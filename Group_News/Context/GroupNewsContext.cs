using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using Group_News.Models;

namespace Group_News.Context
{
    public class GroupNewsContext :DbContext
    {
        public GroupNewsContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<Story> Stories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
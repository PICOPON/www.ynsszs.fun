using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_core.Models
{
    public class MyWebDB:DbContext
    {
        public DbSet<UserDoNet> User { get; set; }
        public DbSet<AdministratorDoNet> Administrator { get; set; }
        public DbSet<CommentDoNet> Comment { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=MyWeb;User ID=sa;Password=qzone.czxy.1227;");
        }
    }
}

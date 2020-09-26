using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TBSTech.Models;

namespace TBSTech.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services {get;set;}
        public DbSet<Course> Courses { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Video> Videos { get; set; }
    }
}

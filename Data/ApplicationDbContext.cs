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
        public DbSet<Banner> Banners { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<CourseTime> CourseTimes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CourseTime>().HasOne(x=>x.Course).WithMany()
            .HasForeignKey(x=>x.CourseId);
        }

    }
}

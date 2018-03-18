using Microsoft.EntityFrameworkCore;
using MVCCoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreData.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<CourseModel> Course { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var course = modelBuilder.Entity<CourseModel>();

            course.Property(p => p.Id).HasColumnName("CourseId");
            course.HasKey(k => k.Id);

            course.Property(p => p.Name).HasColumnType("varchar(100)").IsRequired();
            course.Property(p => p.Price).IsRequired();
            course.Property(p => p.Free).IsRequired();
            course.Property(p => p.Description).HasColumnType("varchar(1000)").IsRequired();
            course.Property(p => p.StartDate).IsRequired();
            course.Property(p => p.EndDate).IsRequired();
            course.Property(p => p.IsActive).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}

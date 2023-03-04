using DAL.DataSeed;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext()
        {

        }

        public SchoolDBContext(DbContextOptions<SchoolDBContext> options) : base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration config = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json").Build();


                string connectionString = config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");

            #region DbModel Relationship
            modelBuilder.Entity<Student>()
                .HasMany(e => e.Enrollments)
                .WithOne(e => e.Student);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Enrollments)
                .WithOne(e => e.Course);

            modelBuilder.Entity<Enrollment>(e =>
            {
                e.Property(e => e.EnrollmentID)
                .UseIdentityColumn(1,1);
            });

            modelBuilder.Entity<Enrollment>()
                .HasOne<Student>(s => s.Student)
                .WithMany(e => e.Enrollments)
                .HasForeignKey(e => e.StudentID);

            modelBuilder.Entity<Enrollment>()
                .HasOne<Course>(c => c.Course)
                .WithMany(e => e.Enrollments)
                .HasForeignKey(e => e.CourseID);

            #endregion

            #region Data Seeding
            modelBuilder.SeedStudent();
            modelBuilder.SeedCourse();
            modelBuilder.SeedEnrollment();
            #endregion

        }

    }
}

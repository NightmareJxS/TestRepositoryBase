using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataSeed
{
    public static class CourseDataSeed
    {
        public static void SeedCourse(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasData(
                    new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
                    new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
                    new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 },
                    new Course { CourseID = 1045, Title = "Calculus", Credits = 4 },
                    new Course { CourseID = 3141, Title = "Trigonometry", Credits = 4 },
                    new Course { CourseID = 2021, Title = "Composition", Credits = 3 },
                    new Course { CourseID = 2042, Title = "Literature", Credits = 4 }
                );
        }
    }
}

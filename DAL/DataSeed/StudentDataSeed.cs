using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataSeed
{
    public static class StudentDataSeed
    {
        public static void SeedStudent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasData(
                    new Student { ID = 1, FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2019-09-01") },
                    new Student { ID = 2, FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2017-09-01") },
                    new Student { ID = 3, FirstMidName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2018-09-01") },
                    new Student { ID = 4, FirstMidName = "Gytis", LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2017-09-01") },
                    new Student { ID = 5, FirstMidName = "Yan", LastName = "Li", EnrollmentDate = DateTime.Parse("2017-09-01") },
                    new Student { ID = 6, FirstMidName = "Peggy", LastName = "Justice", EnrollmentDate = DateTime.Parse("2016-09-01") },
                    new Student { ID = 7, FirstMidName = "Laura", LastName = "Norman", EnrollmentDate = DateTime.Parse("2018-09-01") },
                    new Student { ID = 8, FirstMidName = "Nino", LastName = "Olivetto", EnrollmentDate = DateTime.Parse("2019-09-01") }
                );
        }
    }
}

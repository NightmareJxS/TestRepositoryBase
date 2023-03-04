using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;
using DAL.Repository;

namespace RazerPageLab2.Pages.EnrollmentCRUDGen
{
    public class IndexModel : PageModel
    {
        private readonly StudentRepository studentRepository;
        private readonly CourseRepository courseRepository;
        private readonly EnrollmentRepository enrollmentRepository;

        public IndexModel(DAL.SchoolDBContext context)
        {
            studentRepository = new StudentRepository();
            courseRepository = new CourseRepository();
            enrollmentRepository = new EnrollmentRepository();
        }

        public IList<Enrollment> Enrollment { get;set; } = default!;

        public void OnGet()
        {
            if (enrollmentRepository.GetAll != null)
            {
                Enrollment = enrollmentRepository.GetAllWithRelatedEntities();
            }
        }
    }
}

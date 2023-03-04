using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using DAL.Entities;
using DAL.Repository;

namespace RazerPageLab2.Pages.EnrollmentCRUDGen
{
    public class CreateModel : PageModel
    {
        private readonly StudentRepository studentRepository;
        private readonly CourseRepository courseRepository;
        private readonly EnrollmentRepository enrollmentRepository;

        public CreateModel()
        {
            studentRepository = new StudentRepository();
            courseRepository = new CourseRepository();
            enrollmentRepository = new EnrollmentRepository();
        }

        public IActionResult OnGet()
        {
            ViewData["CourseID"] = new SelectList(courseRepository.GetAll(), "CourseID", "Title");
            ViewData["StudentID"] = new SelectList(studentRepository.GetAll(), "ID", "FirstMidName");
            return Page();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
            if (Enrollment.CourseID <= 0 || Enrollment.StudentID <= 0)
            {
                return Page();
            }

            enrollmentRepository.Create(Enrollment);

            return RedirectToPage("./Index");
        }
    }
}

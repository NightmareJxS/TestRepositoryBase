using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;
using DAL.Repository;

namespace RazerPageLab2.Pages.EnrollmentCRUDGen
{
    public class EditModel : PageModel
    {
        private readonly StudentRepository studentRepository;
        private readonly CourseRepository courseRepository;
        private readonly EnrollmentRepository enrollmentRepository;

        public EditModel()
        {
            studentRepository = new StudentRepository();
            courseRepository = new CourseRepository();
            enrollmentRepository = new EnrollmentRepository();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            var enrollment = enrollmentRepository.Get(e => e.EnrollmentID == id);
            if (enrollment == null)
            {
                return NotFound();
            }
            Enrollment = enrollment;
            ViewData["CourseID"] = new SelectList(courseRepository.GetAll(), "CourseID", "Title");
            ViewData["StudentID"] = new SelectList(studentRepository.GetAll(), "ID", "FirstMidName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (Enrollment.CourseID <= 0 || Enrollment.StudentID <= 0)
            {
                return Page();
            }

            enrollmentRepository.Update(Enrollment);

            return RedirectToPage("./Index");
        }

        private bool EnrollmentExists(int id)
        {
            return enrollmentRepository.Get(e => e.EnrollmentID == id) != null;
        }
    }
}

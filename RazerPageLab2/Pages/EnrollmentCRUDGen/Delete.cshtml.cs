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
    public class DeleteModel : PageModel
    {
        private readonly EnrollmentRepository enrollmentRepository;

        public DeleteModel()
        {
            enrollmentRepository = new EnrollmentRepository();
        }

        [BindProperty]
      public Enrollment Enrollment { get; set; }

        public IActionResult OnGet(int? id)
        {
            var enrollment = enrollmentRepository.GetWithRelatedEntities(e => e.EnrollmentID == id);

            if (enrollment == null)
            {
                return NotFound();
            }
            else 
            {
                Enrollment = enrollment;
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            var enrollment = enrollmentRepository.GetWithRelatedEntities(e => e.EnrollmentID == id);

            if (enrollment != null)
            {
                Enrollment = enrollment;
                enrollmentRepository.Delete(e => e.EnrollmentID == id);
            }

            return RedirectToPage("./Index");
        }
    }
}

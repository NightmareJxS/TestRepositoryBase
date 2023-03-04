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

namespace RazerPageLab2.Pages.CourseCRUDGen
{
    public class EditModel : PageModel
    {
        private readonly CourseRepository courseRepository;

        public EditModel()
        {
            courseRepository = new CourseRepository();
        }

        [BindProperty]
        public Course Course { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            var course =  courseRepository.Get(c => c.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }
            Course = course;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Course.Title) || Course.Credits <= 0)
            {
                return Page();
            }

            courseRepository.Update(Course);

            return RedirectToPage("./Index");
        }

        private bool CourseExists(int id)
        {
          return courseRepository.Get(c => c.CourseID == id) != null;
        }
    }
}

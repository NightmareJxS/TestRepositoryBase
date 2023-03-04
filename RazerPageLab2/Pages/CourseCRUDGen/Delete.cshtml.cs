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

namespace RazerPageLab2.Pages.CourseCRUDGen
{
    public class DeleteModel : PageModel
    {
        private readonly CourseRepository courseRepository;

        public DeleteModel()
        {
            courseRepository = new CourseRepository();
        }

        [BindProperty]
      public Course Course { get; set; }

        public IActionResult OnGet(int? id)
        {
            var course = courseRepository.Get(c => c.CourseID == id);

            if (course == null)
            {
                return NotFound();
            }
            else 
            {
                Course = course;
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            var course = courseRepository.Get(c => c.CourseID == id);

            if (course != null)
            {
                Course = course;
                courseRepository.Delete(c => c.CourseID == id);
            }

            return RedirectToPage("./Index");
        }
    }
}

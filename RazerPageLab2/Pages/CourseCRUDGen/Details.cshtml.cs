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
    public class DetailsModel : PageModel
    {
        private readonly CourseRepository courseRepository;

        public DetailsModel()
        {
            courseRepository = new CourseRepository();
        }

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
    }
}

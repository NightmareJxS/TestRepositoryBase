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

namespace RazerPageLab2.Pages.CourseCRUDGen
{
    public class CreateModel : PageModel
    {
        private readonly CourseRepository courseRepository;

        public CreateModel()
        {
            courseRepository = new CourseRepository();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Course.Title) || Course.Credits <= 0)
            {
                return Page();
            }

            courseRepository.Create(Course);

            return RedirectToPage("./Index");
        }
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly CourseRepository courseRepository;

        public IndexModel()
        {
            courseRepository = new CourseRepository();
        }

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (courseRepository.GetAll != null)
            {
                Course = courseRepository.GetAll();
            }
        }
    }
}

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

namespace RazerPageLab2.StudentCRUDGen
{
    public class DetailsModel : PageModel
    {
        private readonly StudentRepository studentRepository;

        public DetailsModel()
        {
            studentRepository = new StudentRepository();
        }

      public Student Student { get; set; }

        public IActionResult OnGet(int? id)
        {
            var student = studentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            else 
            {
                Student = student;
            }
            return Page();
        }
    }
}

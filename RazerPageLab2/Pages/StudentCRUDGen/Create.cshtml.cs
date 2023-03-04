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

namespace RazerPageLab2.StudentCRUDGen
{
    public class CreateModel : PageModel
    {
        private readonly StudentRepository studentRepository;

        public CreateModel()
        {
            studentRepository = new StudentRepository();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
            if (Student != null)
            {
                if (string.IsNullOrWhiteSpace(Student.FirstMidName) || string.IsNullOrWhiteSpace(Student.LastName))
                {
                    return Page();
                }
                else
                {
                    studentRepository.Create(Student);
                }
            }

            return RedirectToPage("./Index");
        }
    }
}

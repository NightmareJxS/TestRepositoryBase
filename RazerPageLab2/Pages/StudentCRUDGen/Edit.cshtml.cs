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

namespace RazerPageLab2.StudentCRUDGen
{
    public class EditModel : PageModel
    {
        private readonly StudentRepository studentRepository;

        public EditModel()
        {
            studentRepository = new StudentRepository();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public IActionResult OnGetAsync(int? id)
        {
            var student =  studentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            Student = student;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
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
                    studentRepository.Update(Student);
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentExists(int id)
        {
            var student = studentRepository.GetById(id);
            return student != null;
        }
    }
}

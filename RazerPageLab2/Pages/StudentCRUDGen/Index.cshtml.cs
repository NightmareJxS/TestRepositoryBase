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
    public class IndexModel : PageModel
    {
        private readonly StudentRepository studentRepository;

        public IndexModel()
        {
            studentRepository = new StudentRepository();
        }

        public IList<Student> Student { get;set; } = default!;

        public void OnGet()
        {
            if (studentRepository.GetAll != null)
            {
                Student = studentRepository.GetAll();
            }
        }
    }
}

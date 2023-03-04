using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class StudentRepository : RepositoryBase<Student>
    {
        public Student GetByName(string name)
        {
            return Get(s => s.FirstMidName.Equals(name));
        }

        public Student GetById(int? id)
        {
            return Get(s => s.ID.Equals(id));
        }
    }
}

using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class EnrollmentRepository:RepositoryBase<Enrollment>
    {
        private readonly SchoolDBContext _context;
        private readonly DbSet<Enrollment> _dbSet;

        public EnrollmentRepository()
        {
            _context = new SchoolDBContext();
            _dbSet = _context.Set<Enrollment>();
        }

        public List<Enrollment> GetAllWithRelatedEntities()
        {
            return _dbSet.Include(s => s.Student)
                .Include(c => c.Course)
                .ToList();
        }

        public Enrollment GetWithRelatedEntities(Expression<Func<Enrollment,bool>> predicate)
        {
            return _dbSet.Where(predicate)
                .Include(s => s.Student)
                .Include(c => c.Course)
                .FirstOrDefault();
        }
    }
}

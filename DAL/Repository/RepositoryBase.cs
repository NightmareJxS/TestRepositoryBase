using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RepositoryBase<T> where T : class
    {
        private readonly SchoolDBContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase()
        {
            _context = new SchoolDBContext();
            _dbSet = _context.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }

        public bool Delete(Expression<Func<T, bool>> predicate)
        {
            _dbSet.Remove(Get(predicate));
            return _context.SaveChanges() > 0;
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State= EntityState.Modified;
            _context.SaveChanges();
        }
    }
}


using Internship2023_backend.Data;
using Internship2023_backend.Interfaces;
using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;
namespace Internship2023_backend.Models
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDBContext _context;
        private readonly DbSet<T> _dbset;
        public GenericRepository(ApplicationDBContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbset.Add(entity); 
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            _dbset.RemoveRange(_dbset.Where(where));    
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            //return _dbset.FirstOrDefault(where);
            return _dbset.Where(where).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable();
        }

        public T GetById(params object[] keyValues)
        {
            return _dbset.Find(keyValues);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).AsEnumerable();
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }
    }
}

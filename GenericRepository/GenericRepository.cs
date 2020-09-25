using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TBSTech.Data;

namespace TBSTech.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public bool CheckIfExists(Expression<Func<T, bool>> predicate)
        {
           var data =  _context.Set<T>().Find(predicate);
           if(data !=null)
           {
               return true;
           }
           return false;
        }

        public List<T> Collection()
        {
            return _context.Set<T>().ToList();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
          var data =  _context.Set<T>().SingleOrDefault(predicate);
          _context.Remove(data);
        }

        public List<T> GetBy(Expression<Func<T, bool>> predicate)
        {
           return _context.Set<T>().Where(predicate).ToList();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public void Insert(T t)
        {
            _context.Set<T>().Add(t);
        }

        public void Update(T t)
        {
            _context.Set<T>().Update(t);
        }
    }
}
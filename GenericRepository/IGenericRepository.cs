using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TBSTech.GenericRepository
{
    public interface IGenericRepository<T> where T: class
    {
         
        List<T> Collection();
        void Commit();
        void Delete(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T,bool>> predicate);
        List<T> GetBy(Expression<Func<T,bool>> predicate);
        bool CheckIfExists(Expression<Func<T,bool>> predicate);
        void Insert(T t);
        void Update(T t);
    }
}
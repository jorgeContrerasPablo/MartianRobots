using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
    }
}

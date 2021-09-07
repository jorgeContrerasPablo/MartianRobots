using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        T AddAsync(T entity);

        IEnumerable<T> GetAll();

        T GetById(int id);
    }
}

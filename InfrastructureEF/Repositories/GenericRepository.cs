using ServiceLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureEF.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly MartianContext _context;

        public GenericRepository(MartianContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
    }
}

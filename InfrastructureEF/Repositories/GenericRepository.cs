using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using ServiceLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureEF.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbContextOptionsBuilder<MartianContext> _optionsBuilder;

        public GenericRepository(IConfiguration configuration)
        {
            _optionsBuilder = new DbContextOptionsBuilder<MartianContext>();
            _optionsBuilder.UseNpgsql(configuration.GetConnectionString("DatabaseConection"));
            _optionsBuilder.UseLazyLoadingProxies(false);
        }

        public T AddAsync(T entity)
        {
            MartianContext martianContext = NewContext();
            T entityReturn = martianContext.Add(entity).Entity;
            Complete(martianContext);
            return entityReturn;
        }

        public IEnumerable<T> GetAll()
        {
            MartianContext martianContext = NewContext();
            IEnumerable<T> entitiesReturn = martianContext.Set<T>().ToList();
            Complete(martianContext);
            return entitiesReturn;
        }

        public T GetById(int id)
        {
            MartianContext martianContext = NewContext();
            T entityReturn = martianContext.Set<T>().Find(id);
            Complete(martianContext);
            return entityReturn;
        }

        public T Update(T entity)
        {
            MartianContext martianContext = NewContext();
            T entityReturn = martianContext.Update(entity).Entity;
            Complete(martianContext);
            return entityReturn;
        }

        public void Complete(MartianContext martianContext)
        {               
            martianContext.SaveChangesAsync().Wait();
        }

        protected MartianContext NewContext() 
        {
            return new MartianContext(_optionsBuilder.Options);
        }
    }
}

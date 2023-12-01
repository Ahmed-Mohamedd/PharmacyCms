using Microsoft.EntityFrameworkCore;
using Pharmacy.BLL.Interfaces;
using Pharmacy.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
           _dbContext=dbContext;
        }
        public int Add(T entity)
        {
             _dbContext.Set<T>().Add(entity);
            return  _dbContext.SaveChanges();
        }

        public int Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
         =>  _dbContext.Set<T>().ToList();

        public T GetById(int? id)
        {
            return  _dbContext.Set<T>().Find(id);
        }

        public int Update(T entity)
        {
             _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}

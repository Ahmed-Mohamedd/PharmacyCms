using Pharmacy.BLL.Interfaces;
using Pharmacy.DAL.Context;
using Pharmacy.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.Repositories
{
    public class CategoryRepository:GenericRepository<Category> , ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext=dbContext;
        }
    }
}

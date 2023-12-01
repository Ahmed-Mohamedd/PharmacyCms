using Pharmacy.BLL.Interfaces;
using Pharmacy.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.Repositories
{
    public class UnitOfWork : IUnitOfwork
    {
        private readonly ApplicationDbContext _dbContext;

        public IMedicineRepository Medicines { get; private set; }
        public ICategoryRepository Categories { get; private set; }


        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext=dbContext;
            Medicines = new MedicineRepository(_dbContext);
            Categories = new CategoryRepository(_dbContext);
        }

        public void Dispose()
            =>  _dbContext.Dispose();
        
    }
}

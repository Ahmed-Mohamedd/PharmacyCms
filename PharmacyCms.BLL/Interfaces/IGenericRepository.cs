using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        IEnumerable<T> GetAll();
        T GetById(int? id);

    }
}

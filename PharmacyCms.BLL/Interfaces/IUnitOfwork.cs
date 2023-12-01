using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.Interfaces
{
    public  interface IUnitOfwork:IDisposable
    {
        public IMedicineRepository Medicines { get;  }
        public ICategoryRepository Categories { get;  }
    }
}

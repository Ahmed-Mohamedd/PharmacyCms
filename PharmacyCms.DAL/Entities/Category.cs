using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public ICollection<Medicine> Medicines { get; set; } = new HashSet<Medicine>();

    }
}

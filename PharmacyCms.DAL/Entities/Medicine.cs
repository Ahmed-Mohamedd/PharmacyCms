using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.Entities
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Indications { get; set; }
        public string StorageInstruction { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}

using Pharmacy.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.PL.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name Is Required")]
        [MaxLength(35 , ErrorMessage = "Name Shouldn't be more than 35 chars")]
        public string Name { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public ICollection<Medicine> Medicines { get; set; } = new HashSet<Medicine>();
    }
}

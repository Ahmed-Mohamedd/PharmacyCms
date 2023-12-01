using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PoatalCode { get; set; }
        public bool IsActive { get; set; } 
    }
}

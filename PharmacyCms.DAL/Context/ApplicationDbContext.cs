using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pharmacy.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.Context
{
    public  class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        //public DbSet<IdentityRole> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .Property(u => u.IsActive)
                .HasDefaultValue(true);

            base.OnModelCreating(builder);
        }
    }
}

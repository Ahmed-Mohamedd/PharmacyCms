using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pharmacy.BLL.Interfaces;
using Pharmacy.BLL.Repositories;
using Pharmacy.DAL.Context;
using Pharmacy.DAL.Entities;
using Pharmacy.PL.Mappers;

namespace PharmacyCms.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add singleton For Database Connection
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add Scoped for DI
            builder.Services.AddScoped<IUnitOfwork, UnitOfWork>();

            // Allow dependencyInjection for AutoMApper
            builder.Services.AddAutoMapper(m => m.AddProfile(new CategoryProfile()));


            // Add Identity Services
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                //options.Password.RequireDigit = true;
                //options.Password.RequireLowercase = true;
                //options.Password.RequireNonAlphanumeric = true;
                //options.Password.RequiredLength = 20;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);



            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "Identity/Account/Login";
                    options.AccessDeniedPath = "Customer/Home/Error";
                });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
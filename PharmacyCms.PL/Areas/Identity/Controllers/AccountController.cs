using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.DAL.Entities;
using Pharmacy.PL.Models;
using Pharmacy.PL.Utilities;
using System.Data;
using System.Drawing;

namespace Pharmacy.PL.Areas.Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
       

        public AccountController(UserManager<ApplicationUser> userManager ,
            SignInManager<ApplicationUser> signInManager ,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager=userManager;
            _signInManager=signInManager;
            _roleManager=roleManager;
            
        }


        #region Register
        public IActionResult Register()
        {
            if (!_roleManager.RoleExistsAsync(Roles.AdminRole).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(Roles.AdminRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Roles.CustomerRole)).GetAwaiter().GetResult();
            }
            TempData["UserOperation"] = "Create Account";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = registerViewModel.Email.Split("@")[0],
                    Email = registerViewModel.Email,
                    State = registerViewModel.State,
                    City = registerViewModel.City,
                    Street = registerViewModel.Street,
                    PoatalCode = registerViewModel.PostalCode
                };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.CustomerRole);
                    return RedirectToAction(nameof(Login), "Account" , new { area = "Identity" });
                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            
            return View(registerViewModel);
        }

        #endregion


        #region Login

        public IActionResult Login()
        {
            TempData["UserOperation"] = "Login Now";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if(user != null)
                {
                    var CheckedPasswordCorrectness = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                    if(CheckedPasswordCorrectness)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, false);
                        if (result.Succeeded)
                            return RedirectToAction("Index", "Home", new { area = "Customer" });  
                    }
                    ModelState.AddModelError(string.Empty, "Password Is Incorrect");
                }
                ModelState.AddModelError(string.Empty, "There no user with the email provided.");
            }
            return View(loginViewModel);
        }
        #endregion

        #region LogOut
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login), "Account", new { area = "Identity" });
        }
        #endregion

        #region ForgetPassword


        #endregion
    }
}

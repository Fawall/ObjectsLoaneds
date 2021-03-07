using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ObjectsLoaneds.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectsLoaneds.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public AccountController(UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM) 
        {
            if (!ModelState.IsValid)
                return View(loginVM);

            var user = await _userManager.FindByNameAsync(loginVM.Username);
           
            if(user != null) 
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                if (result.Succeeded) 
                {
                    if (string.IsNullOrEmpty(loginVM.ReturnUrl)) 
                    {
                        return RedirectToAction("Index", "Home");
                    
                    }
                    return Redirect($"https://localhost:5001{loginVM.ReturnUrl}");
                }             
            }
            ModelState.AddModelError("", "Usuário ou Senha inválidos");
            return View(loginVM);           
        }

        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel registroVM) 
        {
            if (ModelState.IsValid) 
            {
                var user = new IdentityUser() { UserName = registroVM.Username, Email = registroVM.Email };
                var result = await _userManager.CreateAsync(user, registroVM.Password);

                if (result.Succeeded) 
                {
                    await _signInManager.SignInAsync(user,isPersistent:false);
                    return RedirectToAction("Index", "Home");
                }
                                   
                ModelState.AddModelError("Password", "A senha precisa ter : Caracteres especiais" +
                    " Letras maiusculas e números");
            }
            return View(registroVM);
        }
        
        [HttpPost]
        public async Task<IActionResult> Logout() 
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        
        }

    }
}

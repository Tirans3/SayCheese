using EmailApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SayCheese.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
 
namespace SayCheese.Controllers
{
        public class AccountController : Controller
        {
            private readonly UserManager<IdentityUser> _userManager;
            private readonly SignInManager<IdentityUser> _signInManager;

            public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
            }

            public IActionResult Login(string returnUrl)
            {
                return View(new LoginViewModel
                {
                    ReturnUrl = returnUrl
                });
            }

            [HttpPost]
            public async Task<IActionResult> Login(LoginViewModel loginViewModel)
            {
            if (ModelState.IsValid)
            {  //return View(loginViewModel);

                var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, false);
                    if (result.Succeeded)
                    {
                        if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
                            return RedirectToAction("Index", "Home");

                        return Redirect(loginViewModel.ReturnUrl);
                    }
                }
            }
                ModelState.AddModelError("", "Username/password not found");
                return View(loginViewModel);

            }

            public IActionResult Register() => View();

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Register(LoginViewModel loginViewModel)
            {
                if (ModelState.IsValid)
                {
                    var user = new IdentityUser() { UserName = loginViewModel.UserName };
                    var result = await _userManager.CreateAsync(user, loginViewModel.Password);

                    if (result.Succeeded)
                    {
                    var codei = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { userId = loginViewModel.UserName, code=codei },
                        protocol: HttpContext.Request.Scheme);
                    EmailService emailService = new EmailService();
                    try
                    {

                    await emailService.SendEmailAsync("tirans3@mail.ru", "Confirm your account",
                        $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");
                    }
                    catch
                    {
                        return RedirectToAction("Register", "Account");
                    }
                   
                   
                    }
                }
                return View(loginViewModel);
            }

            public ViewResult LoggedIn() => View();

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var user = await _userManager.FindByNameAsync(userId);
            if (user == null)
            {
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return RedirectToAction("LoggedIn", "Account");
            else
                return View("Error");
        }


        [HttpPost]
            [Authorize]
            public async Task<IActionResult> Logout()
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
        }
    }


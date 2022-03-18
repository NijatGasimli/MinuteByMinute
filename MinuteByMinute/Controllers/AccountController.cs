using Core.Entity.Entities;
using Core.Entity.ViewModel.AccountVM;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MinuteByMinute.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {


        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,
                                      SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            RegisterVM newuser = new RegisterVM();
            return View(newuser);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var userCheck = await _userManager.FindByEmailAsync(registerVM.Email);
                if (userCheck == null)
                {
                    var user = new AppUser
                    {
                        UserName = registerVM.Username,
                        Email = registerVM.Email,
                        Fullname = registerVM.FullName,
                        FIN = registerVM.FIN,
                        IdentityType = registerVM.IdentityType,
                        IdentityNumber = registerVM.IdentityType,
                        PhoneNumber = registerVM.PhoneNumber,
                        BirthdayTime = registerVM.BirthdayTime
                    };

                    if (registerVM.Username == userCheck.UserName)
                    {
                        ModelState.AddModelError("message", "Bu Istifadeci Adi Artiq Istifade Olunur");
                        return View();
                    }

                    if (registerVM.FIN == userCheck.FIN)
                    {
                        ModelState.AddModelError("message", "Bu Şəxsiyyət Vəsiqəsi İlə Artıq Qeydiyyat Olunub");
                        return View();
                    }

                    var result = await _userManager.CreateAsync(user, registerVM.Password);
                    if (result.Succeeded)
                    {
                      
                 
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        if (result.Errors.Count() > 0)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("message", error.Description);
                            }
                        }
                        return View(registerVM);
                    }
                }
                else
                {
                    ModelState.AddModelError("message", "Email already exists.");
                    return View(registerVM);
                }
            }
            return View(registerVM);

        }
        public IActionResult Login()
        {
            LoginVM model = new LoginVM();
            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError("message", "Email not confirmed yet");
                    return View(model);

                }
                if (await _userManager.CheckPasswordAsync(user, model.Password) == false)
                {
                    ModelState.AddModelError("message", "Invalid credentials");
                    return View(model);

                }

                var result = await _signInManager.PasswordSignInAsync(user, model.Password,true,true);

                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(user, new Claim("UserRole", "User"));
                    return RedirectToAction("Index", "User");
                }
                else if (result.IsLockedOut)
                {
                    return View("AccountLocked");
                }
                else
                {
                    ModelState.AddModelError("message", "Invalid login attempt");
                    return View(model);
                }
            }
            return View(model);
        }
        public async Task<ActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}


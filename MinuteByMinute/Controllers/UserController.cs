using Core.Entity.Entities;
using Core.Entity.ViewModel.AccountVM;
using Data.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinuteByMinute.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserManager<AppUser> _userManager { get; }

        public UserController(AppDbContext Context,UserManager<AppUser> UserManager)
        {
            _context = Context;
            _userManager = UserManager;

        }
        public async Task<IActionResult> Index( string username)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var fromdb = new UserVM
            {
                Fullname=user.Fullname,
                BirthdayTime=user.BirthdayTime,
                FIN=user.FIN,
                IdentityNumber=user.IdentityNumber,
                IdentityType=user.IdentityType,
                Location=user.Location,
                CustomerNumber=user.Id,
                Email=user.Email,
                PhoneNumber=user.PhoneNumber

                
            };
            return View(fromdb);
        }
        public IActionResult CreateCargo()
        {
            return View();
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateCargo(CargoVM cargo)
        {
            if (!ModelState.IsValid) return View();
            var user = await _userManager.GetUserAsync(HttpContext.User);
         
            var fromdb = new Cargos
            {
                About=cargo.About,
                Count=cargo.Count,
                Link=cargo.Link,
                Price=cargo.Price,
                Size=cargo.Size,
                AppUserId=user.Id
            };

            await _context.Cargos.AddAsync(fromdb);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");


        }
        
        public async  Task<IActionResult> Orders()
        {
           var Myorders =await _context.Cargos.ToListAsync();
            return View(Myorders);
        }
    }
}

using Core.Entity.ViewModel;
using Data.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinuteByMinute.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext Context)
        {
            Context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }
     
        public IActionResult Create()
        {
            return View();
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
       
        public async Task<IActionResult> Create(CargoCreateVM model)
        {
            var user = await _context.Users.FirstOrDefaultAsync();
            var FromDB = await _context.Cargos.FirstOrDefaultAsync();
           

            if (!ModelState.IsValid) return View();

           
            if (User.Identity.IsAuthenticated)
            {
                CargoCreateVM cargos = new CargoCreateVM
                {
                    About = FromDB.About,
                    Price = FromDB.Price,
                    Count = FromDB.Count,
                    Size = FromDB.Size,
                    Link = FromDB.Link,
                    IdentityUserId = user.Id

                };
                await _context.AddAsync(cargos);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
           await _context.SaveChangesAsync();
            return View();
        }
        
             
    }

}

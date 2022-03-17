using Core.Entity.AdminPanelEntityes;
using Core.Entity.Entities;
using Core.Entity.ViewModel;
using Core.Entity.ViewModel.AccountVM;
using Data.DAL;
using Data.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MinuteByMinute.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;
        public int OrderID { get; set; }
        public UserManager<AppUser> _userManager { get; }

        public UserController(AppDbContext Context,UserManager<AppUser> UserManager, IWebHostEnvironment env)
        {
            _env = env;
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
                AppUserId=user.Id,
                Status="Wait",
                IsInvoice=false
                
            };

            await _context.Cargos.AddAsync(fromdb);
            await _context.SaveChangesAsync();
          


            return RedirectToAction("Index");


        }
        
        public async  Task<IActionResult> Orders()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var Myorders =await _context.Cargos.Where(x=>x.AppUserId==user.Id).ToListAsync();
            return View(Myorders);
        }
        public async Task<IActionResult> DecleredCargos()
        {
            return View();
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> DecleredCargos(DecleredCargosVM decleredCargos,int id)
        {
           
            var fromdb = await _context.DeclaredCargos.Where(x => x.CargosId == id).FirstOrDefaultAsync();
          
            if (!ModelState.IsValid) return View();

            if (fromdb is null)
            {
                string uniqueFileName = UploadFile(decleredCargos);
                DeclaredCargos declered = new DeclaredCargos
                {
                    Count = decleredCargos.Count,
                    Price = decleredCargos.Price,
                    ImageURL = uniqueFileName,
                    CargosId = id
                };

                await _context.AddAsync(declered);
                var fromcargos = await _context.Cargos.Include(x => x.AppUser).Where(x=>x.Id==id).ToListAsync();
                foreach (var item in fromcargos)
                {
                    await _context.AddAsync(AddFlight(item));
                    item.Status = "Flight";

                }
               

                
                await _context.SaveChangesAsync();

            }
            else
            {
                ModelState.AddModelError("message", "Siz Artiq Kargonuzu Beyan Etdiniz");
                return View();
            }
            return View();
        }


        private  static Flights AddFlight(Cargos cargos)
        {
      
            Flights flight = new Flights
            {
                 Count=cargos.Count,
                  CargosID=cargos.Id,
                  FullName=cargos.AppUser.Fullname,
                  Price=cargos.Price
            };
            return flight;

        }

        private string UploadFile(DecleredCargosVM create)
        {
            string uniqueFileName = null;

            if (create.Photo != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "assets", "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + create.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    create.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}

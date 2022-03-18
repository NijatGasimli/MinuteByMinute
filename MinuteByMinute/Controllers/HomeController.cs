using Core.Entity.Entities;
using Core.Entity.ViewModel;
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
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(AppDbContext Context,UserManager<AppUser> userManager)
        {
            _context = Context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {

            HomeVM home = new HomeVM
            {
                OwlCaruosels = await _context.OwlCaruosels.ToListAsync(),
                Slider = await _context.Sliders.Where(p=>p.IsDeleted==false).ToListAsync()
            };
            return View(home);
        }
     
      
        
             
    }

}
